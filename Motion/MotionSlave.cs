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

        private ushort[] subAxisNo;

        /// <summary>
        /// Axis 模塊在 EtherCAT 網絡中的位置，最多 64 軸。
        /// </summary>
        public ushort[] SubAxisNo
        {
            get => subAxisNo;
            set => subAxisNo = value.Length > 64 ? (new ushort[EtherCatDef.MC_AXIS_NO_MAX]) : value;
        }
        
        private AxisStates[] axisState;

        /// <summary>
        /// 各軸的狀態，最多 64 軸。
        /// </summary>
        public AxisStates[] AxisState
        {
            get => axisState;
            set => axisState = value.Length > 64 ? new AxisStates[EtherCatDef.MC_AXIS_NO_MAX] : value;
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
    }
}
