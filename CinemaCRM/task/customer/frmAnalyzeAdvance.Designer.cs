namespace CinemaCRM.task.customer
{
    partial class frmAnalyzeAdvance
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
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties3 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties4 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties5 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties6 = new PresentationControls.CheckBoxProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalyzeAdvance));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbcGenre = new PresentationControls.CheckBoxComboBox();
            this.cbcType = new PresentationControls.CheckBoxComboBox();
            this.cbcTime = new PresentationControls.CheckBoxComboBox();
            this.cbcAge = new PresentationControls.CheckBoxComboBox();
            this.cbcArea = new PresentationControls.CheckBoxComboBox();
            this.cbcJob = new PresentationControls.CheckBoxComboBox();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCreateChart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartAnalyze = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbAnalyze = new System.Windows.Forms.ComboBox();
            this.cmbStatistic = new System.Windows.Forms.ComboBox();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnalyze)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbcGenre);
            this.groupBox1.Controls.Add(this.cbcType);
            this.groupBox1.Controls.Add(this.cbcTime);
            this.groupBox1.Controls.Add(this.cbcAge);
            this.groupBox1.Controls.Add(this.cbcArea);
            this.groupBox1.Controls.Add(this.cbcJob);
            this.groupBox1.Location = new System.Drawing.Point(6, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 127);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phân tích theo các tiêu chí";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(295, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Loại phim";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(295, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Giờ chiếu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(295, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Độ tuổi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Giới tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Khu vực";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nghề nghiệp";
            // 
            // cbcGenre
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcGenre.CheckBoxProperties = checkBoxProperties1;
            this.cbcGenre.DisplayMemberSingleItem = "";
            this.cbcGenre.FormattingEnabled = true;
            this.cbcGenre.Location = new System.Drawing.Point(98, 92);
            this.cbcGenre.Name = "cbcGenre";
            this.cbcGenre.Size = new System.Drawing.Size(175, 24);
            this.cbcGenre.TabIndex = 27;
            this.cbcGenre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cbcType
            // 
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcType.CheckBoxProperties = checkBoxProperties2;
            this.cbcType.DisplayMemberSingleItem = "";
            this.cbcType.FormattingEnabled = true;
            this.cbcType.Location = new System.Drawing.Point(383, 92);
            this.cbcType.Name = "cbcType";
            this.cbcType.Size = new System.Drawing.Size(175, 24);
            this.cbcType.TabIndex = 27;
            this.cbcType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cbcTime
            // 
            checkBoxProperties3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcTime.CheckBoxProperties = checkBoxProperties3;
            this.cbcTime.DisplayMemberSingleItem = "";
            this.cbcTime.FormattingEnabled = true;
            this.cbcTime.Location = new System.Drawing.Point(383, 58);
            this.cbcTime.Name = "cbcTime";
            this.cbcTime.Size = new System.Drawing.Size(175, 24);
            this.cbcTime.TabIndex = 27;
            this.cbcTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cbcAge
            // 
            checkBoxProperties4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcAge.CheckBoxProperties = checkBoxProperties4;
            this.cbcAge.DisplayMemberSingleItem = "";
            this.cbcAge.FormattingEnabled = true;
            this.cbcAge.Location = new System.Drawing.Point(383, 24);
            this.cbcAge.Name = "cbcAge";
            this.cbcAge.Size = new System.Drawing.Size(175, 24);
            this.cbcAge.TabIndex = 27;
            this.cbcAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cbcArea
            // 
            checkBoxProperties5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcArea.CheckBoxProperties = checkBoxProperties5;
            this.cbcArea.DisplayMemberSingleItem = "";
            this.cbcArea.FormattingEnabled = true;
            this.cbcArea.Location = new System.Drawing.Point(98, 58);
            this.cbcArea.Name = "cbcArea";
            this.cbcArea.Size = new System.Drawing.Size(175, 24);
            this.cbcArea.TabIndex = 27;
            this.cbcArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cbcJob
            // 
            checkBoxProperties6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcJob.CheckBoxProperties = checkBoxProperties6;
            this.cbcJob.DisplayMemberSingleItem = "";
            this.cbcJob.FormattingEnabled = true;
            this.cbcJob.Location = new System.Drawing.Point(98, 24);
            this.cbcJob.Name = "cbcJob";
            this.cbcJob.Size = new System.Drawing.Size(175, 24);
            this.cbcJob.TabIndex = 27;
            this.cbcJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTime.Location = new System.Drawing.Point(11, 92);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(138, 20);
            this.chkTime.TabIndex = 28;
            this.chkTime.Text = "Thời gian làm nhãn";
            this.chkTime.UseVisualStyleBackColor = true;
            this.chkTime.CheckStateChanged += new System.EventHandler(this.chkTime_CheckStateChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Checked = false;
            this.dtpEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(81, 58);
            this.dtpEnd.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(118, 22);
            this.dtpEnd.TabIndex = 26;
            // 
            // dtpStart
            // 
            this.dtpStart.Checked = false;
            this.dtpStart.CustomFormat = "dd/MM/yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(81, 26);
            this.dtpStart.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(118, 22);
            this.dtpStart.TabIndex = 25;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Đến ngày";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(12, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Từ ngày";
            // 
            // btnCreateChart
            // 
            this.btnCreateChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateChart.ForeColor = System.Drawing.Color.Navy;
            this.btnCreateChart.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateChart.Image")));
            this.btnCreateChart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateChart.Location = new System.Drawing.Point(722, 142);
            this.btnCreateChart.Name = "btnCreateChart";
            this.btnCreateChart.Size = new System.Drawing.Size(120, 35);
            this.btnCreateChart.TabIndex = 2;
            this.btnCreateChart.Text = "&Lập biểu đồ";
            this.btnCreateChart.UseVisualStyleBackColor = true;
            this.btnCreateChart.Click += new System.EventHandler(this.btnCreateChart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chartAnalyze);
            this.groupBox2.Location = new System.Drawing.Point(6, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(836, 426);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Biểu đồ";
            // 
            // chartAnalyze
            // 
            this.chartAnalyze.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "chartArea";
            this.chartAnalyze.ChartAreas.Add(chartArea1);
            this.chartAnalyze.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend";
            this.chartAnalyze.Legends.Add(legend1);
            this.chartAnalyze.Location = new System.Drawing.Point(3, 18);
            this.chartAnalyze.Name = "chartAnalyze";
            series1.ChartArea = "chartArea";
            series1.Legend = "Legend";
            series1.Name = "series";
            this.chartAnalyze.Series.Add(series1);
            this.chartAnalyze.Size = new System.Drawing.Size(830, 405);
            this.chartAnalyze.TabIndex = 7;
            this.chartAnalyze.Text = "Biểu đồ";
            // 
            // cmbAnalyze
            // 
            this.cmbAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAnalyze.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnalyze.FormattingEnabled = true;
            this.cmbAnalyze.Items.AddRange(new object[] {
            "Nghề nghiệp",
            "Khu vực",
            "Loại phim",
            "Khung giờ chiếu",
            "Độ tuổi",
            "Tháng",
            "Quý",
            "Năm"});
            this.cmbAnalyze.Location = new System.Drawing.Point(311, 147);
            this.cmbAnalyze.Name = "cmbAnalyze";
            this.cmbAnalyze.Size = new System.Drawing.Size(128, 24);
            this.cmbAnalyze.TabIndex = 9;
            this.cmbAnalyze.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cmbStatistic
            // 
            this.cmbStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatistic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatistic.FormattingEnabled = true;
            this.cmbStatistic.Items.AddRange(new object[] {
            "Tổng doanh thu",
            "Tần suất mua vé",
            "Tần suất xem lại"});
            this.cmbStatistic.Location = new System.Drawing.Point(448, 147);
            this.cmbStatistic.Name = "cmbStatistic";
            this.cmbStatistic.Size = new System.Drawing.Size(128, 24);
            this.cmbStatistic.TabIndex = 8;
            this.cmbStatistic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cmbChartType
            // 
            this.cmbChartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Items.AddRange(new object[] {
            "Biểu đồ tròn",
            "Biểu đồ đường",
            "Biểu đồ cột"});
            this.cmbChartType.Location = new System.Drawing.Point(585, 147);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(128, 24);
            this.cmbChartType.TabIndex = 7;
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.cmbChartType_SelectedIndexChanged);
            this.cmbChartType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // cmbTime
            // 
            this.cmbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(172, 147);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(130, 24);
            this.cmbTime.TabIndex = 12;
            this.cmbTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkTime);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Controls.Add(this.dtpEnd);
            this.groupBox3.Location = new System.Drawing.Point(582, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 127);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Phân tích theo thời gian";
            // 
            // frmAnalyzeAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 612);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmbTime);
            this.Controls.Add(this.cmbAnalyze);
            this.Controls.Add(this.cmbStatistic);
            this.Controls.Add(this.cmbChartType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreateChart);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAnalyzeAdvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân tích dữ liệu cao cấp";
            this.Load += new System.EventHandler(this.frmAnalyzeAdvance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAnalyze)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreateChart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnalyze;
        private System.Windows.Forms.ComboBox cmbStatistic;
        private System.Windows.Forms.ComboBox cmbChartType;
        private PresentationControls.CheckBoxComboBox cbcGenre;
        private PresentationControls.CheckBoxComboBox cbcType;
        private PresentationControls.CheckBoxComboBox cbcTime;
        private PresentationControls.CheckBoxComboBox cbcAge;
        private PresentationControls.CheckBoxComboBox cbcArea;
        private PresentationControls.CheckBoxComboBox cbcJob;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.CheckBox chkTime;
        private System.Windows.Forms.ComboBox cmbAnalyze;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;


    }
}