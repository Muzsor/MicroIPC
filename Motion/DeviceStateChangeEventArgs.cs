namespace Motion
{
    public class DeviceStateChangeEventArgs
    {
        /// <summary>
        /// 裝置編號(卡號)。
        /// </summary>
        public ushort DeviceNo { get; set; }

        /// <summary>
        /// 顯示乙太網路孔連接狀態。
        /// </summary>
        public bool IsLinkUp { get; set; }

        /// <summary>
        /// 目前已連接從站數量。
        /// </summary>
        public uint SlavesResp { get; set; }

        /// <summary>
        /// 顯示目前整個網路 Slave EtherCAT 狀態。
        /// </summary>
        public AlStates AlState { get; set; }

        /// <summary>
        /// 顯示 EtherCAT 工作計數器數值。
        /// </summary>
        public uint WorkingCounter { get; set; }
    }
}
