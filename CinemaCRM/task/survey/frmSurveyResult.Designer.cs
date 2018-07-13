namespace CinemaCRM.task.survey
{
    partial class frmSurveyResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSurveyResult));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbQuestionGroup = new System.Windows.Forms.ComboBox();
            this.cmbQuestionType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.STT_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answers_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartSurvey = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.dgvSurveyResult = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFromAge = new System.Windows.Forms.TextBox();
            this.txtToAge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.grbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSurvey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveyResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cmbQuestionGroup);
            this.groupBox3.Controls.Add(this.cmbQuestionType);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Location = new System.Drawing.Point(10, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(945, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin lọc";
            // 
            // cmbQuestionGroup
            // 
            this.cmbQuestionGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionGroup.FormattingEnabled = true;
            this.cmbQuestionGroup.Location = new System.Drawing.Point(110, 27);
            this.cmbQuestionGroup.Name = "cmbQuestionGroup";
            this.cmbQuestionGroup.Size = new System.Drawing.Size(152, 24);
            this.cmbQuestionGroup.TabIndex = 18;
            // 
            // cmbQuestionType
            // 
            this.cmbQuestionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestionType.FormattingEnabled = true;
            this.cmbQuestionType.Location = new System.Drawing.Point(364, 27);
            this.cmbQuestionType.Name = "cmbQuestionType";
            this.cmbQuestionType.Size = new System.Drawing.Size(152, 24);
            this.cmbQuestionType.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nhóm câu hỏi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(274, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Loại câu hỏi";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ForeColor = System.Drawing.Color.Navy;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(839, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "&Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grbResult
            // 
            this.grbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbResult.Controls.Add(this.dgvResult);
            this.grbResult.Controls.Add(this.chartSurvey);
            this.grbResult.Location = new System.Drawing.Point(287, 112);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(668, 354);
            this.grbResult.TabIndex = 4;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "Biểu đồ";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT_Result,
            this.Id_Result,
            this.Email_Result,
            this.Answers_Result});
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(3, 18);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(662, 333);
            this.dgvResult.TabIndex = 1;
            this.dgvResult.Visible = false;
            // 
            // STT_Result
            // 
            this.STT_Result.DataPropertyName = "STT";
            this.STT_Result.HeaderText = "STT";
            this.STT_Result.Name = "STT_Result";
            this.STT_Result.ReadOnly = true;
            this.STT_Result.Width = 50;
            // 
            // Id_Result
            // 
            this.Id_Result.DataPropertyName = "Id";
            this.Id_Result.HeaderText = "Id";
            this.Id_Result.Name = "Id_Result";
            this.Id_Result.ReadOnly = true;
            this.Id_Result.Visible = false;
            // 
            // Email_Result
            // 
            this.Email_Result.DataPropertyName = "Email";
            this.Email_Result.HeaderText = "Email";
            this.Email_Result.Name = "Email_Result";
            this.Email_Result.ReadOnly = true;
            this.Email_Result.Width = 200;
            // 
            // Answers_Result
            // 
            this.Answers_Result.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Answers_Result.DataPropertyName = "Answers";
            this.Answers_Result.HeaderText = "Câu trả lời";
            this.Answers_Result.Name = "Answers_Result";
            this.Answers_Result.ReadOnly = true;
            // 
            // chartSurvey
            // 
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartArea1";
            this.chartSurvey.ChartAreas.Add(chartArea2);
            this.chartSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartSurvey.Legends.Add(legend2);
            this.chartSurvey.Location = new System.Drawing.Point(3, 18);
            this.chartSurvey.Name = "chartSurvey";
            series2.ChartArea = "ChartArea1";
            series2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSurvey.Series.Add(series2);
            this.chartSurvey.Size = new System.Drawing.Size(662, 333);
            this.chartSurvey.TabIndex = 0;
            this.chartSurvey.Text = "chart1";
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Biểu đồ ABC";
            this.chartSurvey.Titles.Add(title2);
            // 
            // cmbChartType
            // 
            this.cmbChartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Items.AddRange(new object[] {
            "Biểu đồ tròn",
            "Biểu đồ đường",
            "Biểu đồ cột"});
            this.cmbChartType.Location = new System.Drawing.Point(827, 85);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(128, 24);
            this.cmbChartType.TabIndex = 9;
            this.cmbChartType.SelectedIndexChanged += new System.EventHandler(this.@__analyzeAnswers);
            // 
            // cmbGenre
            // 
            this.cmbGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Items.AddRange(new object[] {
            "Biểu đồ tròn",
            "Biểu đồ đường",
            "Biểu đồ cột"});
            this.cmbGenre.Location = new System.Drawing.Point(685, 85);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(128, 24);
            this.cmbGenre.TabIndex = 9;
            this.cmbGenre.SelectionChangeCommitted += new System.EventHandler(this.cmbGenre_SelectionChangeCommitted);
            // 
            // dgvSurveyResult
            // 
            this.dgvSurveyResult.AllowUserToAddRows = false;
            this.dgvSurveyResult.AllowUserToDeleteRows = false;
            this.dgvSurveyResult.AllowUserToResizeColumns = false;
            this.dgvSurveyResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvSurveyResult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSurveyResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurveyResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Id,
            this.QuestionName,
            this.GroupId,
            this.TypeId});
            this.dgvSurveyResult.Location = new System.Drawing.Point(10, 85);
            this.dgvSurveyResult.MultiSelect = false;
            this.dgvSurveyResult.Name = "dgvSurveyResult";
            this.dgvSurveyResult.ReadOnly = true;
            this.dgvSurveyResult.RowHeadersWidth = 5;
            this.dgvSurveyResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSurveyResult.Size = new System.Drawing.Size(271, 381);
            this.dgvSurveyResult.TabIndex = 10;
            this.dgvSurveyResult.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSurveyResult_CellEnter);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STT.DefaultCellStyle = dataGridViewCellStyle3;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 50;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // QuestionName
            // 
            this.QuestionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuestionName.DataPropertyName = "QuestionName";
            this.QuestionName.HeaderText = "Các câu hỏi";
            this.QuestionName.Name = "QuestionName";
            this.QuestionName.ReadOnly = true;
            // 
            // GroupId
            // 
            this.GroupId.DataPropertyName = "GroupId";
            this.GroupId.HeaderText = "GroupId";
            this.GroupId.Name = "GroupId";
            this.GroupId.ReadOnly = true;
            this.GroupId.Visible = false;
            // 
            // TypeId
            // 
            this.TypeId.DataPropertyName = "TypeId";
            this.TypeId.HeaderText = "TypeId";
            this.TypeId.Name = "TypeId";
            this.TypeId.ReadOnly = true;
            this.TypeId.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "STT";
            this.dataGridViewTextBoxColumn1.HeaderText = "STT";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "QuestionName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Câu hỏi";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Answers";
            this.dataGridViewTextBoxColumn3.HeaderText = "Các trả lời";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Percentage";
            this.dataGridViewTextBoxColumn5.HeaderText = "%";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "QuestionName";
            this.dataGridViewTextBoxColumn6.HeaderText = "Các câu hỏi";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "GroupId";
            this.dataGridViewTextBoxColumn7.HeaderText = "GroupId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TypeId";
            this.dataGridViewTextBoxColumn8.HeaderText = "TypeId";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Độ tuổi:";
            // 
            // txtFromAge
            // 
            this.txtFromAge.Location = new System.Drawing.Point(342, 86);
            this.txtFromAge.Name = "txtFromAge";
            this.txtFromAge.Size = new System.Drawing.Size(30, 22);
            this.txtFromAge.TabIndex = 12;
            this.txtFromAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromAge_KeyPress);
            // 
            // txtToAge
            // 
            this.txtToAge.Location = new System.Drawing.Point(405, 86);
            this.txtToAge.Name = "txtToAge";
            this.txtToAge.Size = new System.Drawing.Size(30, 22);
            this.txtToAge.TabIndex = 13;
            this.txtToAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToAge_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "đến";
            // 
            // frmSurveyResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(964, 478);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtToAge);
            this.Controls.Add(this.txtFromAge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSurveyResult);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.cmbChartType);
            this.Controls.Add(this.grbResult);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSurveyResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả khảo sát";
            this.Load += new System.EventHandler(this.frmSurveyResult_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grbResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSurvey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveyResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbQuestionGroup;
        private System.Windows.Forms.ComboBox cmbQuestionType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grbResult;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSurvey;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.DataGridView dgvSurveyResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeId;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Answers_Result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFromAge;
        private System.Windows.Forms.TextBox txtToAge;
        private System.Windows.Forms.Label label4;



    }
}