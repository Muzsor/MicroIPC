
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
        public static uint RetryCount { get; private set; } = 5;

        /// <summary>
        /// 指定重試嘗試之間的間隔(ms)。
        /// </summary>
        public static int RetryInterval { get; private set; } = 200;

        private MotionSlave[] slavesItems;

        /// <summary>
        /// 所有從站模組。
        /// </summary>
        public MotionSlave[] SlaveItems
        {
            get => slavesItems;
            private set => slavesItems = value.Length > EtherCatDef.NETWORK_SLAVE_MAX ?
                slavesItems = new MotionSlave[EtherCatDef.NETWORK_SLAVE_MAX] : slavesItems = value;
        }

        #region Event

        public event EventHandler<DeviceStateChangeEventArgs> DeviceStateChangeEvent;

        public event EventHandler<SalveAxisStateChangeEventArgs> SalveAxisStateChangeEvent;

        #endregion

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

        /// <summary>
        /// 取得當前使用的 dll 版本資訊。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public static ushort GetVersion(ref int resultCode)
        {
            var str = new StringBuilder();
            ushort size = 0;
            int i = 0;
            while (i++ < RetryCount)
            {
                // ECAT-M801 實體卡片上可以更改卡號
                // 傳入 Card ID(卡號)，取得目前卡片上可使用裝置的數量
                resultCode = EtherCatLib.ECAT_GetDllVersion(str, ref size);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{i}]");
                SpinWait.SpinUntil(() => false, RetryInterval);
            }
            return resultCode == 0 ? size : (ushort)0;
        }

        /// <summary>
        /// 取得可用裝置數量。
        /// </summary>
        /// <param name="cardId">軸卡ID。</param>
        /// <returns></returns>
        public static ushort GetDeviceCount(byte[] cardId, ref int resultCode)
        {
            ushort deviceCnt = 0;
            int i = 0;
            while (i++ < RetryCount)
            {
                // ECAT-M801 實體卡片上可以更改卡號
                // 傳入 Card ID(卡號)，取得目前卡片上可使用裝置的數量
                resultCode = EtherCatLib.ECAT_GetDeviceCnt(ref deviceCnt, cardId);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{i}]");
                SpinWait.SpinUntil(() => false, 200);
            }
            return resultCode == 0 ? deviceCnt : (ushort)0;
        }

        #endregion

        /// <summary>
        /// 開啟裝置做通訊操作。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool OpenDevice(ref int resultCode)
        {
            int i = 0;
            while (i++ < RetryCount)
            {                // 開啟指定裝置編號(卡號)來做通訊操作。
                resultCode = EtherCatLib.ECAT_OpenDevice(DeviceNo);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{i}]");
                SpinWait.SpinUntil(() => false, RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 取得 EtherCAT 網絡狀態。
        /// </summary>
        /// <returns></returns>
        public bool GetDeviceState(ref int resultCode)
        {
            uint linkup = 0, slaveResp = 0, alstate = 0, wc = 0;
            int i = 0;
            while (i++ < RetryCount)
            {
                resultCode = EtherCatLib.ECAT_GetDeviceState(
                    DeviceNo,
                    ref linkup,
                    ref slaveResp,
                    ref alstate,
                    ref wc);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{i}]");
                SpinWait.SpinUntil(() => false, RetryInterval);
            }
            if (resultCode == 0)
            {
                IsLinkUp = linkup == 1;
                SlavesResp = slaveResp;
                AlState = (AlStates)alstate;
                WorkingCounter = wc;
                OnDeviceStateChangeEvent();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 開始 EtherCAT 操作任務。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool StartOpTask(ref int resultCode)
        {
            int i = 0;
            while (i++ < RetryCount && GetDeviceState(ref resultCode))
            {
                if (AlState == AlStates.ECAT_AS_OP) // 已進入 Operational 狀態
                {
                    return true;
                }
                resultCode = AlState == AlStates.ECAT_AS_PREOP
                    ? EtherCatLib.ECAT_StartDeviceOpTask(DeviceNo, NetworkInfoNo, EtherCatDef.DEV_OP_CYCLE_TIME_1MS, RetryCount)
                    : EtherCatLib.ECAT_StopDeviceOpTask(DeviceNo);
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{i}]");
                SpinWait.SpinUntil(() => false, RetryInterval);
            }
            return false;
        }

        /// <summary>
        /// 裝置、從站初始化。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool InitializeSlave()
        {
            int resultCode = 0;
            if (OpenDevice(ref resultCode) && StartOpTask(ref resultCode))
            {
                if (AlState != AlStates.ECAT_AS_OP)
                {
                    Logger.Error(MethodBase.GetCurrentMethod().Name, "裝置不在 Operational 狀態，無法取得從站資訊。");
                    return false;
                }
                SlaveItems = new MotionSlave[SlavesResp];
                for (ushort i = 0; i < SlaveItems.Length; i++)
                {
                    SlaveItems[i] = new MotionSlave(DeviceNo, i);
                    SlaveItems[i].GetSlaveInfo(ref resultCode);
                }
                if (SlaveItems.Length > 0)
                {
                    return true;
                }
                Logger.Error(MethodBase.GetCurrentMethod().Name, $"DeviceNo=[{DeviceNo}] 從站為 null，無法初始化。");
            }
            return false;
        }

        /// <summary>
        /// 從站之子軸初始化。
        /// </summary>
        /// <returns></returns>
        public bool InitMotionAxis()
        {
            for (int i = 0; i < SlaveItems.Length; i++)
            {
                var mcSlaveNo = new List<ushort>();
                var mcSubAxisNo = new List<ushort>();
                MotionSlave slave = SlaveItems[i];
                if (slave.AxisItems == null)
                {
                    Logger.Error(MethodBase.GetCurrentMethod().Name, $"DeviceNo=[{DeviceNo}], SlaveNo=[{slave.SlaveNo}] 子軸為 null，無法初始化。");
                    continue;
                }
                int resultCode;
                int retryCount;
                for (int j = 0; j < slave.AxisItems.Length; j++)
                {
                    MotionAxis axis = slave.AxisItems[j];
                    resultCode = 0;
                    retryCount = 0;
                    while (retryCount++ < 10)
                    {
                        axis.GetAxisState(ref resultCode);
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
                            axis.IsMcInitOk = true;
                            // Servo 尚未停止，執行 ServoOff。
                            axis.ServoControl(false);
                        }
                        else if (axis.AxisState == AxisStates.MC_AS_ERRORSTOP) // 軸出現異常。
                        {
                            axis.IsMcInitOk = true;
                            axis.GetAxisErrorState();
                            SalveAxisStateChangeEvent?.Invoke(slave, new SalveAxisStateChangeEventArgs()
                            {
                                SlaveNo = slave.SlaveNo,
                                AlState = slave.AlState,
                                SlaveName = slave.SlaveName,
                                AxisNo = axis.AxisNo,
                                AxisState = axis.AxisState,
                                LastError = axis.LastError,
                                DriveError = axis.DriveError
                            });
                            Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"SlaveNo=[{slave.SlaveNo}], AxisNo=[{axis.AxisNo}] 軸目前出現錯誤且為停止狀態 !!!");
                            break;
                        }
                        else if (axis.AxisState != AxisStates.MC_AS_STOPPING) // 軸仍在運動中。
                        {
                            axis.IsMcInitOk = true;
                            // 如果不在停止狀態，立刻停止。
                            axis.AxisQuickStop();
                        }
                        SpinWait.SpinUntil(() => false, RetryInterval);
                    }
                }
                if (mcSlaveNo.Count > 0 && mcSubAxisNo.Count > 0)
                {
                    resultCode = 0;
                    retryCount = 0;
                    while (retryCount++ < RetryCount)
                    {
                        resultCode = EtherCatLib.ECAT_McInit(
                           slave.DeviceNo,
                           mcSlaveNo.ToArray(),
                           mcSubAxisNo.ToArray(),
                           (ushort)mcSubAxisNo.Count);
                        if (resultCode == 0)
                        {
                            break;
                        }
                        Logger.Error(resultCode, "ECAT_McInit", $"SlaveNo=[{slave.SlaveNo}], 嘗試次數=[{i}]");
                        SpinWait.SpinUntil(() => false, RetryInterval);
                    }
                    if (resultCode == 0)
                    {
                        foreach (MotionAxis axis in slave.AxisItems)
                        {
                            axis.IsMcInitOk = true;
                        }
                    }
                    else
                    {
                        foreach (MotionAxis axis in slave.AxisItems)
                        {
                            axis.IsMcInitOk = false;
                        }
                        Logger.Error(resultCode, "ECAT_McInit", $"DeviceNo=[{DeviceNo}], SlaveNo=[{slave.SlaveNo}] 初始化失敗 !!!");
                    }
                }
            }
            return true;
        }
    }
}
