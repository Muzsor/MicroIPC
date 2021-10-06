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
        /// 設定軸的參數。
        /// </summary>
        /// <param name="motionParam"></param>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public (MotionParam, bool) SetAxisParam(MotionParam motionParam, ref int resultCode)
        {
            int i;
            var motionParamResult = new MotionParam();
            if (IsMcInitOk)
            {
                return (motionParamResult, false);
            }
            // 設定 Pulse per Unit 參數。
            if (motionParam.PPU > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisPPU(DeviceNo, AxisNo, motionParam.PPU);
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                } while (resultCode != 0 && i++ < MotionController.RetryCount);
            }
            double ppu = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisPPU(DeviceNo, AxisNo, ref ppu);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            motionParamResult.PPU = ppu;
            // 設定自動原點復歸的模式。
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McSetAxisHomeMethod(DeviceNo, AxisNo, motionParam.HomeMethod);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            int homeMethod = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeMethod(DeviceNo, AxisNo, ref homeMethod);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            motionParamResult.HomeMethod = homeMethod;
            // 設定執行自動原點復歸時使用的速度。
            if (motionParam.ORGHomeSpeed > 0 && motionParam.EZHomeSpeed > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisHomeSpeed(DeviceNo, AxisNo, motionParam.ORGHomeSpeed, motionParam.EZHomeSpeed);
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                } while (resultCode != 0 && i++ < MotionController.RetryCount);
            }
            double ORGHomeSpeed = 0;
            double EZHomeSpeed = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeSpeed(DeviceNo, AxisNo, ref ORGHomeSpeed, ref EZHomeSpeed);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            motionParamResult.ORGHomeSpeed = ORGHomeSpeed;
            motionParamResult.EZHomeSpeed = EZHomeSpeed;
            // 設定執行自動原點復歸時使用的加速度。
            if (motionParam.HomeAcc > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisHomeAcc(DeviceNo, AxisNo, motionParam.HomeAcc);
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                } while (resultCode != 0 && i++ < MotionController.RetryCount);
            }
            double homeAcc = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeAcc(DeviceNo, AxisNo, ref homeAcc);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            motionParamResult.HomeAcc = homeAcc;
            // 設定速度/加速度換算參數。
            if (motionParam.VelScale > 0 && motionParam.AccScale > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisVelAccScale(DeviceNo, AxisNo, motionParam.VelScale, motionParam.AccScale);
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                } while (resultCode != 0 && i++ < MotionController.RetryCount);
            }
            double velScale = 0;
            double accScale = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisVelAccScale(DeviceNo, AxisNo, ref velScale, ref accScale);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            motionParamResult.VelScale = velScale;
            motionParamResult.AccScale = accScale;
            // 設定執行單軸運動時使用的加減速時間。
            if (motionParam.AccTime > 0 && motionParam.DecTime > 0)
            {
                i = 0;
                resultCode = 0;
                do
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisAccDecTime_Stepper(DeviceNo, AxisNo, motionParam.AccTime, motionParam.DecTime);
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                } while (resultCode != 0 && i++ < MotionController.RetryCount);
            }
            ushort accTime = 0;
            ushort decTime = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisAccDecTime_Stepper(DeviceNo, AxisNo, ref accTime, ref decTime);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            motionParamResult.AccTime = accTime;
            motionParamResult.DecTime = decTime;
            // 設定執行單軸運動時使用的加速度類型。
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McSetAxisAccDecType(DeviceNo, AxisNo, (ushort)motionParam.AccDecType);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            ushort accDecType = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisAccDecType(DeviceNo, AxisNo, ref accDecType);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            motionParamResult.AccDecType = (AccDecType)accDecType;
            // 設定指定軸號之位置軟體極限。
            uint AbortCode = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McSetAxisPosSoftwareLimit(DeviceNo, AxisNo, motionParam.PosSoftwareMaxLimit, motionParam.PosSoftwareMinLimit, ref AbortCode);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            double posSoftwareMaxLimit = 0;
            double posSoftwareMinLimit = 0;
            i = 0;
            resultCode = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisPosSoftwareLimit(DeviceNo, AxisNo, ref posSoftwareMaxLimit, ref posSoftwareMinLimit, ref AbortCode);
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            motionParamResult.PosSoftwareMaxLimit = posSoftwareMaxLimit;
            motionParam.PosSoftwareMinLimit = posSoftwareMinLimit;
            return (motionParamResult, true);
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
        /// 取得錯誤代碼。
        /// </summary>
        /// <param name="resultCode"></param>
        internal void GetAxisErrorState(ref int resultCode)
        {
            // 取得最後出錯代碼。
            int lastError = 0;
            int i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McGetAxisLastError(DeviceNo, AxisNo, ref lastError);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            LastError = lastError;
            // 取得驅動器出錯代碼。
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
            // 取得命令位置。
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
            // 取得當前位置。
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
            // 取得當前速度。
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
            // 取得錯誤代碼。
            GetAxisErrorState(ref resultCode);
            // 取得運動控制相關 I/O 訊號狀態。
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

        /// <summary>
        /// 設定 Servo 啟動/停止。
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public bool ServoControl(bool isOn, ref int resultCode)
        {
            int i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McSetAxisServoOn(DeviceNo, AxisNo, (ushort)(isOn ? 1 : 0));
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            return resultCode == 0;
        }

        /// <summary>
        /// 立即停止運動。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool AxisQuickStop(ref int resultCode)
        {
            int i = 0;
            do
            {
                resultCode = EtherCatLib.ECAT_McAxisQuickStop(DeviceNo, AxisNo);
                if (resultCode != 0)
                {
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            } while (resultCode != 0 && i++ < MotionController.RetryCount);
            return resultCode == 0;
        }
    }
}
