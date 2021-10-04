using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion.Enum
{
    public enum SlaveType
    {
        /// <summary>
        /// 通用種類。
        /// </summary>
        SLAVE_TYPE_GENERIC = 0,
        /// <summary>
        /// CiA 402 種類。
        /// </summary>
        SLAVE_TYPE_CiA402 = 1,
        /// <summary>
        /// 單軸步進馬達種類。
        /// </summary>
        SLAVE_TYPE_STEPPER_MOTOR = 2,
        /// <summary>
        /// 4軸步進馬達種類。
        /// </summary>
        SLAVE_TYPE_4_AXIS_STEPPER_MOTOR = 3,
        /// <summary>
        /// 2610(?)
        /// </summary>
        SLAVE_TYPE_2610 = 4
    }
}
