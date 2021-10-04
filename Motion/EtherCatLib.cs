using System.Runtime.InteropServices;
using System.Text;

namespace Motion
{
    internal class EtherCatLib
    {
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDllVersion")]
        public static extern int ECAT_GetDllVersion(StringBuilder Version, ref ushort Size);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetFirmwareVersion")]
        public static extern int ECAT_GetFirmwareVersion(ushort DeviceNo, StringBuilder Version, ref ushort Size);

        /// <summary>
        /// 取得目前可使用裝置(ECAT-M801/ e-M901)數量。
        /// </summary>
        /// <param name="DeviceCnt">可使用裝置數量。</param>
        /// <param name="CardID">各裝置的 Card ID (卡號)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceCnt")]
        public static extern int ECAT_GetDeviceCnt(ref ushort DeviceCnt, byte[] CardID);

        /// <summary>
        /// 開啟指定裝置編號(卡號)來做通訊操作。
        /// </summary>
        /// <param name="DeviceNo">裝置編號(卡號)</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_OpenDevice")]
        public static extern int ECAT_OpenDevice(ushort DeviceNo);

        /// <summary>
        /// 關閉指定裝置編號(卡號)的通訊操作。
        /// </summary>
        /// <param name="DeviceNo">裝置編號(卡號)</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_CloseDevice")]
        public static extern int ECAT_CloseDevice(ushort DeviceNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceSerialNo")]
        public static extern int ECAT_GetDeviceSerialNo(ushort DeviceNo, byte[] SerialNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceDI")]
        public static extern int ECAT_GetDeviceDI(ushort DeviceNo, ref uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceDIBit")]
        public static extern int ECAT_GetDeviceDIBit(ushort DeviceNo, ushort BitNo, ref uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceDO")]
        public static extern int ECAT_GetDeviceDO(ushort DeviceNo, ref uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceDOBit")]
        public static extern int ECAT_GetDeviceDOBit(ushort DeviceNo, ushort BitNo, ref uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceDO")]
        public static extern int ECAT_SetDeviceDO(ushort DeviceNo, uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceDOBit")]
        public static extern int ECAT_SetDeviceDOBit(ushort DeviceNo, ushort BitNo, uint Value);

        /// <summary>
        /// 取得指定裝置編號 EtherCAT 網絡狀態。
        /// </summary>
        /// <param name="DeviceNo">裝置編號 (卡號)</param>
        /// <param name="LinkUp">顯示乙太網路孔連接狀態，0: 主站無連接任何從站，1: 主站已連接任何從站。</param>
        /// <param name="SlavesResp">顯示目前已連接從站數量。</param>
        /// <param name="AlStates">顯示目前整個網絡 Slave EtherCAT 狀態。</param>
        /// <param name="Wc">顯示 EtherCAT 工作計數器數值(Working Counter)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceState")]
        public static extern int ECAT_GetDeviceState(ushort DeviceNo, ref uint LinkUp, ref uint SlavesResp, ref uint AlStates, ref uint Wc);

        /// <summary>
        /// 取得從站模組相關資訊。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="SlaveNo">從站編號。</param>
        /// <param name="Alias">從站 Alias 數值。</param>
        /// <param name="ProductCode">從站 Product Code 數值。</param>
        /// <param name="VendorID">從站 Vendor ID 數值。</param>
        /// <param name="RevisionNo">從站 Revision No 數值。</param>
        /// <param name="SerialNo">從站 Serial No 數值。</param>
        /// <param name="AlState">從站 EtherCAT 狀態。</param>
        /// <param name="SlaveType">從站種類，若尚未開始 EtherCAT 操作任務時此值永遠為 0。</param>
        /// <param name="SlaveName">從站名稱。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveInfo")]
        public static extern int ECAT_GetSlaveInfo(ushort DeviceNo, ushort SlaveNo, ref ushort Alias, ref uint ProductCode, ref uint VendorID,
        ref uint RevisionNo, ref uint SerialNo, ref byte AlState, ref uint SlaveType, StringBuilder SlaveName);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_UploadNetworkInfo")]
        public static extern int ECAT_UploadNetworkInfo(ushort DeviceNo, ushort NetworkInfoNo, uint Offset, string Data, uint DataSize, byte LastFlag);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_UploadFirmware")]
        public static extern int ECAT_UploadFirmware(ushort DeviceNo, uint Offset, string Data, uint DataSize, byte LastFlag);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_DownloadNetworkInfo")]
        public static extern int ECAT_DownloadNetworkInfo(ushort DeviceNo, ushort NetworkInfoNo, ref uint Offset, StringBuilder Data, ref uint DataSize, ref byte LastFlag);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveSdoObject")]
        public static extern int ECAT_GetSlaveSdoObject(ushort DeviceNo, ushort SlaveNo, ushort Index, byte SubIndex, ushort DataSize, ref uint ObjectVal, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveSdoObject")]
        public static extern int ECAT_SetSlaveSdoObject(ushort DeviceNo, ushort SlaveNo, ushort Index, byte SubIndex, ushort DataSize, uint ObjectVal, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SlaveNonBlockSdoRequestRead")]
        public static extern int ECAT_SlaveNonBlockSdoRequestRead(ushort DeviceNo, ushort SlaveNo, ushort Index, byte SubIndex, uint Timeout_ms);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SlaveNonBlockSdoRequestReadState")]
        public static extern int ECAT_SlaveNonBlockSdoRequestReadState(ushort DeviceNo, ushort SlaveNo, ushort DataSize, ref uint ObjectVal);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SlaveNonBlockSdoRequestWrite")]
        public static extern int ECAT_SlaveNonBlockSdoRequestWrite(ushort DeviceNo, ushort SlaveNo, ushort Index, byte SubIndex, ushort DataSize, uint ObjectVal, uint Timeout_ms);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SlaveNonBlockSdoRequestWriteState")]
        public static extern int ECAT_SlaveNonBlockSdoRequestWriteState(ushort DeviceNo, ushort SlaveNo, ushort DataSize);

        /// <summary>
        /// 開始指定裝置編號 EtherCAT 操作任務。
        /// </summary>
        /// <param name="DeviceNo">裝置編號 (卡號)。</param>
        /// <param name="NetworkInfoNo">網絡架構編號 (由 Utility 建立並寫入的網路資訊檔案編號)。</param>
        /// <param name="EnumCycleTime">EtherCAT 通訊週期編號。</param>
        /// <param name="WcErrCnt">設定裝置網絡狀態出錯時，裝置可容許連續出錯次數，當發生次數到達設定值時才發出錯誤告知使用者端。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_StartDeviceOpTask")]
        public static extern int ECAT_StartDeviceOpTask(ushort DeviceNo, ushort NetworkInfoNo, byte EnumCycleTime, uint WcErrCnt);

        /// <summary>
        /// 停止指定裝置編號 EtherCAT 操作任務。
        /// </summary>
        /// <param name="DeviceNo">指定裝置編號。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_StopDeviceOpTask")]
        public static extern int ECAT_StopDeviceOpTask(ushort DeviceNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveRxPdoData")]
        public static extern int ECAT_SetSlaveRxPdoData(ushort DeviceNo, ushort SlaveNo, ushort OffsetByte, ushort DataSize, ref byte Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveRxPdoData")]
        public static extern int ECAT_GetSlaveRxPdoData(ushort DeviceNo, ushort SlaveNo, ushort OffsetByte, ushort DataSize, ref byte Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveRxPdoOffset")]
        public static extern int ECAT_GetSlaveRxPdoOffset(ushort DeviceNo, ushort SlaveNo, byte channel, ref ushort OffsetByte);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveRxPdoChannel")]
        public static extern int ECAT_GetSlaveRxPdoChannel(ushort DeviceNo, ushort SlaveNo, ref byte channel, ref byte bitsize);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveTxPdoData")]
        public static extern int ECAT_GetSlaveTxPdoData(ushort DeviceNo, ushort SlaveNo, ushort OffsetByte, ushort DataSize, ref byte Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveTxPdoOffset")]
        public static extern int ECAT_GetSlaveTxPdoOffset(ushort DeviceNo, ushort SlaveNo, byte channel, ref ushort OffsetByte);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveTxPdoChannel")]
        public static extern int ECAT_GetSlaveTxPdoChannel(ushort DeviceNo, ushort SlaveNo, ref byte channel, ref byte bitsize);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveDI")]
        public static extern int ECAT_GetSlaveDI(ushort DeviceNo, ushort SlaveNo, ref uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveDIBit")]
        public static extern int ECAT_GetSlaveDIBit(ushort DeviceNo, ushort SlaveNo, ushort BitNo, ref uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveDO")]
        public static extern int ECAT_GetSlaveDO(ushort DeviceNo, ushort SlaveNo, ref uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveDOBit")]
        public static extern int ECAT_GetSlaveDOBit(ushort DeviceNo, ushort SlaveNo, ushort BitNo, ref uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveDO")]
        public static extern int ECAT_SetSlaveDO(ushort DeviceNo, ushort SlaveNo, uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveDOBit")]
        public static extern int ECAT_SetSlaveDOBit(ushort DeviceNo, ushort SlaveNo, ushort BitNo, uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveAoProperty")]
        public static extern int ECAT_SetSlaveAoProperty(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, byte Range);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveAoProperty")]
        public static extern int ECAT_GetSlaveAoProperty(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref byte Range);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveAoRawData")]
        public static extern int ECAT_SetSlaveAoRawData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ushort Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveAoRawData")]
        public static extern int ECAT_GetSlaveAoRawData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref ushort Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveAoVoltData")]
        public static extern int ECAT_SetSlaveAoVoltData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, double Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveAoVoltData")]
        public static extern int ECAT_GetSlaveAoVoltData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref double Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveEncProperty")]
        public static extern int ECAT_SetSlaveEncProperty(ushort DeviceNo, ushort SlaveNo, ushort EncNo, byte Mode, byte InvertCnt, byte LPF);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveEncProperty")]
        public static extern int ECAT_GetSlaveEncProperty(ushort DeviceNo, ushort SlaveNo, ushort EncNo, ref byte Mode, ref byte InvertCnt, ref byte LPF);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveEncCount")]
        public static extern int ECAT_GetSlaveEncCount(ushort DeviceNo, ushort SlaveNo, ushort EncNo, ref uint Cnt);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_ResetSlaveEncCount")]
        public static extern int ECAT_ResetSlaveEncCount(ushort DeviceNo, ushort SlaveNo, ushort EncNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveEncLatch")]
        public static extern int ECAT_SetSlaveEncLatch(ushort DeviceNo, ushort SlaveNo, ushort EncNo, byte Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveEncLatch")]
        public static extern int ECAT_GetSlaveEncLatch(ushort DeviceNo, ushort SlaveNo, ushort EncNo, ref byte Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveEncLatchCnt")]
        public static extern int ECAT_GetSlaveEncLatchCnt(ushort DeviceNo, ushort SlaveNo, ushort EncNo, ref uint Cnt);

        /// <summary>
        /// 初始化運動控制軸數，並配置軸號對應的從站編號。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="SlaveNo">從站編號陣列，陣列的索引編號即為對應的軸號。</param>
        /// <param name="SubAxisNo">從站驅動器子軸號。</param>
        /// <param name="AxisCount">初始化軸數(最大可初始化軸數定義於標頭檔名稱 MC_AXIS_NO_MAX)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McInit")]
        public static extern int ECAT_McInit(ushort DeviceNo, ushort[] SlaveNo, ushort[] SubAxisNo, ushort AxisCount);

        /// <summary>
        /// 設定指定軸號伺服啟動訊號的狀態。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="State">訊號狀態，0: OFF，1: ON。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisServoOn")]
        public static extern int ECAT_McSetAxisServoOn(ushort DeviceNo, ushort AxisNo, ushort State);

        /// <summary>
        /// 設定指定軸號 Pulse per Unit 參數。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="PPU">Pulse per Unit 參數，預設為 1 。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisPPU")]
        public static extern int ECAT_McSetAxisPPU(ushort DeviceNo, ushort AxisNo, double PPU);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisPPU")]
        public static extern int ECAT_McGetAxisPPU(ushort DeviceNo, ushort AxisNo, ref double PPU);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisEncoderPPR")]
        public static extern int ECAT_McSetAxisEncoderPPR(ushort DeviceNo, ushort AxisNo, uint PPR);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisEncoderPPR")]
        public static extern int ECAT_McGetAxisEncoderPPR(ushort DeviceNo, ushort AxisNo, ref uint PPR);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisMotorPPR")]
        public static extern int ECAT_McSetAxisMotorPPR(ushort DeviceNo, ushort AxisNo, uint PPR);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisMotorPPR")]
        public static extern int ECAT_McGetAxisMotorPPR(ushort DeviceNo, ushort AxisNo, ref uint PPR);

        /// <summary>
        /// 設定自動原點復歸的模式。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Method">原點復歸模式，請查閱伺服馬達文件資料確認模式是否支援。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisHomeMethod")]
        public static extern int ECAT_McSetAxisHomeMethod(ushort DeviceNo, ushort AxisNo, int Method);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisHomeMethod")]
        public static extern int ECAT_McGetAxisHomeMethod(ushort DeviceNo, ushort AxisNo, ref int Method);

        /// <summary>
        /// 設定執行自動原點復歸時使用的速度。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="SeachSw">尋找原點(ORG)訊號時使用的速度，(單位: user unit/s)。</param>
        /// <param name="SeachZr">尋找馬達索引(EZ)訊號時使用的速度，(單位: user unit/s)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisHomeSpeed")]
        public static extern int ECAT_McSetAxisHomeSpeed(ushort DeviceNo, ushort AxisNo, double SeachSw, double SeachZr);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisHomeSpeed")]
        public static extern int ECAT_McGetAxisHomeSpeed(ushort DeviceNo, ushort AxisNo, ref double SeachSw, ref double SeachZr);

        /// <summary>
        /// 設定執行自動原點復歸時使用的加速度。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Acc">執行自動原點復歸時使用的加速度，(單位: user unit/s^2)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisHomeAcc")]
        public static extern int ECAT_McSetAxisHomeAcc(ushort DeviceNo, ushort AxisNo, double Acc);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisHomeAcc")]
        public static extern int ECAT_McGetAxisHomeAcc(ushort DeviceNo, ushort AxisNo, ref double Acc);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisHomeOffset")]
        public static extern int ECAT_McSetAxisHomeOffset(ushort DeviceNo, ushort AxisNo, double Offset);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisHomeOffset")]
        public static extern int ECAT_McGetAxisHomeOffset(ushort DeviceNo, ushort AxisNo, ref double Offset);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisAccTime")]
        public static extern int ECAT_McSetAxisAccTime(ushort DeviceNo, ushort AxisNo, ushort Time_ms);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisAccTime")]
        public static extern int ECAT_McGetAxisAccTime(ushort DeviceNo, ushort AxisNo, ref ushort Time_ms);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisAccDecType")]
        public static extern int ECAT_McSetAxisAccDecType(ushort DeviceNo, ushort AxisNo, ushort Type);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisAccDecType")]
        public static extern int ECAT_McGetAxisAccDecType(ushort DeviceNo, ushort AxisNo, ref ushort Type);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetVirtualAxisEncoder")]
        public static extern int ECAT_McSetVirtualAxisEncoder(ushort DeviceNo, ushort AxisNo, ushort SlaveNo, ushort EncNo, byte Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetVirtualAxisEncoder")]
        public static extern int ECAT_McGetVirtualAxisEncoder(ushort DeviceNo, ushort AxisNo, ref ushort SlaveNo, ref ushort EncNo, ref byte Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisTouchProbeProperty")]
        public static extern int ECAT_McSetAxisTouchProbeProperty(ushort DeviceNo, ushort AxisNo, ushort ProbeNo, byte Enable, byte Logic);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisTouchProbeProperty")]
        public static extern int ECAT_McGetAxisTouchProbeProperty(ushort DeviceNo, ushort AxisNo, ushort ProbeNo, ref byte Enable, ref byte Logic);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisTouchProbeValue")]
        public static extern int ECAT_McGetAxisTouchProbeValue(ushort DeviceNo, ushort AxisNo, ushort ProbeNo, ref double Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisAbortingMode")]
        public static extern int ECAT_McSetAxisAbortingMode(ushort DeviceNo, ushort AxisNo, uint Enable);

        /// <summary>
        /// 取得指定軸號當前狀態。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="State">取得指定軸號當前狀態編號。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisState")]
        public static extern int ECAT_McGetAxisState(ushort DeviceNo, ushort AxisNo, ref uint State);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisMotionState")]
        public static extern int ECAT_McGetAxisMotionState(ushort DeviceNo, ushort AxisNo, ref uint State);

        /// <summary>
        /// 取得指定軸號最後出錯代碼。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Error">指定軸號最後出錯代碼。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisLastError")]
        public static extern int ECAT_McGetAxisLastError(ushort DeviceNo, ushort AxisNo, ref int Error);

        /// <summary>
        /// 取得指定軸號驅動器出錯代碼。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Error">指定軸號驅動器出錯代碼，(請根據驅動器使用手冊尋找相關錯誤代碼說明)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisDriveError")]
        public static extern int ECAT_McGetAxisDriveError(ushort DeviceNo, ushort AxisNo, ref ushort Error);

        /// <summary>
        /// 取得指定軸號命令位置，將 AxisNo 設為 65535 時，可以一次取得所有軸的命令位置。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Pos">指定軸號命令位置(單位:user unit)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisCommandPos")]
        public static extern int ECAT_McGetAxisCommandPos(ushort DeviceNo, ushort AxisNo, ref double Pos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisActualPos_Directly")]
        public static extern int ECAT_McGetAxisActualPos_Directly(ushort DeviceNo, ushort AxisNo, ref double Pos);

        /// <summary>
        /// 取得指定軸號當前位置。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Pos">指定軸號當前位置(單位:user unit)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisActualPos")]
        public static extern int ECAT_McGetAxisActualPos(ushort DeviceNo, ushort AxisNo, ref double Pos);

        /// <summary>
        /// 取得指定軸號當前速度。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Vel">取得指定軸號當前速度(單位: user unit/s)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisActualVel")]
        public static extern int ECAT_McGetAxisActualVel(ushort DeviceNo, ushort AxisNo, ref double Vel);

        /// <summary>
        /// 取得指定軸號運動控制相關 I/O 訊號狀態。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="DI">軸 I/O 訊號狀態，位元若為 0:表示對應的訊號狀態為 OFF，位元若為 1:表示對應的訊號狀態為 ON。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisDI")]
        public static extern int ECAT_McGetAxisDI(ushort DeviceNo, ushort AxisNo, ref uint DI);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetProfileData")]
        public static extern int ECAT_McSetProfileData(ushort DeviceNo, ushort ProfileNo, ref double Data, ushort DataSize);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetProfileData")]
        public static extern int ECAT_McGetProfileData(ushort DeviceNo, ushort ProfileNo, ref double Data, ushort DataSize);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetProfileCSV")]
        public static extern int ECAT_McSetProfileCSV(ushort DeviceNo, ushort ProfileNo, uint Offset, string Data, uint DataSize, byte LastFlag);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetProfileCSV")]
        public static extern int ECAT_McGetProfileCSV(ushort DeviceNo, ushort ProfileNo, ref uint Offset, StringBuilder Data, ref uint DataSize, ref byte LastFlag);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetEcamTable")]
        public static extern int ECAT_McSetEcamTable(ushort DeviceNo, ushort TableNo, ref double Data, ushort DataSize);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetEcamTable")]
        public static extern int ECAT_McGetEcamTable(ushort DeviceNo, ushort TableNo, ref double Data, ushort DataSize);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McConfigEcamTable")]
        public static extern int ECAT_McConfigEcamTable(ushort DeviceNo, ushort TableNo, byte SlaveAbs);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisHome")]
        public static extern int ECAT_McAxisHome(ushort DeviceNo, ushort AxisNo);

        /// <summary>
        /// 重置指定軸號的錯誤狀態，異常發生時軸將切換至錯誤狀態，請在異常排除後執行此函式重置軸的狀態。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisErrorReset")]
        public static extern int ECAT_McAxisErrorReset(ushort DeviceNo, ushort AxisNo);

        /// <summary>
        /// 停止指定軸號單軸運動控制，執行此命令將減速後停止運動。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisStop")]
        public static extern int ECAT_McAxisStop(ushort DeviceNo, ushort AxisNo);

        /// <summary>
        /// 停止指定軸號單軸運動控制，執行此命令將立即停止運動。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisQuickStop")]
        public static extern int ECAT_McAxisQuickStop(ushort DeviceNo, ushort AxisNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisStop_RemainState")]
        public static extern int ECAT_McAxisStop_RemainState(ushort DeviceNo, ushort AxisNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisClearStopping")]
        public static extern int ECAT_McAxisClearStopping(ushort DeviceNo, ushort AxisNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisHalt")]
        public static extern int ECAT_McAxisHalt(ushort DeviceNo, ushort AxisNo);

        /// <summary>
        /// 開始執行指定軸號單軸絕對位置運動控制。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Pos">目標位置(單位: user unit)。</param>
        /// <param name="Vel">移動速度(單位: user unit/s)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveAbs")]
        public static extern int ECAT_McAxisMoveAbs(ushort DeviceNo, ushort AxisNo, double Pos, double Vel);

        /// <summary>
        /// 開始執行指定軸號單軸相對距離運動控制。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Pos">目標位置(單位: user unit)。</param>
        /// <param name="Vel">移動速度(單位: user unit/s)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveRel")]
        public static extern int ECAT_McAxisMoveRel(ushort DeviceNo, ushort AxisNo, double Pos, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisChangePos")]
        public static extern int ECAT_McAxisChangePos(ushort DeviceNo, ushort AxisNo, double Pos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisChangeVel")]
        public static extern int ECAT_McAxisChangeVel(ushort DeviceNo, ushort AxisNo, double Vel);

        /// <summary>
        /// 開始執行指定軸號單軸等速連續運動控制，此運動持續移動，直到停止指令(執行函式或硬體訊號)觸發終止運動。
        /// </summary>
        /// <param name="DeviceNo">裝置編號。</param>
        /// <param name="AxisNo">軸號。</param>
        /// <param name="Vel">移動速度(單位: user unit/s)。</param>
        /// <returns>0: 函式執行成功。其他: 請參考附錄"函式錯誤回傳代碼"說明。</returns>
        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveVel")]
        public static extern int ECAT_McAxisMoveVel(ushort DeviceNo, ushort AxisNo, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveVelByPos")]
        public static extern int ECAT_McAxisMoveVelByPos(ushort DeviceNo, ushort AxisNo, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisGearIn")]
        public static extern int ECAT_McAxisGearIn(ushort DeviceNo, ushort MasterNo, ushort SlaveNo, int RatioNum, uint RationDen, ushort SyncSource);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisGearOut")]
        public static extern int ECAT_McAxisGearOut(ushort DeviceNo, ushort SlaveNo, ushort Stop);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveProfile")]
        public static extern int ECAT_McAxisMoveProfile(ushort DeviceNo, ushort AxisNo, ushort ProfileNo, ushort TotalStep);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveProfileCSV")]
        public static extern int ECAT_McAxisMoveProfileCSV(ushort DeviceNo, ushort AxisNo, ushort ProfileNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisCamIn")]
        public static extern int ECAT_McAxisCamIn(ushort DeviceNo, ushort MasterNo, ushort SlaveNo, ushort TableNo, ushort SyncSource, double MasterInterval, double SlaveScaling);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisCamOut")]
        public static extern int ECAT_McAxisCamOut(ushort DeviceNo, ushort SlaveNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisCamPhaseShift")]
        public static extern int ECAT_McAxisCamPhaseShift(ushort DeviceNo, ushort SlaveNo, double PhaseShift);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisTangentInGroup")]
        public static extern int ECAT_McAxisTangentInGroup(ushort DeviceNo, ushort AxisNo, ushort GroupNo, double Angle, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAddAxisToGroup")]
        public static extern int ECAT_McAddAxisToGroup(ushort DeviceNo, ushort GroupNo, ushort AxisNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McRemoveAxisFromGroup")]
        public static extern int ECAT_McRemoveAxisFromGroup(ushort DeviceNo, ushort GroupNo, ushort AxisNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McUngroupAllAxes")]
        public static extern int ECAT_McUngroupAllAxes(ushort DeviceNo, ushort GroupNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupCmdMode")]
        public static extern int ECAT_McSetGroupCmdMode(ushort DeviceNo, ushort GroupNo, ushort CmdMode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetGroupCmdMode")]
        public static extern int ECAT_McGetGroupCmdMode(ushort DeviceNo, ushort GroupNo, ref ushort CmdMode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetGroupState")]
        public static extern int ECAT_McGetGroupState(ushort DeviceNo, ushort GroupNo, ref uint State);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetGroupCmdBuffer")]
        public static extern int ECAT_McGetGroupCmdBuffer(ushort DeviceNo, ushort GroupNo, ref ushort Buffer);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupAccTime")]
        public static extern int ECAT_McSetGroupAccTime(ushort DeviceNo, ushort GroupNo, ushort Time_ms);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetGroupAccTime")]
        public static extern int ECAT_McGetGroupAccTime(ushort DeviceNo, ushort GroupNo, ref ushort Time_ms);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupAccDecType")]
        public static extern int ECAT_McSetGroupAccDecType(ushort DeviceNo, ushort GroupNo, ushort Type);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetGroupAccDecType")]
        public static extern int ECAT_McGetGroupAccDecType(ushort DeviceNo, ushort GroupNo, ref ushort Type);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupStop")]
        public static extern int ECAT_McGroupStop(ushort DeviceNo, ushort GroupNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupQuickStop")]
        public static extern int ECAT_McGroupQuickStop(ushort DeviceNo, ushort GroupNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupStop_RemainState")]
        public static extern int ECAT_McGroupStop_RemainState(ushort DeviceNo, ushort GroupNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupClearStopping")]
        public static extern int ECAT_McGroupClearStopping(ushort DeviceNo, ushort GroupNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineAbs")]
        public static extern int ECAT_McGroupMoveLineAbs(ushort DeviceNo, ushort GroupNo, double[] Pos, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineAbs_PT")]
        public static extern int ECAT_McGroupMoveLineAbs_PT(ushort DeviceNo, ushort GroupNo, double[] Pos, double Time);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineAbs_PVT")]
        public static extern int ECAT_McGroupMoveLineAbs_PVT(ushort DeviceNo, ushort GroupNo, double[] Pos, double[] Vel, double Time);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineRel")]
        public static extern int ECAT_McGroupMoveLineRel(ushort DeviceNo, ushort GroupNo, double[] Pos, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineRel_PT")]
        public static extern int ECAT_McGroupMoveLineRel_PT(ushort DeviceNo, ushort GroupNo, double[] Pos, double Time);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineRel_PVT")]
        public static extern int ECAT_McGroupMoveLineRel_PVT(ushort DeviceNo, ushort GroupNo, double[] Pos, double[] Vel, double Time);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveCircularAbs")]
        public static extern int ECAT_McGroupMoveCircularAbs(ushort DeviceNo, ushort GroupNo, double Angle, double[] AuxPos, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveCircularAbs_CP_Angle")]
        public static extern int ECAT_McGroupMoveCircularAbs_CP_Angle(ushort DeviceNo, ushort GroupNo, double Vel, double Angle, double[] AuxPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveCircularAbs_CP_EP")]
        public static extern int ECAT_McGroupMoveCircularAbs_CP_EP(ushort DeviceNo, ushort GroupNo, double Vel, byte Dir, double[] AuxPos, double[] EndPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveCircularAbs_BP_EP")]
        public static extern int ECAT_McGroupMoveCircularAbs_BP_EP(ushort DeviceNo, ushort GroupNo, double Vel, byte Dir, double[] AuxPos, double[] EndPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DCircularAbs_CP_Angle")]
        public static extern int ECAT_McGroupMove3DCircularAbs_CP_Angle(ushort DeviceNo, ushort GroupNo, double Vel, double Angle, double[] AuxPos, double[] NV);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DCircularAbs_CP_EP")]
        public static extern int ECAT_McGroupMove3DCircularAbs_CP_EP(ushort DeviceNo, ushort GroupNo, double Vel, byte Dir, double[] AuxPos, double[] EndPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DCircularAbs_BP_EP")]
        public static extern int ECAT_McGroupMove3DCircularAbs_BP_EP(ushort DeviceNo, ushort GroupNo, double Vel, byte Dir, double[] AuxPos, double[] EndPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveCircularRel")]
        public static extern int ECAT_McGroupMoveCircularRel(ushort DeviceNo, ushort GroupNo, double Angle, double[] AuxPos, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveCircularRel_CP_Angle")]
        public static extern int ECAT_McGroupMoveCircularRel_CP_Angle(ushort DeviceNo, ushort GroupNo, double Vel, double Angle, double[] AuxPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveCircularRel_CP_EP")]
        public static extern int ECAT_McGroupMoveCircularRel_CP_EP(ushort DeviceNo, ushort GroupNo, double Vel, byte Dir, double[] AuxPos, double[] EndPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveCircularRel_BP_EP")]
        public static extern int ECAT_McGroupMoveCircularRel_BP_EP(ushort DeviceNo, ushort GroupNo, double Vel, byte Dir, double[] AuxPos, double[] EndPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DCircularRel_CP_Angle")]
        public static extern int ECAT_McGroupMove3DCircularRel_CP_Angle(ushort DeviceNo, ushort GroupNo, double Vel, double Angle, double[] AuxPos, double[] NV);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DCircularRel_CP_EP")]
        public static extern int ECAT_McGroupMove3DCircularRel_CP_EP(ushort DeviceNo, ushort GroupNo, double Vel, byte Dir, double[] AuxPos, double[] EndPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DCircularRel_BP_EP")]
        public static extern int ECAT_McGroupMove3DCircularRel_BP_EP(ushort DeviceNo, ushort GroupNo, double Vel, byte Dir, double[] AuxPos, double[] EndPos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveHelicalAbs")]
        public static extern int ECAT_McGroupMoveHelicalAbs(ushort DeviceNo, ushort GroupNo, double Angle, double[] AuxPos, double Pitch, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DHelicalAbs_CP_Angle")]
        public static extern int ECAT_McGroupMove3DHelicalAbs_CP_Angle(ushort DeviceNo, ushort GroupNo, double Vel, double Angle, double Pitch, double[] AuxPos, double[] NV);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveHelicalRel")]
        public static extern int ECAT_McGroupMoveHelicalRel(ushort DeviceNo, ushort GroupNo, double Angle, double[] AuxPos, double Pitch, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DHelicalRel_CP_Angle")]
        public static extern int ECAT_McGroupMove3DHelicalRel_CP_Angle(ushort DeviceNo, ushort GroupNo, double Vel, double Angle, double Pitch, double[] AuxPos, double[] NV);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveConicalHelixAbs")]
        public static extern int ECAT_McGroupMoveConicalHelixAbs(ushort DeviceNo, ushort GroupNo, double Angle, double[] AuxPos, double Pitch, double Vel, double EndRadius);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DConicalHelixAbs_CP_Angle")]
        public static extern int ECAT_McGroupMove3DConicalHelixAbs_CP_Angle(ushort DeviceNo, ushort GroupNo, double Vel, double Angle, double Pitch, double[] AuxPos, double[] NV, double EndRadius);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveConicalHelixRel")]
        public static extern int ECAT_McGroupMoveConicalHelixRel(ushort DeviceNo, ushort GroupNo, double Angle, double[] AuxPos, double Pitch, double Vel, double EndRadius);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMove3DConicalHelixRel_CP_Angle")]
        public static extern int ECAT_McGroupMove3DConicalHelixRel_CP_Angle(ushort DeviceNo, ushort GroupNo, double Vel, double Angle, double Pitch, double[] AuxPos, double[] NV, double EndRadius);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveProfile")]
        public static extern int ECAT_McGroupMoveProfile(ushort DeviceNo, ushort GroupNo, ushort[] ProfileNo, ushort TotalStep);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveProfileCSV")]
        public static extern int ECAT_McGroupMoveProfileCSV(ushort DeviceNo, ushort GroupNo, ushort ProfileNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveDwell")]
        public static extern int ECAT_McGroupMoveDwell(ushort DeviceNo, ushort GroupNo, uint Cnt);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveDO")]
        public static extern int ECAT_McGroupMoveDO(ushort DeviceNo, ushort GroupNo, ushort SlaveNo, ushort BitNo, uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveBlendingSync")]
        public static extern int ECAT_McGroupMoveBlendingSync(ushort DeviceNo, ushort GroupNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceEncProperty")]
        public static extern int ECAT_SetDeviceEncProperty(ushort DeviceNo, ushort EncNo, byte Mode, byte InvertCnt, byte LPF);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceEncProperty")]
        public static extern int ECAT_GetDeviceEncProperty(ushort DeviceNo, ushort EncNo, ref byte Mode, ref byte InvertCnt, ref byte LPF);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceEnCount")]
        public static extern int ECAT_GetDeviceEnCount(ushort DeviceNo, ushort EncNo, ref int Cnt);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_ResetDeviceEncCount")]
        public static extern int ECAT_ResetDeviceEncCount(ushort DeviceNo, ushort EncNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceCmpTrigProperty")]
        public static extern int ECAT_SetDeviceCmpTrigProperty(ushort DeviceNo, ushort EncNo, uint PulseWidth);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceCmpTrigProperty")]
        public static extern int ECAT_GetDeviceCmpTrigProperty(ushort DeviceNo, ushort EncNo, ref uint PulseWidth);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceCmpTrigData")]
        public static extern int ECAT_SetDeviceCmpTrigData(ushort DeviceNo, ushort EncNo, int CmpData);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceContCmpTrigData")]
        public static extern int ECAT_SetDeviceContCmpTrigData(ushort DeviceNo, ushort EncNo, int Start, uint Interval, uint Times);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceEmg")]
        public static extern int ECAT_SetDeviceEmg(ushort DeviceNo, byte Source, byte Enable, byte Logic, ushort SlaveNo, ushort BitNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceEmg")]
        public static extern int ECAT_GetDeviceEmg(ushort DeviceNo, ref byte Source, ref byte Enable, ref byte Logic, ref ushort SlaveNo, ref ushort BitNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceEmgStatus")]
        public static extern int ECAT_GetDeviceEmgStatus(ushort DeviceNo, ref byte Status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceEmgSoftSig")]
        public static extern int ECAT_SetDeviceEmgSoftSig(ushort DeviceNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetDeviceMPG")]
        public static extern int ECAT_SetDeviceMPG(ushort DeviceNo, byte Enable, ref ushort AxisNo, ushort AxisCount);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetDeviceMPG")]
        public static extern int ECAT_GetDeviceMPG(ushort DeviceNo, ref byte Enable, ref ushort AxisNo, ref ushort AxisCount);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_OpenMotionConfig")]
        public static extern int ECAT_OpenMotionConfig(string bstrFileName, ref ushort AxisCnt, ushort[] SlaveNo, ushort[] SubAxisNo, double[] PPU, int[] HomeMethod, double[] HomeSpeedSeachSw, double[] HomeSpeedSeachZr, double[] HomeAcc, uint[] EncoderPPR, uint[] MotorPPR);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveRegister")]
        public static extern int ECAT_GetSlaveRegister(ushort DeviceNo, ushort SlaveNo, ushort Addr, ushort DataSize, ref uint Val, ref byte state);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveRegister")]
        public static extern int ECAT_SetSlaveRegister(ushort DeviceNo, ushort SlaveNo, ushort Addr, ushort DataSize, uint Val, ref byte state);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetMotionRecordState")]
        public static extern int ECAT_McGetMotionRecordState(ushort DeviceNo, ref ushort state, ref uint count);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetMotionRecord")]
        public static extern int ECAT_McSetMotionRecord(ushort DeviceNo, ushort state);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_DownloadMotionLog")]
        public static extern int ECAT_DownloadMotionLog(ushort DeviceNo, ref uint Offset, StringBuilder Data, ref uint DataSize, ref byte LastFlag);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetTimer")]
        public static extern int ECAT_SetTimer(ushort DeviceNo, uint Interval);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetTimerStop")]
        public static extern int ECAT_SetTimerStop(ushort DeviceNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetPdo_Directly")]
        public static extern int ECAT_McGetPdo_Directly(ushort DeviceNo, ushort Size, StringBuilder Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetStewartPlatform_M1")]
        public static extern int ECAT_McSetStewartPlatform_M1(ushort DeviceNo, double radiusB, double angleB, double radiusP, double angleP, double RodLength, double Max_RodLength);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisActualPosVel")]
        public static extern int ECAT_McGetAxisActualPosVel(ushort DeviceNo, ushort AxisNo, ref float Pos, ref float Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidSetSetPointValue")]
        public static extern int ECAT_PidSetSetPointValue(ushort DeviceNo, uint PidNo, double SetPointValue);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetControlOutputValue")]
        public static extern int ECAT_PidGetControlOutputValue(ushort DeviceNo, uint PidNo, ref double Output);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidSetParameter")]
        public static extern int ECAT_PidSetParameter(ushort DeviceN, uint PidNoo, double kp, double ki, double kd);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidSetStatus")]
        public static extern int ECAT_PidSetStatus(ushort DeviceN, uint PidNo, byte status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidSetSimulateMode")]
        public static extern int ECAT_PidSetSimulateMode(ushort DeviceN, uint PidNo, byte status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidSetSampleTime")]
        public static extern int ECAT_PidSetSampleTime(ushort DeviceN, uint PidNo, uint Interval);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidSetProcessVariableModule")]
        public static extern int ECAT_PidSetProcessVariableModule(ushort DeviceN, uint PidNo, ushort SlaveNo, ushort OffsetByte, ushort Bitlength, double ScaleGain, double ScaleOffset);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidSetControlOutputModule")]
        public static extern int ECAT_PidSetControlOutputModule(ushort DeviceN, uint PidNo, ushort SlaveNo, ushort OffsetByte, ushort Bitlength, double ScaleGain, double ScaleOffset, double Output_Max_Value, double Output_Min_Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetParameter")]
        public static extern int ECAT_PidGetParameter(ushort DeviceN, uint PidNoo, ref double kp, ref double ki, ref double kd);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetStatus")]
        public static extern int ECAT_PidGetStatus(ushort DeviceN, uint PidNo, ref byte status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetSimulateMode")]
        public static extern int ECAT_PidGetSimulateMode(ushort DeviceN, uint PidNo, ref byte status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetSampleTime")]
        public static extern int ECAT_PidGetSampleTime(ushort DeviceN, uint PidNo, ref uint Interval);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetProcessVariableModule")]
        public static extern int ECAT_PidGetProcessVariableModule(ushort DeviceN, uint PidNo, ref ushort SlaveNo, ref ushort OffsetByte, ref ushort Bitlength, ref double ScaleGain, ref double ScaleOffset);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetControlOutputModule")]
        public static extern int ECAT_PidGetControlOutputModule(ushort DeviceN, uint PidNo, ref ushort SlaveNo, ref ushort OffsetByte, ref ushort Bitlength, ref double ScaleGain, ref double ScaleOffset, ref int Output_Max_Value, ref int Output_Min_Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetProcessVariable")]
        public static extern int ECAT_PidGetProcessVariable(ushort DeviceN, uint PidNo, ref int Input);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetSimulateFeedback")]
        public static extern int ECAT_PidGetSimulateFeedback(ushort DeviceN, uint PidNo, ref double Feedback);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_WaitforTimer")]
        public static extern int ECAT_WaitforTimer(ushort DeviceNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGetSetPointValue")]
        public static extern int ECAT_PidGetSetPointValue(ushort DeviceNo, uint PidNo, ref double SetPointValue);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_PidGet_Sp_Err_Op_Pv")]
        public static extern int ECAT_PidGet_Sp_Err_Op_Pv(ushort DeviceNo, uint PidNo, ref double SetPointValue, ref double Error, ref double OutputValue, ref double ProcessVariable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisVelocityFeedForwardGain")]
        public static extern int ECAT_McSetAxisVelocityFeedForwardGain(ushort DeviceNo, ushort AxisNo, double Gain);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisVelocityFeedForwardGain")]
        public static extern int ECAT_McGetAxisVelocityFeedForwardGain(ushort DeviceNo, ushort AxisNo, ref double Gain);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McStewartPlatformMoveAbs_PT")]
        public static extern int ECAT_McStewartPlatformMoveAbs_PT(ushort DeviceNo, ushort GroupNo, double[] Pose, ref double Pos, double Time);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetStewartPlatform_M1")]
        public static extern int ECAT_McGetStewartPlatform_M1(ushort DeviceNo, ref double radiusB, ref double angleB, ref double radiusP, ref double angleP, ref double RodLength, ref double Max_RodLength);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetStewartPlatform_M2")]
        public static extern int ECAT_McSetStewartPlatform_M2(ushort DeviceNo, double[] Bx, double[] By, double[] Px, double[] Py, double Z0, double[] RodLength, double[] Max_RodLength);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupVelLimitStatus")]
        public static extern int ECAT_McSetGroupVelLimitStatus(ushort DeviceNo, ushort GroupNo, ushort Status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetGroupVelLimitStatus")]
        public static extern int ECAT_McGetGroupVelLimitStatus(ushort DeviceNo, ushort GroupNo, ref ushort Status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupVelLimitValue")]
        public static extern int ECAT_McSetGroupVelLimitValue(ushort DeviceNo, ushort GroupNo, double Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetGroupVelLimitValue")]
        public static extern int ECAT_McGetGroupVelLimitValue(ushort DeviceNo, ushort GroupNo, ref double Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetMotionRecordParam")]
        public static extern int ECAT_McSetMotionRecordParam(ushort DeviceNo, ushort Value1, ushort Value2);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetMotionRecordParam")]
        public static extern int ECAT_McGetMotionRecordParam(ushort DeviceNo, ref ushort Value1, ref ushort Value2);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetMotionRecordValue")]
        public static extern int ECAT_McGetMotionRecordValue(ushort DeviceNo, uint CountNo, ushort AxisNo, ref float Value1, ref float Value2);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McClearMotionRecord")]
        public static extern int ECAT_McClearMotionRecord(ushort DeviceNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisPosSoftwareLimit")]
        public static extern int ECAT_McSetAxisPosSoftwareLimit(ushort DeviceNo, ushort AxisNo, double Maximum, double Minimum, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisPosSoftwareLimit")]
        public static extern int ECAT_McGetAxisPosSoftwareLimit(ushort DeviceNo, ushort AxisNo, ref double Maximum, ref double Minimum, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetProcessTime")]
        public static extern int ECAT_GetProcessTime(ushort DeviceNo, ref double Time);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupHold")]
        public static extern int ECAT_McSetGroupHold(ushort DeviceNo, ushort GroupNo, ushort Status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisPosSoftwareLimitStatus")]
        public static extern int ECAT_McSetAxisPosSoftwareLimitStatus(ushort DeviceNo, ushort AxisNo, ushort Status, ushort ErrorStop);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisPosSoftwareLimitStatus")]
        public static extern int ECAT_McGetAxisPosSoftwareLimitStatus(ushort DeviceNo, ushort AxisNo, ref ushort Status, ref ushort ErrorStop);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisHomeState")]
        public static extern int ECAT_McGetAxisHomeState(ushort DeviceNo, ushort AxisNo, ref ushort State);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisGantryIn")]
        public static extern int ECAT_McAxisGantryIn(ushort DeviceNo, ushort MasterNo, ushort SlaveNo, int Direction);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupCmdModeEx")]
        public static extern int ECAT_McSetGroupCmdModeEx(ushort DeviceNo, ushort GroupNo, ushort CmdMode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisGantryMaxPosDiff")]
        public static extern int ECAT_McAxisGantryMaxPosDiff(ushort DeviceNo, ushort SlaveNo, double Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisGantryMaxPosDiffStatus")]
        public static extern int ECAT_McAxisGantryMaxPosDiffStatus(ushort DeviceNo, ushort SlaveNo, ushort Status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvCreatEvent")]
        public static extern int ECAT_EvCreatEvent(ushort DeviceNo, ref ushort EventID);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvCloseEvent")]
        public static extern int ECAT_EvCloseEvent(ushort DeviceNo, ushort EventID);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvEnableEvent")]
        public static extern int ECAT_EvEnableEvent(ushort DeviceNo, ushort EventID);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvDisableEvent")]
        public static extern int ECAT_EvDisableEvent(ushort DeviceNo, ushort EventID);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvSetComparePositionParameters")]
        public static extern int ECAT_EvSetComparePositionParameters(ushort DeviceNo, ushort EventID, ushort AxisNo, ushort Operator, double ComparePosition);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_WaitforEvent")]
        public static extern int ECAT_WaitforEvent(ushort DeviceNo, uint TimeOut, ref uint TriggeredEvent);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_ECAT_EvSetCompareDIBitParameters")]
        public static extern int ECAT_ECAT_EvSetCompareDIBitParameters(ushort DeviceNo, ushort EventID, ushort SlaveNo, ushort BitNo, uint CompareValue);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvSetMotionCompleteParameters")]
        public static extern int ECAT_EvSetMotionCompleteParameters(ushort DeviceNo, ushort EventID, ushort AxisNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveAO")]
        public static extern int ECAT_McGroupMoveAO(ushort DeviceNo, ushort GroupNo, ushort SlaveNo, uint RunMode, ushort ChannelNo, ushort RawData, double VoltData);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupAccTimeEx")]
        public static extern int ECAT_McSetGroupAccTimeEx(ushort DeviceNo, ushort GroupNo, ushort Time_ms);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupBlendingPercent")]
        public static extern int ECAT_McSetGroupBlendingPercent(ushort DeviceNo, ushort GroupNo, ushort Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetProfileInterval")]
        public static extern int ECAT_McSetProfileInterval(ushort DeviceNo, ushort ProfileNo, ushort Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveSuperimposed")]
        public static extern int ECAT_McAxisMoveSuperimposed(ushort DeviceNo, ushort AxisNo, double Pos, double Vel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisHaltSuperimposed")]
        public static extern int ECAT_McAxisHaltSuperimposed(ushort DeviceNo, ushort AxisNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetMotionRecordValueEx")]
        public static extern int ECAT_McGetMotionRecordValueEx(ushort DeviceNo, uint CountNo, ushort Count, ushort AxisNo, ref float Value1, ref float Value2, ref ushort ActualCount);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetHeartBeat")]
        public static extern int ECAT_SetHeartBeat(ushort DeviceNo, uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetHeartBeatStatus")]
        public static extern int ECAT_SetHeartBeatStatus(ushort DeviceNo, uint Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupBlendingPercentEx")]
        public static extern int ECAT_McSetGroupBlendingPercentEx(ushort DeviceNo, ushort GroupNo, ushort Value);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvSetCompareDIParameters")]
        public static extern int ECAT_EvSetCompareDIParameters(ushort DeviceNo, ushort EventID, ushort SlaveNo, ushort OffsetByte, uint CompareValue, uint Mask);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupPause")]
        public static extern int ECAT_McSetGroupPause(ushort DeviceNo, ushort GroupNo, ushort Status);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvSetCompareAxisStateParameters")]
        public static extern int ECAT_EvSetCompareAxisStateParameters(ushort DeviceNo, ushort EventID, ushort AxisNo, uint CompareState);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveAiProperty")]
        public static extern int ECAT_SetSlaveAiProperty(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, byte Range);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveAiProperty")]
        public static extern int ECAT_GetSlaveAiProperty(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref byte Range);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveAiRawData")]
        public static extern int ECAT_GetSlaveAiRawData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref short Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveAiVoltData")]
        public static extern int ECAT_GetSlaveAiVoltData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref double Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveAimAData")]
        public static extern int ECAT_GetSlaveAimAData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref double Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisHomeEx")]
        public static extern int ECAT_McAxisHomeEx(ushort DeviceNo, ushort AxisNo, ushort Settings);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvSetCompareCmdPositionParameters")]
        public static extern int ECAT_EvSetCompareCmdPositionParameters(ushort DeviceNo, ushort EventID, ushort AxisNo, ushort Operator, double ComparePosition);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvSetCompareAxisVelStateParameters")]
        public static extern int ECAT_EvSetCompareAxisVelStateParameters(ushort DeviceNo, ushort EventID, ushort AxisNo, uint CompareState);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisMaxVelocity")]
        public static extern int ECAT_McSetAxisMaxVelocity(ushort DeviceNo, ushort AxisNo, double MaxVelocity);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisMaxVelocity")]
        public static extern int ECAT_McGetAxisMaxVelocity(ushort DeviceNo, ushort AxisNo, ref double MaxVelocity);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineAbs_P2P")]
        public static extern int ECAT_McGroupMoveLineAbs_P2P(ushort DeviceNo, ushort GroupNo, double[] Pos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineRel_P2P")]
        public static extern int ECAT_McGroupMoveLineRel_P2P(ushort DeviceNo, ushort GroupNo, double[] Pos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveAbs_P2P")]
        public static extern int ECAT_McAxisMoveAbs_P2P(ushort DeviceNo, ushort AxisNo, double Pos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveRel_P2P")]
        public static extern int ECAT_McAxisMoveRel_P2P(ushort DeviceNo, ushort AxisNo, double Pos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_Set_ECAT2016_AiProperty")]
        public static extern int ECAT_Set_ECAT2016_AiProperty(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, byte Range, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_Get_ECAT2016_AiProperty")]
        public static extern int ECAT_Get_ECAT2016_AiProperty(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref byte Range, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_Get_ECAT2016_AiRawData")]
        public static extern int ECAT_Get_ECAT2016_AiRawData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref short Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_Get_ECAT2016_AiVoltData")]
        public static extern int ECAT_Get_ECAT2016_AiVoltData(ushort DeviceNo, ushort SlaveNo, ushort ChannelNo, ref double Data);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvSetCompareAiParameters")]
        public static extern int ECAT_EvSetCompareAiParameters(ushort DeviceNo, ushort EventID, ushort Operator, ushort SlaveNo, ushort OffsetByte, ushort DataSize, double ScaleGain, double ScaleOffset, double CompareValue);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisTorqueGain")]
        public static extern int ECAT_McSetAxisTorqueGain(ushort DeviceNo, ushort AxisNo, double Gain, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisTorqueGain")]
        public static extern int ECAT_McGetAxisTorqueGain(ushort DeviceNo, ushort AxisNo, ref double Gain);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisRatedTorque")]
        public static extern int ECAT_McGetAxisRatedTorque(ushort DeviceNo, ushort AxisNo, ref double Torque, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveTor")]
        public static extern int ECAT_McAxisMoveTor(ushort DeviceNo, ushort AxisNo, double Torque);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisActualTorque")]
        public static extern int ECAT_McGetAxisActualTorque(ushort DeviceNo, ushort AxisNo, ref double Torque);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisMaxTorque")]
        public static extern int ECAT_McSetAxisMaxTorque(ushort DeviceNo, ushort AxisNo, double Torque, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisMaxTorque")]
        public static extern int ECAT_McGetAxisMaxTorque(ushort DeviceNo, ushort AxisNo, ref double Torque, ref uint AbortCode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisCommandVel")]
        public static extern int ECAT_McGetAxisCommandVel(ushort DeviceNo, ushort AxisNo, ref double Pos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMovePath")]
        public static extern int ECAT_McGroupMovePath(ushort DeviceNo, ushort GroupNo, ushort PathDataNo, byte Restart, ushort DataIndex, byte Repeat);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAddPathData")]
        public static extern int ECAT_McAddPathData(ushort DeviceNo, ushort PathDataNo, uint CmdType, byte AbsMove, double[] EndPos, double[] AuxPos, double[] Args);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetPathData")]
        public static extern int ECAT_McSetPathData(ushort DeviceNo, ushort PathDataNo, ushort DataIndex, uint CmdType, byte AbsMove, double[] EndPos, double[] AuxPos, double[] Args);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetPathData")]
        public static extern int ECAT_McGetPathData(ushort DeviceNo, ushort PathDataNo, ushort DataIndex, ref uint CmdType, ref byte AbsMove, double[] EndPos, double[] AuxPos, double[] Args);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McClearPathData")]
        public static extern int ECAT_McClearPathData(ushort DeviceNo, ushort PathDataNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetPathDataSize")]
        public static extern int ECAT_McGetPathDataSize(ushort DeviceNo, ushort PathDataNo, ref ushort Size);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveAbsAdv")]
        public static extern int ECAT_McAxisMoveAbsAdv(ushort DeviceNo, ushort AxisNo, double EndPos, double StartVel, double ReqVel, double FinalVel, double Accel, double Decel, byte AccDecMode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveRelAdv")]
        public static extern int ECAT_McAxisMoveRelAdv(ushort DeviceNo, ushort AxisNo, double EndPos, double StartVel, double ReqVel, double FinalVel, double Accel, double Decel, byte AccDecMode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineAbsAdv")]
        public static extern int ECAT_McGroupMoveLineAbsAdv(ushort DeviceNo, ushort GroupNo, double[] EndPos, double StartVel, double ReqVel, double FinalVel, double Accel, double Decel, byte AccDecMode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGroupMoveLineRelAdv")]
        public static extern int ECAT_McGroupMoveLineRelAdv(ushort DeviceNo, ushort GroupNo, double[] EndPos, double StartVel, double ReqVel, double FinalVel, double Accel, double Decel, byte AccDecMode);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMove_CiA402_PP")]
        public static extern int ECAT_McAxisMove_CiA402_PP(ushort DeviceNo, ushort AxisNo, byte Abort, byte AbsMove, double EndPos, double Vel, double Accel, double Decel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMove_CiA402_PV")]
        public static extern int ECAT_McAxisMove_CiA402_PV(ushort DeviceNo, ushort AxisNo, double Vel, double Accel, double Decel);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMove_CiA402_PT")]
        public static extern int ECAT_McAxisMove_CiA402_PT(ushort DeviceNo, ushort AxisNo, double Torque, double Slope);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_UpdateFirmware_")]
        public static extern int ECAT_UpdateFirmware_(ushort DeviceNo, uint Offset, string Data, uint DataSize, byte LastFlag);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetTxPdoBufParam")]
        public static extern int ECAT_SetTxPdoBufParam(ushort DeviceNo, ushort ChannelNo, ushort SlaveNo, ushort OffsetByte, ushort DataSize, ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetTxPdoBufParam")]
        public static extern int ECAT_GetTxPdoBufParam(ushort DeviceNo, ushort ChannelNo, ref ushort SlaveNo, ref ushort OffsetByte, ref ushort DataSize, ref ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetTxPdoBufEnable")]
        public static extern int ECAT_SetTxPdoBufEnable(ushort DeviceNo, ushort ChannelNo, ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetTxPdoBufEnable")]
        public static extern int ECAT_GetTxPdoBufEnable(ushort DeviceNo, ushort ChannelNo, ref ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetTxPdoBufValue")]
        public static extern int ECAT_GetTxPdoBufValue(ushort DeviceNo, ushort ChannelNo, ref float Data, ushort Size, ref ushort ActualGetSize);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetAxisHomeTorque")]
        public static extern int ECAT_McSetAxisHomeTorque(ushort DeviceNo, ushort AxisNo, ushort Torque);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetAxisHomeTorque")]
        public static extern int ECAT_McGetAxisHomeTorque(ushort DeviceNo, ushort AxisNo, ref ushort Torque);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetAiFilterParam")]
        public static extern int ECAT_SetAiFilterParam(ushort DeviceNo, ushort ChannelNo, ushort SlaveNo, ushort OffsetByte, ushort DataSize, ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetAiFilterParam")]
        public static extern int ECAT_GetAiFilterParam(ushort DeviceNo, ushort ChannelNo, ref ushort SlaveNo, ref ushort OffsetByte, ref ushort DataSize, ref ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetAiFilterEnable")]
        public static extern int ECAT_SetAiFilterEnable(ushort DeviceNo, ushort ChannelNo, ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetAiFilterEnable")]
        public static extern int ECAT_GetAiFilterEnable(ushort DeviceNo, ushort ChannelNo, ref ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetAiFilterFreq")]
        public static extern int ECAT_SetAiFilterFreq(ushort DeviceNo, ushort ChannelNo, ushort FilterType, double Frequency);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetAiFilterFreq")]
        public static extern int ECAT_GetAiFilterFreq(ushort DeviceNo, ushort ChannelNo, ushort FilterType, ref double Frequency);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetAiFilterOutput")]
        public static extern int ECAT_GetAiFilterOutput(ushort DeviceNo, ushort ChannelNo, ref int Output);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetPdoInToOutParam")]
        public static extern int ECAT_SetPdoInToOutParam(ushort DeviceNo, ushort ChannelNo, ushort SlaveNoIn, ushort OffsetByteIn, ushort DataSizeIn, ushort SlaveNoOut, ushort OffsetByteOut, ushort DataSizeOut);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetPdoInToOutParam")]
        public static extern int ECAT_GetPdoInToOutParam(ushort DeviceNo, ushort ChannelNo, ref ushort SlaveNoIn, ref ushort OffsetByteIn, ref ushort DataSizeIn, ref ushort SlaveNoOut, ref ushort OffsetByteOut, ref ushort DataSizeOut);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetPdoInToOutCoeff")]
        public static extern int ECAT_SetPdoInToOutCoeff(ushort DeviceNo, ushort ChannelNo, float gain, float offset);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetPdoInToOutCoeff")]
        public static extern int ECAT_GetPdoInToOutCoeff(ushort DeviceNo, ushort ChannelNo, ref float gain, ref float offset);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetPdoInToOutEnable")]
        public static extern int ECAT_SetPdoInToOutEnable(ushort DeviceNo, ushort ChannelNo, ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetPdoInToOutEnable")]
        public static extern int ECAT_GetPdoInToOutEnable(ushort DeviceNo, ushort ChannelNo, ref ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McStewartPlatformShaker")]
        public static extern int ECAT_McStewartPlatformShaker(ushort DeviceNo, ushort GroupNo, double[] Amp, double Freq);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McStewartPlatformShaker_Stop")]
        public static extern int ECAT_McStewartPlatformShaker_Stop(ushort DeviceNo, ushort GroupNo, int QuickStop);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisMoveVelShaker")]
        public static extern int ECAT_McAxisMoveVelShaker(ushort DeviceNo, ushort AxisNo, double Amp, double Freq, uint N);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McAxisGantryGain")]
        public static extern int ECAT_McAxisGantryGain(ushort DeviceNo, ushort SlaveNo, double Kp, double Ki);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveAlias")]
        public static extern int ECAT_SetSlaveAlias(ushort DeviceNo, ushort SlaveNo, ushort Alias);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveSwAlias")]
        public static extern int ECAT_GetSlaveSwAlias(ushort DeviceNo, ushort SlaveNo, ref ushort Alias);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_SetSlaveNoType")]
        public static extern int ECAT_SetSlaveNoType(ushort DeviceNo, ushort Type);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveNoType")]
        public static extern int ECAT_GetSlaveNoType(ushort DeviceNo, ref ushort Type);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlavePos")]
        public static extern int ECAT_GetSlavePos(ushort DeviceNo, ushort SlaveNo, ref ushort Pos);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_GetSlaveNo")]
        public static extern int ECAT_GetSlaveNo(ushort DeviceNo, ushort Pos, ref ushort SlaveNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_EvSetMotionCompleteParameters_Grp")]
        public static extern int ECAT_EvSetMotionCompleteParameters_Grp(ushort DeviceNo, ushort EventID, ushort GrpNo);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McSetGroupPvtDecEnable")]
        public static extern int ECAT_McSetGroupPvtDecEnable(ushort DeviceNo, ushort GroupNo, ushort Enable);

        [DllImport("libecatdevice.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "ECAT_McGetGroupPvtDecEnable")]
        public static extern int ECAT_McGetGroupPvtDecEnable(ushort DeviceNo, ushort GroupNo, ref ushort Enable);
    }
}
