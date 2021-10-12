namespace EtherCATMaster
{
    internal static class EtherCatDef
    {
        /** Max Macro */
        public const int DEV_NETWORK_INFO_NO_MAX = 8;
        public const int MC_AXIS_NO_MAX = 64;
        public const int MC_AXIS_NO_LIMIT = 64;
        public const int MC_GROUP_NO_MAX = 8;
        public const int MC_AXIS_ADVANCE_NO_MAX = 4;
        public const int MC_GROUP_CMD_BUFFER_MAX = 7000;
        public const int MC_PROFILE_NO_MAX = 16;
        public const int MC_PROFILE_DATA_MAX = 3000;
        public const int RW_PDO_DATA_SIZE_MAX = 512;
        public const int NETWORK_SLAVE_MAX = 80;
        public const int CARD_DEVICE_NO_MAX = 16;
        public const int DEVICE_SERIAL_NO_SIZE = 8;
        public const int MOTION_DATA_MAX = 100000;
        public const int FILE_BUFFER_SIZE = 512;
        public const int PID_NO_MAX = 10;
        public const int EVENT_NO_MAX = 32;
        public const int RECORDDATA_GET_COUNT_MAX = 64;
        public const int MAX_SLAVE_NAME_LENGTH = 64;
        public const int MC_PATH_DATA_NO_MAX = 3;
        public const int MC_PATH_DATA_ARGS_MAX = 5;
        public const int PDO_BUFFER_CHANNEL_MAX = 3;
        public const int PDO_BUFFER_DATA_MAX = 128;
        public const int MC_AXIS_CMD_BUFFER_MAX = 100;
        public const int AI_FILTER_CHANNEL_MAX = 8;
        public const int PDO_INTOOUT_CHANNEL_MAX = 8;
        public const int LACK_PDOS_GET_COUNT_MAX = 16;
        public const int ENC_BUFFER_CHANNEL_MAX = 6;
        public const int ENC_BUFFER_MAX = 128;

        /*****************************************************************************/
        /** Slave Type */
        public const int SLAVE_TYPE_GENERIC = 0;                /**< Generic */
        public const int SLAVE_TYPE_CiA402 = 1;                 /**< Profile No.402 */
        public const int SLAVE_TYPE_STEPPER_MOTOR = 2;          /**< ICPDAS 1 Axis Stepper Motor*/
        public const int SLAVE_TYPE_4_AXIS_STEPPER_MOTOR = 3;   /**< ICPDAS 4 Axis Stepper Motor*/
        public const int SLAVE_TYPE_2610 = 4;                   /**< ICPDAS Modbus To Ethercat*/

        /*****************************************************************************/
        /** Slave AO range code */
        public const int SLAVE_AO_UNI_5V = 0;       /**< Unipolar 5V (0-5V)*/
        public const int SLAVE_AO_BI_5V = 1;        /**< Bipolar 5V (+-5V) */
        public const int SLAVE_AO_UNI_10V = 2;      /**< Unipolar 10V (0-10V)*/
        public const int SLAVE_AO_BI_10V = 3;       /**< Bipolar 10V (+-10V)*/

        /*****************************************************************************/
        /** Slave AI range code */
        public const int SLAVE_AI_BI_10V = 0;           /**< Bipolar 10V (+-10V)*/
        public const int SLAVE_AI_BI_5V = 1;            /**< Bipolar 5V (+-5V) */
        public const int SLAVE_AI_BI_2_5V = 2;          /**< Bipolar 2.5V (+-2.5V) */
        public const int SLAVE_AI_UNI_10V = 3;          /**< Unipolar 10V (0-10V)*/
        public const int SLAVE_AI_UNI_20mA = 4;         /**< Unipolar 20mA (0-20mA) */
        public const int SLAVE_AI_UNI_4_20mA = 5;       /**< Unipolar 4-20mA(4-20mA)*/
        public const int SLAVE_AI_BI_20mA = 6;          /**< Bipolar 20mA(+-20mA)*/
        public const int SLAVE_AI_BI_4_20mA = 7;        /**< Bipolar 4-20mA(+-4-20mA)*/
        public const int SLAVE_AI_BI_10V_UNI_20mA = 8;  /**< ch0~3 Bipolar 10V (+-10V) ch4~7 Unipolar 20mA (0-20mA)*/
        public const int SLAVE_AI_BI_10V_UNI_4_20mA = 9;/**< ch0~3 Bipolar 10V (+-10V) ch4~7 Unipolar 4-20mA(4-20mA)*/
        public const int SLAVE_AI_BI_10V_BI_20mA = 10;  /**< ch0~3 Bipolar 10V (+-10V) ch4~7 Bipolar 20mA(+-20mA)*/
        public const int SLAVE_AI_BI_10V_BI_4_20mA = 11;/**< ch0~3 Bipolar 10V (+-10V) ch4~7 Bipolar 4-20mA(+-4-20mA)*/

        /*****************************************************************************/
        /** EtherCAT AL State */
        /** EtherCAT AL狀態 */
        /// <summary>
        /// Init狀態。
        /// </summary>
        public const int ECAT_AS_INIT = 0x00;
        /// <summary>
        /// Pre-Operational狀態。
        /// </summary>
        public const int ECAT_AS_PREOP = 0x02;
        /// <summary>
        /// Safe-Operational狀態。
        /// </summary>
        public const int ECAT_AS_SAFEOP = 0x04;
        /// <summary>
        /// Operational狀態。
        /// </summary>
        public const int ECAT_AS_OP = 0x08;

        /*****************************************************************************/
        /** Device OP task cycle time */
        /** 從站通訊週期編號 */
        public const int DEV_OP_CYCLE_TIME_1MS = 0;     /**< 1 ms */
        public const int DEV_OP_CYCLE_TIME_2MS = 1;     /**< 2 ms */
        public const int DEV_OP_CYCLE_TIME_3MS = 2;     /**< 3 ms */
        public const int DEV_OP_CYCLE_TIME_4MS = 3;     /**< 4 ms */
        public const int DEV_OP_CYCLE_TIME_5MS = 4;     /**< 5 ms */
        public const int DEV_OP_CYCLE_TIME_6MS = 5;     /**< 6 ms */
        public const int DEV_OP_CYCLE_TIME_7MS = 6;     /**< 7 ms */
        public const int DEV_OP_CYCLE_TIME_8MS = 7;     /**< 8 ms */
        public const int DEV_OP_CYCLE_TIME_9MS = 8;     /**< 9 ms */
        public const int DEV_OP_CYCLE_TIME_10MS = 9;    /**< 10 ms */
        public const int DEV_OP_CYCLE_TIME_11MS = 10;   /**< 11 ms */
        public const int DEV_OP_CYCLE_TIME_12MS = 11;   /**< 12 ms */
        public const int DEV_OP_CYCLE_TIME_13MS = 12;   /**< 13 ms */
        public const int DEV_OP_CYCLE_TIME_14MS = 13;   /**< 14 ms */
        public const int DEV_OP_CYCLE_TIME_15MS = 14;   /**< 15 ms */
        public const int DEV_OP_CYCLE_TIME_16MS = 15;   /**< 16 ms */

        /*****************************************************************************/
        /** Motion Control Group command mode */
        public const int MS_GRP_CM_ABORTING = 0;
        public const int MS_GRP_CM_BUFFERED = 1;
        public const int MS_GRP_CM_BLENDING = 2;

        /*****************************************************************************/
        /**  Motion Control Axis Synchronization source */
        public const int MC_AXIS_SYNC_SOURCE_SET_VALUE = 0;
        public const int MC_AXIS_SYNC_SOURCE_ACTUAL_VALUE = 1;

        /*****************************************************************************/
        /** Motion Control Axis State */
        /** 軸狀態編號 */
        /// <summary>
        /// 軸尚未啟用。
        /// </summary>
        public const int MC_AS_DISABLED = 0;
        /// <summary>
        /// 軸啟用且為停止狀態，準備接收新的運動命令。
        /// </summary>
        public const int MC_AS_STANDSTILL = 1;
        /// <summary>
        /// 軸目前出現錯誤且為停止狀態。
        /// </summary>
        public const int MC_AS_ERRORSTOP = 2;
        /// <summary>
        /// 軸目前在停止運動中。
        /// </summary>
        public const int MC_AS_STOPPING = 3;
        /// <summary>
        /// 軸目前在原點復歸中。
        /// </summary>
        public const int MC_AS_HOMING = 4;
        /// <summary>
        /// 軸目前單軸運動中。
        /// </summary>
        public const int MC_AS_DISCRETEMOTION = 5;
        /// <summary>
        /// 軸目前連續運動中。
        /// </summary>
        public const int MC_AS_CONTINUOUSMOTION = 6;
        /// <summary>
        /// 軸目前同步運動中，軸在群組中，群組正在進行補間運動。
        /// </summary>
        public const int MC_AS_SYNCHRONIZEDMOTION = 7;
        /// <summary>
        /// 方向盤運動中(?)。
        /// </summary>
        public const int MC_AS_STEERWHEELMOTION = 8;

        /*****************************************************************************/
        /** Motion Control Axis State */
        public const int MC_AS_CONSTANT_VEL = 0;
        public const int MC_AS_ACC = 1;
        public const int MC_AS_DEC = 2;

        /*****************************************************************************/
        /** Motion Control Motion State */
        public const int MC_MS_CONSTANT_VEL = 0;
        public const int MC_MS_ACC = 1;
        public const int MC_MS_DEC = 2;

        /*****************************************************************************/
        /** Motion Control Group State */
        public const int MC_GS_DISABLED = 0;
        public const int MC_GS_STANDBY = 1;
        public const int MC_GS_ERRORSTOP = 2;
        public const int MC_GS_STOPPING = 3;
        public const int MC_GS_HOMING = 4;
        public const int MC_GS_MOVING = 5;
        public const int MC_GS_HOLD = 6;
        public const int MC_GS_PAUSE = 7;

        /*****************************************************************************/
        /** Device Encoder Mode */
        public const int DEV_ENC_MODE_CW_CCW = 1;
        public const int DEV_ENC_MODE_PLS_DIR = 2;
        public const int DEV_ENC_MODE_AB_PHASE = 3;

        /*****************************************************************************/
        /** Device Encoder Low Pass Filter */
        public const int DEV_ENC_LPF_4_MHZ = 0;
        public const int DEV_ENC_LPF_3P6_MHZ = 1;
        public const int DEV_ENC_LPF_1P8_MHZ = 2;
        public const int DEV_ENC_LPF_950_KHZ = 4;
        public const int DEV_ENC_LPF_480_KHZ = 8;
        public const int DEV_ENC_LPF_240_KHZ = 16;
        public const int DEV_ENC_LPF_120_KHZ = 32;
        public const int DEV_ENC_LPF_60_KHZ = 64;
        public const int DEV_ENC_LPF_30_KHZ = 128;

        /*****************************************************************************/
        /** Device emergency source */
        public const int DEV_EMG_SOURCE_OB_DI = 0;      /**< On board DI */
        public const int DEV_EMG_SOURCE_SLAVE_DI = 1;   /**< Slave DI */

        /*****************************************************************************/
        /** Motion record parameters */
        public const int MC_RECORD_POSITION = 0;
        public const int MC_RECORD_VELOCITY = 1;
        public const int MC_RECORD_COMMAND_POSITION = 2;
        public const int MC_RECORD_COMMAND_VELOCITY = 3;

        /*****************************************************************************/
        /** Event Type */
        public const int EV_COMPARE_POSITION = 1;
        public const int EV_DIBIT_CHANGE = 2;
        public const int EV_MOTION_CPMPLETE = 3;
        public const int EV_DI_CHANGE = 4;
        public const int EV_MOTION_STATUS = 5;
        public const int EV_COMPARE_AI = 6;

        /*****************************************************************************/
        /** Comparison Operators */
        public const int GREATER_THAN = 0;
        public const int GREATER_THAN_OR_EQUAL_TO = 1;
        public const int LESS_THAN = 2;
        public const int LESS_THAN_OR_EQUAL_TO = 3;

        /*****************************************************************************/
        /** Home Settings */
        public const int MC_AS_HOME_SPEED_SW = 1;
        public const int MC_AS_HOME_SPEED_ZR = 2;
        public const int MC_AS_HOME_ACC = 4;
        public const int MC_AS_HOME_OFFSET = 8;

        /*****************************************************************************/
        /** Path command type */
        public const int MC_PATH_CMD_TYPE_MOVE_LINE = 1;
        public const int MC_PATH_CMD_TYPE_MOVE_CIRC_CP_ANGLE = 2;
        public const int MC_PATH_CMD_TYPE_MOVE_CIRC_CP_EP = 3;
        public const int MC_PATH_CMD_TYPE_MOVE_CIRC_BP_EP = 4;
        public const int MC_PATH_CMD_TYPE_MOVE_3D_CIRC_CP_ANGLE = 5;
        public const int MC_PATH_CMD_TYPE_MOVE_3D_CIRC_CP_EP = 6;
        public const int MC_PATH_CMD_TYPE_MOVE_3D_CIRC_BP_EP = 7;
        public const int MC_PATH_CMD_TYPE_MOVE_HELICAL = 8;
        public const int MC_PATH_CMD_TYPE_MOVE_3D_HELICAL = 9;
        public const int MC_PATH_CMD_TYPE_MOVE_CONICAL_HELIX = 10;
        public const int MC_PATH_CMD_TYPE_MOVE_3D_CONICAL_HELIX = 11;
        public const int MC_PATH_CMD_TYPE_SET_ACCDEC_TIME = 12;
        public const int MC_PATH_CMD_TYPE_SET_ACCDEC_TYPE = 13;
        public const int MC_PATH_CMD_TYPE_SET_CMD_MODE = 14;
        public const int MC_PATH_CMD_TYPE_SET_BLEND_PERCENT = 15;
        public const int MC_PATH_CMD_TYPE_DWELL = 16;
        public const int MC_PATH_CMD_TYPE_SET_DO = 17;
        public const int MC_PATH_CMD_TYPE_SET_AO_VOLT = 18;

        /*****************************************************************************/
        /** Acceleration deceleration mode */
        public const int MC_ACC_DEC_MODE_RATE = 0;
        public const int MC_ACC_DEC_MODE_TIME = 1;

        /*****************************************************************************/
        /** Filter type */
        public const int FILTER_NOTCH = 1;
        public const int FILTER_LOW_PASS = 2;
        public const int FILTER_HIGH_PASS = 4;

        /*****************************************************************************/
        /** Slave No Type  */
        public const int SLAVE_NO_TYPE_POSITION = 0;
        public const int SLAVE_NO_TYPE_ALIAS = 1;

        /*****************************************************************************/
        /** Group interpolation Type */
        public const int MC_DEFAULT_INTERPOLATION = 0;
        public const int MC_POLAR_INTERPOLATION = 1;

        /*****************************************************************************/
        /** Slave Register read type */
        public const int REGISTER_TYPE_ERR = 0;
        public const int REGISTER_TYPE_FWD_CRC_ERR = 1;
        public const int REGISTER_TYPE_LOST_LINK = 2;
    }
}
