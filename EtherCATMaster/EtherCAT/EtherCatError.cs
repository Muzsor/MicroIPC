namespace EtherCATMaster
{
    internal static class EtherCatError
    {
        public const int ECAT_ERR_REQUEST_MASTER = -1001;      /**< Request Master. */
        public const int ECAT_ERR_ETHERNET_LINK_DOWN = -1002;      /**< Ethernet link is down. */
        public const int ECAT_ERR_SLAVES_STATE = -1003;      /**< All slaves al state != OP*/
        public const int ECAT_ERR_WORKING_COUNTER = -1004;      /**< Working counter*/
        public const int ECAT_ERR_SLAVE_CNT_EXCEEDED = -1005;      /**< Slave count exceed maximum support count*/
        public const int ECAT_ERR_CREATE_DOMAIN = -1006;      /**< Create domain*/
        public const int ECAT_ERR_ALLOCATE_SLAVE_DATA = -1007;      /**< Allocate slave data*/
        public const int ECAT_ERR_CONFIG_SLAVE = -1008;      /**< Configure slave*/
        public const int ECAT_ERR_NETWORK_MISMATCH = -1009;      /**< Network configuration mismatch*/
        public const int ECAT_ERR_MASTER_ACTIVATE = -1010;      /**< Master activate*/
        public const int ECAT_ERR_GET_PROCESS_DATA = -1011;      /**< Get ProcessData*/
        public const int ECAT_ERR_CONFIG_CYCLIC_TASK = -1012;      /**< Configure cyclic task*/
        public const int ECAT_ERR_RUN_CYCLIC_TASK = -1013;      /**< Run cyclic task*/
        public const int ECAT_ERR_INVALID_SLAVE_TYPE = -1014;      /**< Invalid slave type. */
        public const int ECAT_ERR_SAME_SLAVE_NO = -1015;      /**< Same slave number. */
        public const int ECAT_ERR_INVALID_SLAVE_NO = -1016;      /**< Invalid slave number. */
        public const int ECAT_ERR_INVALID_PARAM = -1017;      /**< Invalid input parameter. */
        public const int ECAT_ERR_INVALID_DATA_SIZE = -1018;		/**< Invalid data size. */
        public const int ECAT_ERR_SDO_REQUEST_BUSY = -1019;		/**< Sdo request busy. */
        public const int ECAT_ERR_SDO_REQUEST_ERROR = -1020;		/**< Sdo request error. */
        public const int ECAT_ERR_ALLOCATE_PDO_QUEUE = -1021;		/**< Allocate PDO queue. */
        public const int ECAT_ERR_INVALID_OFFSET = -1022;		/**< Invalid offset. */
        public const int ECAT_ERR_INIT_MOTION = -1023;		/**< Initialize motion data*/
        public const int ECAT_ERR_GET_SLAVE_INFO = -1024;		/**< Get slave information. */
        public const int ECAT_ERR_OPEN_FILE = -1025;		/**< open file. */
        public const int ECAT_ERR_WRITE_FILE = -1026;		/**< write data to file. */
        public const int ECAT_ERR_READ_FILE = -1027;		/**< read data from file. */
        public const int ECAT_ERR_FUNC_NOT_SUPPORT = -1028;		/**< Function not support. */
        public const int ECAT_ERR_INVALID_CHANNEL = -1029;		/**< Invalid channel. */
        public const int ECAT_ERR_EMG_HAPPENED = -1030;		/**< EMG happened. */
        public const int ECAT_ERR_INVALID_PID_NO = -1031;   	/**< Invalid PID number. */
        public const int ECAT_ERR_TIMER_NOT_ACTIVATED = -1032;      /**< Timer not activated. */
        public const int ECAT_ERR_ALL_EVENT_CREATE = -1033;      /**< All events are created. */
        public const int ECAT_ERR_EVENT_NOT_CREATE = -1034;      /**< EventID is not created. */
        public const int ECAT_ERR_INVALID_EVENTID = -1035;   	/**< Invalid EventID. */
        public const int ECAT_ERR_INVALID_FILTER_TYPE = -1036;   	/**< Invalid filter type. */
        public const int ECAT_ERR_SLAVES_ALIAS = -1037;		/**< repeating alias or alias == 0*/
        public const int ECAT_ERR_SLAVES_ALIAS_NOT_EXIST = -1038;		/**< alias is not exist*/
        public const int ECAT_ERR_OPTASK = -1039;		/**< start op task*/
        public const int ECAT_ERR_MC_NOT_ENABLE_DC = -1100;   	/**< Slave not enable dc. */
        public const int ECAT_ERR_MC_TIME_OUT = -1101;   	/**< Motion control timeout. */
        public const int ECAT_ERR_MC_AXIS_CNT_EXCEEDED = -1102;		/**< axis count exceed maximum support count. */
        public const int ECAT_ERR_MC_NOT_INITIALIZED = -1103;		/**< Motion not initialized. */
        public const int ECAT_ERR_MC_INVALID_AXIS_NO = -1104;  	/**< Invalid axis number. */
        public const int ECAT_ERR_MC_NOT_AXIS_SERVO_ON = -1105;   	/**< The axis's servo is not on.*/
        public const int ECAT_ERR_MC_INVALID_AXIS_STATE = -1106;   	/**< Invalid axis state. */
        public const int ECAT_ERR_MC_DRIVE_FAULT = -1107;   	/**< Drive fault occurred. */
        public const int ECAT_ERR_MC_DRIVE_WARNING = -1108;   	/**< Drive warning occurred. */
        public const int ECAT_ERR_MC_INVALID_PARAM = -1109;		/**< Invalid input parameter. */
        public const int ECAT_ERR_MC_HOMING = -1110;		/**< Homing error. */
        public const int ECAT_ERR_MC_LIMIT_ACTIVE = -1111;		/**< Limit active. */
        public const int ECAT_ERR_MC_INVALID_ACC_TIME = -1112;		/**< Invalid Acc Time. */
        public const int ECAT_ERR_MC_INVALID_GROUP_NO = -1113;  	/**< Invalid group number. */
        public const int ECAT_ERR_MC_INVALID_GROUP_STATE = -1114;   	/**< Invalid group state. */
        public const int ECAT_ERR_MC_AXIS_WAS_IN_GROUP = -1115;   	/**< Axis was in group. */
        public const int ECAT_ERR_MC_AXIS_IN_OTHER_GROUP = -1116;   	/**< Axis in other group. */
        public const int ECAT_ERR_MC_GROUP_CMD_ALLOCATE = -1117;   	/**< Allocate group command. */
        public const int ECAT_ERR_MC_GROUP_CMD_BUFFER_OVERFLOW = -1118;   	/**< group command buffer overflow. */
        public const int ECAT_ERR_MC_INVALID_AXIS_SYNC_MODE = -1119;   	/**< Invalid axis synchronization mode. */
        public const int ECAT_ERR_MC_INVALID_PROFILE_NO = -1120;   	/**< Invalid profile number. */
        public const int ECAT_ERR_MC_INVALID_GROUP_MOVE_CMD = -1121;   	/**< Invalid group move command. */
        public const int ECAT_ERR_MC_GROUP_CMD_MODE_NOT_SUPPORT = -1122;		/**< Group command mode not support. */
        public const int ECAT_ERR_MC_INVALID_ACC_DEC_TYPE = -1123;		/**< Invalid Acc Dec Type. */
        public const int ECAT_ERR_MC_INVALID_VEL = -1124;		/**< Invalid input velocity. */
        public const int ECAT_ERR_MC_INVALID_ANGLE = -1125;		/**< Invalid input angle. */
        public const int ECAT_ERR_MC_INVALID_RADIUS = -1126;		/**< Invalid input radius. */
        public const int ECAT_ERR_MC_INVALID_END_POS = -1127;		/**< Invalid input end position. */
        public const int ECAT_ERR_MC_INVALID_ECAM_TABLE_NO = -1128;   	/**< Invalid table number. */
        public const int ECAT_ERR_MC_INVALID_NORMAL_VECTOR = -1129;   	/**< Invalid normal vector. */
        public const int ECAT_ERR_MC_NOT_SETUP = -1130;   	/**< stewart platform not setup */
        public const int ECAT_ERR_MC_GREATER_THAN_MAX_RODLENGTH = -1131;   	/**< stewart platform not setup */
        public const int ECAT_ERR_MC_LESS_THAN_RODLENGTH = -1132;   	/**< stewart platform not setup */
        public const int ECAT_ERR_MC_GREATER_THAN_RECORD_COUNT = -1133;      /**< stewart platform not setup */
        public const int ECAT_ERR_MC_SOFTWARE_LIMIT_ACTIVE = -1134;		/**< Position Software Limit active. */
        public const int ECAT_ERR_MC_GANTRY_POS_EXCESSIVE_DEVIATION = -1135;	/**< Gantry Position deviation greater than set value. */
        public const int ECAT_ERR_MC_GROUP_NO_NOT_SUPPORT = -1136;		/**< Group number not support. */
        public const int ECAT_ERR_MC_INVALID_MOVE_CMD = -1137;   	/**< Invalid move command. */
        public const int ECAT_ERR_MC_QUEUE_IS_FULL = -1138;   	/**< Queue is full. */
        public const int ECAT_ERR_MC_COORDINATE_TRANS_ON = -1139;   	/**< Coordinate transform is on */
        public const int ECAT_ERR_IPC_INVALID_DEVICE_NO = -1201;		/**< Invalid device No. */
        public const int ECAT_ERR_IPC_DEVICE_IS_OPEN = -1202;		/**< Device is open. */
        public const int ECAT_ERR_IPC_DEVICE_NOT_OPEN = -1203;		/**< Device not open. */
        public const int ECAT_ERR_IPC_CREATE_HANDLE = -1204;		/**< Create IPC handle object. */
        /**< IPC busy. */
        public const int ECAT_ERR_IPC_BUSY = -1205;

        /// <summary>
        /// 與核心內部進行通訊時通訊逾時，請 1 分鐘後再嘗試。
        /// 若一直發生該問題，請確認 EcatUtility 應用程式是否可以使用。
        /// 若無法開啟，關機後再開機可排除此問題。
        /// </summary>
        public const int ECAT_ERR_IPC_TIME_OUT = -1206;		/**< IPC time out. */
        public const int ECAT_ERR_IPC_INVALID_CMD = -1207;		/**< Invalid command No. */
        public const int ECAT_ERR_IPC_WRITE_SHM = -1208;		/**< write data to shared memory. */
        public const int ECAT_ERR_IPC_READ_SHM = -1209;		/**< read data frome shared memory. */
        public const int ECAT_ERR_IPC_RUN_DOWN_UP_LOAD = -1210;		/**< IPC Process run Download/Upload Command . */
        public const int ECAT_ERR_IPC_INVALID_SHM = -1211;		/**< Invalid shared memory. */
        public const int ECAT_ERR_IPC_DEVICE_NOT_READY = -1212;		/**< IPC not ready. */
        public const int ECAT_ERR_DRV_GET_INFO = -1301;		/**< Get driver information. */
        public const int ECAT_ERR_DRV_CREATE_HANDLE = -1302;		/**< Create driver handle object. */
        public const int ECAT_ERR_DRV_IOCTL = -1303;		/**< Driver I/O control. */
        public const int ECAT_ERR_DRV_DEVICE_NOT_FOUND = -1304;		/**< Cannot find device. */
        public const int ECAT_ERR_ST_NOT_POSITION_MODE = -1401;   	/**< Not in the position mode. */
        public const int ECAT_ERR_ST_TRIP_ALARM = -1402;   	/**< trips a alarm. */
        public const int ECAT_ERR_ST_INVALID_TABLE_NO = -1403;   	/**< Invalid Table No. */
        public const int ECAT_ERR_ST_LIB_NOT_EXIST = -1404;   	/**< wheelControl lib not exist. */
        public const int ECAT_ERR_ST_NOT_DISABLE_MODE = -1405;   	/**< Not in the disable mode. */

    }
}
