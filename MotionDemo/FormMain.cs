using EtherCATMaster;

using MotionDemo.Properties;
using MotionDemo.Utils;

using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace MotionDemo
{
    public partial class FormMain : Form
    {
        private readonly ECatDevice MainDevice;

        public FormMain()
        {
            InitializeComponent();
            int resultCode = 0;
            if (ECatControl.GetDeviceCount(new byte[16], ref resultCode) > 0)
            {
                MainDevice = new ECatDevice(0); // CardId
                MainDevice.DeviceStateChangeEvent += MainDevice_DeviceStateChangeEvent;
                InitializeDevice();
            }
            //Text += $" DllVersion:{ECatControl.GetVersion(ref resultCode)}";
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainDevice.SlaveItems != null)
            {
                for (int i = 0; i < MainDevice.SlaveItems.Length; i++)
                {
                    if (MainDevice.SlaveItems[i] is MotionSlave motionSlave)
                    {
                        motionSlave.CloseAllAxis();
                    }
                }
            }
            int resultCode = 0;
            MainDevice.StopOpTask(ref resultCode);
            MainDevice.CloseDevice(ref resultCode);
        }

        private void MainDevice_DeviceStateChangeEvent(object sender, DeviceStateChangeEventArgs e)
        {
            LinkUpTextBox.Text = e.IsLinkUp ? "Connect" : "DisConnect";
            SlavesRespTextBox.Text = e.SlavesResp.ToString();
            AlStateTextBox.Text = e.AlState.ToString();
            WorkingCounterTextBox.Text = e.WorkingCounter.ToString();
        }

        private void InitializeDevice()
        {
            int resultCode = 0;
            // 設置從站數量
            var slaveList = new AbstractECatSlave[2];
            slaveList[0] = new MotionSlave(MainDevice.DeviceNo, 0);
            slaveList[1] = new IOSlave(MainDevice.DeviceNo, 1);

            // 初始化從站
            if (MainDevice.InitializeSlave(slaveList))
            {
                // slave 1
                if (MainDevice.SlaveItems[0] is MotionSlave slave1 && slave1.SlaveName == Settings.Default.Card1Slave1Name)
                {
                    ushort[] axisList = Settings.Default.Card1Slave1AxisList.Split(',').Select(s => (ushort)int.Parse(s)).ToArray();
                    var listItem = new ListViewItem(slave1.SlaveNo.ToString());  // 0
                    listItem.SubItems.Add(slave1.Alias.ToString()); // 1
                    listItem.SubItems.Add(slave1.SlaveName.ToString()); // 2
                    listItem.SubItems.Add(slave1.SlaveType.ToString()); // 3
                    listItem.SubItems.Add(slave1.AlState.ToString()); // 4
                    SlaveStateListView.Items.Add(listItem);
                    slave1.SetAxisNo(axisList);
                }
                // slave 2
                if (MainDevice.SlaveItems[1] is IOSlave slave2)
                {
                    var listItem = new ListViewItem(slave2.SlaveNo.ToString());  // 0
                    listItem.SubItems.Add(slave2.Alias.ToString()); // 1
                    listItem.SubItems.Add(slave2.SlaveName.ToString()); // 2
                    listItem.SubItems.Add(slave2.SlaveType.ToString()); // 3
                    listItem.SubItems.Add(slave2.AlState.ToString()); // 4
                    SlaveStateListView.Items.Add(listItem);
                }

                if (MainDevice.InitMotionAxis())
                {
                    for (int i = 0; i < MainDevice.SlaveItems.Length; i++)
                    {
                        if (MainDevice.SlaveItems[i] is MotionSlave motionSlave)
                        {
                            var motionConfig = (MotionParam)ConfigurationManager.GetSection(nameof(MotionParam));
                            foreach (MotionAxis axis in motionSlave.AxisItems)
                            {
                                (_, bool result) = axis.SetAxisParam(motionConfig, ref resultCode);
                                if (result)
                                {
                                    var listItem = new ListViewItem(axis.AxisNo.ToString()); // Axis No 0
                                    listItem.SubItems.Add(axis.AxisState.ToString()); // Axis State 1
                                    listItem.SubItems.Add(axis.LastError.ToString()); // Axis Error 2
                                    listItem.SubItems.Add(axis.DriveError.ToString()); // Drive Error 3
                                    listItem.SubItems.Add(axis.CommandPos.ToString()); // CmdPosition 4
                                    listItem.SubItems.Add(axis.ActualPos.ToString()); // Position 5
                                    listItem.SubItems.Add(axis.ActualVel.ToString()); // Velocity 6
                                    AxisListView.Items.Add(listItem);
                                }
                            }
                        }
                    }
                }
            }
            Timer1.Tick += Timer1_Tick;
            Timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int resultCode = 0;
            MainDevice.GetDeviceState(ref resultCode);
            for (int i = 0; i < MainDevice.SlaveItems.Length; i++)
            {
                if (MainDevice.SlaveItems[i] is MotionSlave slave1)
                {
                    if (slave1.GetSlaveInfo() && SlaveStateListView.Items[0] != null)
                    {
                        SlaveStateListView.Items[0].SubItems[4].Text = slave1.AlState.ToString();
                    }
                    MotionAxis axis = slave1.AxisItems[0];
                    if (axis.GetAxisProcessState() && AxisListView.Items[0] != null)
                    {
                        AxisListView.Items[0].SubItems[1].Text = axis.AxisState.GetDescriptionText();
                        AxisListView.Items[0].SubItems[2].Text = axis.LastError.ToString();
                        AxisListView.Items[0].SubItems[3].Text = axis.DriveError.ToString();
                        AxisListView.Items[0].SubItems[4].Text = axis.CommandPos.ToString();
                        AxisListView.Items[0].SubItems[5].Text = axis.ActualPos.ToString();
                        AxisListView.Items[0].SubItems[6].Text = axis.ActualVel.ToString();
                    }
                }
                else if (MainDevice.SlaveItems[i] is IOSlave slave2)
                {
                    if (slave2.GetSlaveInfo() && SlaveStateListView.Items[1] != null)
                    {
                        SlaveStateListView.Items[0].SubItems[4].Text = slave2.AlState.ToString();
                    }
                    uint uint32 = 0;
                    if (slave2.GetDI(ref uint32))
                    {
                        DI0.Checked = (uint32 & 1) == 1;
                        DI1.Checked = (uint32 & 2) == 2;
                        DI2.Checked = (uint32 & 4) == 4;
                        DI3.Checked = (uint32 & 8) == 8;
                        DI4.Checked = (uint32 & 16) == 16;
                        DI5.Checked = (uint32 & 32) == 32;
                        DI6.Checked = (uint32 & 64) == 64;
                        DI7.Checked = (uint32 & 128) == 128;
                        DI8.Checked = (uint32 & 256) == 256;
                        DI9.Checked = (uint32 & 512) == 512;
                        DI10.Checked = (uint32 & 1024) == 1024;
                        DI11.Checked = (uint32 & 2048) == 2048;
                        DI12.Checked = (uint32 & 4096) == 4096;
                        DI13.Checked = (uint32 & 8192) == 8192;
                        DI14.Checked = (uint32 & 16384) == 16384;
                        DI15.Checked = (uint32 & 32768) == 32768;
                    }
                    if (slave2.GetDO(ref uint32))
                    {
                        DO0.Checked = (uint32 & 1) == 1;
                        DO1.Checked = (uint32 & 2) == 2;
                        DO2.Checked = (uint32 & 4) == 4;
                        DO3.Checked = (uint32 & 8) == 8;
                        DO4.Checked = (uint32 & 16) == 16;
                        DO5.Checked = (uint32 & 32) == 32;
                        DO6.Checked = (uint32 & 64) == 64;
                        DO7.Checked = (uint32 & 128) == 128;
                        DO8.Checked = (uint32 & 256) == 256;
                        DO9.Checked = (uint32 & 512) == 512;
                        DO10.Checked = (uint32 & 1024) == 1024;
                        DO11.Checked = (uint32 & 2048) == 2048;
                        DO12.Checked = (uint32 & 4096) == 4096;
                        DO13.Checked = (uint32 & 8192) == 8192;
                        DO14.Checked = (uint32 & 16384) == 16384;
                        DO15.Checked = (uint32 & 32768) == 32768;
                    }
                }
            }
        }

        private void ServoOnButton_Click(object sender, EventArgs e)
            => ((MotionSlave)MainDevice.SlaveItems[0]).AxisItems[0].ServoControl(true);

        private void ServoOff_Click(object sender, EventArgs e)
            => ((MotionSlave)MainDevice.SlaveItems[0]).AxisItems[0].ServoControl(false);

        private void MobeAbsButton_Click(object sender, EventArgs e)
        {
            if (sender is Control button)
            {
                button.Enabled = false;
                double position = Convert.ToDouble(AxisPositionTextBox.Text);
                double velocity = Convert.ToDouble(AxisVelTextBox.Text);
                ((MotionSlave)MainDevice.SlaveItems[0]).AxisItems[0].MoveAbs(position, velocity);
                button.Enabled = true;
            }
        }

        private void MoveRelButton_Click(object sender, EventArgs e)
        {
            if (sender is Control button)
            {
                button.Enabled = false;
                double position = Convert.ToDouble(AxisPositionTextBox.Text);
                double velocity = Convert.ToDouble(AxisVelTextBox.Text);
                ((MotionSlave)MainDevice.SlaveItems[0]).AxisItems[0].MoveRel(position, velocity);
                button.Enabled = true;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (sender is Control button)
            {
                button.Enabled = false;
                ((MotionSlave)MainDevice.SlaveItems[0]).AxisItems[0].AxisStop();
                button.Enabled = true;
            }
        }

        private void QuickStopButton_Click(object sender, EventArgs e)
        {
            if (sender is Control button)
            {
                button.Enabled = false;
                ((MotionSlave)MainDevice.SlaveItems[0]).AxisItems[0].AxisQuickStop();
                button.Enabled = true;
            }
        }

        private void DOSetButton_Click(object sender, EventArgs e)
        {
            uint uint32 = 0;

            if (MainDevice.SlaveItems[1] != null && MainDevice.SlaveItems[1] is IOSlave slave2)
            {
                if (DO0S.Checked)
                {
                    uint32 |= 1 << 0;
                }
                if (DO1S.Checked)
                {
                    uint32 |= 1 << 1;
                }
                if (DO2S.Checked)
                {
                    uint32 |= 1 << 2;
                }
                if (DO3S.Checked)
                {
                    uint32 |= 1 << 3;
                }
                if (DO4S.Checked)
                {
                    uint32 |= 1 << 4;
                }
                if (DO5S.Checked)
                {
                    uint32 |= 1 << 5;
                }
                if (DO6S.Checked)
                {
                    uint32 |= 1 << 6;
                }
                if (DO7S.Checked)
                {
                    uint32 |= 1 << 7;
                }
                if (DO8S.Checked)
                {
                    uint32 |= 1 << 8;
                }
                if (DO9S.Checked)
                {
                    uint32 |= 1 << 9;
                }
                if (DO10S.Checked)
                {
                    uint32 |= 1 << 10;
                }
                if (DO11S.Checked)
                {
                    uint32 |= 1 << 11;
                }
                if (DO12S.Checked)
                {
                    uint32 |= 1 << 12;
                }
                if (DO13S.Checked)
                {
                    uint32 |= 1 << 13;
                }
                if (DO14S.Checked)
                {
                    uint32 |= 1 << 14;
                }
                if (DO15S.Checked)
                {
                    uint32 |= 1 << 15;
                }
                slave2.SetDO(uint32);
            }
        }
    }
}
