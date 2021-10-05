using Motion.Enum;

namespace Motion
{
    public class MotionSlave
    {
        public ushort DeviceNo { get; private set; }

        public ushort SlaveNo { get; private set; }

        public ushort Alias { get; private set; }

        public uint ProductCode { get; private set; }

        public uint VendorID { get; private set; }

        public uint RevisionNo { get; private set; }

        public uint SerialNo { get; private set; }

        public AlStates AlState { get; private set; }

        public SlaveType SlaveType { get; private set; }

        public string SlaveName { get; private set; }

        /// <summary>
        /// 所有軸是否初始化完成。
        /// </summary>
        public bool IsMcInitOk { get; internal set; }

        private MotionAxis[] axisItems;
        /// <summary>
        /// Axis 模塊在 EtherCAT 網絡中的位置，最多 64 軸。
        /// </summary>
        public MotionAxis[] AxisItems
        {
            get => axisItems;
            private set => axisItems = value.Length > 64 ? new MotionAxis[EtherCatDef.MC_AXIS_NO_MAX] : value;
        }

        public MotionSlave(
            ushort deviceNo,
            ushort slaveNo,
            ushort alias,
            uint productCode,
            uint vendorID,
            uint revisionNo,
            uint serialNo,
            byte alState,
            uint slaveType,
            string slaveName)
        {
            DeviceNo = deviceNo;
            SlaveNo = slaveNo;
            Alias = alias;
            ProductCode = productCode;
            VendorID = vendorID;
            RevisionNo = revisionNo;
            SerialNo = serialNo;
            AlState = (AlStates)alState;
            SlaveType = (SlaveType)slaveType;
            SlaveName = slaveName;
        }

        /// <summary>
        /// 指定軸數。
        /// </summary>
        /// <param name="count"></param>
        internal void SetAxisCount(int count)
        {
            if (AxisItems == null)
            {
                AxisItems = new MotionAxis[count];
            }
        }
    }
}
