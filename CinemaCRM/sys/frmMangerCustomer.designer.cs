namespace CinemaCRM.sys
{
    partial class frmMangerCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMangerCustomer));
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbMannuafacture = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAddess = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.Tên = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCustomerRole = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbCustomerRoleSearch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtCustomer = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Manufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Maroon;
            this.txtEmail.Location = new System.Drawing.Point(198, 80);
            this.txtEmail.MaxLength = 500;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(239, 20);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHOTEN_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(13, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên đăng nhập hệ thống";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(198, 111);
            this.txtUsername.MaxLength = 500;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(240, 22);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(13, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mật khẩu đăng nhập hệ thống";
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(198, 143);
            this.txtMK.MaxLength = 500;
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(240, 22);
            this.txtMK.TabIndex = 7;
            this.txtMK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMK_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(781, 185);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "&Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // butDelete
            // 
            this.butDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butDelete.Image = ((System.Drawing.Image)(resources.GetObject("butDelete.Image")));
            this.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDelete.Location = new System.Drawing.Point(241, 185);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(80, 35);
            this.butDelete.TabIndex = 15;
            this.butDelete.Text = "&Xóa ";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(128, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 35);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Ghi lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // butAdd
            // 
            this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAdd.ForeColor = System.Drawing.Color.Navy;
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(15, 185);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(98, 35);
            this.butAdd.TabIndex = 13;
            this.butAdd.Text = "Thêm mới";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.cbMannuafacture);
            this.groupBox2.Controls.Add(this.butDelete);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.butAdd);
            this.groupBox2.Controls.Add(this.txtAddess);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtLast);
            this.groupBox2.Controls.Add(this.Tên);
            this.groupBox2.Controls.Add(this.txtFirst);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbCustomerRole);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtMK);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Location = new System.Drawing.Point(3, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(881, 226);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tạo tài khoản người dùng";
            // 
            // cbMannuafacture
            // 
            this.cbMannuafacture.FormattingEnabled = true;
            this.cbMannuafacture.Location = new System.Drawing.Point(198, 51);
            this.cbMannuafacture.Name = "cbMannuafacture";
            this.cbMannuafacture.Size = new System.Drawing.Size(239, 24);
            this.cbMannuafacture.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(13, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Hãng sản xuất";
            // 
            // txtAddess
            // 
            this.txtAddess.Location = new System.Drawing.Point(517, 112);
            this.txtAddess.MaxLength = 500;
            this.txtAddess.Name = "txtAddess";
            this.txtAddess.Size = new System.Drawing.Size(297, 22);
            this.txtAddess.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(445, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(517, 81);
            this.txtPhone.MaxLength = 500;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(297, 22);
            this.txtPhone.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(445, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Điện thoại";
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(517, 22);
            this.txtLast.MaxLength = 500;
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(297, 22);
            this.txtLast.TabIndex = 8;
            // 
            // Tên
            // 
            this.Tên.AutoSize = true;
            this.Tên.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Tên.Location = new System.Drawing.Point(445, 54);
            this.Tên.Name = "Tên";
            this.Tên.Size = new System.Drawing.Size(29, 16);
            this.Tên.TabIndex = 10;
            this.Tên.Text = "Tên";
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(517, 52);
            this.txtFirst.MaxLength = 500;
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(297, 22);
            this.txtFirst.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(445, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Họ";
            // 
            // cbCustomerRole
            // 
            this.cbCustomerRole.FormattingEnabled = true;
            this.cbCustomerRole.Location = new System.Drawing.Point(198, 22);
            this.cbCustomerRole.Name = "cbCustomerRole";
            this.cbCustomerRole.Size = new System.Drawing.Size(239, 24);
            this.cbCustomerRole.TabIndex = 3;
            this.cbCustomerRole.SelectedIndexChanged += new System.EventHandler(this.cbCustomerRole_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(13, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nhóm người dùng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(13, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Địa chỉ email";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.cbCustomerRoleSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(763, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(358, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tên /email";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Maroon;
            this.txtSearch.Location = new System.Drawing.Point(439, 21);
            this.txtSearch.MaxLength = 30;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(296, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // cbCustomerRoleSearch
            // 
            this.cbCustomerRoleSearch.FormattingEnabled = true;
            this.cbCustomerRoleSearch.Location = new System.Drawing.Point(132, 22);
            this.cbCustomerRoleSearch.Name = "cbCustomerRoleSearch";
            this.cbCustomerRoleSearch.Size = new System.Drawing.Size(213, 24);
            this.cbCustomerRoleSearch.TabIndex = 0;
            this.cbCustomerRoleSearch.SelectedIndexChanged += new System.EventHandler(this.cbCustomerRoleSearch_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(8, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nhóm người dùng";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dtCustomer);
            this.panel1.Location = new System.Drawing.Point(6, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 291);
            this.panel1.TabIndex = 4;
            // 
            // dtCustomer
            // 
            this.dtCustomer.AllowUserToAddRows = false;
            this.dtCustomer.AllowUserToDeleteRows = false;
            this.dtCustomer.AllowUserToResizeColumns = false;
            this.dtCustomer.AllowUserToResizeRows = false;
            this.dtCustomer.ColumnHeadersHeight = 25;
            this.dtCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.UserNames,
            this.Email,
            this.Password,
            this.CustomerRole,
            this.Manufacture});
            this.dtCustomer.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtCustomer.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtCustomer.Location = new System.Drawing.Point(0, 0);
            this.dtCustomer.Name = "dtCustomer";
            this.dtCustomer.ReadOnly = true;
            this.dtCustomer.RowHeadersWidth = 40;
            this.dtCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCustomer.Size = new System.Drawing.Size(878, 291);
            this.dtCustomer.TabIndex = 12;
            this.dtCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCustomer_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // UserNames
            // 
            this.UserNames.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserNames.DataPropertyName = "Username";
            this.UserNames.HeaderText = "Tên đăng nhập";
            this.UserNames.Name = "UserNames";
            this.UserNames.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Địa chỉ email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 400;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            // 
            // CustomerRole
            // 
            this.CustomerRole.DataPropertyName = "CustomerRoleId";
            this.CustomerRole.HeaderText = "CustomerRoleId";
            this.CustomerRole.Name = "CustomerRole";
            this.CustomerRole.ReadOnly = true;
            this.CustomerRole.Visible = false;
            // 
            // Manufacture
            // 
            this.Manufacture.DataPropertyName = "ManufacturerId";
            this.Manufacture.HeaderText = "Mã hãng sản xuất";
            this.Manufacture.Name = "Manufacture";
            this.Manufacture.ReadOnly = true;
            this.Manufacture.Width = 130;
            // 
            // frmMangerCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMangerCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.frmMangerCustomer_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCustomerRole;
        private System.Windows.Forms.ComboBox cbCustomerRoleSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dtCustomer;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Label Tên;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddess;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbMannuafacture;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn Manufacture;

    }
}