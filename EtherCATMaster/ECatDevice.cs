using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace EtherCATMaster
{
    public class ECatDevice : AbstractECatDevice
    {
        public event EventHandler<SalveAxisStateChangeEventArgs> SalveAxisStateChangeEvent;

        public ECatDevice(ushort deviceNo, ushort networkInfoNo = 0) : base(deviceNo, networkInfoNo)
        {
        }

        /// <summary>
        /// 裝置、從站初始化。
        /// </summary>
        /// <param name="resultCode"></param>
        /// <returns></returns>
        public bool InitializeSlave(AbstractECatSlave[] slaveList)
        {
            int resultCode = 0;
            if (OpenDevice(ref resultCode) && StartOpTask(ref resultCode))
            {
                if (AlState != AlStates.ECAT_AS_OP)
                {
                    string msg = "裝置不是 Operational 狀態，無法取得從站資訊。";
                    Logger.Error(MethodBase.GetCurrentMethod().Name, msg);
                    throw new Exception($"{MethodBase.GetCurrentMethod().Name} {msg}");
                }
                if (SlavesResp == slaveList.Length)
                {
                    SlaveItems = slaveList;
                    for (ushort i = 0; i < SlaveItems.Length; i++)
                    {
                        SlaveItems[i].GetSlaveInfo();
                    }
                    return true;
                }
                else
                {
                    string msg = $"DeviceNo=[{DeviceNo}] 從站數量與實際數量不匹配，無法初始化。";
                    Logger.Error(MethodBase.GetCurrentMethod().Name, msg);
                    throw new Exception($"{MethodBase.GetCurrentMethod().Name} {msg}");
                }
            }
            return false;
        }

        /// <summary>
        /// 從站之子軸初始化。
        /// </summary>
        /// <returns></returns>
        public bool InitMotionAxis()
        {
            for (int i = 0; i < SlaveItems.Length; i++)
            {
                if (SlaveItems[i] is MotionSlave slave)
                {
                    if (slave.AxisItems == null)
                    {
                        Logger.Error(MethodBase.GetCurrentMethod().Name, $"DeviceNo=[{DeviceNo}], SlaveNo=[{slave.SlaveNo}] 子軸為 null，無法初始化。");
                        continue;
                    }
                    var mcSlaveNo = new List<ushort>();
                    var mcSubAxisNo = new List<ushort>();
                    int resultCode;
                    int retryCount;
                    for (int j = 0; j < slave.AxisItems.Length; j++)
                    {
                        MotionAxis axis = slave.AxisItems[j];
                        resultCode = 0;
                        retryCount = 0;
                        while (retryCount++ < 10)
                        {
                            axis.GetAxisState(ref resultCode);
                            if (resultCode == EtherCatError.ECAT_ERR_MC_NOT_INITIALIZED) // 軸尚未初始化。
                            {
                                axis.IsMcInitOk = false;
                                mcSlaveNo.Add(slave.SlaveNo);
                                mcSubAxisNo.Add(axis.AxisNo);
                                break;
                            }
                            else if (axis.AxisState == AxisStates.MC_AS_DISABLED) // 軸已初始化，Servo尚未啟動。
                            {
                                axis.IsMcInitOk = true;
                                break;
                            }
                            else if (axis.AxisState == AxisStates.MC_AS_STANDSTILL) // 軸已初始化，Servo啟動，停止中。
                            {
                                axis.IsMcInitOk = true;
                                // Servo 尚未停止，執行 ServoOff。
                                axis.ServoControl(false);
                            }
                            else if (axis.AxisState == AxisStates.MC_AS_ERRORSTOP) // 軸出現異常。
                            {
                                axis.IsMcInitOk = true;
                                axis.GetAxisErrorState();
                                SalveAxisStateChangeEvent?.Invoke(slave, new SalveAxisStateChangeEventArgs()
                                {
                                    SlaveNo = slave.SlaveNo,
                                    AlState = slave.AlState,
                                    SlaveName = slave.SlaveName,
                                    AxisNo = axis.AxisNo,
                                    AxisState = axis.AxisState,
                                    LastError = axis.LastError,
                                    DriveError = axis.DriveError
                                });
                                Logger.Error(resultCode, MethodBase.GetCurrentMethod().Name, $"SlaveNo=[{slave.SlaveNo}], AxisNo=[{axis.AxisNo}] 軸目前出現錯誤且為停止狀態 !!!");
                                break;
                            }
                            else if (axis.AxisState != AxisStates.MC_AS_STOPPING) // 軸仍在運動中。
                            {
                                axis.IsMcInitOk = true;
                                // 如果不在停止狀態，立刻停止。
                                axis.AxisQuickStop();
                            }
                            SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
                        }
                    }
                    if (mcSlaveNo.Count > 0 && mcSubAxisNo.Count > 0)
                    {
                        resultCode = 0;
                        retryCount = 0;
                        while (retryCount++ < ECatControl.RetryCount)
                        {
                            resultCode = EtherCatLib.ECAT_McInit(
                               slave.DeviceNo,
                               mcSlaveNo.ToArray(),
                               mcSubAxisNo.ToArray(),
                               (ushort)mcSubAxisNo.Count);
                            if (resultCode == 0)
                            {
                                break;
                            }
                            Logger.Error(resultCode, "ECAT_McInit", $"SlaveNo=[{slave.SlaveNo}], 嘗試次數=[{i}]");
                            SpinWait.SpinUntil(() => false, ECatControl.RetryInterval);
                        }
                        if (resultCode == 0)
                        {
                            foreach (MotionAxis axis in slave.AxisItems)
                            {
                                axis.IsMcInitOk = true;
                            }
                        }
                        else
                        {
                            foreach (MotionAxis axis in slave.AxisItems)
                            {
                                axis.IsMcInitOk = false;
                            }
                            Logger.Error(resultCode, "ECAT_McInit", $"DeviceNo=[{DeviceNo}], SlaveNo=[{slave.SlaveNo}] 初始化失敗 !!!");
                        }
                    }
                }
            }
            return true;
        }
    }
}
