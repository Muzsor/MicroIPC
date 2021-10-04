using System.Windows.Forms;

namespace Motion
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            MotionController.GetDeviceCount(new byte[16]);
        }
    }
}
