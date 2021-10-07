
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
            this.AxisPositionTextBox = new Sunny.UI.UITextBox();
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
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.AxisVelTextBox = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.ErrorRestButton = new Sunny.UI.UIButton();
            this.QuickStopButton = new Sunny.UI.UIButton();
            this.StopButton = new Sunny.UI.UIButton();
            this.MoveRelButton = new Sunny.UI.UIButton();
            this.MobeAbsButton = new Sunny.UI.UIButton();
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
            // AxisPositionTextBox
            // 
            this.AxisPositionTextBox.ButtonSymbol = 61761;
            this.AxisPositionTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AxisPositionTextBox.FillColor = System.Drawing.Color.White;
            this.AxisPositionTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.AxisPositionTextBox.HasMaximum = true;
            this.AxisPositionTextBox.HasMinimum = true;
            this.AxisPositionTextBox.Location = new System.Drawing.Point(88, 171);
            this.AxisPositionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AxisPositionTextBox.Maximum = 2147483647D;
            this.AxisPositionTextBox.MaximumEnabled = true;
            this.AxisPositionTextBox.Minimum = -2147483648D;
            this.AxisPositionTextBox.MinimumEnabled = true;
            this.AxisPositionTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.AxisPositionTextBox.Name = "AxisPositionTextBox";
            this.AxisPositionTextBox.Size = new System.Drawing.Size(201, 40);
            this.AxisPositionTextBox.TabIndex = 0;
            this.AxisPositionTextBox.Text = "0";
            this.AxisPositionTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.AxisPositionTextBox.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.AxisPositionTextBox.Watermark = "命令位置";
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
            this.uiLabel5.Location = new System.Drawing.Point(9, 171);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(90, 40);
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "目標位置：";
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
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.SlaveStateListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SlaveStateListView.HideSelection = false;
            this.SlaveStateListView.Location = new System.Drawing.Point(0, 50);
            this.SlaveStateListView.MultiSelect = false;
            this.SlaveStateListView.Name = "SlaveStateListView";
            this.SlaveStateListView.Size = new System.Drawing.Size(934, 130);
            this.SlaveStateListView.TabIndex = 12;
            this.SlaveStateListView.UseCompatibleStateImageBehavior = false;
            this.SlaveStateListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "編號";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "別名";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名稱";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "種類";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "狀態";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 150;
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
            this.uiTitlePanel2.Size = new System.Drawing.Size(934, 180);
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
            this.uiTitlePanel3.Size = new System.Drawing.Size(934, 180);
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
            this.AxisListView.Size = new System.Drawing.Size(934, 130);
            this.AxisListView.TabIndex = 15;
            this.AxisListView.UseCompatibleStateImageBehavior = false;
            this.AxisListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "編號";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "狀態";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "最後異常代碼";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "驅動器異常代碼";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "命令位置";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "當前位置";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "速度";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 150;
            // 
            // uiTitlePanel4
            // 
            this.uiTitlePanel4.Controls.Add(this.AxisPositionTextBox);
            this.uiTitlePanel4.Controls.Add(this.AxisVelTextBox);
            this.uiTitlePanel4.Controls.Add(this.uiLabel6);
            this.uiTitlePanel4.Controls.Add(this.ErrorRestButton);
            this.uiTitlePanel4.Controls.Add(this.QuickStopButton);
            this.uiTitlePanel4.Controls.Add(this.uiLabel5);
            this.uiTitlePanel4.Controls.Add(this.StopButton);
            this.uiTitlePanel4.Controls.Add(this.MoveRelButton);
            this.uiTitlePanel4.Controls.Add(this.MobeAbsButton);
            this.uiTitlePanel4.Controls.Add(this.ServoOff);
            this.uiTitlePanel4.Controls.Add(this.ServoOnButton);
            this.uiTitlePanel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiTitlePanel4.Location = new System.Drawing.Point(268, 363);
            this.uiTitlePanel4.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.uiTitlePanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel4.Name = "uiTitlePanel4";
            this.uiTitlePanel4.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.uiTitlePanel4.Size = new System.Drawing.Size(666, 353);
            this.uiTitlePanel4.TabIndex = 16;
            this.uiTitlePanel4.Text = "ControlPanel";
            this.uiTitlePanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AxisVelTextBox
            // 
            this.AxisVelTextBox.ButtonSymbol = 61761;
            this.AxisVelTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AxisVelTextBox.DoubleValue = 150000D;
            this.AxisVelTextBox.Enabled = false;
            this.AxisVelTextBox.FillColor = System.Drawing.Color.White;
            this.AxisVelTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.AxisVelTextBox.HasMaximum = true;
            this.AxisVelTextBox.HasMinimum = true;
            this.AxisVelTextBox.IntValue = 150000;
            this.AxisVelTextBox.Location = new System.Drawing.Point(88, 126);
            this.AxisVelTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AxisVelTextBox.Maximum = 2147483647D;
            this.AxisVelTextBox.MaximumEnabled = true;
            this.AxisVelTextBox.Minimum = -2147483648D;
            this.AxisVelTextBox.MinimumEnabled = true;
            this.AxisVelTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.AxisVelTextBox.Name = "AxisVelTextBox";
            this.AxisVelTextBox.ReadOnly = true;
            this.AxisVelTextBox.Size = new System.Drawing.Size(201, 40);
            this.AxisVelTextBox.TabIndex = 3;
            this.AxisVelTextBox.Text = "150000";
            this.AxisVelTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.AxisVelTextBox.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.AxisVelTextBox.Watermark = "命令位置";
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(9, 126);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(68, 40);
            this.uiLabel6.TabIndex = 25;
            this.uiLabel6.Text = "速度：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrorRestButton
            // 
            this.ErrorRestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ErrorRestButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.ErrorRestButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(174)))), ((int)(((byte)(86)))));
            this.ErrorRestButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.ErrorRestButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.ErrorRestButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ErrorRestButton.Location = new System.Drawing.Point(295, 40);
            this.ErrorRestButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.ErrorRestButton.Name = "ErrorRestButton";
            this.ErrorRestButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.ErrorRestButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(174)))), ((int)(((byte)(86)))));
            this.ErrorRestButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.ErrorRestButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.ErrorRestButton.Size = new System.Drawing.Size(130, 60);
            this.ErrorRestButton.Style = Sunny.UI.UIStyle.Orange;
            this.ErrorRestButton.StyleCustomMode = true;
            this.ErrorRestButton.TabIndex = 24;
            this.ErrorRestButton.Text = "ErrorRest";
            // 
            // QuickStopButton
            // 
            this.QuickStopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuickStopButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.QuickStopButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.QuickStopButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.QuickStopButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.QuickStopButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.QuickStopButton.Location = new System.Drawing.Point(159, 285);
            this.QuickStopButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.QuickStopButton.Name = "QuickStopButton";
            this.QuickStopButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.QuickStopButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.QuickStopButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.QuickStopButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.QuickStopButton.Size = new System.Drawing.Size(130, 60);
            this.QuickStopButton.Style = Sunny.UI.UIStyle.Red;
            this.QuickStopButton.StyleCustomMode = true;
            this.QuickStopButton.TabIndex = 23;
            this.QuickStopButton.Text = "QuickStop";
            this.QuickStopButton.Click += new System.EventHandler(this.QuickStopButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.StopButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.StopButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.StopButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.StopButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.StopButton.Location = new System.Drawing.Point(13, 285);
            this.StopButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.StopButton.Name = "StopButton";
            this.StopButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.StopButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.StopButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.StopButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.StopButton.Size = new System.Drawing.Size(130, 60);
            this.StopButton.Style = Sunny.UI.UIStyle.Red;
            this.StopButton.StyleCustomMode = true;
            this.StopButton.TabIndex = 18;
            this.StopButton.Text = "Stop";
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MoveRelButton
            // 
            this.MoveRelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveRelButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.MoveRelButton.Location = new System.Drawing.Point(159, 219);
            this.MoveRelButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.MoveRelButton.Name = "MoveRelButton";
            this.MoveRelButton.Size = new System.Drawing.Size(130, 60);
            this.MoveRelButton.StyleCustomMode = true;
            this.MoveRelButton.TabIndex = 19;
            this.MoveRelButton.Text = "MoveRel";
            this.MoveRelButton.Click += new System.EventHandler(this.MoveRelButton_Click);
            // 
            // MobeAbsButton
            // 
            this.MobeAbsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MobeAbsButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.MobeAbsButton.Location = new System.Drawing.Point(13, 219);
            this.MobeAbsButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.MobeAbsButton.Name = "MobeAbsButton";
            this.MobeAbsButton.Size = new System.Drawing.Size(130, 60);
            this.MobeAbsButton.StyleCustomMode = true;
            this.MobeAbsButton.TabIndex = 20;
            this.MobeAbsButton.Text = "MobeAbs";
            this.MobeAbsButton.Click += new System.EventHandler(this.MobeAbsButton_Click);
            // 
            // ServoOff
            // 
            this.ServoOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServoOff.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ServoOff.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.ServoOff.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.ServoOff.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.ServoOff.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ServoOff.Location = new System.Drawing.Point(149, 40);
            this.ServoOff.MinimumSize = new System.Drawing.Size(1, 1);
            this.ServoOff.Name = "ServoOff";
            this.ServoOff.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ServoOff.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.ServoOff.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.ServoOff.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.ServoOff.Size = new System.Drawing.Size(140, 80);
            this.ServoOff.Style = Sunny.UI.UIStyle.Red;
            this.ServoOff.StyleCustomMode = true;
            this.ServoOff.TabIndex = 21;
            this.ServoOff.Text = "Servo Off";
            this.ServoOff.Click += new System.EventHandler(this.ServoOff_Click);
            // 
            // ServoOnButton
            // 
            this.ServoOnButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ServoOnButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.ServoOnButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.ServoOnButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ServoOnButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ServoOnButton.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ServoOnButton.Location = new System.Drawing.Point(3, 40);
            this.ServoOnButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.ServoOnButton.Name = "ServoOnButton";
            this.ServoOnButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.ServoOnButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.ServoOnButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ServoOnButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.ServoOnButton.Size = new System.Drawing.Size(140, 80);
            this.ServoOnButton.Style = Sunny.UI.UIStyle.Green;
            this.ServoOnButton.StyleCustomMode = true;
            this.ServoOnButton.TabIndex = 22;
            this.ServoOnButton.Text = "Servo On";
            this.ServoOnButton.Click += new System.EventHandler(this.ServoOnButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 717);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MotionDemo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
            this.uiTitlePanel3.ResumeLayout(false);
            this.uiTitlePanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox AxisPositionTextBox;
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
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
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
        private Sunny.UI.UIButton StopButton;
        private Sunny.UI.UIButton MoveRelButton;
        private Sunny.UI.UIButton MobeAbsButton;
        private Sunny.UI.UIButton QuickStopButton;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private Sunny.UI.UIButton ErrorRestButton;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox AxisVelTextBox;
    }
}

