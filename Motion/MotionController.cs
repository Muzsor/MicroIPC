using NLog;

using System;
using System.Collections.Generic;
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

        public MotionController(ushort deviceNo, ushort networkInfoNo)
        {
            DeviceNo = deviceNo;
            NetworkInfoNo = networkInfoNo;
            Logger.Info("123456");
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
                SpinWait.SpinUntil(() => false, RetryInterval);
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
                SpinWait.SpinUntil(() => false, RetryInterval);
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
                    return false;
                }
            }
            return true;
        }

        public bool GetAxisState(ref MotionSlave motionSlave, ushort axisNo, ref int resultCode)
        {
            if (axisNo >= motionSlave.AxisState.Length)
            {
                throw new IndexOutOfRangeException();
            }
            uint axisState = 0;
            int i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisState(motionSlave.DeviceNo, axisNo, ref axisState);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (resultCode == 0 && i++ < RetryCount);
            if (resultCode == 0)
            {
                motionSlave.AxisState[axisNo] = (AxisStates)axisState;
                return true;
            }
            else
            {
                Error(resultCode, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool InitMotion()
        {
            for (int i = 0; i < slavesItems.Length; i++)
            {
                var mcSlaveNo = new List<ushort>();
                var mcSubAxisNo = new List<ushort>();
                var slave = slavesItems[i];
                for (int j = 0; j < slave.SubAxisNo.Length; j++)
                {
                    // 軸號
                    var axisNo = slave.SubAxisNo[j];
                    // 回傳值
                    int resultCode = 0;
                    // 重試次數
                    int retryCount = 0;
                    do
                    {
                        if (GetAxisState(ref slave, axisNo, ref resultCode))
                        {
                            var axisState = slave.AxisState[j];
                            if (resultCode == EtherCatError.ECAT_ERR_MC_NOT_INITIALIZED) // 軸尚未初始化。
                            {
                                mcSlaveNo.Add(slave.SlaveNo);
                                mcSubAxisNo.Add(axisNo);
                            }
                            else if (axisState == AxisStates.MC_AS_DISABLED) // 軸已初始化，Servo尚未啟動。
                            {
                                break;
                            }
                            else if (axisState == AxisStates.MC_AS_STANDSTILL) // 軸已初始化，Servo啟動，停止中。
                            {
                                // Servo尚未停止，執行 ServoOff。
                                EtherCatLib.ECAT_McSetAxisServoOn(slave.DeviceNo, axisNo, 0);
                            }
                            else if (axisState == AxisStates.MC_AS_ERRORSTOP) // 軸出現異常。
                            {
                                SalveAxisStateChangeEvent?.Invoke(slave, new SalveAxisStateChangeEventArgs()
                                {
                                    SlaveNo = slave.SlaveNo,
                                    AlState = slave.AlState,
                                    SlaveName = slave.SlaveName,
                                    SubAxisNo = axisNo,
                                    AxisState = axisState
                                });
                                Error(resultCode, MethodBase.GetCurrentMethod().Name, $"SlaveNo=[{slave.SlaveNo}], AxisNo=[{axisNo}] MC_AS_ERRORSTOP !!!");
                                break;
                            }
                            else if (axisState != AxisStates.MC_AS_STOPPING) // 軸仍在運動中。
                            {
                                // 如果不在停止狀態，立刻停止。
                                EtherCatLib.ECAT_McAxisQuickStop(slave.DeviceNo, axisNo);
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
                    if (ret != 0)
                    {
                        Error(ret, "ECAT_McInit");
                    }
                }
            }
            return true;
        }
    }
}
