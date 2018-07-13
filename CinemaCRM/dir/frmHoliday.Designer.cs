namespace CinemaCRM.dir
{
    partial class frmHoliday
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoliday));
            this.cbxDateType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxYear = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.dtpSelectDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkChristmas = new System.Windows.Forms.CheckBox();
            this.chkNationalDay = new System.Windows.Forms.CheckBox();
            this.chkLaborDay = new System.Windows.Forms.CheckBox();
            this.chkFreedomDay = new System.Windows.Forms.CheckBox();
            this.chkWomenDay = new System.Windows.Forms.CheckBox();
            this.chkValentine = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.grDateInYear = new System.Windows.Forms.DataGridView();
            this.colDateValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDayInWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDateCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grDateInYear)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxDateType
            // 
            this.cbxDateType.AllowDrop = true;
            this.cbxDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDateType.FormattingEnabled = true;
            this.cbxDateType.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbxDateType.Location = new System.Drawing.Point(255, 15);
            this.cbxDateType.Name = "cbxDateType";
            this.cbxDateType.Size = new System.Drawing.Size(196, 24);
            this.cbxDateType.TabIndex = 1;
            this.cbxDateType.SelectedIndexChanged += new System.EventHandler(this.cbxDateType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(186, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 61;
            this.label4.Text = "Loại ngày";
            // 
            // cbxYear
            // 
            this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYear.FormattingEnabled = true;
            this.cbxYear.Location = new System.Drawing.Point(77, 12);
            this.cbxYear.Name = "cbxYear";
            this.cbxYear.Size = new System.Drawing.Size(103, 24);
            this.cbxYear.TabIndex = 0;
            this.cbxYear.SelectedIndexChanged += new System.EventHandler(this.cbxYear_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 16);
            this.label5.TabIndex = 63;
            this.label5.Text = "Năm";
            // 
            // grpUpdate
            // 
            this.grpUpdate.Controls.Add(this.dtpSelectDate);
            this.grpUpdate.Controls.Add(this.label3);
            this.grpUpdate.Controls.Add(this.label2);
            this.grpUpdate.Controls.Add(this.label1);
            this.grpUpdate.Controls.Add(this.chkChristmas);
            this.grpUpdate.Controls.Add(this.chkNationalDay);
            this.grpUpdate.Controls.Add(this.chkLaborDay);
            this.grpUpdate.Controls.Add(this.chkFreedomDay);
            this.grpUpdate.Controls.Add(this.chkWomenDay);
            this.grpUpdate.Controls.Add(this.chkValentine);
            this.grpUpdate.Controls.Add(this.chkSunday);
            this.grpUpdate.Controls.Add(this.chkSaturday);
            this.grpUpdate.Controls.Add(this.chkFriday);
            this.grpUpdate.Controls.Add(this.chkThursday);
            this.grpUpdate.Controls.Add(this.chkWednesday);
            this.grpUpdate.Controls.Add(this.chkTuesday);
            this.grpUpdate.Controls.Add(this.chkMonday);
            this.grpUpdate.Enabled = false;
            this.grpUpdate.Location = new System.Drawing.Point(457, 69);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(297, 354);
            this.grpUpdate.TabIndex = 6;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Chọn áp dụng hàng loạt";
            // 
            // dtpSelectDate
            // 
            this.dtpSelectDate.Checked = false;
            this.dtpSelectDate.CustomFormat = "dd-MM-yyyy";
            this.dtpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSelectDate.Location = new System.Drawing.Point(10, 257);
            this.dtpSelectDate.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpSelectDate.Name = "dtpSelectDate";
            this.dtpSelectDate.ShowCheckBox = true;
            this.dtpSelectDate.Size = new System.Drawing.Size(118, 22);
            this.dtpSelectDate.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "3.Ngày cụ thể khác";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "2.Ngày đặc biệt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "1.Ngày trong tuần";
            // 
            // chkChristmas
            // 
            this.chkChristmas.AutoSize = true;
            this.chkChristmas.Location = new System.Drawing.Point(195, 197);
            this.chkChristmas.Name = "chkChristmas";
            this.chkChristmas.Size = new System.Drawing.Size(95, 20);
            this.chkChristmas.TabIndex = 12;
            this.chkChristmas.Text = "Ngày 24-12";
            this.chkChristmas.UseVisualStyleBackColor = true;
            // 
            // chkNationalDay
            // 
            this.chkNationalDay.AutoSize = true;
            this.chkNationalDay.Location = new System.Drawing.Point(102, 197);
            this.chkNationalDay.Name = "chkNationalDay";
            this.chkNationalDay.Size = new System.Drawing.Size(81, 20);
            this.chkNationalDay.TabIndex = 11;
            this.chkNationalDay.Text = "Ngày 2-9";
            this.chkNationalDay.UseVisualStyleBackColor = true;
            // 
            // chkLaborDay
            // 
            this.chkLaborDay.AutoSize = true;
            this.chkLaborDay.Location = new System.Drawing.Point(9, 197);
            this.chkLaborDay.Name = "chkLaborDay";
            this.chkLaborDay.Size = new System.Drawing.Size(81, 20);
            this.chkLaborDay.TabIndex = 10;
            this.chkLaborDay.Text = "Ngày 1-5";
            this.chkLaborDay.UseVisualStyleBackColor = true;
            // 
            // chkFreedomDay
            // 
            this.chkFreedomDay.AutoSize = true;
            this.chkFreedomDay.Location = new System.Drawing.Point(195, 171);
            this.chkFreedomDay.Name = "chkFreedomDay";
            this.chkFreedomDay.Size = new System.Drawing.Size(88, 20);
            this.chkFreedomDay.TabIndex = 9;
            this.chkFreedomDay.Text = "Ngày 30-4";
            this.chkFreedomDay.UseVisualStyleBackColor = true;
            // 
            // chkWomenDay
            // 
            this.chkWomenDay.AutoSize = true;
            this.chkWomenDay.Location = new System.Drawing.Point(102, 171);
            this.chkWomenDay.Name = "chkWomenDay";
            this.chkWomenDay.Size = new System.Drawing.Size(81, 20);
            this.chkWomenDay.TabIndex = 8;
            this.chkWomenDay.Text = "Ngày 8-3";
            this.chkWomenDay.UseVisualStyleBackColor = true;
            // 
            // chkValentine
            // 
            this.chkValentine.AutoSize = true;
            this.chkValentine.Location = new System.Drawing.Point(9, 171);
            this.chkValentine.Name = "chkValentine";
            this.chkValentine.Size = new System.Drawing.Size(88, 20);
            this.chkValentine.TabIndex = 7;
            this.chkValentine.Text = "Ngày 14-2";
            this.chkValentine.UseVisualStyleBackColor = true;
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(195, 111);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(78, 20);
            this.chkSunday.TabIndex = 6;
            this.chkSunday.Text = "Chủ nhật";
            this.chkSunday.UseVisualStyleBackColor = true;
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(102, 111);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(60, 20);
            this.chkSaturday.TabIndex = 5;
            this.chkSaturday.Text = "Thứ 7";
            this.chkSaturday.UseVisualStyleBackColor = true;
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(9, 111);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(60, 20);
            this.chkFriday.TabIndex = 4;
            this.chkFriday.Text = "Thứ 6";
            this.chkFriday.UseVisualStyleBackColor = true;
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(102, 85);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(60, 20);
            this.chkThursday.TabIndex = 3;
            this.chkThursday.Text = "Thứ 5";
            this.chkThursday.UseVisualStyleBackColor = true;
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(9, 85);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(60, 20);
            this.chkWednesday.TabIndex = 2;
            this.chkWednesday.Text = "Thứ 4";
            this.chkWednesday.UseVisualStyleBackColor = true;
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(102, 59);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(60, 20);
            this.chkTuesday.TabIndex = 1;
            this.chkTuesday.Text = "Thứ 3";
            this.chkTuesday.UseVisualStyleBackColor = true;
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(9, 59);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(60, 20);
            this.chkMonday.TabIndex = 0;
            this.chkMonday.Text = "Thứ 2";
            this.chkMonday.UseVisualStyleBackColor = true;
            // 
            // grDateInYear
            // 
            this.grDateInYear.AllowUserToAddRows = false;
            this.grDateInYear.AllowUserToDeleteRows = false;
            this.grDateInYear.AllowUserToResizeColumns = false;
            this.grDateInYear.AllowUserToResizeRows = false;
            this.grDateInYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grDateInYear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateValue,
            this.colDayInWeek,
            this.colDateType});
            this.grDateInYear.Location = new System.Drawing.Point(77, 69);
            this.grDateInYear.MultiSelect = false;
            this.grDateInYear.Name = "grDateInYear";
            this.grDateInYear.ReadOnly = true;
            this.grDateInYear.RowHeadersWidth = 70;
            this.grDateInYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grDateInYear.Size = new System.Drawing.Size(374, 549);
            this.grDateInYear.TabIndex = 2;
            this.grDateInYear.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grDateInYear_CellEnter);
            this.grDateInYear.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grDateInYear_DataBindingComplete);
            // 
            // colDateValue
            // 
            this.colDateValue.DataPropertyName = "DateValue";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.colDateValue.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDateValue.HeaderText = "Ngày";
            this.colDateValue.Name = "colDateValue";
            this.colDateValue.ReadOnly = true;
            this.colDateValue.Width = 80;
            // 
            // colDayInWeek
            // 
            this.colDayInWeek.DataPropertyName = "DayInWeek";
            this.colDayInWeek.HeaderText = "Thứ";
            this.colDayInWeek.Name = "colDayInWeek";
            this.colDayInWeek.ReadOnly = true;
            // 
            // colDateType
            // 
            this.colDateType.DataPropertyName = "DateType";
            this.colDateType.HeaderText = "Thuộc loại";
            this.colDateType.Name = "colDateType";
            this.colDateType.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(74, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 16);
            this.label6.TabIndex = 68;
            this.label6.Text = "Danh sách ngày đang áp dụng";
            // 
            // lblDateCount
            // 
            this.lblDateCount.AutoSize = true;
            this.lblDateCount.Location = new System.Drawing.Point(272, 50);
            this.lblDateCount.Name = "lblDateCount";
            this.lblDateCount.Size = new System.Drawing.Size(62, 16);
            this.lblDateCount.TabIndex = 69;
            this.lblDateCount.Text = "(365/365)";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(660, 583);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "&Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(762, 628);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDateCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grDateInYear);
            this.Controls.Add(this.grpUpdate);
            this.Controls.Add(this.cbxYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDateType);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHoliday";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết lập ngày thường, ngày lễ";
            this.Load += new System.EventHandler(this.frmHoliday_Load);
            this.grpUpdate.ResumeLayout(false);
            this.grpUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grDateInYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDateType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.CheckBox chkValentine;
        private System.Windows.Forms.CheckBox chkChristmas;
        private System.Windows.Forms.CheckBox chkNationalDay;
        private System.Windows.Forms.CheckBox chkLaborDay;
        private System.Windows.Forms.CheckBox chkFreedomDay;
        private System.Windows.Forms.CheckBox chkWomenDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grDateInYear;
        private System.Windows.Forms.DateTimePicker dtpSelectDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayInWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateType;
        private System.Windows.Forms.Label lblDateCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
    }
}