namespace CinemaCRM.task.carecustomer
{
    partial class frmComplainDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComplainDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.txtComplainCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComplainEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSelectUser = new System.Windows.Forms.Button();
            this.cbComplainType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbCampaign = new System.Windows.Forms.ComboBox();
            this.txtComplainOrganize = new System.Windows.Forms.TextBox();
            this.txtComplainDepartment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtComplainContentSent = new System.Windows.Forms.TextBox();
            this.txtComplainTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpDateAssigned = new System.Windows.Forms.DateTimePicker();
            this.cbComplainStatus = new System.Windows.Forms.ComboBox();
            this.cbComplainUserAssign = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.cbEmailSend = new System.Windows.Forms.CheckBox();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.txtComplainDescription = new System.Windows.Forms.TextBox();
            this.txtComplainResolve = new System.Windows.Forms.TextBox();
            this.txtComplainCause = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khiếu nại";
            // 
            // txtComplainCode
            // 
            this.txtComplainCode.Location = new System.Drawing.Point(119, 24);
            this.txtComplainCode.Name = "txtComplainCode";
            this.txtComplainCode.Size = new System.Drawing.Size(93, 22);
            this.txtComplainCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khách hàng";
            // 
            // txtComplainEmail
            // 
            this.txtComplainEmail.Location = new System.Drawing.Point(119, 51);
            this.txtComplainEmail.Name = "txtComplainEmail";
            this.txtComplainEmail.ReadOnly = true;
            this.txtComplainEmail.Size = new System.Drawing.Size(170, 22);
            this.txtComplainEmail.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhóm khiếu nại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Chiến dịch";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.btnSelectUser);
            this.groupBox1.Controls.Add(this.cbComplainType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtComplainCode);
            this.groupBox1.Controls.Add(this.txtComplainEmail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 110);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cơ bản";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(218, 24);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(116, 22);
            this.txtPhone.TabIndex = 6;
            this.txtPhone.Text = "--Số điện thoại--";
            // 
            // btnSelectUser
            // 
            this.btnSelectUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectUser.Location = new System.Drawing.Point(295, 51);
            this.btnSelectUser.Name = "btnSelectUser";
            this.btnSelectUser.Size = new System.Drawing.Size(39, 22);
            this.btnSelectUser.TabIndex = 5;
            this.btnSelectUser.Text = "...";
            this.btnSelectUser.UseVisualStyleBackColor = true;
            this.btnSelectUser.Click += new System.EventHandler(this.btnSelectUser_Click);
            // 
            // cbComplainType
            // 
            this.cbComplainType.FormattingEnabled = true;
            this.cbComplainType.Items.AddRange(new object[] {
            "Nguyễn Văn A",
            "Trần Văn D",
            "Bùi Thị C",
            "Lê Thị E"});
            this.cbComplainType.Location = new System.Drawing.Point(119, 77);
            this.cbComplainType.Name = "cbComplainType";
            this.cbComplainType.Size = new System.Drawing.Size(222, 24);
            this.cbComplainType.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCampaign);
            this.groupBox2.Controls.Add(this.txtComplainOrganize);
            this.groupBox2.Controls.Add(this.txtComplainDepartment);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(366, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 110);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Các vấn đề liên quan";
            // 
            // cbCampaign
            // 
            this.cbCampaign.FormattingEnabled = true;
            this.cbCampaign.Items.AddRange(new object[] {
            "Quốc tế phụ nữ",
            "Quốc tế Lao Động",
            "Nhà giáo Việt Nam"});
            this.cbCampaign.Location = new System.Drawing.Point(96, 23);
            this.cbCampaign.Name = "cbCampaign";
            this.cbCampaign.Size = new System.Drawing.Size(146, 24);
            this.cbCampaign.TabIndex = 3;
            // 
            // txtComplainOrganize
            // 
            this.txtComplainOrganize.Location = new System.Drawing.Point(96, 78);
            this.txtComplainOrganize.Name = "txtComplainOrganize";
            this.txtComplainOrganize.Size = new System.Drawing.Size(146, 22);
            this.txtComplainOrganize.TabIndex = 1;
            // 
            // txtComplainDepartment
            // 
            this.txtComplainDepartment.Location = new System.Drawing.Point(96, 51);
            this.txtComplainDepartment.Name = "txtComplainDepartment";
            this.txtComplainDepartment.Size = new System.Drawing.Size(146, 22);
            this.txtComplainDepartment.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổ chức";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Phòng ban";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtComplainContentSent);
            this.groupBox3.Controls.Add(this.txtComplainTitle);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(870, 135);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin xử lý";
            // 
            // txtComplainContentSent
            // 
            this.txtComplainContentSent.Location = new System.Drawing.Point(119, 58);
            this.txtComplainContentSent.Multiline = true;
            this.txtComplainContentSent.Name = "txtComplainContentSent";
            this.txtComplainContentSent.Size = new System.Drawing.Size(733, 64);
            this.txtComplainContentSent.TabIndex = 2;
            // 
            // txtComplainTitle
            // 
            this.txtComplainTitle.Location = new System.Drawing.Point(119, 30);
            this.txtComplainTitle.Name = "txtComplainTitle";
            this.txtComplainTitle.Size = new System.Drawing.Size(353, 22);
            this.txtComplainTitle.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nội dung";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tiêu đề";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Nguyên nhân";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpDateAssigned);
            this.groupBox4.Controls.Add(this.cbComplainStatus);
            this.groupBox4.Controls.Add(this.cbComplainUserAssign);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(624, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(259, 110);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thiết lập xử lý";
            // 
            // dtpDateAssigned
            // 
            this.dtpDateAssigned.CustomFormat = "dd/MM/yyyy H:m";
            this.dtpDateAssigned.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateAssigned.Location = new System.Drawing.Point(108, 54);
            this.dtpDateAssigned.Name = "dtpDateAssigned";
            this.dtpDateAssigned.Size = new System.Drawing.Size(145, 22);
            this.dtpDateAssigned.TabIndex = 3;
            // 
            // cbComplainStatus
            // 
            this.cbComplainStatus.FormattingEnabled = true;
            this.cbComplainStatus.Items.AddRange(new object[] {
            "Mới",
            "Đang xử lý",
            "Đã trả lời"});
            this.cbComplainStatus.Location = new System.Drawing.Point(108, 77);
            this.cbComplainStatus.Name = "cbComplainStatus";
            this.cbComplainStatus.Size = new System.Drawing.Size(145, 24);
            this.cbComplainStatus.TabIndex = 2;
            // 
            // cbComplainUserAssign
            // 
            this.cbComplainUserAssign.FormattingEnabled = true;
            this.cbComplainUserAssign.Items.AddRange(new object[] {
            "Nguyễn Văn A",
            "Trần Văn D",
            "Bùi Thị C",
            "Lê Thị E"});
            this.cbComplainUserAssign.Location = new System.Drawing.Point(108, 23);
            this.cbComplainUserAssign.Name = "cbComplainUserAssign";
            this.cbComplainUserAssign.Size = new System.Drawing.Size(145, 24);
            this.cbComplainUserAssign.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Trạng thái";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngày xử lý";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Người xử lý";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAdd);
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Controls.Add(this.btnAssign);
            this.groupBox5.Controls.Add(this.btnReply);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.cbEmailSend);
            this.groupBox5.Controls.Add(this.cbPriority);
            this.groupBox5.Controls.Add(this.txtComplainDescription);
            this.groupBox5.Controls.Add(this.txtComplainResolve);
            this.groupBox5.Controls.Add(this.txtComplainCause);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Location = new System.Drawing.Point(12, 265);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(870, 284);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Trả lời";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(18, 234);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "&Ghi lại";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(772, 234);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "&Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAssign.ForeColor = System.Drawing.Color.Black;
            this.btnAssign.Image = ((System.Drawing.Image)(resources.GetObject("btnAssign.Image")));
            this.btnAssign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssign.Location = new System.Drawing.Point(258, 234);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(112, 35);
            this.btnAssign.TabIndex = 5;
            this.btnAssign.Text = "&Gán xử lý";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnReply
            // 
            this.btnReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReply.ForeColor = System.Drawing.Color.Navy;
            this.btnReply.Image = ((System.Drawing.Image)(resources.GetObject("btnReply.Image")));
            this.btnReply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReply.Location = new System.Drawing.Point(148, 234);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(100, 35);
            this.btnReply.TabIndex = 5;
            this.btnReply.Text = "&Trả lời";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // cbEmailSend
            // 
            this.cbEmailSend.AutoSize = true;
            this.cbEmailSend.Checked = true;
            this.cbEmailSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEmailSend.Location = new System.Drawing.Point(499, 26);
            this.cbEmailSend.Name = "cbEmailSend";
            this.cbEmailSend.Size = new System.Drawing.Size(316, 20);
            this.cbEmailSend.TabIndex = 4;
            this.cbEmailSend.Text = "Gửi phản hồi qua e-mail (nhập nội dung bên dưới)";
            this.cbEmailSend.UseVisualStyleBackColor = true;
            // 
            // cbPriority
            // 
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(119, 23);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(147, 24);
            this.cbPriority.TabIndex = 3;
            // 
            // txtComplainDescription
            // 
            this.txtComplainDescription.Location = new System.Drawing.Point(499, 53);
            this.txtComplainDescription.Multiline = true;
            this.txtComplainDescription.Name = "txtComplainDescription";
            this.txtComplainDescription.Size = new System.Drawing.Size(353, 175);
            this.txtComplainDescription.TabIndex = 2;
            // 
            // txtComplainResolve
            // 
            this.txtComplainResolve.Location = new System.Drawing.Point(120, 112);
            this.txtComplainResolve.Multiline = true;
            this.txtComplainResolve.Name = "txtComplainResolve";
            this.txtComplainResolve.Size = new System.Drawing.Size(333, 116);
            this.txtComplainResolve.TabIndex = 1;
            // 
            // txtComplainCause
            // 
            this.txtComplainCause.Location = new System.Drawing.Point(119, 53);
            this.txtComplainCause.Multiline = true;
            this.txtComplainCause.Name = "txtComplainCause";
            this.txtComplainCause.Size = new System.Drawing.Size(334, 53);
            this.txtComplainCause.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Cách giải quyết";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Độ ưu tiên";
            // 
            // frmComplainDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(901, 562);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComplainDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết khiếu nại";
            this.Load += new System.EventHandler(this.frmComplainDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cbComplainType;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtComplainCode;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtComplainEmail;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtComplainDepartment;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtComplainOrganize;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox txtComplainTitle;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtComplainContentSent;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.TextBox txtComplainDescription;
        public System.Windows.Forms.TextBox txtComplainResolve;
        public System.Windows.Forms.TextBox txtComplainCause;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.ComboBox cbPriority;
        public System.Windows.Forms.CheckBox cbEmailSend;
        public System.Windows.Forms.Button btnReply;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnAssign;
        public System.Windows.Forms.DateTimePicker dtpDateAssigned;
        public System.Windows.Forms.ComboBox cbComplainUserAssign;
        public System.Windows.Forms.Button btnSelectUser;
        public System.Windows.Forms.ComboBox cbCampaign;
        public System.Windows.Forms.ComboBox cbComplainStatus;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txtPhone;
    }
}