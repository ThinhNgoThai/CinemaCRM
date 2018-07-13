namespace CinemaCRM.task.marketing
{
    partial class frmCampaignPatern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCampaignPatern));
            this.lbTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtParameterCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaternString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCampaignClose = new System.Windows.Forms.Button();
            this.butCampainDelete = new System.Windows.Forms.Button();
            this.btnCampaignSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPaternCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCampaignSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPaternNameSr = new System.Windows.Forms.TextBox();
            this.dgrCampaignPatern = new System.Windows.Forms.DataGridView();
            this.colPaternCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaternString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParameterCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCampaignPatern)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbTitle.Location = new System.Drawing.Point(12, 19);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(252, 16);
            this.lbTitle.TabIndex = 17;
            this.lbTitle.Text = "Danh mục mẫu chiến dịch khuyến mại";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.txtParameterCount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPaternString);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCampaignClose);
            this.groupBox2.Controls.Add(this.butCampainDelete);
            this.groupBox2.Controls.Add(this.btnCampaignSave);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtPaternCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 484);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(881, 174);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội dung chi tiết mẫu chiến dịch";
            // 
            // txtParameterCount
            // 
            this.txtParameterCount.Location = new System.Drawing.Point(144, 95);
            this.txtParameterCount.MaxLength = 1;
            this.txtParameterCount.Name = "txtParameterCount";
            this.txtParameterCount.Size = new System.Drawing.Size(120, 22);
            this.txtParameterCount.TabIndex = 2;
            this.txtParameterCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParameterCount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(17, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Số lượng tham số";
            // 
            // txtPaternString
            // 
            this.txtPaternString.Location = new System.Drawing.Point(144, 61);
            this.txtPaternString.MaxLength = 500;
            this.txtPaternString.Name = "txtPaternString";
            this.txtPaternString.Size = new System.Drawing.Size(720, 22);
            this.txtPaternString.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(17, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tên mẫu chiến dịch";
            // 
            // btnCampaignClose
            // 
            this.btnCampaignClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCampaignClose.ForeColor = System.Drawing.Color.Red;
            this.btnCampaignClose.Image = ((System.Drawing.Image)(resources.GetObject("btnCampaignClose.Image")));
            this.btnCampaignClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCampaignClose.Location = new System.Drawing.Point(744, 133);
            this.btnCampaignClose.Name = "btnCampaignClose";
            this.btnCampaignClose.Size = new System.Drawing.Size(120, 35);
            this.btnCampaignClose.TabIndex = 6;
            this.btnCampaignClose.Text = "&Thoát";
            this.btnCampaignClose.UseVisualStyleBackColor = true;
            this.btnCampaignClose.Click += new System.EventHandler(this.btnCampaignClose_Click);
            // 
            // butCampainDelete
            // 
            this.butCampainDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCampainDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.butCampainDelete.Image = ((System.Drawing.Image)(resources.GetObject("butCampainDelete.Image")));
            this.butCampainDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCampainDelete.Location = new System.Drawing.Point(379, 133);
            this.butCampainDelete.Name = "butCampainDelete";
            this.butCampainDelete.Size = new System.Drawing.Size(96, 35);
            this.butCampainDelete.TabIndex = 5;
            this.butCampainDelete.Text = "&Xóa ";
            this.butCampainDelete.UseVisualStyleBackColor = true;
            this.butCampainDelete.Visible = false;
            this.butCampainDelete.Click += new System.EventHandler(this.butCampainDelete_Click);
            // 
            // btnCampaignSave
            // 
            this.btnCampaignSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCampaignSave.ForeColor = System.Drawing.Color.Navy;
            this.btnCampaignSave.Image = ((System.Drawing.Image)(resources.GetObject("btnCampaignSave.Image")));
            this.btnCampaignSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCampaignSave.Location = new System.Drawing.Point(263, 133);
            this.btnCampaignSave.Name = "btnCampaignSave";
            this.btnCampaignSave.Size = new System.Drawing.Size(101, 35);
            this.btnCampaignSave.TabIndex = 4;
            this.btnCampaignSave.Text = "&Ghi lại";
            this.btnCampaignSave.UseVisualStyleBackColor = true;
            this.btnCampaignSave.Click += new System.EventHandler(this.btnCampaignSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(143, 133);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 35);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPaternCode
            // 
            this.txtPaternCode.Location = new System.Drawing.Point(144, 30);
            this.txtPaternCode.MaxLength = 10;
            this.txtPaternCode.Name = "txtPaternCode";
            this.txtPaternCode.Size = new System.Drawing.Size(246, 22);
            this.txtPaternCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã quản lý mẫu";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.btnCampaignSearch);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPaternNameSr);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 60);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm theo tên mẫu";
            // 
            // btnCampaignSearch
            // 
            this.btnCampaignSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCampaignSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnCampaignSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCampaignSearch.Image")));
            this.btnCampaignSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCampaignSearch.Location = new System.Drawing.Point(482, 14);
            this.btnCampaignSearch.Name = "btnCampaignSearch";
            this.btnCampaignSearch.Size = new System.Drawing.Size(120, 35);
            this.btnCampaignSearch.TabIndex = 2;
            this.btnCampaignSearch.Text = "&Tìm kiếm";
            this.btnCampaignSearch.UseVisualStyleBackColor = true;
            this.btnCampaignSearch.Click += new System.EventHandler(this.btnCampaignSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(17, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tên mẫu chiến dịch";
            // 
            // txtPaternNameSr
            // 
            this.txtPaternNameSr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaternNameSr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaternNameSr.ForeColor = System.Drawing.Color.Black;
            this.txtPaternNameSr.Location = new System.Drawing.Point(155, 22);
            this.txtPaternNameSr.MaxLength = 30;
            this.txtPaternNameSr.Name = "txtPaternNameSr";
            this.txtPaternNameSr.Size = new System.Drawing.Size(321, 20);
            this.txtPaternNameSr.TabIndex = 1;
            // 
            // dgrCampaignPatern
            // 
            this.dgrCampaignPatern.AllowUserToAddRows = false;
            this.dgrCampaignPatern.AllowUserToDeleteRows = false;
            this.dgrCampaignPatern.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrCampaignPatern.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrCampaignPatern.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPaternCode,
            this.colPaternString,
            this.colParameterCount});
            this.dgrCampaignPatern.Location = new System.Drawing.Point(15, 117);
            this.dgrCampaignPatern.Name = "dgrCampaignPatern";
            this.dgrCampaignPatern.ReadOnly = true;
            this.dgrCampaignPatern.RowHeadersWidth = 60;
            this.dgrCampaignPatern.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrCampaignPatern.Size = new System.Drawing.Size(881, 361);
            this.dgrCampaignPatern.TabIndex = 0;
            this.dgrCampaignPatern.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrCampaignPatern_CellEnter);
            this.dgrCampaignPatern.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrCampaignPatern_DataBindingComplete);
            // 
            // colPaternCode
            // 
            this.colPaternCode.DataPropertyName = "PaternCode";
            this.colPaternCode.HeaderText = "Mã quản lý mẫu";
            this.colPaternCode.Name = "colPaternCode";
            this.colPaternCode.ReadOnly = true;
            this.colPaternCode.Width = 120;
            // 
            // colPaternString
            // 
            this.colPaternString.DataPropertyName = "PaternString";
            this.colPaternString.HeaderText = "Tên mẫu chiến dịch";
            this.colPaternString.Name = "colPaternString";
            this.colPaternString.ReadOnly = true;
            this.colPaternString.Width = 560;
            // 
            // colParameterCount
            // 
            this.colParameterCount.DataPropertyName = "ParameterCount";
            this.colParameterCount.HeaderText = "Số lượng tham số";
            this.colParameterCount.Name = "colParameterCount";
            this.colParameterCount.ReadOnly = true;
            this.colParameterCount.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PaternCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã quản lý mẫu";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PaternString";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên mẫu chiến dịch";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 660;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ParameterCount";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng tham số";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // frmCampaignPatern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(912, 670);
            this.Controls.Add(this.dgrCampaignPatern);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCampaignPatern";
            this.Text = "frmCampaignPatern";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCampaignPatern_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCampaignPatern)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCampaignClose;
        private System.Windows.Forms.Button butCampainDelete;
        private System.Windows.Forms.Button btnCampaignSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPaternCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCampaignSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPaternNameSr;
        private System.Windows.Forms.DataGridView dgrCampaignPatern;
        private System.Windows.Forms.TextBox txtPaternString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox txtParameterCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaternCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaternString;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParameterCount;
    }
}