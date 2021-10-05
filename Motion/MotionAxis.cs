namespace Motion
{
    public class MotionAxis
    {
        public ushort DeviceNo { get; private set; }

        public ushort SlaveNo { get; private set; }

        public ushort AxisNo { get; private set; }

        public double CommandPos { get; internal set; }

        public double ActualPos { get; internal set; }

        public double ActualVel { get; internal set; }

        public AxisStates AxisState { get; internal set; }

        public int LastError { get; internal set; }

        public ushort DriveError { get; internal set; }

        public uint AxisDI { get; internal set; }

        /// <summary>
        /// 軸是否初始化完成
        /// </summary>
        public bool IsMcInitOk { get; internal set; }

        public MotionAxis(ushort deviceNo, ushort slaveNo, ushort axisNo, AxisStates axisStates = AxisStates.MC_AS_DISABLED)
        {
            DeviceNo = deviceNo;
            SlaveNo = slaveNo;
            AxisNo = axisNo;
            CommandPos = 0;
            ActualPos = 0;
            AxisState = axisStates;
            LastError = 0;
            DriveError = 0;
            AxisDI = 0;
            IsMcInitOk = false;
        }
    }
}
