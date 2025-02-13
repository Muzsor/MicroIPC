﻿using NLog;

using System;

namespace EtherCATMaster
{
    public static class Logger
    {
        private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        internal static void Error(string methodName, string errorMsg = null)
            => logger.Error($"Method=[{methodName}], {(errorMsg == null ? string.Empty : $", {errorMsg}")}");

        internal static void Error(int errorCode, string methodName, Exception excetionMsg)
            => logger.Error($"ErrorCode=[{errorCode,5}], Method=[{methodName}] {(excetionMsg == null ? string.Empty : $", {excetionMsg}")}");

        internal static void Error(int errorCode, string methodName, string errorMsg = null)
            => logger.Error($"ErrorCode=[{errorCode,5}], Method=[{methodName}] {(errorMsg == null ? string.Empty : $", {errorMsg}")}");
    }
}
