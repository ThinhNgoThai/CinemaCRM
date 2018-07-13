using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CinemaCRM.task.survey
{
    public partial class frmSurveyResult : Form
    {
        public string SurveyId { get; set; }
        private static DataTable _dataSource;
        private static BindingSource _bindingSource;

        public frmSurveyResult()
        {
            InitializeComponent();
        }

        private void frmSurveyResult_Load(object sender, EventArgs e)
        {
            __loadData();
            __loadDataSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = new List<string>();

            if (!cmbQuestionGroup.SelectedValue.ToString().Equals("0"))
                filter.Add("[GroupId] = '" + cmbQuestionGroup.SelectedValue + "'");

            if (!cmbQuestionType.SelectedValue.ToString().Equals("0"))
                filter.Add("[TypeId] = '" + cmbQuestionType.SelectedValue + "'");

            _bindingSource.Filter = String.Join(" AND ", filter);
            dgvSurveyResult.DataSource = _bindingSource;
        }

        #region Các method hỗ trợ
        private void __loadData()
        {
            #region Dữ liệu biểu đồ
            __createDataAnalyze(cmbGenre, true, "Nữ", "Nam");
            __createDataAnalyze(cmbChartType, false, "Biểu đồ cột", "Biểu đồ tròn");
            #endregion

            #region Bảng các câu hỏi
            var dataSource = new CrmDBConnect().myTable("SP_CrmSurvey_SurveyResult", "@SurveyId", SurveyId);

            if (dataSource.Rows.Count <= 0)
            {
                MessageBox.Show(
                    @"Khảo sát này hiện chưa có câu hỏi nào." + Environment.NewLine + @"Vui lòng cập nhật câu hỏi cho khảo sát này!",
                    @"Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Dispose();
                Close();
            }

            _bindingSource = new BindingSource { DataSource = dataSource };
            dgvSurveyResult.DataSource = _bindingSource;
            #endregion
        }

        private void __loadDataSearch()
        {
            var dataSet = new CrmDBConnect().myDataset("SP_CrmSurvey_QuestionDetail");
            if (dataSet.Tables != null && dataSet.Tables.Count > 0)
            {
                __setComboBox(dataSet.Tables[0], cmbQuestionType);
                __setComboBox(dataSet.Tables[1], cmbQuestionGroup);
            }
        }
        private void __setComboBox(DataTable dataTable, ComboBox comboBox)
        {
            var newRow = dataTable.Rows.Add();
            newRow["Id"] = 0;
            newRow["Name"] = "Tất cả";

            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
            comboBox.SelectedValue = 0;
        }

        private void __createDataAnalyze(ComboBox comboBox, bool isAll, params string[] values)
        {
            var analyzeCombo = new List<AnalyzeObject>();
            var i = 1;

            if (isAll)
            {
                analyzeCombo.Add(new AnalyzeObject(0, "Tất cả"));
                comboBox.SelectedValue = 0;
            }

            foreach (var value in values)
            {
                analyzeCombo.Add(new AnalyzeObject(i, value));
                i++;
            }

            comboBox.DataSource = analyzeCombo;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Id";
        }

        private void __clearChart()
        {
            chartSurvey.ChartAreas.Clear();
            chartSurvey.Series.Clear();
            chartSurvey.Titles.Clear();
        }

        private void __toggleResult(bool chartType, bool dgvSurvey)
        {
            chartSurvey.Visible = chartType;
            dgvResult.Visible = dgvSurvey;
        }
        #endregion

        #region Các sự kiện thay đổi biểu đồ
        private void dgvSurveyResult_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSurveyResult.CurrentRow.Cells["TypeId"].Value.ToString().Equals("Textbox"))
            {
                __loadDataAnalyze(2);
                __showAnswers();
                return;
            }

            __loadDataAnalyze();
            __analyzeAnswers(sender, e);
        }

        private void cmbGenre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvSurveyResult.CurrentRow.Cells["TypeId"].Value.ToString().Equals("Textbox"))
            {
                __loadDataAnalyze(2);
                __showAnswers();
                return;
            }

            __loadDataAnalyze();
            __analyzeAnswers(sender, e);
        } 
        #endregion

        #region Load dữ liệu & vẽ
        //Load dữ liệu phân tích
        private void __loadDataAnalyze(int flag = 1)
        {
            _dataSource = new CrmDBConnect().myTable("SP_CrmSurvey_SurveyResult", "@SurveyId", SurveyId,
                "@QuestionId", dgvSurveyResult.CurrentRow.Cells["Id"].Value.ToString(), "@Sex", cmbGenre.SelectedValue,
                "@FromAge", txtFromAge.Text.Trim(), "@ToAge", txtToAge.Text.Trim(), "@flag", flag);
        }

        //Vẽ biểu đồ
        private void __analyzeAnswers(object sender, EventArgs e)
        {
            __toggleResult(true, false);
            __clearChart();

            switch (cmbChartType.SelectedValue.ToString())
            {
                case "1":
                    __columnChart(_dataSource);
                    break;
                case "2":
                    __pieChart(_dataSource, cmbGenre.Text);
                    break;
            }
        }

        //Hiển thị kết quả nếu là Textbox
        private void __showAnswers()
        {
            __toggleResult(false, true);

            dgvResult.AutoGenerateColumns = false;
            dgvResult.DataSource = _dataSource;
        }
        #endregion

        #region Các biểu đồ
        //Biểu đồ cột
        private void __columnChart(DataTable dataSource)
        {
            var areaColumn = new ChartArea
            {
                Name = "ColumnChart",
                AxisX =
                {
                    Title = dgvSurveyResult.CurrentRow.Cells["QuestionName"].Value.ToString(),
                    TitleFont = new Font("Arial", 10)
                },
                AxisY =
                {
                    Title = "Số lượng",
                    TitleFont = new Font("Arial", 10)
                },
            };
            areaColumn.AxisX.LabelStyle.Enabled = false;
            chartSurvey.ChartAreas.Add(areaColumn);

            var total = dataSource.Rows.Cast<DataRow>().Sum(row => Convert.ToInt32(row["Quantity"]));
            foreach (DataRow row in dataSource.Rows)
            {
                var series = new Series
                {
                    ChartArea = "ColumnChart",
                    IsValueShownAsLabel = true,
                    Label = "#VAL",
                    ToolTip = Convert.ToString(decimal.Round(Convert.ToDecimal(row["Quantity"]) / total * 100, 2)) + "%",
                    LegendText = row["Answer"].ToString()
                };
                chartSurvey.Series.Add(series);

                series.Points.AddXY(row["Answer"], row["Quantity"]);
            }
        }

        //Biểu đồ tròn
        private void __pieChart(DataTable dataSource, string label)
        {
            var area = new ChartArea { Name = "pieArea" };
            chartSurvey.ChartAreas.Add(area);

            var title = new Title(label, Docking.Bottom)
            {
                DockedToChartArea = "pieArea",
                IsDockedInsideChartArea = false
            };
            chartSurvey.Titles.Add(title);

            var series = new Series
            {
                ChartArea = "pieArea",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                ToolTip = "Phần trăm: #PERCENT"
            };
            chartSurvey.Series.Add(series);

            foreach (DataRow row in dataSource.Rows)
            {
                series.Points.AddXY(row["Answer"], row["Quantity"]);
            }
        } 
        #endregion

        // 2016/06/06 NguyenNT Fix lỗi nhập được chữ >>>
        private void txtFromAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtToAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        // 2016/06/06 NguyenNT <<<
    }

    #region Các class hỗ trợ
    class AnalyzeObject
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public AnalyzeObject(int Id, string Text)
        {
            this.Id = Id;
            this.Text = Text;
        }
    }
    #endregion
}
