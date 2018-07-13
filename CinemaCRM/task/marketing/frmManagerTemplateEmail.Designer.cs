namespace CinemaCRM.task.marketing
{
    partial class frmManagerTemplateEmail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagerTemplateEmail));
            this.txtEmailCode = new System.Windows.Forms.TextBox();
            this.btnEmailClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEmailDelete = new System.Windows.Forms.Button();
            this.btnEmailAdd = new System.Windows.Forms.Button();
            this.btnEmailSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEmailEdit = new System.Windows.Forms.Button();
            this.btnEmailCopy = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dgEmailTemplateList = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplateCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplateTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmailTemplateList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmailCode
            // 
            this.txtEmailCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailCode.ForeColor = System.Drawing.Color.Black;
            this.txtEmailCode.Location = new System.Drawing.Point(173, 29);
            this.txtEmailCode.MaxLength = 30;
            this.txtEmailCode.Name = "txtEmailCode";
            this.txtEmailCode.Size = new System.Drawing.Size(288, 20);
            this.txtEmailCode.TabIndex = 1;
            // 
            // btnEmailClose
            // 
            this.btnEmailClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmailClose.ForeColor = System.Drawing.Color.Red;
            this.btnEmailClose.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailClose.Image")));
            this.btnEmailClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmailClose.Location = new System.Drawing.Point(781, 24);
            this.btnEmailClose.Name = "btnEmailClose";
            this.btnEmailClose.Size = new System.Drawing.Size(80, 35);
            this.btnEmailClose.TabIndex = 3;
            this.btnEmailClose.Text = "&Thoát";
            this.btnEmailClose.UseVisualStyleBackColor = true;
            this.btnEmailClose.Click += new System.EventHandler(this.btnEmailClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(8, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tên mẫu , tiêu đề email";
            // 
            // btnEmailDelete
            // 
            this.btnEmailDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmailDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEmailDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailDelete.Image")));
            this.btnEmailDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmailDelete.Location = new System.Drawing.Point(355, 25);
            this.btnEmailDelete.Name = "btnEmailDelete";
            this.btnEmailDelete.Size = new System.Drawing.Size(80, 35);
            this.btnEmailDelete.TabIndex = 2;
            this.btnEmailDelete.Text = "&Xóa ";
            this.btnEmailDelete.UseVisualStyleBackColor = true;
            this.btnEmailDelete.Click += new System.EventHandler(this.btnEmailDelete_Click);
            // 
            // btnEmailAdd
            // 
            this.btnEmailAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmailAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnEmailAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailAdd.Image")));
            this.btnEmailAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmailAdd.Location = new System.Drawing.Point(15, 24);
            this.btnEmailAdd.Name = "btnEmailAdd";
            this.btnEmailAdd.Size = new System.Drawing.Size(98, 35);
            this.btnEmailAdd.TabIndex = 0;
            this.btnEmailAdd.Text = "Thêm mới";
            this.btnEmailAdd.UseVisualStyleBackColor = true;
            this.btnEmailAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // btnEmailSearch
            // 
            this.btnEmailSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmailSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnEmailSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailSearch.Image")));
            this.btnEmailSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmailSearch.Location = new System.Drawing.Point(770, 21);
            this.btnEmailSearch.Name = "btnEmailSearch";
            this.btnEmailSearch.Size = new System.Drawing.Size(100, 35);
            this.btnEmailSearch.TabIndex = 2;
            this.btnEmailSearch.Text = "&Tìm kiếm";
            this.btnEmailSearch.UseVisualStyleBackColor = true;
            this.btnEmailSearch.Click += new System.EventHandler(this.btnEmailSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.btnEmailSearch);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEmailCode);
            this.groupBox1.Location = new System.Drawing.Point(2, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(881, 71);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.btnEmailEdit);
            this.groupBox2.Controls.Add(this.btnEmailClose);
            this.groupBox2.Controls.Add(this.btnEmailCopy);
            this.groupBox2.Controls.Add(this.btnEmailDelete);
            this.groupBox2.Controls.Add(this.btnEmailAdd);
            this.groupBox2.Location = new System.Drawing.Point(2, 540);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(881, 65);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btnEmailEdit
            // 
            this.btnEmailEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmailEdit.ForeColor = System.Drawing.Color.Navy;
            this.btnEmailEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailEdit.Image")));
            this.btnEmailEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmailEdit.Location = new System.Drawing.Point(125, 25);
            this.btnEmailEdit.Name = "btnEmailEdit";
            this.btnEmailEdit.Size = new System.Drawing.Size(98, 35);
            this.btnEmailEdit.TabIndex = 4;
            this.btnEmailEdit.Text = "&Chỉnh sửa";
            this.btnEmailEdit.UseVisualStyleBackColor = true;
            this.btnEmailEdit.Click += new System.EventHandler(this.btnEmailEdit_Click);
            // 
            // btnEmailCopy
            // 
            this.btnEmailCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmailCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnEmailCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnEmailCopy.Image")));
            this.btnEmailCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmailCopy.Location = new System.Drawing.Point(235, 25);
            this.btnEmailCopy.Name = "btnEmailCopy";
            this.btnEmailCopy.Size = new System.Drawing.Size(108, 35);
            this.btnEmailCopy.TabIndex = 2;
            this.btnEmailCopy.Text = "&Sao chép";
            this.btnEmailCopy.UseVisualStyleBackColor = true;
            this.btnEmailCopy.Click += new System.EventHandler(this.btnEmailCopy_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbTitle.Location = new System.Drawing.Point(2, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(154, 16);
            this.lbTitle.TabIndex = 13;
            this.lbTitle.Text = "Quản lý mẫu gửi email";
            // 
            // dgEmailTemplateList
            // 
            this.dgEmailTemplateList.AllowUserToAddRows = false;
            this.dgEmailTemplateList.AllowUserToDeleteRows = false;
            this.dgEmailTemplateList.AllowUserToResizeColumns = false;
            this.dgEmailTemplateList.AllowUserToResizeRows = false;
            this.dgEmailTemplateList.ColumnHeadersHeight = 25;
            this.dgEmailTemplateList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Id,
            this.TemplateCode,
            this.TemplateTitle,
            this.TemplateName,
            this.Description});
            this.dgEmailTemplateList.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgEmailTemplateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEmailTemplateList.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgEmailTemplateList.Location = new System.Drawing.Point(0, 0);
            this.dgEmailTemplateList.Name = "dgEmailTemplateList";
            this.dgEmailTemplateList.ReadOnly = true;
            this.dgEmailTemplateList.RowHeadersWidth = 5;
            this.dgEmailTemplateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEmailTemplateList.Size = new System.Drawing.Size(881, 430);
            this.dgEmailTemplateList.TabIndex = 14;
            this.dgEmailTemplateList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmailTemplateList_CellDoubleClick);
            this.dgEmailTemplateList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmailTemplateList_CellEnter);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 70;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // TemplateCode
            // 
            this.TemplateCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TemplateCode.DataPropertyName = "TemplateCode";
            this.TemplateCode.FillWeight = 42.55319F;
            this.TemplateCode.HeaderText = "Mã ";
            this.TemplateCode.Name = "TemplateCode";
            this.TemplateCode.ReadOnly = true;
            this.TemplateCode.Width = 120;
            // 
            // TemplateTitle
            // 
            this.TemplateTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TemplateTitle.DataPropertyName = "TemplateTitle";
            this.TemplateTitle.FillWeight = 42.55319F;
            this.TemplateTitle.HeaderText = "Tiêu đề";
            this.TemplateTitle.Name = "TemplateTitle";
            this.TemplateTitle.ReadOnly = true;
            this.TemplateTitle.Width = 250;
            // 
            // TemplateName
            // 
            this.TemplateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TemplateName.DataPropertyName = "TemplateName";
            this.TemplateName.FillWeight = 42.55319F;
            this.TemplateName.HeaderText = "Tên mẫu email";
            this.TemplateName.Name = "TemplateName";
            this.TemplateName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.bindingNavigator);
            this.panel1.Controls.Add(this.dgEmailTemplateList);
            this.panel1.Location = new System.Drawing.Point(2, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 430);
            this.panel1.TabIndex = 15;
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator.Location = new System.Drawing.Point(0, 405);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(881, 25);
            this.bindingNavigator.TabIndex = 15;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // frmManagerTemplateEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManagerTemplateEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDemo";
            this.Load += new System.EventHandler(this.frmManagerTemplateEmail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmailTemplateList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

      
        private System.Windows.Forms.TextBox txtEmailCode;
        private System.Windows.Forms.Button btnEmailClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEmailDelete;
        private System.Windows.Forms.Button btnEmailAdd;
        private System.Windows.Forms.Button btnEmailSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridView dgEmailTemplateList;
        private System.Windows.Forms.Button btnEmailCopy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Button btnEmailEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;


    }
}