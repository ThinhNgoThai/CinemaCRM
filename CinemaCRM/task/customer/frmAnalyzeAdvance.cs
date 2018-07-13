using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PresentationControls;
using System.Windows.Forms.DataVisualization.Charting;

namespace CinemaCRM.task.customer
{
    public partial class frmAnalyzeAdvance : Form
    {
        private DataSet _dataSet;
        private static string _xLabel, _yLabel;
        private static DataTable _resultTable;
        private CrmDBConnect _connect;

        #region Khởi tạo & Load dữ liệu
        public frmAnalyzeAdvance()
        {
            InitializeComponent();
            //LONGDT - 22/12/2016 - thay đổi code từ >>>
            _connect = new CrmDBConnect();
            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
        }

        private void frmAnalyzeAdvance_Load(object sender, EventArgs e)
        {            
            __loadData(cbcJob, cbcArea, cbcGenre, cbcAge, cbcTime, cbcType);
            __loadDataAnalyze();
            chartAnalyze.Series.Clear();
            cmbTime.Enabled = false;            
        }
        #endregion

        #region Các method hỗ trợ
        private void __loadData(params CheckBoxComboBox[] checkBoxComboBoxes)
        {
            long start = DateTime.Now.Ticks;
            //LONGDT - 22/12/2016 - thay đổi code từ >>>
            //_dataSet = new DBConnect().myDataset("SP_CrmCustomer_AnalyzeAdvance", "@flag", 0);
            _dataSet = _connect.myDataset("SP_CrmCustomer_AnalyzeAdvance", "@flag", 0);
            _connect.Dispose();
            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
            var i = 1;
            foreach (var checkBoxComboBox in checkBoxComboBoxes)
            {
                var text = checkBoxComboBox.Text;
                checkBoxComboBox.Items.Clear();
                checkBoxComboBox.DataSource = new ListSelectionWrapper<DataRow>(_dataSet.Tables[i].Rows, "Text");
                checkBoxComboBox.DisplayMemberSingleItem = "Name";
                checkBoxComboBox.DisplayMember = "NameConcatenated";
                checkBoxComboBox.ValueMember = "Selected";
                checkBoxComboBox.Text = text;
                i++;
            }
            long end = DateTime.Now.Ticks;
            long result = end - start;
            System.Console.WriteLine("Initdata handling in {0:N2} seconds", (new TimeSpan(result)).TotalSeconds);
        }

        private void __loadDataAnalyze()
        {
            #region Phân tích theo
            // 2016/04/21 - NguyenNT >>>
            // __createDataAnalyze(cmbAnalyze, "- Phân tích theo -", "Nghề nghiệp", "Khu vực", "Giới tính", "Độ tuổi", "Khung giờ chiếu", "Thể loại phim");
            __createDataAnalyze(cmbAnalyze, "Nghề nghiệp", "Khu vực", "Giới tính", "Độ tuổi",
                "Khung giờ chiếu", "Thể loại phim");
            // 2016/04/21 - NguyenNT <<<
            #endregion

            #region Thống kê theo
            // 2016/04/21 - NguyenNT >>>
            // __createDataAnalyze(cmbStatistic, "- Thống kê theo -", "Tổng doanh thu", "Số vé đã mua", "Tần suất xem lại");
            __createDataAnalyze(cmbStatistic, "Tổng doanh thu");
            // 2016/04/21 - NguyenNT <<<
            #endregion

            #region Chọn thời gian
            // 2016/04/21 - NguyenNT >>>
            // __createDataAnalyze(cmbTime, "- Chọn thời gian -", "Ngày", "Tháng", "Năm");
            __createDataAnalyze(cmbTime, "Ngày", "Tháng", "Năm");
            // 2016/04/21 - NguyenNT <<<
            #endregion

            #region Các biểu đồ
            // 2016/04/21 - NguyenNT >>>
            // __createDataAnalyze(cmbChartType, "- Chọn biểu đồ -", "Biểu đồ cột", "Biểu đồ tròn", "Biểu đồ đường");
            __createDataAnalyze(cmbChartType, "Biểu đồ cột");
            // 2016/04/21 - NguyenNT <<<
            #endregion
        }

        private void __createDataAnalyze(ComboBox comboBox, params string[] values)
        {
            var analyzeCombo = new List<AnalyzeObject>();
            var i = 1;

            foreach (var value in values)
            {
                analyzeCombo.Add(new AnalyzeObject(i, value));
                i++;
            }

            comboBox.DataSource = analyzeCombo;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Id";

            // 2016/04/21 - NguyenNT >>>
            // comboBox.Text = text;
            // 2016/04/21 - NguyenNT <<<
        }

        private void __clearChart()
        {
            chartAnalyze.ChartAreas.Clear();
            chartAnalyze.Series.Clear();
            chartAnalyze.Titles.Clear();
        }

        private string __getCheckedItems(CheckBoxComboBox checkBoxComboBox)
        {
            return String.Join(",", checkBoxComboBox.CheckBoxItems.
                Where(c => c.Checked).
                Select(c => ((ObjectSelectionWrapper<DataRow>)(c.ComboBoxItem)).Item.ItemArray[0]));
        }

        private CheckBoxComboBox __getCbc(string value)
        {
            switch (value)
            {
                case "1":
                    return cbcJob;
                case "2":
                    return cbcArea;
                case "3":
                    return cbcGenre;
                case "4":
                    return cbcAge;
                case "5":
                    return cbcTime;
                case "6":
                    return cbcType;
                default:
                    return null;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.MinDate = dtpStart.Value;
        }

        private void chkTime_CheckStateChanged(object sender, EventArgs e)
        {
            cmbAnalyze.Enabled = !chkTime.Checked;
            cmbTime.Enabled = chkTime.Checked;
        }

        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Tạo biểu đồ
        //Tạo biểu đồ
        private void btnCreateChart_Click(object sender, EventArgs e)
        {            
            var analyzeValue = cmbAnalyze.SelectedValue.ToString();
            _xLabel = !chkTime.Checked ? cmbAnalyze.Text : "Thời gian";
            __drawChart(__getCbc(analyzeValue), _xLabel, _yLabel = cmbStatistic.Text);
        }

        //Thay đổi loại biểu đồ
        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            __clearChart();

            if (null == _resultTable) return;

            switch (cmbChartType.SelectedValue.ToString())
            {
                case "1":
                    __columnChart(_resultTable, _xLabel, _yLabel);
                    break;
                case "2":
                    __pieChart(_resultTable, _xLabel);
                    break;
                case "3":
                    __lineChart(_resultTable, _xLabel, _yLabel);
                    break;
            }
        }
        #endregion

        #region Vẽ biểu đồ
        private void __drawChart(CheckBoxComboBox checkBoxComboBox, string error, string yLabel)
        {
            if (String.IsNullOrEmpty(__getCheckedItems(checkBoxComboBox)) && !chkTime.Checked)
            {
                MessageBox.Show(@"Bạn phải chọn " + error, @"Có lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            System.Console.WriteLine(String.Format("Analytics starting [{0} - {1}]...", dtpStart.Value, dtpEnd.Value));
            __clearChart();    
            _resultTable = __getResultData();
            
            //LONGDT - 22/12/2016 - thay đổi code từ >>>
            //switch (cmbChartType.SelectedValue.ToString())
            //{
            //    case "1":
            //        __columnChart(_resultTable, !chkTime.Checked ? cmbAnalyze.Text : "Thời gian", yLabel);
            //        break;
            //    case "2":
            //        __pieChart(_resultTable, !chkTime.Checked ? cmbAnalyze.Text : "Thời gian");
            //        break;
            //    case "3":
            //        __lineChart(_resultTable, !chkTime.Checked ? cmbAnalyze.Text : "Thời gian", yLabel);
            //        break;
            //}            
            __columnChart(_resultTable, !chkTime.Checked ? cmbAnalyze.Text : "Thời gian", yLabel);           
            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
        }

        private DataTable __getResultData()
        {            
            var dateAnalyze = chkTime.Checked ? cmbTime.SelectedValue.ToString() : "0";
            var analyzeType = chkTime.Checked ? "0" : cmbAnalyze.SelectedValue.ToString();
            //LONGDT - 22/12/2016 - thay đổi code từ >>>
            //return new DBConnect().myTable("SP_CrmCustomer_AnalyzeAdvance", "@Job_Ids", __getCheckedItems(cbcJob),
            //    "@Area_Ids", __getCheckedItems(cbcArea), "@Genre_Ids", __getCheckedItems(cbcGenre),
            //    "@Age_Ids", __getCheckedItems(cbcAge), "@TimePrice_Ids", __getCheckedItems(cbcTime),
            //    "@Category_Ids", __getCheckedItems(cbcType),
            //    "@startDate", dtpStart.Value, "@endDate", dtpEnd.Value,
            //    "@dateAnalyze", dateAnalyze, "@statisticAnalyze", cmbStatistic.SelectedValue.ToString(),
            //    "@analyzeType", analyzeType, "@flag", 1);

            DataTable result = _connect.executeQuery("SP_CrmCustomer_AnalyzeAdvance", "@Job_Ids", __getCheckedItems(cbcJob),
                "@Area_Ids", __getCheckedItems(cbcArea), "@Genre_Ids", __getCheckedItems(cbcGenre),
                "@Age_Ids", __getCheckedItems(cbcAge), "@TimePrice_Ids", __getCheckedItems(cbcTime),
                "@Category_Ids", __getCheckedItems(cbcType),
                "@startDate", dtpStart.Value, "@endDate", dtpEnd.Value,
                "@dateAnalyze", dateAnalyze, "@statisticAnalyze", cmbStatistic.SelectedValue.ToString(),
                "@analyzeType", analyzeType, "@flag", 1);
            _connect.Dispose();            
            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
            return result;
        }
        #endregion

        #region Các biểu đồ
        //Biểu đồ cột
        private void __columnChart(DataTable dataSource, string xTitle, string yTitle)
        {
            if (!chartAnalyze.ChartAreas.Any())
            {
                var areaColumn = new ChartArea
                {
                    Name = "chartArea",
                    AxisX = { Title = xTitle },
                    AxisY = { Title = yTitle }
                };
                areaColumn.AxisX.LabelStyle.Enabled = false;
                chartAnalyze.ChartAreas.Add(areaColumn);
            }

            foreach (DataRow row in dataSource.Rows)
            {
                var series = new Series
                {
                    ChartArea = "chartArea",
                    IsValueShownAsLabel = true,
                    ToolTip = "Phần trăm: #PERCENT",
                    LegendText = row["Name"].ToString()
                };
                chartAnalyze.Series.Add(series);

                series.Points.AddXY(row["Name"], row["Value"]);
            }
        }

        //Biểu đồ tròn
        private void __pieChart(DataTable dataSource, string label)
        {
            chartAnalyze.Titles.Clear();

            if (!chartAnalyze.ChartAreas.Any())
            {
                var area = new ChartArea { Name = "chartArea" };
                chartAnalyze.ChartAreas.Add(area);
            }

            var title = new Title(label, Docking.Bottom)
            {
                DockedToChartArea = "chartArea",
                IsDockedInsideChartArea = false
            };

            var series = new Series
            {
                ChartArea = "chartArea",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                ToolTip = "Phần trăm: #PERCENT"
            };
            chartAnalyze.Series.Add(series);
            chartAnalyze.Titles.Add(title);

            foreach (DataRow row in dataSource.Rows)
            {
                series.Points.AddXY(row["Name"], row["Value"]);
            }
        }

        //Biểu đồ đường
        private void __lineChart(DataTable dataSource, string xTitle, string yTitle)
        {
            if (!chartAnalyze.ChartAreas.Any())
            {
                var areaColumn = new ChartArea
                {
                    Name = "chartArea",
                    AxisX = { Title = xTitle },
                    AxisY = { Title = yTitle }
                };
                areaColumn.AxisX.LabelStyle.Enabled = false;
                chartAnalyze.ChartAreas.Add(areaColumn);
            }

            var series = new Series
            {
                ChartArea = "chartArea",
                ChartType = SeriesChartType.Spline,
                IsValueShownAsLabel = true,
                ToolTip = "Phần trăm: #PERCENT",
                LegendText = xTitle
            };
            chartAnalyze.Series.Add(series);

            foreach (DataRow row in dataSource.Rows)
            {
                series.Points.AddXY(row["Name"], row["Value"]);
            }
        }
        #endregion
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
