namespace CinemaCRM.dir
{
    partial class frmManufacturerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManufacturerList));
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManufacturerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddessBank = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAcountBank = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhonNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdManufacturers = new System.Windows.Forms.DataGridView();
            this.ManufacturerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcountBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdManufacturers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(730, 167);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 35);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Th&oát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(24, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên hãng phim";
            // 
            // txtManufacturerName
            // 
            this.txtManufacturerName.Location = new System.Drawing.Point(123, 21);
            this.txtManufacturerName.Margin = new System.Windows.Forms.Padding(4);
            this.txtManufacturerName.MaxLength = 200;
            this.txtManufacturerName.Name = "txtManufacturerName";
            this.txtManufacturerName.Size = new System.Drawing.Size(231, 22);
            this.txtManufacturerName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(24, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên công ty";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(123, 51);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFullName.MaxLength = 200;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(231, 22);
            this.txtFullName.TabIndex = 11;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(123, 79);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(231, 22);
            this.txtAddress.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(24, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Địa chỉ";
            // 
            // txtAddessBank
            // 
            this.txtAddessBank.Location = new System.Drawing.Point(492, 79);
            this.txtAddessBank.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddessBank.MaxLength = 200;
            this.txtAddessBank.Name = "txtAddessBank";
            this.txtAddessBank.Size = new System.Drawing.Size(231, 22);
            this.txtAddessBank.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(378, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Địa chỉ NH";
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(492, 51);
            this.txtBank.Margin = new System.Windows.Forms.Padding(4);
            this.txtBank.MaxLength = 200;
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(231, 22);
            this.txtBank.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(378, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tên ngân hàng";
            // 
            // txtAcountBank
            // 
            this.txtAcountBank.Location = new System.Drawing.Point(492, 21);
            this.txtAcountBank.Margin = new System.Windows.Forms.Padding(4);
            this.txtAcountBank.MaxLength = 200;
            this.txtAcountBank.Name = "txtAcountBank";
            this.txtAcountBank.Size = new System.Drawing.Size(231, 22);
            this.txtAcountBank.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(378, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tài khoản NH";
            // 
            // txtPhonNumber
            // 
            this.txtPhonNumber.Location = new System.Drawing.Point(123, 109);
            this.txtPhonNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhonNumber.MaxLength = 200;
            this.txtPhonNumber.Name = "txtPhonNumber";
            this.txtPhonNumber.Size = new System.Drawing.Size(231, 22);
            this.txtPhonNumber.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(24, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Điện thoại";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(123, 139);
            this.txtFax.Margin = new System.Windows.Forms.Padding(4);
            this.txtFax.MaxLength = 200;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(231, 22);
            this.txtFax.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(24, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Fax";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(123, 169);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.MaxLength = 200;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(231, 22);
            this.txtUrl.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(24, 172);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Website";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbTitle.Location = new System.Drawing.Point(11, 12);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(136, 16);
            this.lbTitle.TabIndex = 26;
            this.lbTitle.Text = "Thiết lập hãng phim";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.txtBank);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.txtManufacturerName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFax);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPhonNumber);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAddessBank);
            this.groupBox1.Controls.Add(this.txtAcountBank);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(11, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 209);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hãng phim";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.grdManufacturers);
            this.panel1.Location = new System.Drawing.Point(11, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 295);
            this.panel1.TabIndex = 28;
            // 
            // grdManufacturers
            // 
            this.grdManufacturers.AllowUserToAddRows = false;
            this.grdManufacturers.AllowUserToDeleteRows = false;
            this.grdManufacturers.AllowUserToResizeColumns = false;
            this.grdManufacturers.AllowUserToResizeRows = false;
            this.grdManufacturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdManufacturers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ManufacturerId,
            this.ManufacturerName,
            this.FullName,
            this.Address,
            this.AcountBank,
            this.BankName,
            this.AddressBank,
            this.PhoneNumber,
            this.Fax,
            this.Url});
            this.grdManufacturers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdManufacturers.Location = new System.Drawing.Point(0, 0);
            this.grdManufacturers.MultiSelect = false;
            this.grdManufacturers.Name = "grdManufacturers";
            this.grdManufacturers.ReadOnly = true;
            this.grdManufacturers.RowHeadersVisible = false;
            this.grdManufacturers.RowHeadersWidth = 5;
            this.grdManufacturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdManufacturers.Size = new System.Drawing.Size(857, 295);
            this.grdManufacturers.TabIndex = 10;
            this.grdManufacturers.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdManufacturers_CellEnter);
            // 
            // ManufacturerId
            // 
            this.ManufacturerId.DataPropertyName = "Id";
            this.ManufacturerId.HeaderText = "Id";
            this.ManufacturerId.Name = "ManufacturerId";
            this.ManufacturerId.ReadOnly = true;
            this.ManufacturerId.Visible = false;
            // 
            // ManufacturerName
            // 
            this.ManufacturerName.DataPropertyName = "Name";
            this.ManufacturerName.HeaderText = "Hãng phim phát hành";
            this.ManufacturerName.Name = "ManufacturerName";
            this.ManufacturerName.ReadOnly = true;
            this.ManufacturerName.Width = 200;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Tên công ty";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 300;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Địa chỉ cty";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // AcountBank
            // 
            this.AcountBank.DataPropertyName = "AcountBank";
            this.AcountBank.HeaderText = "Tài khoản";
            this.AcountBank.Name = "AcountBank";
            this.AcountBank.ReadOnly = true;
            this.AcountBank.Visible = false;
            // 
            // BankName
            // 
            this.BankName.DataPropertyName = "BankName";
            this.BankName.HeaderText = "Tên ngân hàng";
            this.BankName.Name = "BankName";
            this.BankName.ReadOnly = true;
            this.BankName.Visible = false;
            // 
            // AddressBank
            // 
            this.AddressBank.DataPropertyName = "AddressBank";
            this.AddressBank.HeaderText = "Địa chỉ ngân hàng";
            this.AddressBank.Name = "AddressBank";
            this.AddressBank.ReadOnly = true;
            this.AddressBank.Visible = false;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "Điện thoại";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.Visible = false;
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "Fax";
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.ReadOnly = true;
            this.Fax.Visible = false;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Visible = false;
            // 
            // frmManufacturerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(879, 588);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManufacturerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách hãng phim";
            this.Load += new System.EventHandler(this.frmManufacturerList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdManufacturers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManufacturerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddessBank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAcountBank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhonNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdManufacturers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcountBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
    }
}