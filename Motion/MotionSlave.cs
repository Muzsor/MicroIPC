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

        public uint SlaveType { get; private set; }

        public string SlaveName { get; private set; }

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
            SlaveType = slaveType;
            SlaveName = slaveName;
        }
    }
}
