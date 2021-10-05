
namespace Motion
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PositionTextBox = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.LinkUpTextBox = new Sunny.UI.UITextBox();
            this.SlavesRespTextBox = new Sunny.UI.UITextBox();
            this.AlStateTextBox = new Sunny.UI.UITextBox();
            this.WorkingCounterTextBox = new Sunny.UI.UITextBox();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.SlaveStateListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            this.uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            this.AxisListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uiTitlePanel4 = new Sunny.UI.UITitlePanel();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.ServoOff = new Sunny.UI.UIButton();
            this.ServoOnButton = new Sunny.UI.UIButton();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.uiTitlePanel2.SuspendLayout();
            this.uiTitlePanel3.SuspendLayout();
            this.uiTitlePanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionTextBox
            // 
            this.PositionTextBox.ButtonSymbol = 61761;
            this.PositionTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PositionTextBox.FillColor = System.Drawing.Color.White;
            this.PositionTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.PositionTextBox.Location = new System.Drawing.Point(100, 124);
            this.PositionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PositionTextBox.Maximum = 2147483647D;
            this.PositionTextBox.Minimum = -2147483648D;
            this.PositionTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.PositionTextBox.Name = "PositionTextBox";
            this.PositionTextBox.Size = new System.Drawing.Size(189, 40);
            this.PositionTextBox.TabIndex = 0;
            this.PositionTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(92, 42);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "連接狀態：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(3, 42);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(92, 42);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "從站數量：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(3, 84);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(92, 42);
            this.uiLabel3.TabIndex = 3;
            this.uiLabel3.Text = "從站狀態：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(3, 126);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(92, 43);
            this.uiLabel4.TabIndex = 4;
            this.uiLabel4.Text = "工作計數：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(3, 123);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(90, 40);
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "Position：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LinkUpTextBox
            // 
            this.LinkUpTextBox.ButtonSymbol = 61761;
            this.LinkUpTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LinkUpTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LinkUpTextBox.FillColor = System.Drawing.Color.White;
            this.LinkUpTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.LinkUpTextBox.Location = new System.Drawing.Point(102, 5);
            this.LinkUpTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LinkUpTextBox.Maximum = 2147483647D;
            this.LinkUpTextBox.Minimum = -2147483648D;
            this.LinkUpTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.LinkUpTextBox.Name = "LinkUpTextBox";
            this.LinkUpTextBox.ReadOnly = true;
            this.LinkUpTextBox.Size = new System.Drawing.Size(141, 32);
            this.LinkUpTextBox.TabIndex = 6;
            this.LinkUpTextBox.TabStop = false;
            this.LinkUpTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlavesRespTextBox
            // 
            this.SlavesRespTextBox.ButtonSymbol = 61761;
            this.SlavesRespTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SlavesRespTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SlavesRespTextBox.FillColor = System.Drawing.Color.White;
            this.SlavesRespTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.SlavesRespTextBox.Location = new System.Drawing.Point(102, 47);
            this.SlavesRespTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SlavesRespTextBox.Maximum = 2147483647D;
            this.SlavesRespTextBox.Minimum = -2147483648D;
            this.SlavesRespTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.SlavesRespTextBox.Name = "SlavesRespTextBox";
            this.SlavesRespTextBox.ReadOnly = true;
            this.SlavesRespTextBox.Size = new System.Drawing.Size(141, 32);
            this.SlavesRespTextBox.TabIndex = 7;
            this.SlavesRespTextBox.TabStop = false;
            this.SlavesRespTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlStateTextBox
            // 
            this.AlStateTextBox.ButtonSymbol = 61761;
            this.AlStateTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AlStateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlStateTextBox.FillColor = System.Drawing.Color.White;
            this.AlStateTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.AlStateTextBox.Location = new System.Drawing.Point(102, 89);
            this.AlStateTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AlStateTextBox.Maximum = 2147483647D;
            this.AlStateTextBox.Minimum = -2147483648D;
            this.AlStateTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.AlStateTextBox.Name = "AlStateTextBox";
            this.AlStateTextBox.ReadOnly = true;
            this.AlStateTextBox.Size = new System.Drawing.Size(141, 32);
            this.AlStateTextBox.TabIndex = 8;
            this.AlStateTextBox.TabStop = false;
            this.AlStateTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkingCounterTextBox
            // 
            this.WorkingCounterTextBox.ButtonSymbol = 61761;
            this.WorkingCounterTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.WorkingCounterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingCounterTextBox.FillColor = System.Drawing.Color.White;
            this.WorkingCounterTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.WorkingCounterTextBox.Location = new System.Drawing.Point(102, 131);
            this.WorkingCounterTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorkingCounterTextBox.Maximum = 2147483647D;
            this.WorkingCounterTextBox.Minimum = -2147483648D;
            this.WorkingCounterTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.WorkingCounterTextBox.Name = "WorkingCounterTextBox";
            this.WorkingCounterTextBox.ReadOnly = true;
            this.WorkingCounterTextBox.Size = new System.Drawing.Size(141, 33);
            this.WorkingCounterTextBox.TabIndex = 9;
            this.WorkingCounterTextBox.TabStop = false;
            this.WorkingCounterTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.WorkingCounterTextBox, 1, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.AlStateTextBox, 1, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel3, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.SlavesRespTextBox, 1, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel4, 0, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.LinkUpTextBox, 1, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(8, 40);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 4;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(247, 169);
            this.uiTableLayoutPanel1.TabIndex = 10;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.uiTableLayoutPanel1);
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTitlePanel1.Location = new System.Drawing.Point(0, 363);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(0);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(8, 40, 8, 8);
            this.uiTitlePanel1.Size = new System.Drawing.Size(263, 217);
            this.uiTitlePanel1.TabIndex = 11;
            this.uiTitlePanel1.Text = "CardState";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlaveStateListView
            // 
            this.SlaveStateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.SlaveStateListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SlaveStateListView.HideSelection = false;
            this.SlaveStateListView.Location = new System.Drawing.Point(0, 50);
            this.SlaveStateListView.MultiSelect = false;
            this.SlaveStateListView.Name = "SlaveStateListView";
            this.SlaveStateListView.Size = new System.Drawing.Size(984, 130);
            this.SlaveStateListView.TabIndex = 12;
            this.SlaveStateListView.UseCompatibleStateImageBehavior = false;
            this.SlaveStateListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Slave Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "AlState";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "IsMcInitOk";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // uiTitlePanel2
            // 
            this.uiTitlePanel2.Controls.Add(this.SlaveStateListView);
            this.uiTitlePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTitlePanel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTitlePanel2.Location = new System.Drawing.Point(0, 0);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.uiTitlePanel2.Size = new System.Drawing.Size(984, 180);
            this.uiTitlePanel2.TabIndex = 13;
            this.uiTitlePanel2.Text = "SlaveState";
            this.uiTitlePanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTitlePanel3
            // 
            this.uiTitlePanel3.Controls.Add(this.AxisListView);
            this.uiTitlePanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTitlePanel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTitlePanel3.Location = new System.Drawing.Point(0, 180);
            this.uiTitlePanel3.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.uiTitlePanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel3.Name = "uiTitlePanel3";
            this.uiTitlePanel3.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.uiTitlePanel3.Size = new System.Drawing.Size(984, 180);
            this.uiTitlePanel3.TabIndex = 14;
            this.uiTitlePanel3.Text = "AxisState";
            this.uiTitlePanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AxisListView
            // 
            this.AxisListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.AxisListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxisListView.HideSelection = false;
            this.AxisListView.Location = new System.Drawing.Point(0, 50);
            this.AxisListView.MultiSelect = false;
            this.AxisListView.Name = "AxisListView";
            this.AxisListView.Size = new System.Drawing.Size(984, 130);
            this.AxisListView.TabIndex = 15;
            this.AxisListView.UseCompatibleStateImageBehavior = false;
            this.AxisListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "No";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Axis State";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Axis Error";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Drive Error";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "CmdPosition";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Position";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Velocity";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 120;
            // 
            // uiTitlePanel4
            // 
            this.uiTitlePanel4.Controls.Add(this.uiButton4);
            this.uiTitlePanel4.Controls.Add(this.uiLabel5);
            this.uiTitlePanel4.Controls.Add(this.PositionTextBox);
            this.uiTitlePanel4.Controls.Add(this.uiButton3);
            this.uiTitlePanel4.Controls.Add(this.uiButton2);
            this.uiTitlePanel4.Controls.Add(this.uiButton1);
            this.uiTitlePanel4.Controls.Add(this.ServoOff);
            this.uiTitlePanel4.Controls.Add(this.ServoOnButton);
            this.uiTitlePanel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTitlePanel4.Location = new System.Drawing.Point(268, 363);
            this.uiTitlePanel4.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.uiTitlePanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel4.Name = "uiTitlePanel4";
            this.uiTitlePanel4.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.uiTitlePanel4.Size = new System.Drawing.Size(716, 393);
            this.uiTitlePanel4.TabIndex = 16;
            this.uiTitlePanel4.Text = "ControlPanel";
            this.uiTitlePanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton4.Location = new System.Drawing.Point(169, 228);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Size = new System.Drawing.Size(120, 50);
            this.uiButton4.TabIndex = 23;
            this.uiButton4.Text = "QuickStop";
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton3.Location = new System.Drawing.Point(43, 228);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Size = new System.Drawing.Size(120, 50);
            this.uiButton3.TabIndex = 18;
            this.uiButton3.Text = "Stop";
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton2.Location = new System.Drawing.Point(169, 172);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(120, 50);
            this.uiButton2.TabIndex = 19;
            this.uiButton2.Text = "MovRel";
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiButton1.Location = new System.Drawing.Point(43, 172);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(120, 50);
            this.uiButton1.TabIndex = 20;
            this.uiButton1.Text = "MovAbs";
            // 
            // ServoOff
            // 
            this.ServoOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServoOff.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ServoOff.Location = new System.Drawing.Point(149, 40);
            this.ServoOff.MinimumSize = new System.Drawing.Size(1, 1);
            this.ServoOff.Name = "ServoOff";
            this.ServoOff.Size = new System.Drawing.Size(140, 80);
            this.ServoOff.TabIndex = 21;
            this.ServoOff.Text = "Servo Off";
            this.ServoOff.Click += new System.EventHandler(this.ServoOff_Click);
            // 
            // ServoOnButton
            // 
            this.ServoOnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServoOnButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ServoOnButton.Location = new System.Drawing.Point(3, 40);
            this.ServoOnButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.ServoOnButton.Name = "ServoOnButton";
            this.ServoOnButton.Size = new System.Drawing.Size(140, 80);
            this.ServoOnButton.TabIndex = 22;
            this.ServoOnButton.Text = "Servo On";
            this.ServoOnButton.Click += new System.EventHandler(this.ServoOnButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.uiTitlePanel4);
            this.Controls.Add(this.uiTitlePanel3);
            this.Controls.Add(this.uiTitlePanel2);
            this.Controls.Add(this.uiTitlePanel1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "MotionDemo";
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
            this.uiTitlePanel3.ResumeLayout(false);
            this.uiTitlePanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox PositionTextBox;
        private Sunny.UI.UILabel uiLabel1;        
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox LinkUpTextBox;
        private Sunny.UI.UITextBox SlavesRespTextBox;
        private Sunny.UI.UITextBox AlStateTextBox;
        private Sunny.UI.UITextBox WorkingCounterTextBox;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private System.Windows.Forms.ListView SlaveStateListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private System.Windows.Forms.ListView AxisListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private Sunny.UI.UITitlePanel uiTitlePanel4;
        private Sunny.UI.UIButton ServoOnButton;
        private Sunny.UI.UIButton ServoOff;                
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton4;
        private System.Windows.Forms.Timer Timer1;
    }
}

