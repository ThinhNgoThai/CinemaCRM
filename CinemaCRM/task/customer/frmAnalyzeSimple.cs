using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using PresentationControls;

namespace CinemaCRM.task.customer
{
    public partial class frmAnalyzeSimple : Form
    {
        private DataTable _dataSource;
        private int caseSwitch = 1;
        private CrmDBConnect _connect;
        public frmAnalyzeSimple()
        {
            InitializeComponent();
            if(_connect == null)
            {
                _connect = new CrmDBConnect();
            }
        }

        #region Khu vực load dữ liệu
        private void TestReport_Load(object sender, EventArgs e)
        {
            LoadData();
            enableJobForm(true, true, true, true);            
        }

        private void LoadData()
        {
            tabAnalyzeControl.TabPages.Remove(tabTicket);
            //Clear series
            __clearSeries(chartJob, chartAge, chartArea, chartGenre, chartCategory, chartTicket, chartRevenue);

            //Lấy dữ liệu phân tích
            __loadCrmData("SP_CrmJob_CRUD", cbcJob, @"- Chọn nghề nghiệp -", "Id", 0, "JobName");
            __loadCrmData("SP_CrmAge_CRUD", cbcAge, @"- Chọn độ tuổi -", "Id", 0, "FromAge", "ToAge");
            __loadCrmData("SP_CrmArea_CRUD", cbcArea, @"- Chọn khu vực -", "ID", 6, "AreaName");
            __loadDataGenre(cbcGenre, @"- Chọn giới tính - ");
            __loadCrmData("SP_CrmCategory_CRUD", cbcCategory, @"- Thể loại phim -", "Id", 0, "Name");
            __loadCrmData("CRM_Dir_TicketBuy_CRUD", cbcTicket, @"- Số lượng vé -", "Id", 0, "FromTicketBuy", "ToTicketBuy");
            __loadCrmData("SP_CrmRevenue_CRUD", cbcRevenue, @"- Doanh thu -", "Id", 0, "FromRevenue", "ToRevenue");

            //Lấy thời gian trong năm
            __getTimeOfYear(cmbTimeJob, cmbTimeAge, cmbTimeArea, cmbTimeGenre, cmbTimeCategory, cmbTimeTicket, cmbTimeRevenue);
            //Load các kiểu biểu đồ
            __getChartType(cmbChartTypeJob, cmbChartTypeAge, cmbChartTypeArea, cmbChartTypeGenre, cmbChartTypeCategory, cmbChartTypeTicket, cmbChartTypeRevenue);
        }

        //Tự lấy thời gian theo lựa chọn
        private void cmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (caseSwitch)
            {
                case 1:
                    __getTime(cmbTimeJob, dtpStartJob, dtpEndJob, cmbAnalyzeJob);
                    break;
                case 2:
                    __getTime(cmbTimeAge, dtpStartAge, dtpEndAge, cmbAnalyzeAge);
                    break;
                case 3:
                    __getTime(cmbTimeArea, dtpStartArea, dtpEndArea, cmbAnalyzeArea);
                    break;
                case 4:
                    __getTime(cmbTimeGenre, dtpStartGenre, dtpEndGenre, cmbAnalyzeGenre);
                    break;
                //case 5:
                //    __getTime(cmbTimeShow, dtpStartShow, dtpEndShow, cmbAnalyzeShow);
                //    break;
                case 5:
                    __getTime(cmbTimeCategory, dtpStartCategory, dtpEndCategory, cmbAnalyzeCategory);
                    break;
                //case 7:
                //    __getTime(cmbTimeTicket, dtpStartTicket, dtpEndTicket, cmbAnalyzeTicket);
                //    break;
                case 6:
                    __getTime(cmbTimeRevenue, dtpStartRevenue, dtpEndRevenue, cmbAnalyzeRevenue);
                    break;
                default:
                    break;
            }

        }

        //Validate thời gian đầu cuối
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            //dtpEndJob.MinDate = dtpStartJob.Value;
            //dtpEndAge.MinDate = dtpStartAge.Value;
            //dtpEndArea.MinDate = dtpStartArea.Value;
            //dtpEndGenre.MinDate = dtpStartGenre.Value;
            //dtpEndShow.MinDate = dtpStartShow.Value;
            //dtpEndCategory.MinDate = dtpStartCategory.Value;
            //dtpEndTicket.MinDate = dtpStartTicket.Value;
            //dtpEndRevenue.MinDate = dtpStartRevenue.Value;
        }
        #endregion

        #region Các method hỗ trợ
        private static void __getTime(ComboBox cmbTime, DateTimePicker startDate, DateTimePicker endDate, ComboBox analyzeBox)
        {
            var ci = new CultureInfo("vi-VN");
            var currentYear = DateTime.Now.Year;

            try
            {
                if (null == cmbTime.SelectedItem) return;
                if (cmbTime.SelectedItem.ToString().StartsWith("Tháng"))
                {
                    startDate.Enabled = endDate.Enabled = false;
                    var monthInDigit = DateTime.ParseExact(cmbTime.SelectedItem.ToString(), "MMMM", ci).Month;
                    var lastDayOfMonth = DateTime.DaysInMonth(currentYear, monthInDigit);
                    startDate.Value = new DateTime(currentYear, monthInDigit, 1);
                    endDate.Value = new DateTime(currentYear, monthInDigit, lastDayOfMonth);

                    analyzeBox.Items.Clear();
                    analyzeBox.Items.Add("Ngày");
                    analyzeBox.SelectedItem = "Ngày";
                }
                else if (cmbTime.SelectedItem.ToString().StartsWith("Quý"))
                {
                    startDate.Enabled = endDate.Enabled = false;
                    var qChar = cmbTime.SelectedItem.ToString().Last();
                    var quarter = Char.GetNumericValue(qChar);
                    startDate.Value = new DateTime(currentYear, ((int)quarter - 1) * 3 + 1, 1);
                    endDate.Value = startDate.Value.AddMonths(3).AddDays(-1);

                    analyzeBox.Items.Clear();
                    object[] value = { "Ngày", "Tháng" };
                    analyzeBox.Items.AddRange(value);
                    analyzeBox.SelectedItem = "Tháng";
                }
                else if (cmbTime.SelectedItem.ToString() == "Khác")
                {
                    startDate.Enabled = endDate.Enabled = true;
                    analyzeBox.Items.Clear();
                    object[] value = { "Ngày", "Tháng", "Năm" };
                    analyzeBox.Items.AddRange(value);
                    analyzeBox.SelectedItem = "Ngày";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void __getTimeOfYear(params ComboBox[] comboBoxes)
        {
            var ci = new CultureInfo("vi-VN");
            object[] months = ci.DateTimeFormat.MonthNames;
            months = months.Where(m => !m.Equals("")).ToArray();

            foreach (var comboBox in comboBoxes)
            {
                comboBox.Items.AddRange(months);

                for (var i = 1; i <= 4; i++)
                {
                    comboBox.Items.Add("Quý " + i);
                }

                comboBox.Items.Add("Khác");
                comboBox.SelectedItem = "Khác";
            }
        }

        private static void __getChartType(params ComboBox[] comboBoxes)
        {
            var chartType = new List<chartType>
            {
                new chartType(1, "Biểu đồ cột"),
                new chartType(2, "Biểu đồ tròn"),
                new chartType(3, "Biểu đồ đường")
            };

            foreach (var comboBox in comboBoxes)
            {
                comboBox.DataSource = chartType;
                comboBox.DisplayMember = "Text";
                comboBox.ValueMember = "Id";
            }
        }

        private void __loadCrmData(string stored, CheckBoxComboBox checkBoxComboBox, string text, string id, int flag, params string[] columns)
        {
            _dataSource = new CrmDBConnect().myTable(stored, "@flag", flag);
            var listObject = new List<ObjectAnalyze>();

            if (columns.Count() > 1)
            {
                foreach (DataRow row in _dataSource.Rows)
                {
                    listObject.Add(new ObjectAnalyze(row[id].ToString(), row[columns[0]] + " - " + row[columns[1]]));
                }
            }
            else
            {
                foreach (DataRow row in _dataSource.Rows)
                {
                    listObject.Add(new ObjectAnalyze(row[id].ToString(), row[columns[0]].ToString()));
                }
            }

            checkBoxComboBox.DataSource = new ListSelectionWrapper<ObjectAnalyze>(listObject, "Text");
            checkBoxComboBox.DisplayMemberSingleItem = "Name";
            checkBoxComboBox.DisplayMember = "NameConcatenated";
            checkBoxComboBox.ValueMember = "Selected";
            checkBoxComboBox.Text = text;
        }

        private void __loadTicketData(string stored, CheckBoxComboBox checkBoxComboBox, string text, string id, int flag, params string[] columns)
        {
            _dataSource = new TicketDBConnect().myTable(stored, "@flag", flag);
            var listObject = new List<ObjectAnalyze>();

            if (columns.Count() > 1)
            {
                foreach (DataRow row in _dataSource.Rows)
                {
                    listObject.Add(new ObjectAnalyze(row[id].ToString(), row[columns[0]] + " - " + row[columns[1]]));
                }
            }
            else
            {
                foreach (DataRow row in _dataSource.Rows)
                {
                    listObject.Add(new ObjectAnalyze(row[id].ToString(), row[columns[0]].ToString()));
                }
            }

            checkBoxComboBox.DataSource = new ListSelectionWrapper<ObjectAnalyze>(listObject, "Text");
            checkBoxComboBox.DisplayMemberSingleItem = "Name";
            checkBoxComboBox.DisplayMember = "NameConcatenated";
            checkBoxComboBox.ValueMember = "Selected";
            checkBoxComboBox.Text = text;
        }

        private void __loadDataGenre(CheckBoxComboBox checkBoxComboBox, string text)
        {
            var listObject = new List<ObjectAnalyze>
            {
                new ObjectAnalyze("0", "Nữ"),
                new ObjectAnalyze("1", "Nam")
            };


            checkBoxComboBox.DataSource = new ListSelectionWrapper<ObjectAnalyze>(listObject, "Text");
            checkBoxComboBox.DisplayMemberSingleItem = "Name";
            checkBoxComboBox.DisplayMember = "NameConcatenated";
            checkBoxComboBox.ValueMember = "Selected";
            checkBoxComboBox.Text = text;
        }

        private void __clearSeries(params Chart[] charts)
        {
            foreach (var chart in charts)
            {
                chart.Series.Clear();
            }
        }
        #endregion

        #region Khu vực vẽ biểu đồ
        #region Tạo biểu đồ
        //Tạo biểu đồ theo Nghề nghiệp
        private void btnChartJob_Click(object sender, EventArgs e)
        {
            var type = 0;
            var titelY = rdRevenueJob.Text;
            if (rdCustomerJob.Checked == true)
            {
                type = 1;
                titelY = rdCustomerJob.Text;
            }
            __drawChart("SP_CrmCustomer_AnalyzeSimple", chartJob, cbcJob, cmbAnalyzeJob, cmbChartTypeJob, dtpStartJob, dtpEndJob, 0, type, titelY, "Nghề nghiệp");
        }

        //Tạo biểu đồ Độ tuổi
        private void btnChartAge_Click(object sender, EventArgs e)
        {
            var type = 0;
            var titelY = rdRevenueAge.Text;
            if (rdCustomerAge.Checked == true)
            {
                type = 1;
                titelY = rdCustomerAge.Text;
            }
            __drawChart_Range("SP_CrmCustomer_AnalyzeSimple", chartAge, cbcAge, cmbAnalyzeAge, cmbChartTypeAge, dtpStartAge, dtpEndAge, 1, type, titelY, "Độ tuổi");
        }

        //Tạo biểu đồ Khu vực
        private void btnChartArea_Click(object sender, EventArgs e)
        {
            var type = 0;
            var titelY = rdRevenueArea.Text;
            if (rdCustomerArea.Checked == true)
            {
                type = 1;
                titelY = rdCustomerArea.Text;
            }
            __drawChart("SP_CrmCustomer_AnalyzeSimple", chartArea, cbcArea, cmbAnalyzeArea, cmbChartTypeArea, dtpStartArea, dtpEndArea, 2, type, titelY, "Khu vực");
        }

        //Tạo biểu đồ Giới tính
        private void btnChartGenre_Click(object sender, EventArgs e)
        {
            var type = 0;
            var titelY = rdQuantityGenner.Text;
            if (rdCustomerGenner.Checked == true)
            {
                type = 1;
                titelY = rdCustomerGenner.Text;
            }
            __drawChart("SP_CrmCustomer_AnalyzeSimple", chartGenre, cbcGenre, cmbAnalyzeGenre, cmbChartTypeGenre, dtpStartGenre, dtpEndGenre, 3, type, "Số lượng khách hàng", "Giới tính");
        }

        //Tạo biểu đồ Khung giờ chiếu
        private void btnChartShow_Click(object sender, EventArgs e)
        {
            // __drawChart_Range("SP_CrmCustomer_AnalyzeSimpleOrder", chartShow, cbcShow, cmbAnalyzeShow, cmbChartTypeShow, dtpStartShow, dtpEndShow, 0, "Khung giờ chiếu");
        }

        //Tạo biểu đồ Thể loại phim
        private void btnChartCategory_Click(object sender, EventArgs e)
        {
            var type = 0;
            var titelY = rdRevennueFilm.Text;
            if (rdHabit.Checked == true)
            {
                type = 1;
                titelY = rdHabit.Text;
            }
            __drawChart("SP_CrmCustomer_AnalyzeSimpleCategoryFilm", chartCategory, cbcCategory, cmbAnalyzeCategory, cmbChartTypeCategory, dtpStartCategory, dtpEndCategory, 2, type, titelY, "Thể loại phim");
        }

        //Tạo biểu đồ số lượng vé bán ra/lần
        private void btnChartTicket_Click(object sender, EventArgs e)
        {
            // __drawChart_Range("SP_CrmCustomer_AnalyzeSimpleTicket", chartTicket, cbcTicket, cmbAnalyzeTicket, cmbChartTypeTicket, dtpStartTicket, dtpEndTicket, 0, "Số lượng vé bán ra/lần");
        }

        //Tạo biểu đồ Tổng doanh thu
        private void btnChartRevenue_Click(object sender, EventArgs e)
        {
            var type = 0;
            __drawChart_Range("SP_CrmCustomer_AnalyzeSimpleRevenue", chartRevenue, cbcRevenue, cmbAnalyzeRevenue, cmbChartTypeRevenue, dtpStartRevenue, dtpEndRevenue, 0, type, "Tổng doanh thu", "Mức doanh thu");
        }
        #endregion

        #region Vẽ biểu đồ
        private void __drawChart(string stored, Chart chart, CheckBoxComboBox cbComboBox, ComboBox analyzeBox, ComboBox chartType, DateTimePicker dateStart, DateTimePicker dateEnd, int flag, int type, string titleY, string titleX)
        {            
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Titles.Clear();
            var checkes = cbComboBox.CheckBoxItems.Where(j => j.Checked);            
            // tính theo doanh thu
            if (type == 0)
            {
                foreach (var data in checkes)
                {
                    #region Xử lý dữ liệu
                    var id = ((ObjectSelectionWrapper<ObjectAnalyze>)(data.ComboBoxItem)).Item.Id;
                    #endregion

                    switch (analyzeBox.Text.Trim())
                    {
                        case "Ngày":

                            #region Lấy dữ liệu
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //_dataSource = new DBConnect().myTable(stored, "@startDate", dateStart.Value,
                            //    "@endDate", dateEnd.Value, "@Common_Id", id, "@flag", flag, "@type", type, "@dateAnalyze", 0);
                            _dataSource = _connect.myTable(stored, "@startDate", dateStart.Value,
                                "@endDate", dateEnd.Value, "@Common_Id", id, "@flag", flag, "@type", type, "@dateAnalyze", 0);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            #region Vẽ biểu đồ

                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //switch (Convert.ToInt32(chartType.SelectedValue))
                            //{
                            //    case 1:
                            //        __columnChart(chart, data, _dataSource, "Date_Name", titleY, titleX);
                            //        break;
                            //    case 2:
                            //        __pieChart(chart, data, _dataSource, "Date_Name");
                            //        break;
                            //    case 3:
                            //        __lineChart(chart, data, _dataSource, "Date_Name", titleY, titleX);
                            //        break;
                            //}
                            __columnChart(chart, data, _dataSource, "Date_Name", titleY, titleX);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<

                            #endregion

                            break;
                        case "Tháng":

                            #region Lấy dữ liệu
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //_dataSource = new DBConnect().myTable(stored, "@startDate", dateStart.Value,
                            //    "@endDate", dateEnd.Value, "@Common_Id", id, "@flag", flag, "@type", type, "@dateAnalyze", 1);
                            _dataSource = _connect.myTable(stored, "@startDate", dateStart.Value,
                                "@endDate", dateEnd.Value, "@Common_Id", id, "@flag", flag, "@type", type, "@dateAnalyze", 1);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            #region Vẽ biểu đồ
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //switch (Convert.ToInt32(chartType.SelectedValue))
                            //{
                            //    case 1:
                            //        __columnChart(chart, data, _dataSource, "MonthName", titleY, titleX);
                            //        break;
                            //    case 2:
                            //        __pieChart(chart, data, _dataSource, "Tháng", "MonthName");
                            //        break;
                            //    case 3:
                            //        __lineChart(chart, data, _dataSource, "MonthName", titleY, titleX);
                            //        break;
                            //}
                            __columnChart(chart, data, _dataSource, "MonthName", titleY, titleX);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            break;
                        case "Năm":
                            #region Lấy dữ liệu
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //_dataSource = new DBConnect().myTable(stored, "@startDate", dateStart.Value,
                            //    "@endDate", dateEnd.Value, "@Common_Id", id, "@flag", flag, "@type", type, "@dateAnalyze", 2);
                            _dataSource = _connect.myTable(stored, "@startDate", dateStart.Value,
                                "@endDate", dateEnd.Value, "@Common_Id", id, "@flag", flag, "@type", type, "@dateAnalyze", 2);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            #region Vẽ biểu đồ
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //switch (Convert.ToInt32(chartType.SelectedValue))
                            //{
                            //    case 1:
                            //        __columnChart(chart, data, _dataSource, "YearName", titleY, titleX);
                            //        break;
                            //    case 2:
                            //        __pieChart(chart, data, _dataSource, "Năm", "YearName");
                            //        break;
                            //    case 3:
                            //        __lineChart(chart, data, _dataSource, "YearName", titleY, titleX);
                            //        break;
                            //}
                            __columnChart(chart, data, _dataSource, "YearName", titleY, titleX);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            break;
                    }
                }
            }
            else
            {
                foreach (var data in checkes)
                {
                    #region Xử lý dữ liệu
                    var id = ((ObjectSelectionWrapper<ObjectAnalyze>)(data.ComboBoxItem)).Item.Id;
                    #endregion

                    #region Lấy dữ liệu
                    //LONGDT - 22/12/2016 - thay đổi code từ >>>
                    //_dataSource = new DBConnect().myTable(stored, "@Common_Id", id, "@flag", flag, "@type", type, "@dateAnalyze", 0);
                    _dataSource = _connect.myTable(stored, "@Common_Id", id, "@flag", flag, "@type", type, "@dateAnalyze", 0);
                    // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                    #endregion

                    #region Vẽ biểu đồ
                    //LONGDT - 22/12/2016 - thay đổi code từ >>>
                    //switch (Convert.ToInt32(chartType.SelectedValue))
                    //{
                    //    case 1:
                    //        __columnChart(chart, data, _dataSource, "Name", titleY, titleX);
                    //        break;
                    //    case 2:
                    //        __pieChart(chart, data, _dataSource, "Name");
                    //        break;
                    //    case 3:
                    //        __lineChart(chart, data, _dataSource, "Name", titleY, titleX);
                    //        break;
                    //}
                    __columnChart(chart, data, _dataSource, "Name", titleY, titleX);
                    // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                    #endregion

                }
            }
            _connect.Dispose();            
        }

        private void __drawChart_Range(string stored, Chart chart, CheckBoxComboBox cbComboBox, ComboBox analyzeBox, ComboBox chartType, DateTimePicker dateStart, DateTimePicker dateEnd, int flag, int type, string titleY, string titleX)
        {
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Titles.Clear();

            var checkes = cbComboBox.CheckBoxItems.Where(j => j.Checked);

            if (type == 0)
            {
                foreach (var data in checkes)
                {
                    #region Xử lý dữ liệu
                    var id = ((ObjectSelectionWrapper<ObjectAnalyze>)(data.ComboBoxItem)).Item.Id;
                    var value = ((ObjectSelectionWrapper<ObjectAnalyze>)(data.ComboBoxItem)).Item.Text.Replace(" ", "");
                    var values = value.Split(Convert.ToChar("-"));
                    #endregion

                    switch (analyzeBox.Text.Trim())
                    {
                        case "Ngày":
                            #region Lấy dữ liệu
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //_dataSource = new DBConnect().myTable(stored, "@Common_Id", id, "@startDate", dateStart.Value, "@endDate", dateEnd.Value,
                            //                    "@fromValue", Convert.ToDecimal(values[0].ToString()), "@toValue", Convert.ToDecimal(values[1].ToString()), "@flag", flag, "@dateAnalyze", 0);
                            _dataSource = _connect.myTable(stored, "@Common_Id", id, "@startDate", dateStart.Value, "@endDate", dateEnd.Value,
                                                "@fromValue", Convert.ToDecimal(values[0].ToString()), "@toValue", Convert.ToDecimal(values[1].ToString()), "@flag", flag, "@dateAnalyze", 0);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            #region Vẽ biểu đồ
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //switch (Convert.ToInt32(chartType.SelectedValue))
                            //{
                            //    case 1:
                            //        __columnChart(chart, data, _dataSource, "Date_Name", titleY, titleX);
                            //        break;
                            //    case 2:
                            //        __pieChart(chart, data, _dataSource, "Date_Name");
                            //        break;
                            //    case 3:
                            //        __lineChart(chart, data, _dataSource, "Date_Name", titleY, titleX);
                            //        break;
                            //}
                            __columnChart(chart, data, _dataSource, "Date_Name", titleY, titleX);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            break;
                        case "Tháng":
                            #region Lấy dữ liệu
                            _dataSource = _connect.myTable(stored, "@startDate", dateStart.Value, "@endDate", dateEnd.Value,
                                                "@fromValue", values[0], "@toValue", values[1], "@flag", flag, "@dateAnalyze", 1);
                            #endregion

                            #region Vẽ biểu đồ
                            //switch (Convert.ToInt32(chartType.SelectedValue))
                            //{
                            //    case 1:
                            //        __columnChart(chart, data, _dataSource, "MonthName", titleY, titleX);
                            //        break;
                            //    case 2:
                            //        __pieChart(chart, data, _dataSource, "Tháng", "MonthName");
                            //        break;
                            //    case 3:
                            //        __lineChart(chart, data, _dataSource, "MonthName", titleY, titleX);
                            //        break;
                            //}
                            __columnChart(chart, data, _dataSource, "MonthName", titleY, titleX);
                            #endregion

                            break;
                        case "Năm":
                            #region Lấy dữ liệu
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //_dataSource = new DBConnect().myTable(stored, "@startDate", dateStart.Value, "@endDate", dateEnd.Value,
                            //                    "@fromValue", values[0], "@toValue", values[1], "@flag", flag, "@dateAnalyze", 2);
                            _dataSource = _connect.myTable(stored, "@startDate", dateStart.Value, "@endDate", dateEnd.Value,
                                                "@fromValue", values[0], "@toValue", values[1], "@flag", flag, "@dateAnalyze", 2);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            #region Vẽ biểu đồ
                            //LONGDT - 22/12/2016 - thay đổi code từ >>>
                            //switch (Convert.ToInt32(chartType.SelectedValue))
                            //{
                            //    case 1:
                            //        __columnChart(chart, data, _dataSource, "YearName", titleY, titleX);
                            //        break;
                            //    case 2:
                            //        __pieChart(chart, data, _dataSource, "Năm", "YearName");
                            //        break;
                            //    case 3:
                            //        __lineChart(chart, data, _dataSource, "YearName", titleY, titleX);
                            //        break;
                            //}
                            __columnChart(chart, data, _dataSource, "YearName", titleY, titleX);
                            // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                            #endregion

                            break;
                    }
                }
            }
            else
            {

                foreach (var data in checkes)
                {

                    #region Xử lý dữ liệu
                    var id = ((ObjectSelectionWrapper<ObjectAnalyze>)(data.ComboBoxItem)).Item.Id;
                    var value = ((ObjectSelectionWrapper<ObjectAnalyze>)(data.ComboBoxItem)).Item.Text.Replace(" ", "");
                    var values = value.Split(Convert.ToChar("-"));
                    #endregion
                    #region Lấy dữ liệu
                    //LONGDT - 22/12/2016 - thay đổi code từ >>>
                    //_dataSource = new DBConnect().myTable(stored, "@Common_Id", id, "@fromValue", values[0], "@toValue", values[1], "@flag", flag, "@type", type, "@dateAnalyze", 0);
                    _dataSource = _connect.myTable(stored, "@Common_Id", id, "@fromValue", values[0], "@toValue", values[1], "@flag", flag, "@type", type, "@dateAnalyze", 0);
                    // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                    #endregion

                    #region Vẽ biểu đồ
                    //LONGDT - 22/12/2016 - thay đổi code từ >>>
                    //switch (Convert.ToInt32(chartType.SelectedValue))
                    //{
                    //    case 1:
                    //        __columnChart(chart, data, _dataSource, "Name", titleY, titleX);
                    //        break;
                    //    case 2:
                    //        __pieChart(chart, data, _dataSource, "Name");
                    //        break;
                    //    case 3:
                    //        __lineChart(chart, data, _dataSource, "Name", titleY, titleX);
                    //        break;
                    //}
                    __columnChart(chart, data, _dataSource, "Name", titleY, titleX);
                    // LONGDT - 22/12/2016 - kết thúc thay đổi <<<<
                    #endregion
                }
            }
            _connect.Dispose();
        }
        #endregion

        #region Các biểu đồ
        //Biểu đồ cột
        private void __columnChart(Chart chart, CheckBoxComboBoxItem data, DataTable dataSource, string label, string titleY, string titleX)
        {
            if (!chart.ChartAreas.Any())
            {
                var areaColumn = new ChartArea
                {
                    Name = "ColumnChart",
                    AxisX = { Title = titleX },
                    AxisY = { Title = titleY }
                };
                chart.ChartAreas.Add(areaColumn);
            }

            var series = new Series
            {
                ChartArea = "ColumnChart",
                Name = data.Text,
                IsValueShownAsLabel = true,
                ToolTip = "Phần trăm: #PERCENT",
                LegendText = data.Text
            };
            chart.Series.Add(series);

            foreach (DataRow row in dataSource.Rows)
            {
                series.Points.AddXY(row[label
                    ], row["NumCustomer"]);
            }
        }

        //Biểu đồ tròn
        private void __pieChart(Chart chart, CheckBoxComboBoxItem data, DataTable dataSource, params string[] label)
        {
            var areaPie = new ChartArea { Name = data.Text };
            chart.ChartAreas.Add(areaPie);

            var title = new Title(data.Text, Docking.Bottom)
            {
                DockedToChartArea = data.Text,
                IsDockedInsideChartArea = false
            };
            chart.Titles.Add(title);

            var series = new Series
            {
                ChartArea = data.Text,
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                ToolTip = "Phần trăm: #PERCENT"
            };
            chart.Series.Add(series);

            if (chart.Series.Count() > 1)
                series.IsVisibleInLegend = false;

            if (label.Count() == 1)
            {
                foreach (DataRow row in dataSource.Rows)
                {
                    series.Points.AddXY(row[label[0]], row["NumCustomer"]);
                }
            }
            else
            {
                foreach (DataRow row in dataSource.Rows)
                {
                    series.Points.AddXY(label[0] + " " + row[label[1]], row["NumCustomer"]);
                }
            }
        }

        //Biểu đồ đường
        private void __lineChart(Chart chart, CheckBoxComboBoxItem data, DataTable dataSource, string label, string titleY, string titleX)
        {
            if (!chart.ChartAreas.Any())
            {
                var areaLine = new ChartArea
                {
                    Name = "SplineChart",
                    AxisX = { Title = titleX },
                    AxisY = { Title = titleY }
                };
                chart.ChartAreas.Add(areaLine);
            }

            var series = new Series
            {
                ChartArea = "SplineChart",
                ChartType = SeriesChartType.Spline,
                IsValueShownAsLabel = true,
                ToolTip = "Phần trăm: #PERCENT"
            };

            chart.Series.Add(series);

            foreach (DataRow row in dataSource.Rows)
            {
                series.LegendText = data.Text;
                series.Points.AddXY(row[label], row["NumCustomer"]);
            }
        }
        #endregion


        #endregion

        private void tabAnalyzeControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            caseSwitch = tabAnalyzeControl.SelectedIndex + 1;

            //2016/07/01 ThienNQ Default selected combobox thời gian ở các tab
            SetDefaultSelectedCombobox();
        }

        //2016/07/01 ThienNQ Default selected combobox thời gian ở các tab
        //Tự lấy thời gian theo lựa chọn
        private void SetDefaultSelectedCombobox()
        {

            switch (caseSwitch)
            {
                case 1:
                    __getTime(cmbTimeJob, dtpStartJob, dtpEndJob, cmbAnalyzeJob);
                    break;
                case 2:
                    __getTime(cmbTimeAge, dtpStartAge, dtpEndAge, cmbAnalyzeAge);
                    break;
                case 3:
                    __getTime(cmbTimeArea, dtpStartArea, dtpEndArea, cmbAnalyzeArea);
                    break;
                case 4:
                    __getTime(cmbTimeGenre, dtpStartGenre, dtpEndGenre, cmbAnalyzeGenre);
                    break;
                case 5:
                    __getTime(cmbTimeCategory, dtpStartCategory, dtpEndCategory, cmbAnalyzeCategory);
                    break;
                case 6:
                    __getTime(cmbTimeRevenue, dtpStartRevenue, dtpEndRevenue, cmbAnalyzeRevenue);
                    break;
                default:
                    break;
            }

        }

        private void tabGenre_Click(object sender, EventArgs e)
        {
            enableGennerForm(true, true, true, true);
        }

        // enable genner form
        private void enableGennerForm(bool _cbTimeGenner, bool _cbAnalyze, bool _dtpStart, bool _dtpEnd)
        {
            cmbTimeGenre.Enabled = _cbTimeGenner;
            cmbAnalyzeGenre.Enabled = _cbAnalyze;
            dtpStartGenre.Enabled = _dtpStart;
            dtpEndGenre.Enabled = _dtpEnd;
        }

        private void rdQuantityGenner_CheckedChanged(object sender, EventArgs e)
        {
            enableGennerForm(true, true, true, true);
        }

        private void rdCustomerGenner_CheckedChanged(object sender, EventArgs e)
        {
            enableGennerForm(false, false, false, false);
        }

        private void rdRevenueJob_CheckedChanged(object sender, EventArgs e)
        {
            enableJobForm(true, true, true, true);
        }

        // enable  form
        private void enableJobForm(bool _cbTimeJob, bool _cbAnalyze, bool _dtpStart, bool _dtpEnd)
        {
            cmbTimeJob.Enabled = _cbTimeJob;
            cmbAnalyzeJob.Enabled = _cbAnalyze;
            dtpStartJob.Enabled = _dtpStart;
            dtpEndJob.Enabled = _dtpEnd;
        }

        private void rdCustomerJob_CheckedChanged(object sender, EventArgs e)
        {
            enableJobForm(false, false, false, false);
        }

        private void rdHabit_CheckedChanged(object sender, EventArgs e)
        {
            enableFilmForm(false, false, false, false);
        }

        private void enableFilmForm(bool _cbTimeCategory, bool _cbAnalyze, bool _dtpStart, bool _dtpEnd)
        {
            cmbTimeCategory.Enabled = _cbTimeCategory;
            cmbAnalyzeCategory.Enabled = _cbAnalyze;
            dtpStartCategory.Enabled = _dtpStart;
            dtpEndCategory.Enabled = _dtpEnd;
        }

        private void rdRevennueFilm_CheckedChanged(object sender, EventArgs e)
        {
            enableFilmForm(true, true, true, true);
        }

        private void cbcCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdRevenueAge_CheckedChanged(object sender, EventArgs e)
        {
            enableAgeForm(true, true, true, true);
        }

        private void enableAgeForm(bool _cbTime, bool _cbAnalyze, bool _dtpStart, bool _dtpEnd)
        {
            cmbTimeAge.Enabled = _cbTime;
            cmbAnalyzeAge.Enabled = _cbAnalyze;
            dtpStartAge.Enabled = _dtpStart;
            dtpEndAge.Enabled = _dtpEnd;
        }

        private void rdCustomerAge_CheckedChanged(object sender, EventArgs e)
        {
            enableAgeForm(false, false, false, false);
        }


        private void enableAreaForm(bool _cbTime, bool _cbAnalyze, bool _dtpStart, bool _dtpEnd)
        {
            cmbTimeArea.Enabled = _cbTime;
            cmbAnalyzeArea.Enabled = _cbAnalyze;
            dtpStartArea.Enabled = _dtpStart;
            dtpEndArea.Enabled = _dtpEnd;
        }

        private void rdRevenueArea_CheckedChanged(object sender, EventArgs e)
        {
            enableAreaForm(true, true, true, true);
        }

        private void rdCustomerArea_CheckedChanged(object sender, EventArgs e)
        {
            enableAreaForm(false, false, false, false);
        }

        private void cmbAnalyzeRevenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 2016/04/20 - NguyenNT >>>
            enableRevenueForm(true, true, true, true);
            // 2016/04/20 - NguyenNT <<<
        }

        private void enableRevenueForm(bool _cbTime, bool _cbAnalyze, bool _dtpStart, bool _dtpEnd)
        {
            cmbTimeRevenue.Enabled = _cbTime;
            cmbAnalyzeRevenue.Enabled = _cbAnalyze;
            dtpStartRevenue.Enabled = _dtpStart;
            dtpEndRevenue.Enabled = _dtpEnd;
        }

        private void rdRevenuOrder_CheckedChanged(object sender, EventArgs e)
        {
            enableRevenueForm(false, false, false, false);
        }

    }

    #region Các class hỗ trợ
    public class chartType
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public chartType(int Id, string Text)
        {
            this.Id = Id;
            this.Text = Text;
        }
    }

    public class ObjectAnalyze
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public ObjectAnalyze(string Id, string Text)
        {
            this.Id = Id;
            this.Text = Text;
        }
    }
    #endregion
}
