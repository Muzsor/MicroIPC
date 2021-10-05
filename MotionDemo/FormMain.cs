using MotionDemo.Properties;

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
            DeviceCount = MotionController.GetDeviceCount(new byte[16]);
            MainMotionController = new MotionController(0);
            MainMotionController.DeviceStateChangeEvent += MainMotionController_DeviceStateChangeEvent;
            if (MainMotionController.OpenDevice())
            {
                Init();
            }
        }

        private void MainMotionController_DeviceStateChangeEvent(object sender, DeviceStateChangeEventArgs e)
        {
            LinkUpTextBox.Text = e.IsLinkUp ? "Connect" : "DisConnect";
            SlavesRespTextBox.Text = e.SlavesResp.ToString();
            AlStateTextBox.Text = e.AlState.ToString();
            WorkingCounterTextBox.Text = e.WorkingCounter.ToString();
        }

        private void Init()
        {
            if (MainMotionController.StartOpTask() && MainMotionController.GetSlaveInfo())
            {
                for (int i = 0; i < MainMotionController.SlaveItems.Length; i++)
                {
                    var slave = MainMotionController.SlaveItems[i];
                    if (slave.SlaveName == Settings.Default.Card1Slave1Name)
                    {
                        ushort[] axisList = Settings.Default.Card1Slave1.Split(',').Select(s => (ushort)int.Parse(s)).ToArray();
                        MainMotionController.SetAxisToSlave(ref slave, axisList);
                        // 
                        var listItem = new ListViewItem();
                        listItem.SubItems.Add(slave.SlaveNo.ToString());
                        listItem.SubItems.Add(slave.SlaveName.ToString());
                        listItem.SubItems.Add(slave.AlState.ToString());
                        listItem.SubItems.Add(slave.IsMcInitOk.ToString());
                        SlaveStateListView.Items.Add(listItem);
                        SlaveStateListView.Items[0].SubItems[2].Text = slave.AlState.ToString();
                    }
                }
                if (MainMotionController.InitMotion())
                {
                    for (int i = 0; i < MainMotionController.SlaveItems.Length; i++)
                    {
                        var slave = MainMotionController.SlaveItems[i];
                        var motionConfig = (MotionParam)ConfigurationManager.GetSection(nameof(MotionParam));
                        foreach (MotionAxis axis in MainMotionController.SlaveItems[i].AxisItems)
                        {
                            MainMotionController.SetAxisParam(ref slave, axis.AxisNo, motionConfig);
                            //
                            var listItem = new ListViewItem();
                            listItem.SubItems.Add(axis.AxisNo.ToString()); // Axis No
                            listItem.SubItems.Add(axis.AxisState.ToString()); // Axis State
                            listItem.SubItems.Add(string.Empty); // Axis Error
                            listItem.SubItems.Add(string.Empty); // Drive Error
                            listItem.SubItems.Add(string.Empty); // CmdPosition
                            listItem.SubItems.Add(string.Empty); // Position
                            listItem.SubItems.Add(string.Empty); // Velocity
                            AxisListView.Items.Add(listItem);
                        }
                        SlaveStateListView.Items[0].SubItems[2].Text = MainMotionController.SlaveItems[i].AlState.ToString();
                    }
                }
            }
            Timer1.Tick += Timer1_Tick;
            Timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            MainMotionController.GetDeviceState();
            int resultCode = 0;
            for (int i = 0; i < MainMotionController.SlaveItems.Length; i++)
            {
                MotionAxis axis = MainMotionController.SlaveItems[i].AxisItems[0];
                MainMotionController.GetAxisState(ref MainMotionController.SlaveItems[i], ref axis, ref resultCode);
                // TODO
                AxisListView.Items[0].SubItems[1].Text = axis.AxisState.ToString();
            }
        }

        private void ServoOnButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
