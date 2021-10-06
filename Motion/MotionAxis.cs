using System.Reflection;
using System.Threading;

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

        /// <summary>
        /// 取得軸當前狀態。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        internal bool GetAxisState(ref int resultCode)
        {
            uint axisState = 0;
            int i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisState(DeviceNo, AxisNo, ref axisState);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            if (resultCode == 0)
            {
                AxisState = (AxisStates)axisState;
                return true;
            }
            else
            {
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        /// <summary>
        /// 取得軸當前運轉狀態。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool GetAxisProcessState(ref int resultCode)
        {
            if (!GetAxisState(ref resultCode))
            {
                return false;
            }
            // 取得指定軸號命令位置。
            double dValue = 0;
            int i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisCommandPos(DeviceNo, AxisNo, ref dValue);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            CommandPos = dValue;
            // 取得指定軸號當前位置。
            dValue = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisActualPos(DeviceNo, AxisNo, ref dValue);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            ActualPos = dValue;
            // 取得指定軸號當前速度。
            dValue = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisActualVel(DeviceNo, AxisNo, ref dValue);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            ActualVel = dValue;
            // 取得指定軸號最後出錯代碼。
            int lastError = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisLastError(DeviceNo, AxisNo, ref lastError);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            LastError = lastError;
            // 取得指定軸號驅動器出錯代碼。
            ushort driveError = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisDriveError(DeviceNo, AxisNo, ref driveError);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            DriveError = driveError;
            // 取得指定軸號驅動器出錯代碼。
            uint axisDI = 0;
            i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisDI(DeviceNo, AxisNo, ref axisDI);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            AxisDI = axisDI;
            return true;
        }
    }
}
