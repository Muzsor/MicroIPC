using MotionDemo.Properties;
using MotionDemo.Utils;

using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace Motion
{
    public partial class FormMain : Form
    {
        private readonly ushort DeviceCount;

        private readonly MotionController MainMotionController;

        public FormMain()
        {
            InitializeComponent();
            int resultCode = 0;
            //Text += $" DllVersion:{MotionController.GetVersion(ref resultCode)}";
            DeviceCount = MotionController.GetDeviceCount(new byte[16], ref resultCode);
            if (DeviceCount > 0)
            {
                MainMotionController = new MotionController(0); // CardId
                MainMotionController.DeviceStateChangeEvent += MainMotionController_DeviceStateChangeEvent;
                InitializeMotion();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainMotionController.SlaveItems != null && MainMotionController.SlaveItems[0].AxisItems != null)
            {
                MainMotionController.SlaveItems[0].AxisItems[0].AxisQuickStop();
                MainMotionController.SlaveItems[0].AxisItems[0].ServoControl(false);
            }
            int resultCode = 0;
            MainMotionController.StopOpTask(ref resultCode);
            MainMotionController.CloseDevice(ref resultCode);
        }

        private void MainMotionController_DeviceStateChangeEvent(object sender, DeviceStateChangeEventArgs e)
        {
            LinkUpTextBox.Text = e.IsLinkUp ? "Connect" : "DisConnect";
            SlavesRespTextBox.Text = e.SlavesResp.ToString();
            AlStateTextBox.Text = e.AlState.ToString();
            WorkingCounterTextBox.Text = e.WorkingCounter.ToString();
        }

        private void InitializeMotion()
        {
            int resultCode = 0;
            if (MainMotionController.InitializeSlave())
            {
                for (int i = 0; i < MainMotionController.SlaveItems.Length; i++)
                {
                    MotionSlave slave = MainMotionController.SlaveItems[i];
                    // Card 1
                    if (slave.SlaveName == Settings.Default.Card1Slave1Name)
                    {
                        ushort[] axisList = Settings.Default.Card1Slave1AxisList.Split(',').Select(s => (ushort)int.Parse(s)).ToArray();
                        if (slave.SetAxisNo(axisList, ref resultCode))
                        {
                            var listItem = new ListViewItem(slave.SlaveNo.ToString());  // 0
                            listItem.SubItems.Add(slave.Alias.ToString()); // 1
                            listItem.SubItems.Add(slave.SlaveName.ToString()); // 2
                            listItem.SubItems.Add(slave.SlaveType.ToString()); // 3
                            listItem.SubItems.Add(slave.AlState.ToString()); // 4
                            SlaveStateListView.Items.Add(listItem);
                        }
                    }
                }
                if (MainMotionController.InitMotionAxis())
                {
                    for (int i = 0; i < MainMotionController.SlaveItems.Length; i++)
                    {
                        MotionSlave slave = MainMotionController.SlaveItems[i];
                        var motionConfig = (MotionParam)ConfigurationManager.GetSection(nameof(MotionParam));
                        foreach (MotionAxis axis in MainMotionController.SlaveItems[i].AxisItems)
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
            Timer1.Tick += Timer1_Tick;
            Timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int resultCode = 0;
            MainMotionController.GetDeviceState(ref resultCode);
            for (int i = 0; i < MainMotionController.SlaveItems.Length; i++)
            {
                MotionSlave slave = MainMotionController.SlaveItems[i];
                if (slave.GetSlaveInfo() && SlaveStateListView.Items[0] != null)
                {
                    SlaveStateListView.Items[0].SubItems[4].Text = slave.AlState.ToString();
                }
                MotionAxis axis = MainMotionController.SlaveItems[i].AxisItems[0];
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
        }

        private void ServoOnButton_Click(object sender, EventArgs e)
            => MainMotionController.SlaveItems[0].AxisItems[0].ServoControl(true);

        private void ServoOff_Click(object sender, EventArgs e)
            => MainMotionController.SlaveItems[0].AxisItems[0].ServoControl(false);

        private void MobeAbsButton_Click(object sender, EventArgs e)
        {
            if (sender is Control button)
            {
                button.Enabled = false;
                double position = Convert.ToDouble(AxisPositionTextBox.Text);
                double velocity = Convert.ToDouble(AxisVelTextBox.Text);
                MainMotionController.SlaveItems[0].AxisItems[0].MoveAbs(position, velocity);
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
                MainMotionController.SlaveItems[0].AxisItems[0].MoveRel(position, velocity);
                button.Enabled = true;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            if (sender is Control button)
            {
                button.Enabled = false;
                MainMotionController.SlaveItems[0].AxisItems[0].AxisStop();
                button.Enabled = true;
            }
        }

        private void QuickStopButton_Click(object sender, EventArgs e)
        {
            if (sender is Control button)
            {
                button.Enabled = false;
                MainMotionController.SlaveItems[0].AxisItems[0].AxisQuickStop();
                button.Enabled = true;
            }
        }
    }
}
