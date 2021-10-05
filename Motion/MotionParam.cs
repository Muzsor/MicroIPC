namespace Motion
{
    public class MotionParam
    {
        /// <summary>
        /// Pulse per Unit參數。
        /// </summary>
        public double PPU { get; set; }

        /// <summary>
        /// 自動原點復歸的模式。
        /// </summary>
        public int HomeMethod { get; set; }

        /// <summary>
        /// 尋找原點(ORG)訊號時使用的速度，(user unit/s)。
        /// </summary>
        public double ORGHomeSpeed { get; set; }

        /// <summary>
        /// 尋找馬達索引(EZ)訊號時使用的速度，(user unit/s)。
        /// </summary>
        public double EZHomeSpeed { get; set; }

        /// <summary>
        /// 自動原點復歸時使用的加速度。
        /// </summary>
        public double HomeAcc { get; set; }

        /// <summary>
        /// 速度換算參數(rpm)，設定值為 (1/1圈所需的pulse數)*60 。
        /// 例：假設1圈所需要的pulse數為10000，則速度換算參數就設定為1/10000*60 = 0.006。
        /// </summary>
        public double VelScale { get; set; }

        /// <summary>
        /// 加速度換算參數(rpm/s)，設定值為 (1/1圈所需的pulse數)*60 。
        /// 例：假設1圈所需要的pulse數為10000，則加速度換算參數就設定為1/10000*60 = 0.006。
        /// </summary>
        public double AccScale { get; set; }

        /// <summary>
        /// 加速時間。
        /// </summary>
        public ushort AccTime { get; set; }

        /// <summary>
        /// 減速時間。
        /// </summary>
        public ushort DecTime { get; set; }

        /// <summary>
        /// 加減速類型。
        /// </summary>
        public AccDecType AccDecType { get; set; }

        /// <summary>
        /// 位置最小軟體極限。
        /// </summary>
        public double PosSoftwareMinLimit { get; set; }

        /// <summary>
        /// 位置最大軟體極限。
        /// </summary>
        public double PosSoftwareMaxLimit { get; set; }
    }
}
