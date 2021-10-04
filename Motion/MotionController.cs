using System;
using System.Collections.Generic;
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

        /// <summary>
        /// 所有從站模組。
        /// </summary>
        public List<MotionSlave> SlaveItems { get; private set; }

        public event EventHandler<DeviceStateChangeEventArgs> DeviceStateChangeEvent;

        private readonly byte EnumCycleTime = EtherCatDef.DEV_OP_CYCLE_TIME_1MS;

        public static ushort GetDeviceCount(byte[] cardId)
        {
            ushort DeviceCnt = 0;
            int ret;
            int i = 0;
            do
            {
                // ECAT-M801 實體卡片上可以更改卡號
                // 傳入 Card ID(卡號)，取得目前卡片上可使用裝置的數量
                ret = EtherCatLib.ECAT_GetDeviceCnt(ref DeviceCnt, cardId);
            } while (ret == 0 && i++ < 10);
            return ret == 0 ? DeviceCnt : (ushort)0;
        }

        public MotionController(ushort deviceNo, ushort networkInfoNo)
        {
            DeviceNo = deviceNo;
            NetworkInfoNo = networkInfoNo;
        }

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

        public bool OpenDevice()
        {
            int i = 0;
            int ret;
            do
            {
                // 開啟指定裝置編號(卡號)來做通訊操作。
                ret = EtherCatLib.ECAT_OpenDevice(DeviceNo);
                SpinWait.SpinUntil(() => false, RetryInterval);
            } while (ret == 0 && i++ < RetryCount);
            return ret == 0;
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
            } while (ret == 0 && i++ < RetryCount);
            if (ret == 0)
            {
                IsLinkUp = linkup == 1;
                SlavesResp = slaveResp;
                Enum.TryParse(alstates.ToString(), out AlStates state);
                AlState = state;
                WorkingCounter = wc;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StartOpTask()
        {
            int i = 0;
            while (GetDeviceState() && i++ < RetryCount)
            {
                if (AlState == AlStates.ECAT_AS_OP)
                {
                    return true;
                }
                else if (AlState == AlStates.ECAT_AS_PREOP)
                {
                    EtherCatLib.ECAT_StartDeviceOpTask(DeviceNo, NetworkInfoNo, EnumCycleTime, RetryCount);
                }
                else
                {
                    EtherCatLib.ECAT_StopDeviceOpTask(DeviceNo);
                }
                SpinWait.SpinUntil(() => false, RetryInterval);
            }
            return false;
        }

        public void GetSlaveInfo()
        {
            SlaveItems = new List<MotionSlave>();
            ushort Alias = 0;
            uint ProductCode = 0, VendorID = 0, RevisionNo = 0, SerialNo = 0, SlaveType = 0;
            byte AlState = 0;
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
                        ref Alias,
                        ref ProductCode,
                        ref VendorID,
                        ref RevisionNo,
                        ref SerialNo,
                        ref AlState,
                        ref SlaveType,
                        slvName);
                } while (ret == 0 && i++ < RetryCount);
                if (ret == 0)
                {
                    SlaveItems.Add(new MotionSlave(
                        DeviceNo,
                        slaveNo,
                        Alias,
                        ProductCode,
                        VendorID,
                        RevisionNo,
                        SerialNo,
                        AlState,
                        SlaveType,
                        slvName.ToString())
                    );
                }
            }
        }
    }
}
