using System.Reflection;
using System.Threading;

namespace Motion
{
    public class MotionAxis
    {
        /// <summary>
        /// 裝置編號。
        /// </summary>
        public ushort DeviceNo { get; private set; }

        /// <summary>
        /// 從站編號。
        /// </summary>
        public ushort SlaveNo { get; private set; }

        /// <summary>
        /// 軸編號。
        /// </summary>
        public ushort AxisNo { get; private set; }

        /// <summary>
        /// 軸命令位置(單位:user unit)。
        /// </summary>
        public double CommandPos { get; internal set; }

        /// <summary>
        /// 軸當前位置(單位:user unit)。
        /// </summary>
        public double ActualPos { get; internal set; }

        /// <summary>
        /// 軸號當前速度(單位: user unit/s)。
        /// </summary>
        public double ActualVel { get; internal set; }

        /// <summary>
        /// 軸當前狀態。
        /// </summary>
        public AxisStates AxisState { get; internal set; }

        /// <summary>
        /// 最後出錯代碼。
        /// </summary>
        public int LastError { get; internal set; }

        /// <summary>
        /// 驅動器出錯代碼。
        /// </summary>
        public ushort DriveError { get; internal set; }

        /// <summary>
        /// 軸 I/O 訊號狀態
        /// </summary>
        public bool AxisDI { get; internal set; }

        /// <summary>
        /// 軸是否初始化完成
        /// </summary>
        public bool IsMcInitOk { get; internal set; }

        public MotionAxis(ushort deviceNo, ushort slaveNo, ushort axisNo)
        {
            DeviceNo = deviceNo;
            SlaveNo = slaveNo;
            AxisNo = axisNo;
            CommandPos = 0;
            ActualPos = 0;
            ActualVel = 0;
            AxisState = AxisStates.MC_AS_DISABLED;
            LastError = 0;
            DriveError = 0;
            AxisDI = false;
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
            var motionParamResult = new MotionParam();
            if (!IsMcInitOk)
            {
                return (motionParamResult, false);
            }
            int retryCount;
            // 設定 Pulse per Unit 參數。
            if (motionParam.PPU > 0)
            {
                retryCount = 0;
                resultCode = 0;
                while (retryCount++ < MotionController.RetryCount)
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisPPU(DeviceNo, AxisNo, motionParam.PPU);
                    if (resultCode == 0)
                    {
                        break;
                    }
                    Logger.Error(
                        resultCode,
                        "ECAT_McSetAxisPPU",
                        $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 設定失敗。");
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            }
            // 取得 Pulse per Unit 參數。
            double ppu = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisPPU(DeviceNo, AxisNo, ref ppu);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McGetAxisPPU",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 讀取失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            motionParamResult.PPU = ppu;
            // 設定自動原點復歸的模式。
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McSetAxisHomeMethod(DeviceNo, AxisNo, motionParam.HomeMethod);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McSetAxisHomeMethod",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 設定失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            // 取得自動原點復歸的模式。
            int homeMethod = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeMethod(DeviceNo, AxisNo, ref homeMethod);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McGetAxisHomeMethod",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 讀取失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            motionParamResult.HomeMethod = homeMethod;
            // 設定執行自動原點復歸時使用的速度。
            if (motionParam.ORGHomeSpeed > 0 && motionParam.EZHomeSpeed > 0)
            {
                retryCount = 0;
                resultCode = 0;
                while (retryCount++ < MotionController.RetryCount)
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisHomeSpeed(DeviceNo, AxisNo, motionParam.ORGHomeSpeed, motionParam.EZHomeSpeed);
                    if (resultCode == 0)
                    {
                        break;
                    }
                    Logger.Error(
                        resultCode,
                        "ECAT_McSetAxisHomeSpeed",
                        $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 設定失敗。");
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            }
            // 讀取執行自動原點復歸時使用的速度。
            double ORGHomeSpeed = 0;
            double EZHomeSpeed = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeSpeed(DeviceNo, AxisNo, ref ORGHomeSpeed, ref EZHomeSpeed);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McGetAxisHomeSpeed",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 讀取失敗。");
            }
            motionParamResult.ORGHomeSpeed = ORGHomeSpeed;
            motionParamResult.EZHomeSpeed = EZHomeSpeed;
            // 設定執行自動原點復歸時使用的加速度。
            if (motionParam.HomeAcc > 0)
            {
                retryCount = 0;
                resultCode = 0;
                while (retryCount++ < MotionController.RetryCount)
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisHomeAcc(DeviceNo, AxisNo, motionParam.HomeAcc);
                    if (resultCode == 0)
                    {
                        break;
                    }
                    Logger.Error(
                        resultCode,
                        "ECAT_McSetAxisHomeAcc",
                        $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 設定失敗。");
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            }
            // 讀取執行自動原點復歸時使用的加速度。
            double homeAcc = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisHomeAcc(DeviceNo, AxisNo, ref homeAcc);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McGetAxisHomeAcc",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 讀取失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            motionParamResult.HomeAcc = homeAcc;
            // 設定速度與加速度換算參數。
            if (motionParam.VelScale > 0 && motionParam.AccScale > 0)
            {
                retryCount = 0;
                resultCode = 0;
                while (retryCount++ < MotionController.RetryCount)
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisVelAccScale(DeviceNo, AxisNo, motionParam.VelScale, motionParam.AccScale);
                    if (resultCode == 0)
                    {
                        break;
                    }
                    Logger.Error(
                        resultCode,
                        "ECAT_McSetAxisVelAccScale",
                        $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 設定失敗。");
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            }
            // 讀取速度與加速度換算參數。
            double velScale = 0;
            double accScale = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisVelAccScale(DeviceNo, AxisNo, ref velScale, ref accScale);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McGetAxisVelAccScale",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 讀取失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            motionParamResult.VelScale = velScale;
            motionParamResult.AccScale = accScale;
            // 設定執行單軸運動時使用的加減速時間。
            if (motionParam.AccTime > 0 && motionParam.DecTime > 0)
            {
                retryCount = 0;
                resultCode = 0;
                while (retryCount++ < MotionController.RetryCount)
                {
                    resultCode = EtherCatLib.ECAT_McSetAxisAccDecTime_Stepper(DeviceNo, AxisNo, motionParam.AccTime, motionParam.DecTime);
                    if (resultCode == 0)
                    {
                        break;
                    }
                    Logger.Error(
                        resultCode,
                        "ECAT_McSetAxisAccDecTime_Stepper",
                        $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 設定失敗。");
                    SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
                }
            }
            // 讀取執行單軸運動時使用的加減速時間。
            ushort accTime = 0;
            ushort decTime = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisAccDecTime_Stepper(DeviceNo, AxisNo, ref accTime, ref decTime);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McGetAxisAccDecTime_Stepper",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 讀取失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            motionParamResult.AccTime = accTime;
            motionParamResult.DecTime = decTime;
            // 設定執行單軸運動時使用的加速度類型。
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McSetAxisAccDecType(DeviceNo, AxisNo, (ushort)motionParam.AccDecType);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McSetAxisAccDecType",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 設定失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            // 讀取執行單軸運動時使用的加速度類型。
            ushort accDecType = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisAccDecType(DeviceNo, AxisNo, ref accDecType);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McGetAxisAccDecType",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 讀取失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            motionParamResult.AccDecType = (AccDecType)accDecType;
            // 設定指定軸號之位置軟體極限。
            uint AbortCode = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McSetAxisPosSoftwareLimit(DeviceNo, AxisNo, motionParam.PosSoftwareMaxLimit, motionParam.PosSoftwareMinLimit, ref AbortCode);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McSetAxisPosSoftwareLimit",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 設定失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            // 讀取指定軸號之位置軟體極限。
            double posSoftwareMaxLimit = 0;
            double posSoftwareMinLimit = 0;
            retryCount = 0;
            resultCode = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisPosSoftwareLimit(DeviceNo, AxisNo, ref posSoftwareMaxLimit, ref posSoftwareMinLimit, ref AbortCode);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(
                    resultCode,
                    "ECAT_McGetAxisPosSoftwareLimit",
                    $"DeviceNo=[{DeviceNo}], SlaveNo=[{SlaveNo}], AxisNo=[{AxisNo}], 嘗試次數=[{retryCount}] 讀取失敗。");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
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
            int retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisState(DeviceNo, AxisNo, ref axisState);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            if (resultCode == 0)
            {
                AxisState = (AxisStates)axisState;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 取得錯誤代碼。
        /// </summary>
        /// <param name="resultCode"></param>
        internal void GetAxisErrorState()
        {
            int resultCode = 0;
            // 取得最後出錯代碼。
            int lastError = 0;
            int retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisLastError(DeviceNo, AxisNo, ref lastError);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McGetAxisLastError", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            LastError = lastError;
            // 取得驅動器出錯代碼。
            ushort driveError = 0;
            retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisDriveError(DeviceNo, AxisNo, ref driveError);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McGetAxisDriveError", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            DriveError = driveError;
        }

        /// <summary>
        /// 取得軸當前運轉狀態。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool GetAxisProcessState()
        {
            int resultCode = 0;
            if (!GetAxisState(ref resultCode))
            {
                return false;
            }
            // 取得命令位置。
            double dValue = 0;
            int retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisCommandPos(DeviceNo, AxisNo, ref dValue);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McGetAxisCommandPos", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            CommandPos = dValue;
            // 取得當前位置。
            dValue = 0;
            retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisActualPos(DeviceNo, AxisNo, ref dValue);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McGetAxisActualPos", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            ActualPos = dValue;
            // 取得當前速度。
            dValue = 0;
            retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisActualVel(DeviceNo, AxisNo, ref dValue);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McGetAxisActualVel", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            ActualVel = dValue;
            // 取得錯誤代碼。
            GetAxisErrorState();
            // 取得運動控制相關 I/O 訊號狀態。
            uint axisDI = 0;
            retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McGetAxisDI(DeviceNo, AxisNo, ref axisDI);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McGetAxisDI", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            AxisDI = axisDI == 1;
            return true;
        }

        /// <summary>
        /// 設定 Servo 啟動/停止。
        /// </summary>
        /// <param name="isOn"></param>
        /// <returns></returns>
        public bool ServoControl(bool isOn)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McSetAxisServoOn(DeviceNo, AxisNo, (ushort)(isOn ? 1 : 0));
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McSetAxisServoOn", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 減速停止運動。
        /// </summary>
        /// <returns></returns>
        public bool AxisStop()
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McAxisStop(DeviceNo, AxisNo);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McAxisStop", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 立即停止運動。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool AxisQuickStop()
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McAxisQuickStop(DeviceNo, AxisNo);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McAxisQuickStop", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 移動到絕對位置。
        /// </summary>
        /// <param name="postion"></param>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public bool MoveAbs(double postion, double velocity)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McAxisMoveAbs(DeviceNo, AxisNo, postion, velocity);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McAxisMoveAbs", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 移動到相對位置。
        /// </summary>
        /// <param name="postion"></param>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public bool MoveRel(double postion, double velocity)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < MotionController.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_McAxisMoveRel(DeviceNo, AxisNo, postion, velocity);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_McAxisMoveRel", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, MotionController.RetryInterval);
            }
            return resultCode == 0;
        }


    }
}
