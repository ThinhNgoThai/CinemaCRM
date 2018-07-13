namespace CinemaCRM.Reports
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbnRpt1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStore = new System.Windows.Forms.ComboBox();
            this.rbnRpt2 = new System.Windows.Forms.RadioButton();
            this.rbnRpt4 = new System.Windows.Forms.RadioButton();
            this.rbnRpt3 = new System.Windows.Forms.RadioButton();
            this.dtpRpt1Day = new System.Windows.Forms.DateTimePicker();
            this.grb1 = new System.Windows.Forms.GroupBox();
            this.dtpRpt1Month = new System.Windows.Forms.DateTimePicker();
            this.rbnMonth = new System.Windows.Forms.RadioButton();
            this.rbnDay = new System.Windows.Forms.RadioButton();
            this.grb2 = new System.Windows.Forms.GroupBox();
            this.cboCampaign = new System.Windows.Forms.ComboBox();
            this.dtpRpt2Day = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.grb4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpUseRewardTo = new System.Windows.Forms.DateTimePicker();
            this.dtpUseRewardFrom = new System.Windows.Forms.DateTimePicker();
            this.grb1.SuspendLayout();
            this.grb2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grb4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbnRpt1
            // 
            this.rbnRpt1.AutoSize = true;
            this.rbnRpt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnRpt1.ForeColor = System.Drawing.Color.Red;
            this.rbnRpt1.Location = new System.Drawing.Point(24, 89);
            this.rbnRpt1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnRpt1.Name = "rbnRpt1";
            this.rbnRpt1.Size = new System.Drawing.Size(498, 29);
            this.rbnRpt1.TabIndex = 0;
            this.rbnRpt1.TabStop = true;
            this.rbnRpt1.Text = "Báo cáo sô lượng khán giả theo khung giờ chiếu";
            this.rbnRpt1.UseVisualStyleBackColor = true;
            this.rbnRpt1.CheckedChanged += new System.EventHandler(this.rbnRpt1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(20, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 48;
            this.label2.Text = "Rạp chiếu";
            // 
            // cboStore
            // 
            this.cboStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStore.FormattingEnabled = true;
            this.cboStore.Location = new System.Drawing.Point(144, 18);
            this.cboStore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboStore.Name = "cboStore";
            this.cboStore.Size = new System.Drawing.Size(454, 33);
            this.cboStore.TabIndex = 47;
            // 
            // rbnRpt2
            // 
            this.rbnRpt2.AutoSize = true;
            this.rbnRpt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnRpt2.ForeColor = System.Drawing.Color.Red;
            this.rbnRpt2.Location = new System.Drawing.Point(24, 231);
            this.rbnRpt2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnRpt2.Name = "rbnRpt2";
            this.rbnRpt2.Size = new System.Drawing.Size(434, 29);
            this.rbnRpt2.TabIndex = 49;
            this.rbnRpt2.TabStop = true;
            this.rbnRpt2.Text = "Báo cáo kết quả chương trình khuyến mại";
            this.rbnRpt2.UseVisualStyleBackColor = true;
            this.rbnRpt2.CheckedChanged += new System.EventHandler(this.rbnRpt2_CheckedChanged);
            // 
            // rbnRpt4
            // 
            this.rbnRpt4.AutoSize = true;
            this.rbnRpt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnRpt4.ForeColor = System.Drawing.Color.Red;
            this.rbnRpt4.Location = new System.Drawing.Point(24, 486);
            this.rbnRpt4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnRpt4.Name = "rbnRpt4";
            this.rbnRpt4.Size = new System.Drawing.Size(334, 29);
            this.rbnRpt4.TabIndex = 51;
            this.rbnRpt4.TabStop = true;
            this.rbnRpt4.Text = "Báo cáo điểm thưởng, điểm thẻ";
            this.rbnRpt4.UseVisualStyleBackColor = true;
            this.rbnRpt4.CheckedChanged += new System.EventHandler(this.rbnRpt4_CheckedChanged);
            // 
            // rbnRpt3
            // 
            this.rbnRpt3.AutoSize = true;
            this.rbnRpt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnRpt3.ForeColor = System.Drawing.Color.Red;
            this.rbnRpt3.Location = new System.Drawing.Point(24, 429);
            this.rbnRpt3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnRpt3.Name = "rbnRpt3";
            this.rbnRpt3.Size = new System.Drawing.Size(323, 29);
            this.rbnRpt3.TabIndex = 52;
            this.rbnRpt3.TabStop = true;
            this.rbnRpt3.Text = "Báo cáo thông tin khách hàng";
            this.rbnRpt3.UseVisualStyleBackColor = true;
            // 
            // dtpRpt1Day
            // 
            this.dtpRpt1Day.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dtpRpt1Day.CustomFormat = "dd-MM-yyyy";
            this.dtpRpt1Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRpt1Day.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRpt1Day.Location = new System.Drawing.Point(117, 20);
            this.dtpRpt1Day.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpRpt1Day.Name = "dtpRpt1Day";
            this.dtpRpt1Day.Size = new System.Drawing.Size(158, 30);
            this.dtpRpt1Day.TabIndex = 46;
            // 
            // grb1
            // 
            this.grb1.Controls.Add(this.dtpRpt1Month);
            this.grb1.Controls.Add(this.rbnMonth);
            this.grb1.Controls.Add(this.rbnDay);
            this.grb1.Controls.Add(this.dtpRpt1Day);
            this.grb1.Location = new System.Drawing.Point(24, 122);
            this.grb1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grb1.Name = "grb1";
            this.grb1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grb1.Size = new System.Drawing.Size(687, 83);
            this.grb1.TabIndex = 58;
            this.grb1.TabStop = false;
            // 
            // dtpRpt1Month
            // 
            this.dtpRpt1Month.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dtpRpt1Month.CustomFormat = "MM-yyyy";
            this.dtpRpt1Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRpt1Month.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRpt1Month.Location = new System.Drawing.Point(422, 20);
            this.dtpRpt1Month.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpRpt1Month.Name = "dtpRpt1Month";
            this.dtpRpt1Month.Size = new System.Drawing.Size(158, 30);
            this.dtpRpt1Month.TabIndex = 56;
            // 
            // rbnMonth
            // 
            this.rbnMonth.AutoSize = true;
            this.rbnMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnMonth.ForeColor = System.Drawing.Color.Navy;
            this.rbnMonth.Location = new System.Drawing.Point(322, 25);
            this.rbnMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnMonth.Name = "rbnMonth";
            this.rbnMonth.Size = new System.Drawing.Size(87, 26);
            this.rbnMonth.TabIndex = 56;
            this.rbnMonth.TabStop = true;
            this.rbnMonth.Text = "Tháng";
            this.rbnMonth.UseVisualStyleBackColor = true;
            this.rbnMonth.CheckedChanged += new System.EventHandler(this.rbnMonth_CheckedChanged);
            // 
            // rbnDay
            // 
            this.rbnDay.AutoSize = true;
            this.rbnDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnDay.ForeColor = System.Drawing.Color.Navy;
            this.rbnDay.Location = new System.Drawing.Point(28, 25);
            this.rbnDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbnDay.Name = "rbnDay";
            this.rbnDay.Size = new System.Drawing.Size(77, 26);
            this.rbnDay.TabIndex = 55;
            this.rbnDay.TabStop = true;
            this.rbnDay.Text = "Ngày";
            this.rbnDay.UseVisualStyleBackColor = true;
            this.rbnDay.CheckedChanged += new System.EventHandler(this.rbnDay_CheckedChanged);
            // 
            // grb2
            // 
            this.grb2.Controls.Add(this.cboCampaign);
            this.grb2.Controls.Add(this.dtpRpt2Day);
            this.grb2.Controls.Add(this.label10);
            this.grb2.Controls.Add(this.label7);
            this.grb2.Location = new System.Drawing.Point(24, 271);
            this.grb2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grb2.Name = "grb2";
            this.grb2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grb2.Size = new System.Drawing.Size(687, 128);
            this.grb2.TabIndex = 59;
            this.grb2.TabStop = false;
            // 
            // cboCampaign
            // 
            this.cboCampaign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampaign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCampaign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cboCampaign.FormattingEnabled = true;
            this.cboCampaign.Location = new System.Drawing.Point(258, 68);
            this.cboCampaign.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCampaign.Name = "cboCampaign";
            this.cboCampaign.Size = new System.Drawing.Size(392, 33);
            this.cboCampaign.TabIndex = 55;
            // 
            // dtpRpt2Day
            // 
            this.dtpRpt2Day.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dtpRpt2Day.CustomFormat = "dd-MM-yyyy";
            this.dtpRpt2Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRpt2Day.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRpt2Day.Location = new System.Drawing.Point(258, 25);
            this.dtpRpt2Day.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpRpt2Day.Name = "dtpRpt2Day";
            this.dtpRpt2Day.Size = new System.Drawing.Size(158, 30);
            this.dtpRpt2Day.TabIndex = 46;
            this.dtpRpt2Day.Leave += new System.EventHandler(this.dtpRpt2Day_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(14, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 25);
            this.label10.TabIndex = 45;
            this.label10.Text = "Thời gian thực hiện";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(14, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 25);
            this.label7.TabIndex = 53;
            this.label7.Text = "Chương trình khuyến mại";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 649);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 66);
            this.panel1.TabIndex = 60;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(586, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(158, 54);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Th&oát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.Red;
            this.btnExportExcel.Location = new System.Drawing.Point(339, 6);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(236, 54);
            this.btnExportExcel.TabIndex = 7;
            this.btnExportExcel.Text = "&Xuất file Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // grb4
            // 
            this.grb4.Controls.Add(this.label3);
            this.grb4.Controls.Add(this.label1);
            this.grb4.Controls.Add(this.dtpUseRewardTo);
            this.grb4.Controls.Add(this.dtpUseRewardFrom);
            this.grb4.Location = new System.Drawing.Point(24, 540);
            this.grb4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grb4.Name = "grb4";
            this.grb4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grb4.Size = new System.Drawing.Size(687, 83);
            this.grb4.TabIndex = 61;
            this.grb4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(310, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 22);
            this.label3.TabIndex = 49;
            this.label3.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 22);
            this.label1.TabIndex = 48;
            this.label1.Text = "Từ ngày";
            // 
            // dtpUseRewardTo
            // 
            this.dtpUseRewardTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dtpUseRewardTo.CustomFormat = "dd-MM-yyyy";
            this.dtpUseRewardTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpUseRewardTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUseRewardTo.Location = new System.Drawing.Point(414, 29);
            this.dtpUseRewardTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpUseRewardTo.Name = "dtpUseRewardTo";
            this.dtpUseRewardTo.Size = new System.Drawing.Size(158, 30);
            this.dtpUseRewardTo.TabIndex = 47;
            // 
            // dtpUseRewardFrom
            // 
            this.dtpUseRewardFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dtpUseRewardFrom.CustomFormat = "dd-MM-yyyy";
            this.dtpUseRewardFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpUseRewardFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUseRewardFrom.Location = new System.Drawing.Point(102, 29);
            this.dtpUseRewardFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpUseRewardFrom.Name = "dtpUseRewardFrom";
            this.dtpUseRewardFrom.Size = new System.Drawing.Size(158, 30);
            this.dtpUseRewardFrom.TabIndex = 46;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 715);
            this.Controls.Add(this.grb4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grb2);
            this.Controls.Add(this.grb1);
            this.Controls.Add(this.rbnRpt3);
            this.Controls.Add(this.rbnRpt4);
            this.Controls.Add(this.rbnRpt2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStore);
            this.Controls.Add(this.rbnRpt1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.grb1.ResumeLayout(false);
            this.grb1.PerformLayout();
            this.grb2.ResumeLayout(false);
            this.grb2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grb4.ResumeLayout(false);
            this.grb4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnRpt1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStore;
        private System.Windows.Forms.RadioButton rbnRpt2;
        private System.Windows.Forms.RadioButton rbnRpt4;
        private System.Windows.Forms.RadioButton rbnRpt3;
        private System.Windows.Forms.DateTimePicker dtpRpt1Day;
        private System.Windows.Forms.GroupBox grb1;
        private System.Windows.Forms.RadioButton rbnMonth;
        private System.Windows.Forms.RadioButton rbnDay;
        private System.Windows.Forms.GroupBox grb2;
        private System.Windows.Forms.ComboBox cboCampaign;
        private System.Windows.Forms.DateTimePicker dtpRpt2Day;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox grb4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpUseRewardTo;
        private System.Windows.Forms.DateTimePicker dtpUseRewardFrom;
        private System.Windows.Forms.DateTimePicker dtpRpt1Month;
    }
}