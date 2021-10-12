using System.Threading;

namespace EtherCATMaster
{
    public class IOSlave : AbstractECatSlave
    {
        public uint DIStatus { get; private set; }

        public uint DOStatus { get; private set; }

        public IOSlave(ushort deviceNo, ushort slaveNo) : base(deviceNo, slaveNo)
        {
        }

        /// <summary>
        /// 取得 DI 狀態。
        /// </summary>
        /// <param name="value">輸入埠資料。</param>
        /// <returns></returns>
        public bool GetDI(ref uint value)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_GetSlaveDI(DeviceNo, SlaveNo, ref value);
                if (resultCode == 0)
                {
                    DIStatus = value;
                    break;
                }
                Logger.Error(resultCode, "ECAT_GetSlaveDI", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 取得指定位元的 DI 狀態。
        /// </summary>
        /// <param name="bitNo">指定位元。</param>
        /// <param name="value">輸入埠資料。</param>
        /// <returns></returns>
        public bool GetDI(ushort bitNo, ref uint value)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_GetSlaveDIBit(DeviceNo, SlaveNo, bitNo, ref value);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_GetSlaveDIBit", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 取得 DO 狀態。
        /// </summary>
        /// <param name="value">輸出埠資料。</param>
        /// <returns></returns>
        public bool GetDO(ref uint value)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_GetSlaveDO(DeviceNo, SlaveNo, ref value);
                if (resultCode == 0)
                {
                    DOStatus = value;
                    break;
                }
                Logger.Error(resultCode, "ECAT_GetSlaveDO", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 取得指定位元的 DO 狀態。
        /// </summary>
        /// <param name="bitNo">指定位元。</param>
        /// <param name="value">指定位元。</param>
        /// <returns></returns>
        public bool GetDO(ushort bitNo, ref uint value)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_GetSlaveDOBit(DeviceNo, SlaveNo, bitNo, ref value);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_GetSlaveDOBit", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 同時讀取多個從站模組的 DO 狀態。
        /// </summary>
        /// <param name="ioSlaves">從站模組集合。</param>
        /// <param name="values">輸出埠資料。</param>
        /// <returns></returns>
        public static bool GetDO(IOSlave[] ioSlaves, ref uint[] values)
        {
            int resultCode = 0;
            int retryCount = 0;
            ushort[] SlaveNo = new ushort[ioSlaves.Length];
            for (int i = 0; i < ioSlaves.Length; i++)
            {
                SlaveNo[i] = ioSlaves[i].SlaveNo;
            }
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_GetMultiSlaveDO(ioSlaves[0].DeviceNo, SlaveNo, ref values, (ushort)SlaveNo.Length);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_GetMultiSlaveDO", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 設定 DO 狀態。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetDO(uint value)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_SetSlaveDO(DeviceNo, SlaveNo, value);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_SetSlaveDO", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 設定指定位元的 DO 狀態。
        /// </summary>
        /// <param name="bitNo">指定位元。</param>
        /// <param name="value">輸出埠資料。</param>
        /// <returns></returns>
        public bool SetDO(ushort bitNo, uint value)
        {
            int resultCode = 0;
            int retryCount = 0;
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_SetSlaveDOBit(DeviceNo, SlaveNo, bitNo, value);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_SetSlaveDOBit", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 同時設定多個從站模組的 DI 狀態，必須為相同裝置編號。
        /// </summary>
        /// <param name="ioSlaves">從站模組集合。</param>
        /// <param name="values">輸出埠資料。</param>
        /// <returns></returns>
        public static bool SetDO(IOSlave[] ioSlaves, uint[] values)
        {
            int resultCode = 0;
            int retryCount = 0;
            ushort[] SlaveNo = new ushort[ioSlaves.Length];
            for (int i = 0; i < ioSlaves.Length; i++)
            {
                SlaveNo[i] = ioSlaves[i].SlaveNo;
            }
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_SetMultiSlaveDO(ioSlaves[0].DeviceNo, SlaveNo, values, (ushort)SlaveNo.Length);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_SetMultiSlaveDO", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }

        /// <summary>
        /// 同時設定多個從站模組的 DI 狀態，必須為相同裝置編號。在指定的 resetTime 時間後，將指定位元的 DO 狀態關閉。
        /// </summary>
        /// <param name="ioSlaves">從站模組集合。</param>
        /// <param name="values">輸出埠資料。</param>
        /// <param name="resetTime">時間，EtherCAT 通訊週期的倍數。</param>
        /// <param name="bitNos">遮罩，僅在有遮罩設定的 BIT 會被關閉。</param>
        /// <returns></returns>
        public static bool SetDO_AutoOff(IOSlave[] ioSlaves, uint[] values, uint[] resetTime, uint[] bitNos)
        {
            int resultCode = 0;
            int retryCount = 0;
            ushort[] SlaveNo = new ushort[ioSlaves.Length];
            for (int i = 0; i < ioSlaves.Length; i++)
            {
                SlaveNo[i] = ioSlaves[i].SlaveNo;
            }
            while (retryCount++ < ECatControl.RetryCount)
            {
                resultCode = EtherCatLib.ECAT_SetMultiSlaveDO_AutoOff(
                    ioSlaves[0].DeviceNo,
                    SlaveNo,
                    values,
                    resetTime,
                    bitNos,
                    (ushort)SlaveNo.Length);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, "ECAT_SetMultiSlaveDO_AutoOff", $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
            }
            return resultCode == 0;
        }
    }
}
