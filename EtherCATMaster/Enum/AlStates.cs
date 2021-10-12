using System;

namespace EtherCATMaster
{
    [Flags]
    public enum AlStates
    {
        /// <summary>
        /// Init狀態。
        /// </summary>
        ECAT_AS_INIT = 0x00,
        /// <summary>
        /// Pre-Operational狀態。
        /// </summary>
        ECAT_AS_PREOP = 0x02,
        /// <summary>
        /// Safe-Operational狀態。
        /// </summary>
        ECAT_AS_SAFEOP = 0x04,
        /// <summary>
        /// Operational狀態。
        /// </summary>
        ECAT_AS_OP = 0x08
    }
}
