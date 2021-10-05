using MotionDemo.Properties;

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

        }

        private void Init()
        {
            if (MainMotionController.StartOpTask() && MainMotionController.GetSlaveInfo())
            {
                foreach (MotionSlave slave in MainMotionController.SlaveItems)
                {
                    if (slave.SlaveName == Settings.Default.Card1Slave1Name)
                    {
                        slave.SetAxisNumber(Settings.Default.Card1Slave1Name.Length);
                    }
                }
                MainMotionController.InitMotion();
            }
        }
    }
}
