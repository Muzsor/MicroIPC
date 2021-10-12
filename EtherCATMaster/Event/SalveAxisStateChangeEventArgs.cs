namespace EtherCATMaster
{
    public class SalveAxisStateChangeEventArgs
    {
        public ushort SlaveNo { get; set; }

        public AlStates AlState { get; set; }

        public string SlaveName { get; set; }

        public ushort AxisNo { get; set; }

        public AxisStates AxisState { get; set; }

        /// <summary>
        /// 最後出錯代碼。
        /// </summary>
        public int LastError { get; internal set; }

        /// <summary>
        /// 驅動器出錯代碼。
        /// </summary>
        public ushort DriveError { get; internal set; }
    }
}