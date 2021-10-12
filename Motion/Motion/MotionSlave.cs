namespace EtherCATMaster
{
    public class MotionSlave : AbstractECatSlave
    {
        private MotionAxis[] axisItems;
        /// <summary>
        /// Axis 模塊在 EtherCAT 網絡中的位置，最多 64 軸。
        /// </summary>
        public MotionAxis[] AxisItems
        {
            get => axisItems;
            private set => axisItems = value.Length > EtherCatDef.MC_AXIS_NO_MAX ?
                new MotionAxis[EtherCatDef.MC_AXIS_NO_MAX] : value;
        }

        public MotionSlave(ushort deviceNo, ushort slaveNo) : base(deviceNo, slaveNo)
        {
        }

        /// <summary>
        /// 指定軸數量與軸號。
        /// </summary>
        /// <param name="count"></param>
        public bool SetAxisNo(ushort[] axisList, ref int resultCode)
        {
            if (AxisItems == null)
            {
                AxisItems = new MotionAxis[axisList.Length];
                for (ushort i = 0; i < AxisItems.Length; i++)
                {
                    AxisItems[i] = new MotionAxis(DeviceNo, SlaveNo, axisList[i]);
                }
                return true;
            }
            return false;
        }
    }
}
