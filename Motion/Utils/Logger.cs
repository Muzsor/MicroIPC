using NLog;

using System;

namespace Motion
{
    public static class Logger
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        internal static void Error(int errorCode, string methodName, Exception excetionMsg)
            => logger.Error($"ErrorCode=[{errorCode:####}], Method=[{methodName}] {(excetionMsg != null ? $", {excetionMsg}" : string.Empty)}");

        internal static void Error(int errorCode, string methodName, string errorMsg = null)
            => logger.Error($"ErrorCode=[{errorCode:####}], Method=[{methodName}] {(errorMsg != null ? $", {errorMsg}" : string.Empty)}");
    }
}
