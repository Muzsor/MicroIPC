using System;
using System.Reflection;
using System.Threading;

namespace EtherCATMaster
{
    public abstract class AbstractECatDevice
    {
        #region Property

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

        private AbstractECatSlave[] slavesItems;

        /// <summary>
        /// 所有從站模組。
        /// </summary>
        public AbstractECatSlave[] SlaveItems
        {
            get => slavesItems;
            protected set => slavesItems = value.Length > EtherCatDef.NETWORK_SLAVE_MAX ?
                slavesItems = new AbstractECatSlave[EtherCatDef.NETWORK_SLAVE_MAX] : slavesItems = value;
        }

        #endregion

        #region Event

        public event EventHandler<DeviceStateChangeEventArgs> DeviceStateChangeEvent;

        #endregion

        #region Private Method

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

        #region Public Method

        public AbstractECatDevice(ushort deviceNo, ushort networkInfoNo)
        {
            DeviceNo = deviceNo;
            NetworkInfoNo = networkInfoNo;
        }

        /// <summary>
        /// 開啟裝置做通訊操作。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool OpenDevice(ref int resultCode)
        {
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                // 開啟指定裝置編號(卡號)來做通訊操作。
                resultCode = EtherCatLib.ECAT_OpenDevice(DeviceNo);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 關閉裝置做通訊操作。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool CloseDevice(ref int resultCode)
        {
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                // 關閉指定裝置編號(卡號)來做通訊操作。
                resultCode = EtherCatLib.ECAT_CloseDevice(DeviceNo);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
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
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
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
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
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
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount && GetDeviceState(ref resultCode))
            {
                if (AlState == AlStates.ECAT_AS_OP) // 已進入 Operational 狀態
                {
                    return true;
                }
                resultCode = AlState == AlStates.ECAT_AS_PREOP
                    ? EtherCatLib.ECAT_StartDeviceOpTask(DeviceNo, NetworkInfoNo, EtherCatDef.DEV_OP_CYCLE_TIME_1MS, ECatControl.RetryCount)
                    : EtherCatLib.ECAT_StopDeviceOpTask(DeviceNo);
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return false;
        }

        /// <summary>
        /// 停止 EtherCAT 操作任務。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool StopOpTask(ref int resultCode)
        {
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_StopDeviceOpTask(DeviceNo);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return false;
        }

        #endregion
    }
}
