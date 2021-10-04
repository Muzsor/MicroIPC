using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion
{
    public enum AxisStates
    {
        /// <summary>
        /// 軸尚未啟用。
        /// </summary>
        MC_AS_DISABLED = 0,
        /// <summary>
        /// 軸啟用且為停止狀態，準備接收新的運動命令。
        /// </summary>
        MC_AS_STANDSTILL = 1,
        /// <summary>
        /// 軸目前出現錯誤且為停止狀態。
        /// </summary>
        MC_AS_ERRORSTOP = 2,
        /// <summary>
        /// 軸目前在停止運動中。
        /// </summary>
        MC_AS_STOPPING = 3,
        /// <summary>
        /// 軸目前在原點復歸中。
        /// </summary>
        MC_AS_HOMING = 4,
        /// <summary>
        /// 軸目前單軸運動中。
        /// </summary>
        MC_AS_DISCRETEMOTION = 5,
        /// <summary>
        /// 軸目前連續運動中。
        /// </summary>
        MC_AS_CONTINUOUSMOTION = 6,
        /// <summary>
        /// 軸目前同步運動中，軸在群組中，群組正在進行補間運動。
        /// </summary>
        MC_AS_SYNCHRONIZEDMOTION = 7,
        /// <summary>
        /// 方向盤運動中(?)。
        /// </summary>
        MC_AS_STEERWHEELMOTION = 8
    }
}
