using EtherCATMaster.Enum;

using System.Text;
using System.Threading;

namespace EtherCATMaster
{
    public abstract class AbstractECatSlave
    {
        #region Property

        /// <summary>
        /// 裝置編號(卡號)。
        /// </summary>
        public ushort DeviceNo { get; private set; }

        /// <summary>
        /// 從站編號。
        /// </summary>
        public ushort SlaveNo { get; private set; }

        private ushort alias;
        /// <summary>
        /// 別名。
        /// </summary>
        public ushort Alias
        {
            get => alias;
            private set => alias = value;
        }

        private uint productCode;
        public uint ProductCode
        {
            get => productCode;
            private set => productCode = value;
        }

        private uint vendorID;
        public uint VendorID
        {
            get => vendorID;
            private set => vendorID = value;
        }

        private uint revisionNo;
        public uint RevisionNo
        {
            get => revisionNo;
            private set => revisionNo = value;
        }

        private uint serialNo;
        public uint SerialNo
        {
            get => serialNo;
            private set => serialNo = value;
        }

        /// <summary>
        /// EtherCAT 狀態。
        /// </summary>
        public AlStates AlState { get; private set; }

        /// <summary>
        /// 從站種類。
        /// </summary>
        public SlaveType SlaveType { get; private set; }

        /// <summary>
        /// 從站名稱。
        /// </summary>
        public string SlaveName { get; private set; }

        #endregion

        #region Public Method

        public AbstractECatSlave(ushort deviceNo, ushort slaveNo)
        {
            DeviceNo = deviceNo;
            SlaveNo = slaveNo;
            Alias = 0;
            ProductCode = 0;
            VendorID = 0;
            RevisionNo = 0;
            SerialNo = 0;
            AlState = AlStates.ECAT_AS_INIT;
            SlaveName = string.Empty;
            SlaveType = SlaveType.SLAVE_TYPE_GENERIC;
        }

        /// <summary>
        /// 取得從站模組相關資訊。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool GetSlaveInfo()
        {
            uint slaveType = 0;
            byte alState = 0;
            var slvName = new StringBuilder(string.Empty, EtherCatDef.MAX_SLAVE_NAME_LENGTH);
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_GetSlaveInfo(
                    DeviceNo,
                    SlaveNo,
                    ref alias,
                    ref productCode,
                    ref vendorID,
                    ref revisionNo,
                    ref serialNo,
                    ref alState,
                    ref slaveType,
                    slvName);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_GetSlaveInfo", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            if (resultCode == 0)
            {
                AlState = (AlStates)alState;
                SlaveType = (SlaveType)slaveType;
                SlaveName = slvName.ToString();
                return true;
            }
            return false;
        }

        #endregion
    }
}
