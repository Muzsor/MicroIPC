using System;

namespace Motion
{
    [Flags]
    public enum AlStates
    {
        ECAT_AS_INIT = 0x00,
        ECAT_AS_PREOP = 0x02,
        ECAT_AS_SAFEOP = 0x04,
        ECAT_AS_OP = 0x08
    }
}
