using System.Reflection;
using System.Text;
using System.Threading;

namespace EtherCATMaster
{
    public static class ECatControl
    {
        /// <summary>
        /// 指定結果操作的嘗試次數，預設為5次。
        /// </summary>
        public static uint RetryCount { get; private set; } = 5;

        /// <summary>
        /// 指定重試嘗試之間的間隔(ms)。
        /// </summary>
        public static int RetryInterval { get; private set; } = 200;

        /// <summary>
        /// 取得當前使用的 dll 版本資訊。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public static ushort GetVersion(ref int resultCode)
        {
            var str = new StringBuilder();
            ushort size = 0;
            int retryCount = 0;
            while (retryCount++ < RetryCount)
            {
                // ECAT-M801 實體卡片上可以更改卡號
                // 傳入 Card ID(卡號)，取得目前卡片上可使用裝置的數量
                resultCode = EtherCatLib.ECAT_GetDllVersion(str, ref size);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, RetryInterval);
            }
            return resultCode == 0 ? size : (ushort)0;
        }

        /// <summary>
        /// 取得可用裝置數量。
        /// </summary>
        /// <param name="cardId">軸卡ID。</param>
        /// <returns></returns>
        public static ushort GetDeviceCount(byte[] cardId, ref int resultCode)
        {
            ushort deviceCnt = 0;
            int retryCount = 0;
            while (retryCount++ < RetryCount)
            {
                // ECAT-M801 實體卡片上可以更改卡號
                // 傳入 Card ID(卡號)，取得目前卡片上可使用裝置的數量
                resultCode = EtherCatLib.ECAT_GetDeviceCnt(ref deviceCnt, cardId);
                if (resultCode == 0)
                {
                    break;
                }
                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"嘗試次數=[{retryCount}]");
                SpinWait.SpinUntil(() => false, 200);
            }
            return resultCode == 0 ? deviceCnt : (ushort)0;
        }
    }
}
