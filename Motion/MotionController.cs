using NLog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Motion
{
    public class MotionController
    {
        /// <summary>
        /// 網路架構編號(由 Utility 建立並寫入的網路資訊檔案編號)。
        /// </summary>
        public ushort NetworkInfoNo { get; private set; }

        /// <summary>
        /// 裝置編號(卡號)。
        /// </summary>
        public ushort DeviceNo { get; private set; }

        /// <summary>
        /// 顯示乙太網路孔連接狀態。
        /// </summary>
        public bool IsLinkUp { get; private set; }

        /// <summary>
        /// 目前已連接從站數量。
        /// </summary>
        public uint SlavesResp { get; private set; }

        /// <summary>
        /// 顯示目前整個網路 Slave EtherCAT 狀態。
        /// </summary>
        public AlStates AlState { get; private set; }

        /// <summary>
        /// 顯示 EtherCAT 工作計數器數值。
        /// </summary>
        public uint WorkingCounter { get; private set; }

        /// <summary>
        /// 指定結果操作的嘗試次數，預設為5次。
        /// </summary>
        public uint RetryCount { get; private set; } = 5;

        /// <summary>
        /// 指定重試嘗試之間的間隔(ms)。
        /// </summary>
        public int RetryInterval { get; private set; } = 200;

        private MotionSlave[] slavesItems;

        /// <summary>
        /// 所有從站模組。
        /// </summary>
        public MotionSlave[] SlaveItems { get => slavesItems; private set => slavesItems = value; }

        #region Event

        public event EventHandler<DeviceStateChangeEventArgs> DeviceStateChangeEvent;

        public event EventHandler<SalveAxisStateChangeEventArgs> SalveAxisStateChangeEvent;

        #endregion

        private readonly byte EnumCycleTime = EtherCatDef.DEV_OP_CYCLE_TIME_1MS;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public MotionController(ushort deviceNo, ushort networkInfoNo = 0)
        {
            DeviceNo = deviceNo;
            NetworkInfoNo = networkInfoNo;
        }

        #region private Method

        private void OnDeviceStateChangeEvent()
        {
            DeviceStateChangeEvent?.Invoke(this, new DeviceStateChangeEventArgs()
            {
                DeviceNo = DeviceNo,
                IsLinkUp = IsLinkUp,
                SlavesResp = SlavesResp,
                AlState = AlState,
                WorkingCounter = WorkingCounter
            });
        }

        #endregion

        #region Static Method

        private static void Error(int errorCode, string methodName, Exception excetionMsg)
            => Logger.Error($"ErrorCode=[{errorCode:####}], Method=[{methodName}] {(excetionMsg != null ? $", {excetionMsg}" : string.Empty)}");

        private static void Error(int errorCode, string methodName, string errorMsg = null)
            => Logger.Error($"ErrorCode=[{errorCode:####}], Method=[{methodName}] {(errorMsg != null ? $", {errorMsg}" : string.Empty)}");

        public static ushort GetVersion()
        {
            var str = new StringBuilder();
            ushort size = 0;
            int ret = 0;
            int i = 0;
            do
            {
                try
                {
                    // ECAT-M801 實體卡片上可以更改卡號
                    // 傳入 Card ID(卡號)，取得目前卡片上可使用裝置的數量
                    ret = EtherCatLib.ECAT_GetDllVersion(str, ref size);
                }
                catch (Exception ex)
                {
                    Error(ret, MethodBase.GetCurrentMethod().Name, ex);
                    break;
                }
                SpinWait.SpinUntil(() => false, 200);
            } while (ret != 0 && i++ < 10);
            if (ret == 0)
            {
                return size;
            }
            else
            {
                Error(ret, MethodBase.GetCurrentMethod().Name);
                return 0;
            }
        }

        public static ushort GetDeviceCount(byte[] cardId)
        {
            ushort DeviceCnt = 0;
            int ret = 0;
            int i = 0;
            do
            {
                try
                {
                    // ECAT-M801 實體卡片上可以更改卡號
                    // 傳入 Card ID(卡號)，取得目前卡片上可使用裝置的數量
                    ret = EtherCatLib.ECAT_GetDeviceCnt(ref DeviceCnt, cardId);
                }
                catch (Exception ex)
                {
                    Error(ret, MethodBase.GetCurrentMethod().Name, ex);
                    break;
                }
                SpinWait.SpinUntil(() => false, 200);
            } while (ret != 0 && i++ < 10);
            if (ret == 0)
            {
                return DeviceCnt;
            }
            else
            {
                Error(ret, MethodBase.GetCurrentMethod().Name);
                return 0;
            }
        }

        #endregion

        public bool OpenDevice()
        {
            int i = 0;
            int ret;
            do
            {
                // 開啟指定裝置編號(卡號)來做通訊操作。
                ret = EtherCatLib.ECAT_OpenDevice(DeviceNo);
                if (ret != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (ret != 0 && i++ < RetryCount);
            if (ret == 0)
            {
                return true;
            }
            else
            {
                Error(ret, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GetDeviceState()
        {
            uint linkup = 0, slaveResp = 0, alstates = 0, wc = 0;
            int i = 0;
            int ret;
            do
            {
                ret = EtherCatLib.ECAT_GetDeviceState(DeviceNo, ref linkup, ref slaveResp, ref alstates, ref wc);
                if (ret != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (ret != 0 && i++ < RetryCount);
            if (ret == 0)
            {
                IsLinkUp = linkup == 1;
                SlavesResp = slaveResp;
                AlState = (AlStates)alstates;
                WorkingCounter = wc;
                OnDeviceStateChangeEvent();
                return true;
            }
            else
            {
                Error(ret, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool StartOpTask()
        {
            int i = 0;
            int ret = 0;
            while (GetDeviceState() && i++ < RetryCount)
            {
                if (AlState == AlStates.ECAT_AS_OP)
                {
                    return true;
                }
                else
                {
                    ret = AlState == AlStates.ECAT_AS_PREOP
                        ? EtherCatLib.ECAT_StartDeviceOpTask(DeviceNo, NetworkInfoNo, EnumCycleTime, RetryCount)
                        : EtherCatLib.ECAT_StopDeviceOpTask(DeviceNo);
                }
                SpinWait.SpinUntil(() => false, RetryInterval);
            }
            if (ret != 0)
            {
                Error(ret, MethodBase.GetCurrentMethod().Name);
            }
            return false;
        }

        public bool GetSlaveInfo()
        {
            if (AlState != AlStates.ECAT_AS_OP)
            {
                return false;
            }
            SlaveItems = new MotionSlave[SlavesResp];
            ushort alias = 0;
            uint productCode = 0, vendorID = 0, revisionNo = 0, serialNo = 0, slaveType = 0;
            byte alState = 0;
            var slvName = new StringBuilder(string.Empty, EtherCatDef.MAX_SLAVE_NAME_LENGTH);
            int ret, i;
            for (ushort slaveNo = 0; slaveNo < SlavesResp; slaveNo++)
            {
                i = 0;
                do
                {
                    ret = EtherCatLib.ECAT_GetSlaveInfo(
                        DeviceNo,
                        slaveNo,
                        ref alias,
                        ref productCode,
                        ref vendorID,
                        ref revisionNo,
                        ref serialNo,
                        ref alState,
                        ref slaveType,
                        slvName);
                } while (ret != 0 && i++ < RetryCount);
                if (ret == 0)
                {
                    SlaveItems[slaveNo] = new MotionSlave(
                        DeviceNo,
                        slaveNo,
                        alias,
                        productCode,
                        vendorID,
                        revisionNo,
                        serialNo,
                        alState,
                        slaveType,
                        slvName.ToString());
                }
                else
                {
                    Error(ret, MethodBase.GetCurrentMethod().Name);
                }
            }
            return true;
        }

        public bool SetAxisToSlave(ref MotionSlave motionSlave, ushort[] axisList)
        {
            if (!SlaveItems.Contains(motionSlave))
            {
                throw new KeyNotFoundException();
            }
            motionSlave.SetAxisCount(axisList.Length);
            for (ushort i = 0; i < motionSlave.AxisItems.Length; i++)
            {
                motionSlave.AxisItems[i] = new MotionAxis(DeviceNo, motionSlave.SlaveNo, axisList[i]);
            }
            return true;
        }

        private bool GetAxisState(ref MotionAxis motionAxis, ref int resultCode)
        {
            uint axisState = 0;
            int i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisState(motionAxis.DeviceNo, motionAxis.AxisNo, ref axisState);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (resultCode != 0 && i++ < RetryCount);
            if (resultCode == 0)
            {
                motionAxis.AxisState = (AxisStates)axisState;
                return true;
            }
            else
            {
                Error(resultCode, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GetAxisProcessState(ref MotionAxis motionAxis, ref int resultCode)
        {
            if (!GetAxisState(ref motionAxis, ref resultCode))
            {
                return false;
            }
            // 取得指定軸號命令位置。
            double dValue = 0;
            int i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisCommandPos(motionAxis.DeviceNo, motionAxis.AxisNo, ref dValue);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (resultCode != 0 && i++ < RetryCount);
            motionAxis.CommandPos = dValue;
            // 取得指定軸號當前位置。
            dValue = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisActualPos(motionAxis.DeviceNo, motionAxis.AxisNo, ref dValue);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (resultCode != 0 && i++ < RetryCount);
            motionAxis.ActualPos = dValue;
            // 取得指定軸號當前速度。
            dValue = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisActualVel(motionAxis.DeviceNo, motionAxis.AxisNo, ref dValue);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (resultCode != 0 && i++ < RetryCount);
            motionAxis.ActualVel = dValue;
            // 取得指定軸號最後出錯代碼。
            int lastError = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisLastError(motionAxis.DeviceNo, motionAxis.AxisNo, ref lastError);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (resultCode != 0 && i++ < RetryCount);
            motionAxis.LastError = lastError;
            // 取得指定軸號驅動器出錯代碼。
            ushort driveError = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisDriveError(motionAxis.DeviceNo, motionAxis.AxisNo, ref driveError);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (resultCode != 0 && i++ < RetryCount);
            motionAxis.DriveError = driveError;
            // 取得指定軸號驅動器出錯代碼。
            uint axisDI = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisDI(motionAxis.DeviceNo, motionAxis.AxisNo, ref axisDI);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (resultCode != 0 && i++ < RetryCount);
            motionAxis.AxisDI = axisDI;
            return true;
        }

        public bool InitMotion()
        {
            for (int i = 0; i < slavesItems.Length; i++)
            {
                var mcSlaveNo = new List<ushort>();
                var mcSubAxisNo = new List<ushort>();
                MotionSlave slave = slavesItems[i];
                if (slave.AxisItems == null)
                {
                    continue;
                }
                for (int j = 0; j < slave.AxisItems.Length; j++)
                {
                    // 軸
                    MotionAxis axis = slave.AxisItems[j];
                    int resultCode = 0; // 回傳值
                    int retryCount = 0; // 重試次數
                    do
                    {
                        if (GetAxisState(ref axis, ref resultCode))
                        {
                            if (resultCode == EtherCatError.ECAT_ERR_MC_NOT_INITIALIZED) // 軸尚未初始化。
                            {
                                axis.IsMcInitOk = false;
                                mcSlaveNo.Add(slave.SlaveNo);
                                mcSubAxisNo.Add(axis.AxisNo);
                                break;
                            }
                            else if (axis.AxisState == AxisStates.MC_AS_DISABLED) // 軸已初始化，Servo尚未啟動。
                            {
                                axis.IsMcInitOk = true;
                                break;
                            }
                            else if (axis.AxisState == AxisStates.MC_AS_STANDSTILL) // 軸已初始化，Servo啟動，停止中。
                            {
                                // Servo尚未停止，執行 ServoOff。
                                EtherCatLib.ECAT_McSetAxisServoOn(slave.DeviceNo, axis.AxisNo, 0);
                            }
                            else if (axis.AxisState == AxisStates.MC_AS_ERRORSTOP) // 軸出現異常。
                            {
                                axis.IsMcInitOk = false;
                                axis.LastError = -1; // TODO 發生異常
                                SalveAxisStateChangeEvent?.Invoke(slave, new SalveAxisStateChangeEventArgs()
                                {
                                    SlaveNo = slave.SlaveNo,
                                    AlState = slave.AlState,
                                    SlaveName = slave.SlaveName,
                                    AxisNo = axis.AxisNo,
                                    AxisState = axis.AxisState
                                });
                                Error(resultCode, MethodBase.GetCurrentMethod().Name, $"SlaveNo=[{slave.SlaveNo}], AxisNo=[{axis.AxisNo}] MC_AS_ERRORSTOP !!!");
                                break;
                            }
                            else if (axis.AxisState != AxisStates.MC_AS_STOPPING) // 軸仍在運動中。
                            {
                                // 如果不在停止狀態，立刻停止。
                                EtherCatLib.ECAT_McAxisQuickStop(slave.DeviceNo, axis.AxisNo);
                            }
                        }
                        SpinWait.SpinUntil(() => false, RetryInterval);
                    }
                    while (retryCount++ < RetryCount);
                }
                if (mcSlaveNo.Count > 0 && mcSubAxisNo.Count > 0)
                {
                    int k = 0;
                    int ret;
                    do
                    {
                        ret = EtherCatLib.ECAT_McInit(
                            slave.DeviceNo,
                            mcSlaveNo.ToArray(),
                            mcSubAxisNo.ToArray(),
                            (ushort)mcSubAxisNo.Count);
                        SpinWait.SpinUntil(() => false, RetryInterval);
                    } while (ret != 0 && k++ < RetryCount);
                    if (ret == 0)
                    {
                        slave.IsMcInitOk = true;
                    }
                    else
                    {
                        slave.IsMcInitOk = false;
                        Error(ret, "ECAT_McInit", $"SlaveNo=[{slave.SlaveNo}] Error !!!");
                    }
                }
            }
            return true;
        }

        public (MotionParam, bool) SetAxisParam(ref MotionSlave motionSlave, ushort axisNo, MotionParam motionParam)
        {

            int resultCode;
            int i;
            var motionParamResult = new MotionParam();
            if (motionSlave.AxisItems == null || !motionSlave.IsMcInitOk)
            {
                return (motionParamResult, false);
            }
            // 設定 Pulse per Unit 參數。
            if (motionParam.PPU > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisPPU(motionSlave.DeviceNo, axisNo, motionParam.PPU);
                    SpinWait.SpinUntil(() => false, RetryInterval);
                } while (resultCode != 0 && i++ < RetryCount);
            }
            double ppu = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisPPU(motionSlave.DeviceNo, axisNo, ref ppu);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            motionParamResult.PPU = ppu;
            // 設定自動原點復歸的模式。
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McSetAxisHomeMethod(motionSlave.DeviceNo, axisNo, motionParam.HomeMethod);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            int homeMethod = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeMethod(motionSlave.DeviceNo, axisNo, ref homeMethod);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            motionParamResult.HomeMethod = homeMethod;
            // 設定執行自動原點復歸時使用的速度。
            if (motionParam.ORGHomeSpeed > 0 && motionParam.EZHomeSpeed > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisHomeSpeed(motionSlave.DeviceNo, axisNo, motionParam.ORGHomeSpeed, motionParam.EZHomeSpeed);
                    SpinWait.SpinUntil(() => false, RetryInterval);
                } while (resultCode != 0 && i++ < RetryCount);
            }
            double ORGHomeSpeed = 0;
            double EZHomeSpeed = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeSpeed(motionSlave.DeviceNo, axisNo, ref ORGHomeSpeed, ref EZHomeSpeed);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            motionParamResult.ORGHomeSpeed = ORGHomeSpeed;
            motionParamResult.EZHomeSpeed = EZHomeSpeed;
            // 設定執行自動原點復歸時使用的加速度。
            if (motionParam.HomeAcc > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisHomeAcc(motionSlave.DeviceNo, axisNo, motionParam.HomeAcc);
                    SpinWait.SpinUntil(() => false, RetryInterval);
                } while (resultCode != 0 && i++ < RetryCount);
            }
            double homeAcc = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeAcc(motionSlave.DeviceNo, axisNo, ref homeAcc);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            motionParamResult.HomeAcc = homeAcc;
            // 設定速度/加速度換算參數。
            if (motionParam.VelScale > 0 && motionParam.AccScale > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisVelAccScale(motionSlave.DeviceNo, axisNo, motionParam.VelScale, motionParam.AccScale);
                    SpinWait.SpinUntil(() => false, RetryInterval);
                } while (resultCode != 0 && i++ < RetryCount);
            }
            double velScale = 0;
            double accScale = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisVelAccScale(motionSlave.DeviceNo, axisNo, ref velScale, ref accScale);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            motionParamResult.VelScale = velScale;
            motionParamResult.AccScale = accScale;
            // 設定執行單軸運動時使用的加減速時間。
            if (motionParam.AccTime > 0 && motionParam.DecTime > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisAccDecTime_Stepper(motionSlave.DeviceNo, axisNo, motionParam.AccTime, motionParam.DecTime);
                    SpinWait.SpinUntil(() => false, RetryInterval);
                } while (resultCode != 0 && i++ < RetryCount);
            }
            ushort accTime = 0;
            ushort decTime = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisAccDecTime_Stepper(motionSlave.DeviceNo, axisNo, ref accTime, ref decTime);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            motionParamResult.AccTime = accTime;
            motionParamResult.DecTime = decTime;
            // 設定執行單軸運動時使用的加速度類型。
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McSetAxisAccDecType(motionSlave.DeviceNo, axisNo, (ushort)motionParam.AccDecType);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            ushort accDecType = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisAccDecType(motionSlave.DeviceNo, axisNo, ref accDecType);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            motionParamResult.AccDecType = (AccDecType)accDecType;
            // 設定指定軸號之位置軟體極限。
            uint AbortCode = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McSetAxisPosSoftwareLimit(motionSlave.DeviceNo, axisNo, motionParam.PosSoftwareMaxLimit, motionParam.PosSoftwareMinLimit, ref AbortCode);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            double posSoftwareMaxLimit = 0;
            double posSoftwareMinLimit = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisPosSoftwareLimit(motionSlave.DeviceNo, axisNo, ref posSoftwareMaxLimit, ref posSoftwareMinLimit, ref AbortCode);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode != 0 && i++ < RetryCount);
            motionParamResult.PosSoftwareMaxLimit = posSoftwareMaxLimit;
            motionParam.PosSoftwareMinLimit = posSoftwareMinLimit;
            return (motionParamResult, true);
        }

        public bool ServoControl(MotionAxis motionAxis, bool isOn)
        {
            int ret = 0;
            int i = 0;
            do
            {
                ret = EtherCatLib.ECAT_McSetAxisServoOn(motionAxis.DeviceNo, motionAxis.AxisNo, (ushort)(isOn ? 1 : 0));
                if (ret != 0)
                {
                    SpinWait.SpinUntil(() => false, RetryInterval);
                }
            } while (ret != 0 && i++ < RetryCount);
            return ret == 0;
        }
    }
}
