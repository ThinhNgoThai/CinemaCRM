namespace CinemaCRM.task.marketing
{
    partial class frmCampaignList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCampaignList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCampaignName = new System.Windows.Forms.TextBox();
            this.grdCampaign = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCampaignName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartOnUtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndOnUtc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colParameterCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParamValue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParamValue2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParamValue3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParamValue4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParamValue5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCampaign)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbTitle.Location = new System.Drawing.Point(12, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(150, 16);
            this.lbTitle.TabIndex = 19;
            this.lbTitle.Text = "Danh mục khuyến mại";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCampaignName);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm khuyến mại";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(508, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 35);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "&Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(17, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tìm theo tên khuyến mại";
            // 
            // txtCampaignName
            // 
            this.txtCampaignName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCampaignName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCampaignName.ForeColor = System.Drawing.Color.Black;
            this.txtCampaignName.Location = new System.Drawing.Point(174, 21);
            this.txtCampaignName.MaxLength = 30;
            this.txtCampaignName.Name = "txtCampaignName";
            this.txtCampaignName.Size = new System.Drawing.Size(328, 20);
            this.txtCampaignName.TabIndex = 0;
            // 
            // grdCampaign
            // 
            this.grdCampaign.AllowUserToAddRows = false;
            this.grdCampaign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCampaign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCampaign.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCampaignName,
            this.colStartOnUtc,
            this.colEndOnUtc,
            this.colClosed,
            this.colParameterCount,
            this.colParamValue1,
            this.colParamValue2,
            this.colParamValue3,
            this.colParamValue4,
            this.colParamValue5});
            this.grdCampaign.Location = new System.Drawing.Point(15, 111);
            this.grdCampaign.Name = "grdCampaign";
            this.grdCampaign.ReadOnly = true;
            this.grdCampaign.RowHeadersWidth = 60;
            this.grdCampaign.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdCampaign.Size = new System.Drawing.Size(896, 499);
            this.grdCampaign.TabIndex = 0;
            this.grdCampaign.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCampaign_CellDoubleClick);
            this.grdCampaign.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCampaign_CellEnter);
            this.grdCampaign.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdCampaign_DataBindingComplete);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 5;
            // 
            // colCampaignName
            // 
            this.colCampaignName.DataPropertyName = "Name";
            this.colCampaignName.HeaderText = "Tên chương trình khuyến mại";
            this.colCampaignName.Name = "colCampaignName";
            this.colCampaignName.ReadOnly = true;
            this.colCampaignName.Width = 250;
            // 
            // colStartOnUtc
            // 
            this.colStartOnUtc.DataPropertyName = "StartOnUtc";
            dataGridViewCellStyle1.Format = "dd-MM-yyyy";
            this.colStartOnUtc.DefaultCellStyle = dataGridViewCellStyle1;
            this.colStartOnUtc.HeaderText = "Ngày bắt đầu";
            this.colStartOnUtc.Name = "colStartOnUtc";
            this.colStartOnUtc.ReadOnly = true;
            this.colStartOnUtc.Width = 85;
            // 
            // colEndOnUtc
            // 
            this.colEndOnUtc.DataPropertyName = "EndOnUtc";
            dataGridViewCellStyle2.Format = "dd-MM-yyyy";
            this.colEndOnUtc.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEndOnUtc.HeaderText = "Ngày kết thúc";
            this.colEndOnUtc.Name = "colEndOnUtc";
            this.colEndOnUtc.ReadOnly = true;
            this.colEndOnUtc.Width = 85;
            // 
            // colClosed
            // 
            this.colClosed.DataPropertyName = "Closed";
            this.colClosed.HeaderText = "Kết thúc";
            this.colClosed.Name = "colClosed";
            this.colClosed.ReadOnly = true;
            this.colClosed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colClosed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colClosed.Width = 50;
            // 
            // colParameterCount
            // 
            this.colParameterCount.DataPropertyName = "ParameterCount";
            this.colParameterCount.HeaderText = "SL tham số";
            this.colParameterCount.Name = "colParameterCount";
            this.colParameterCount.ReadOnly = true;
            this.colParameterCount.Width = 50;
            // 
            // colParamValue1
            // 
            this.colParamValue1.DataPropertyName = "ParamValue1";
            this.colParamValue1.HeaderText = "Giá trị tham số 1";
            this.colParamValue1.Name = "colParamValue1";
            this.colParamValue1.ReadOnly = true;
            this.colParamValue1.Width = 95;
            // 
            // colParamValue2
            // 
            this.colParamValue2.DataPropertyName = "ParamValue2";
            this.colParamValue2.HeaderText = "Giá trị tham số 2";
            this.colParamValue2.Name = "colParamValue2";
            this.colParamValue2.ReadOnly = true;
            this.colParamValue2.Width = 95;
            // 
            // colParamValue3
            // 
            this.colParamValue3.DataPropertyName = "ParamValue3";
            this.colParamValue3.HeaderText = "Giá trị tham số 3";
            this.colParamValue3.Name = "colParamValue3";
            this.colParamValue3.ReadOnly = true;
            this.colParamValue3.Width = 95;
            // 
            // colParamValue4
            // 
            this.colParamValue4.DataPropertyName = "ParamValue4";
            this.colParamValue4.HeaderText = "Giá trị tham số 4";
            this.colParamValue4.Name = "colParamValue4";
            this.colParamValue4.ReadOnly = true;
            this.colParamValue4.Width = 95;
            // 
            // colParamValue5
            // 
            this.colParamValue5.DataPropertyName = "ParamValue5";
            this.colParamValue5.HeaderText = "Giá trị tham số 5";
            this.colParamValue5.Name = "colParamValue5";
            this.colParamValue5.ReadOnly = true;
            this.colParamValue5.Width = 95;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Controls.Add(this.btnFinish);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.butAdd);
            this.groupBox2.Location = new System.Drawing.Point(15, 617);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 51);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFinish.ForeColor = System.Drawing.Color.Navy;
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(278, 12);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(120, 35);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "Kết thúc";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(412, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Xóa ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.ForeColor = System.Drawing.Color.Navy;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(144, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(770, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // butAdd
            // 
            this.butAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAdd.ForeColor = System.Drawing.Color.Navy;
            this.butAdd.Image = ((System.Drawing.Image)(resources.GetObject("butAdd.Image")));
            this.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAdd.Location = new System.Drawing.Point(10, 12);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(120, 35);
            this.butAdd.TabIndex = 0;
            this.butAdd.Text = "Thêm mới";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên chương trình khuyến mại";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "StartOnUtc";
            dataGridViewCellStyle3.Format = "dd-MM-yyyy";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "Ngày bắt đầu";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EndOnUtc";
            dataGridViewCellStyle4.Format = "dd-MM-yyyy";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "Ngày kết thúc";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Closed";
            this.dataGridViewTextBoxColumn5.HeaderText = "Kết thúc";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ParameterCount";
            this.dataGridViewTextBoxColumn6.HeaderText = "SL tham số";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ParamValue1";
            this.dataGridViewTextBoxColumn7.HeaderText = "Tham số 1";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 95;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ParamValue2";
            this.dataGridViewTextBoxColumn8.HeaderText = "Tham số 2";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 95;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ParamValue3";
            this.dataGridViewTextBoxColumn9.HeaderText = "Tham số 3";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 95;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ParamValue4";
            this.dataGridViewTextBoxColumn10.HeaderText = "Tham số 4";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 95;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ParamValue5";
            this.dataGridViewTextBoxColumn11.HeaderText = "Tham số 5";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // frmCampaignList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(924, 670);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grdCampaign);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCampaignList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCampaignList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCampaign)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCampaignName;
        private System.Windows.Forms.DataGridView grdCampaign;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCampaignName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartOnUtc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndOnUtc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParameterCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParamValue1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParamValue2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParamValue3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParamValue4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParamValue5;
    }
}