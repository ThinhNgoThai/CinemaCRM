namespace CinemaCRM.sys
{
    partial class frmActingGroup
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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Administrator", 0, 1);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Ban giám đốc", 0, 1);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Trưởng , phó phòng", 0, 1);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Bộ phận kế hoạch", 0, 1);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Bộ phận kế toán");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Bộ phận bán vé");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Bộ phận Marketting");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Chủ phim");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActingGroup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvGroup = new System.Windows.Forms.TreeView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtActityGroup = new System.Windows.Forms.DataGridView();
            this.STT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Read = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtActityGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tvGroup);
            this.panel1.Location = new System.Drawing.Point(0, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 550);
            this.panel1.TabIndex = 0;
            // 
            // tvGroup
            // 
            this.tvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvGroup.HideSelection = false;
            this.tvGroup.Indent = 10;
            this.tvGroup.ItemHeight = 20;
            this.tvGroup.Location = new System.Drawing.Point(0, 3);
            this.tvGroup.Name = "tvGroup";
            treeNode9.ImageIndex = 0;
            treeNode9.Name = "nodRoot1";
            treeNode9.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode9.SelectedImageIndex = 1;
            treeNode9.Text = "Administrator";
            treeNode10.ImageIndex = 0;
            treeNode10.Name = "nodRoot2";
            treeNode10.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode10.SelectedImageIndex = 1;
            treeNode10.Text = "Ban giám đốc";
            treeNode11.ImageIndex = 0;
            treeNode11.Name = "nodRoot3";
            treeNode11.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode11.SelectedImageIndex = 1;
            treeNode11.Text = "Trưởng , phó phòng";
            treeNode12.ImageIndex = 0;
            treeNode12.Name = "nodRoot4";
            treeNode12.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode12.SelectedImageIndex = 1;
            treeNode12.Text = "Bộ phận kế hoạch";
            treeNode13.Name = "nodRoot5";
            treeNode13.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode13.Text = "Bộ phận kế toán";
            treeNode14.Name = "nodRoot6";
            treeNode14.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode14.Text = "Bộ phận bán vé";
            treeNode15.Name = "nodRoot7";
            treeNode15.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode15.Text = "Bộ phận Marketting";
            treeNode16.Name = "nodRoot8";
            treeNode16.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode16.Text = "Chủ phim";
            this.tvGroup.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            this.tvGroup.Size = new System.Drawing.Size(276, 535);
            this.tvGroup.TabIndex = 1;
            this.tvGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGroup_AfterSelect);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(793, 515);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 35);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(680, 515);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Ghi lại";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtActityGroup);
            this.groupBox1.Location = new System.Drawing.Point(290, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 500);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phân quyền";
            // 
            // dtActityGroup
            // 
            this.dtActityGroup.AllowUserToAddRows = false;
            this.dtActityGroup.AllowUserToDeleteRows = false;
            this.dtActityGroup.AllowUserToResizeColumns = false;
            this.dtActityGroup.AllowUserToResizeRows = false;
            this.dtActityGroup.ColumnHeadersHeight = 25;
            this.dtActityGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT1,
            this.ID1,
            this.Menu,
            this.MenuName,
            this.Edit,
            this.Read});
            this.dtActityGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtActityGroup.Location = new System.Drawing.Point(3, 18);
            this.dtActityGroup.Name = "dtActityGroup";
            this.dtActityGroup.RowHeadersWidth = 5;
            this.dtActityGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtActityGroup.Size = new System.Drawing.Size(586, 479);
            this.dtActityGroup.TabIndex = 0;
            // 
            // STT1
            // 
            this.STT1.DataPropertyName = "STT";
            this.STT1.HeaderText = "STT";
            this.STT1.Name = "STT1";
            this.STT1.Width = 60;
            // 
            // ID1
            // 
            this.ID1.DataPropertyName = "CustomerRole_Id";
            this.ID1.HeaderText = "ID";
            this.ID1.Name = "ID1";
            this.ID1.Visible = false;
            // 
            // Menu
            // 
            this.Menu.DataPropertyName = "Menu";
            this.Menu.HeaderText = "Chức năng";
            this.Menu.Name = "Menu";
            this.Menu.Visible = false;
            // 
            // MenuName
            // 
            this.MenuName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MenuName.DataPropertyName = "MenuName";
            this.MenuName.HeaderText = "Tên chức năng";
            this.MenuName.Name = "MenuName";
            // 
            // Edit
            // 
            this.Edit.DataPropertyName = "Edit";
            this.Edit.FalseValue = "False";
            this.Edit.HeaderText = "Có Thể Sửa";
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.TrueValue = "True";
            // 
            // Read
            // 
            this.Read.DataPropertyName = "ReadOnly";
            this.Read.FalseValue = "False";
            this.Read.HeaderText = "Chỉ đọc";
            this.Read.Name = "Read";
            this.Read.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Read.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Read.TrueValue = "True";
            this.Read.Visible = false;
            // 
            // frmActingGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmActingGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền người dùng";
            this.Load += new System.EventHandler(this.frmActingGroup_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtActityGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtActityGroup;
        private System.Windows.Forms.TreeView tvGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Edit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Read;
    }
}