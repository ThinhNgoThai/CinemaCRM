namespace CinemaCRM
{
    partial class frmChangePass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePass));
            this.txtMK_OLD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTEN_ND = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMK_NEW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMK_CONFIRM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMK_OLD
            // 
            this.txtMK_OLD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMK_OLD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK_OLD.ForeColor = System.Drawing.Color.Navy;
            this.txtMK_OLD.Location = new System.Drawing.Point(177, 55);
            this.txtMK_OLD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMK_OLD.MaxLength = 100;
            this.txtMK_OLD.Name = "txtMK_OLD";
            this.txtMK_OLD.PasswordChar = '@';
            this.txtMK_OLD.Size = new System.Drawing.Size(200, 22);
            this.txtMK_OLD.TabIndex = 1;
            this.txtMK_OLD.UseSystemPasswordChar = true;
            this.txtMK_OLD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMK_OLD_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mật khẩu cũ";
            // 
            // txtTEN_ND
            // 
            this.txtTEN_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTEN_ND.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTEN_ND.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTEN_ND.Location = new System.Drawing.Point(177, 15);
            this.txtTEN_ND.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTEN_ND.Name = "txtTEN_ND";
            this.txtTEN_ND.ReadOnly = true;
            this.txtTEN_ND.Size = new System.Drawing.Size(200, 22);
            this.txtTEN_ND.TabIndex = 0;
            this.txtTEN_ND.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTEN_ND_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên người sử dụng";
            // 
            // txtMK_NEW
            // 
            this.txtMK_NEW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMK_NEW.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK_NEW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMK_NEW.Location = new System.Drawing.Point(177, 95);
            this.txtMK_NEW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMK_NEW.MaxLength = 100;
            this.txtMK_NEW.Name = "txtMK_NEW";
            this.txtMK_NEW.PasswordChar = '@';
            this.txtMK_NEW.Size = new System.Drawing.Size(200, 22);
            this.txtMK_NEW.TabIndex = 2;
            this.txtMK_NEW.UseSystemPasswordChar = true;
            this.txtMK_NEW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMK_NEW_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mật khẩu mới";
            // 
            // txtMK_CONFIRM
            // 
            this.txtMK_CONFIRM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMK_CONFIRM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK_CONFIRM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtMK_CONFIRM.Location = new System.Drawing.Point(177, 135);
            this.txtMK_CONFIRM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMK_CONFIRM.MaxLength = 100;
            this.txtMK_CONFIRM.Name = "txtMK_CONFIRM";
            this.txtMK_CONFIRM.PasswordChar = '@';
            this.txtMK_CONFIRM.Size = new System.Drawing.Size(200, 22);
            this.txtMK_CONFIRM.TabIndex = 3;
            this.txtMK_CONFIRM.UseSystemPasswordChar = true;
            this.txtMK_CONFIRM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMK_CONFIRM_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Xác nhận mật khẩu mới";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(277, 179);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 35);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(177, 179);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Ghi lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(393, 226);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMK_CONFIRM);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMK_NEW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMK_OLD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTEN_ND);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmChangePass_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChangePass_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMK_OLD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTEN_ND;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMK_CONFIRM;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtMK_NEW;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
    }
}