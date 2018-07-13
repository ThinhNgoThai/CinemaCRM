namespace CinemaCRM.dir
{
    partial class frmTimePrice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimePrice));
            this.grdTimePricePlus = new System.Windows.Forms.DataGridView();
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
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPricePlus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimePricePlus)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTimePricePlus
            // 
            this.grdTimePricePlus.AllowUserToAddRows = false;
            this.grdTimePricePlus.AllowUserToDeleteRows = false;
            this.grdTimePricePlus.AllowUserToResizeColumns = false;
            this.grdTimePricePlus.AllowUserToResizeRows = false;
            this.grdTimePricePlus.ColumnHeadersHeight = 30;
            this.grdTimePricePlus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colVersionName,
            this.colDateTypeName,
            this.colName,
            this.colFromTime,
            this.colToTime,
            this.colPricePlus});
            this.grdTimePricePlus.Location = new System.Drawing.Point(0, 0);
            this.grdTimePricePlus.MultiSelect = false;
            this.grdTimePricePlus.Name = "grdTimePricePlus";
            this.grdTimePricePlus.ReadOnly = true;
            this.grdTimePricePlus.RowHeadersWidth = 4;
            this.grdTimePricePlus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdTimePricePlus.Size = new System.Drawing.Size(683, 453);
            this.grdTimePricePlus.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Khung giờ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FromTime";
            this.dataGridViewTextBoxColumn3.HeaderText = "Giờ bắt đầu";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ToTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "Giờ kết thúc";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "VersionCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "VersionName";
            this.dataGridViewTextBoxColumn6.HeaderText = "Phiên bản";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PricePlusNormal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "### ### ### ##0";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn7.HeaderText = "Giá (+) ngày thường";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PricePlusSpecial";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "### ### ### ##0";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn8.HeaderText = "Giá (+) ngày lễ";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "VersionName";
            this.dataGridViewTextBoxColumn9.HeaderText = "Phiên bản áp dụng";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PricePlusNormal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "### ### ### ##0";
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn10.HeaderText = "Giá (+) thêm";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colVersionName
            // 
            this.colVersionName.DataPropertyName = "VersionName";
            this.colVersionName.HeaderText = "Phiên bản";
            this.colVersionName.Name = "colVersionName";
            this.colVersionName.ReadOnly = true;
            this.colVersionName.Width = 113;
            // 
            // colDateTypeName
            // 
            this.colDateTypeName.DataPropertyName = "DateType";
            this.colDateTypeName.HeaderText = "Ngày";
            this.colDateTypeName.Name = "colDateTypeName";
            this.colDateTypeName.ReadOnly = true;
            this.colDateTypeName.Width = 113;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Khung giờ";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 113;
            // 
            // colFromTime
            // 
            this.colFromTime.DataPropertyName = "FromTime";
            this.colFromTime.HeaderText = "Giờ bắt đầu";
            this.colFromTime.Name = "colFromTime";
            this.colFromTime.ReadOnly = true;
            this.colFromTime.Width = 112;
            // 
            // colToTime
            // 
            this.colToTime.DataPropertyName = "ToTime";
            this.colToTime.HeaderText = "Giờ kết thúc";
            this.colToTime.Name = "colToTime";
            this.colToTime.ReadOnly = true;
            this.colToTime.Width = 113;
            // 
            // colPricePlus
            // 
            this.colPricePlus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPricePlus.DataPropertyName = "PricePlus";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "### ### ### ##0";
            this.colPricePlus.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPricePlus.HeaderText = "Giá (+) thêm";
            this.colPricePlus.Name = "colPricePlus";
            this.colPricePlus.ReadOnly = true;
            // 
            // frmTimePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(683, 451);
            this.Controls.Add(this.grdTimePricePlus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimePrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục khung giờ";
            this.Load += new System.EventHandler(this.frmTimePrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTimePricePlus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTimePricePlus;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPricePlus;
    }
}