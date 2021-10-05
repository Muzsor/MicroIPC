
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.LinkUpTextBox = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.SlavesRespTextBox = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.AlStateTextBox = new Sunny.UI.UITextBox();
            this.WorkingCounterTextBox = new Sunny.UI.UITextBox();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(3, 0);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(94, 37);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "連接狀態：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LinkUpTextBox
            // 
            this.LinkUpTextBox.ButtonSymbol = 61761;
            this.LinkUpTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.LinkUpTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LinkUpTextBox.FillColor = System.Drawing.Color.White;
            this.LinkUpTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.LinkUpTextBox.Location = new System.Drawing.Point(104, 5);
            this.LinkUpTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LinkUpTextBox.Maximum = 2147483647D;
            this.LinkUpTextBox.Minimum = -2147483648D;
            this.LinkUpTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.LinkUpTextBox.Name = "LinkUpTextBox";
            this.LinkUpTextBox.ReadOnly = true;
            this.LinkUpTextBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.LinkUpTextBox.Size = new System.Drawing.Size(92, 29);
            this.LinkUpTextBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.LinkUpTextBox.TabIndex = 1;
            this.LinkUpTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(3, 37);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(94, 37);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "從站數量：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SlavesRespTextBox
            // 
            this.SlavesRespTextBox.ButtonSymbol = 61761;
            this.SlavesRespTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SlavesRespTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SlavesRespTextBox.FillColor = System.Drawing.Color.White;
            this.SlavesRespTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.SlavesRespTextBox.Location = new System.Drawing.Point(104, 42);
            this.SlavesRespTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SlavesRespTextBox.Maximum = 2147483647D;
            this.SlavesRespTextBox.Minimum = -2147483648D;
            this.SlavesRespTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.SlavesRespTextBox.Name = "SlavesRespTextBox";
            this.SlavesRespTextBox.ReadOnly = true;
            this.SlavesRespTextBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.SlavesRespTextBox.Size = new System.Drawing.Size(92, 29);
            this.SlavesRespTextBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.SlavesRespTextBox.TabIndex = 3;
            this.SlavesRespTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(3, 74);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(94, 37);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "從站狀態：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(3, 111);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(94, 39);
            this.uiLabel4.TabIndex = 5;
            this.uiLabel4.Text = "工作計數：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AlStateTextBox
            // 
            this.AlStateTextBox.ButtonSymbol = 61761;
            this.AlStateTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.AlStateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlStateTextBox.FillColor = System.Drawing.Color.White;
            this.AlStateTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.AlStateTextBox.Location = new System.Drawing.Point(104, 79);
            this.AlStateTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AlStateTextBox.Maximum = 2147483647D;
            this.AlStateTextBox.Minimum = -2147483648D;
            this.AlStateTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.AlStateTextBox.Name = "AlStateTextBox";
            this.AlStateTextBox.ReadOnly = true;
            this.AlStateTextBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.AlStateTextBox.Size = new System.Drawing.Size(92, 29);
            this.AlStateTextBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.AlStateTextBox.TabIndex = 4;
            this.AlStateTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkingCounterTextBox
            // 
            this.WorkingCounterTextBox.ButtonSymbol = 61761;
            this.WorkingCounterTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.WorkingCounterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkingCounterTextBox.FillColor = System.Drawing.Color.White;
            this.WorkingCounterTextBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.WorkingCounterTextBox.Location = new System.Drawing.Point(104, 116);
            this.WorkingCounterTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorkingCounterTextBox.Maximum = 2147483647D;
            this.WorkingCounterTextBox.Minimum = -2147483648D;
            this.WorkingCounterTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.WorkingCounterTextBox.Name = "WorkingCounterTextBox";
            this.WorkingCounterTextBox.ReadOnly = true;
            this.WorkingCounterTextBox.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.WorkingCounterTextBox.Size = new System.Drawing.Size(92, 29);
            this.WorkingCounterTextBox.Style = Sunny.UI.UIStyle.Office2010Black;
            this.WorkingCounterTextBox.TabIndex = 5;
            this.WorkingCounterTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel1, 0, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.WorkingCounterTextBox, 1, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel2, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.AlStateTextBox, 1, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel3, 0, 2);
            this.uiTableLayoutPanel1.Controls.Add(this.SlavesRespTextBox, 1, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiLabel4, 0, 3);
            this.uiTableLayoutPanel1.Controls.Add(this.LinkUpTextBox, 1, 0);
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 4;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(200, 150);
            this.uiTableLayoutPanel1.TabIndex = 6;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox LinkUpTextBox;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox SlavesRespTextBox;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox AlStateTextBox;
        private Sunny.UI.UITextBox WorkingCounterTextBox;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
    }
}

