using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.Contanst;
using System.Reflection;

namespace CinemaCRM.Reports
{
    public partial class frmReports : Form
    {
        public CrmDBConnect crmdbconnect = new CrmDBConnect();
        public TicketDBConnect ticketdbconnect = new TicketDBConnect();

        public frmReports()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hiển thị thông tin ban đầu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReports_Load(object sender, EventArgs e)
        {
            //Hiển thị danh sách Rạp chiếu phim
            DataTable tblCinemas = ticketdbconnect.myTable("SP_Store_GetAll");
            this.cboStore.DataSource = tblCinemas;
            this.cboStore.ValueMember = "Id";
            this.cboStore.DisplayMember = "Name";
            if (tblCinemas.Rows.Count == 1) cboStore.Enabled = false;

            //Default loại báo cáo
            grb2.Enabled = false;
            grb4.Enabled = false;
            dtpRpt1Month.Enabled = false;
        }

        /// <summary>
        /// Đóng form xuất báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Lựa chọn mẫu báo cáo
        private void rbnRpt1_CheckedChanged(object sender, EventArgs e)
        {
            grb1.Enabled = rbnRpt1.Checked;
            rbnDay.Checked = true;
        }

        private void rbnDay_CheckedChanged(object sender, EventArgs e)
        {
            dtpRpt1Day.Enabled = rbnDay.Checked;
        }

        private void rbnMonth_CheckedChanged(object sender, EventArgs e)
        {
            dtpRpt1Month.Enabled = rbnMonth.Checked;
        }

        private void rbnRpt2_CheckedChanged(object sender, EventArgs e)
        {
            grb2.Enabled = rbnRpt2.Checked;
            if (rbnRpt2.Checked)
            {
                //Lấy danh sách chương trình khuyến mại với điều kiện thời gian đã nhập vào.
                getDataCampaign();
            }
        }

        private void rbnRpt4_CheckedChanged(object sender, EventArgs e)
        {
            grb4.Enabled = rbnRpt4.Checked;
        }
        #endregion Lựa chọn mẫu báo cáo

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string fileName;

            //Lấy tên file báo cáo từ lựa chọn trên form
            if (rbnRpt1.Checked)
            {
                fileName = Contanst.Contanst.gCurrentDirectory + "Report\\BCTheoKhungGioChieu.xls";
            }
            else if (rbnRpt2.Checked)
            {
                fileName = Contanst.Contanst.gCurrentDirectory + "Report\\BCKetQuaChuongTrinhKhuyenMai.xls";
            }
            else if (rbnRpt3.Checked)
            {
                fileName = Contanst.Contanst.gCurrentDirectory + "Report\\BCThongTinKhachHang.xls";
            }
            else
            {
                fileName = Contanst.Contanst.gCurrentDirectory + "Report\\BCSuDungDiemThuongDeDoiQua.xls";
            }

            //Khởi tạo cột
            String[] Characters;
            int j;
            //KHOI TAO BANG CHU CAI PHUC VỤ DANH DIA CHI COT CUA EXCEL
            j = 65;
            int dem = 0;
            Characters = new String[200];
            while (dem < 200)
            {
                if (dem <= 25) Characters[dem] = Convert.ToChar(j).ToString();
                else Characters[dem] = "A" + Convert.ToChar(j - 26).ToString();
                dem = dem + 1;
                j = j + 1;
            }

            //Xuất file excel
            String mPath;
            saveFileDialog.Filter = "(*.xls)|*.xls";
            saveFileDialog.ShowDialog();
            mPath = saveFileDialog.FileName;

            if (string.IsNullOrEmpty(mPath))
            {
                MessageBox.Show("Bạn chưa chọn tên file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Khởi tạo
                Excel.Application excApp = new Excel.Application();
                excApp.DisplayAlerts = false;
                Excel.Workbook excelWorkbook = excApp.Workbooks.Open(fileName, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, false, true, false, false);
                excelWorkbook.SaveCopyAs(mPath);
                Excel.Sheets excelSheet = excelWorkbook.Worksheets;
                String SheetName = "Sheet1";
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheet.get_Item(SheetName);
                Excel.Range excelCell = null;

                // Xử lý dữ liệu báo cáo
                if (rbnRpt1.Checked)
                {
                    #region Báo cáo số lượng khán giả theo khung giờ chiếu

                    //Get data
                    DataSet getDataAll = ticketdbconnect.myDataset("SP_ReportQuantityOfGuest", "@Classification", (rbnMonth.Checked ? 0 : 1), "@Date", (rbnMonth.Checked ? dtpRpt1Month.Value.Date : dtpRpt1Day.Value.Date));

                    //Hiển thị các mức giá vé
                    int StartColPrice = 1;
                    //Tổng số vé mỗi khung giờ
                    int[] khung = new int[5] { 0, 0, 0, 0, 0 };

                    //Phân loại báo cáo
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[1] + "5", Characters[1] + "5");
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    excelCell.Value2 = (rbnMonth.Checked ? dtpRpt1Month.Value.ToString("MM/yyyy") : dtpRpt1Day.Value.ToString("dd/MM/yyyy"));

                    //Header text "Số lượng khán giả"
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[1] + "7", Characters[1 + getDataAll.Tables[0].Rows.Count - 1] + "7");
                    excelCell.Merge(Type.Missing);
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = "Số lượng khán giả";

                    //Giá vé

                    //Đổ dữ liệu theo giá tiền
                    if (getDataAll.Tables[0].Rows.Count > 0)
                    {
                        //Đổ dữ liệu giá vé (tạo các cột tương ứng các mức giá vé)
                        for (int p = 0; p < getDataAll.Tables[0].Rows.Count; p++)
                        {
                            //Header giá vé
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice] + "8", Characters[StartColPrice] + "8");
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Font.Bold = true;
                            excelCell.Value2 = string.Format("{0:#,0}", getDataAll.Tables[0].Rows[p]["Price"]);

                            //Fill data tương ứng
                            //Trước 12:00
                            DataRow[] dr = getDataAll.Tables[2].Select("Price = " + getDataAll.Tables[0].Rows[p]["Price"].ToString());
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice] + "9", Characters[StartColPrice] + "9");
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Font.Bold = false;
                            excelCell.Value2 = (dr.Length > 0 ? string.Format("{0:#,0}", dr[0].ItemArray[0]) : "0");
                            khung[0] += (dr.Length > 0 ? Convert.ToInt32(dr[0].ItemArray[0]) : 0);

                            //Từ 12:00 trước 17:00
                            dr = getDataAll.Tables[3].Select("Price = " + getDataAll.Tables[0].Rows[p]["Price"].ToString());
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice] + "10", Characters[StartColPrice] + "10");
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Font.Bold = false;
                            excelCell.Value2 = (dr.Length > 0 ? string.Format("{0:#,0}", dr[0].ItemArray[0]) : "0");
                            khung[1] += (dr.Length > 0 ? Convert.ToInt32(dr[0].ItemArray[0]) : 0);

                            //Từ 17:00 trước 19:00
                            dr = getDataAll.Tables[4].Select("Price = " + getDataAll.Tables[0].Rows[p]["Price"].ToString());
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice] + "11", Characters[StartColPrice] + "11");
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Font.Bold = false;
                            excelCell.Value2 = (dr.Length > 0 ? string.Format("{0:#,0}", dr[0].ItemArray[0]) : "0");
                            khung[2] += (dr.Length > 0 ? Convert.ToInt32(dr[0].ItemArray[0]) : 0);

                            //Từ 19:00 đến 22:00
                            dr = getDataAll.Tables[5].Select("Price = " + getDataAll.Tables[0].Rows[p]["Price"].ToString());
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice] + "12", Characters[StartColPrice] + "12");
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Font.Bold = false;
                            excelCell.Value2 = (dr.Length > 0 ? string.Format("{0:#,0}", dr[0].ItemArray[0]) : "0");
                            khung[3] += (dr.Length > 0 ? Convert.ToInt32(dr[0].ItemArray[0]) : 0);

                            //Sau 22:00
                            dr = getDataAll.Tables[6].Select("Price = " + getDataAll.Tables[0].Rows[p]["Price"].ToString());
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice] + "13", Characters[StartColPrice] + "13");
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = (dr.Length > 0 ? string.Format("{0:#,0}", dr[0].ItemArray[0]) : "0");
                            khung[4] += (dr.Length > 0 ? Convert.ToInt32(dr[0].ItemArray[0]) : 0);

                            StartColPrice += 1;
                        }
                    }

                    //Text Tổng cộng
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice] + "7", Characters[StartColPrice] + "8");
                    excelCell.Merge(Type.Missing);
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = "Tổng cộng";

                    //fill value cho column tổng cộng
                    for (int i = 0; i < 5; i++)
                    {
                        excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice] + (9 + i).ToString(), Characters[StartColPrice] + (9 + i).ToString());
                        excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                        excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        excelCell.Font.Bold = true;
                        excelCell.Value2 = string.Format("{0:#,0}", khung[i]);
                    }

                    //Hà Nội, ngày.... tháng ...  năm 2016  
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[StartColPrice - 1] + "15", Characters[StartColPrice - 1] + "15");
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = "Hà Nội, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();

                    #endregion Báo cáo số lượng khán giả theo khung giờ chiếu
                }
                else if (rbnRpt2.Checked)
                {
                    #region Báo cáo kết quả khuyến mại
                    //Get data
                    DataSet getDataAll = crmdbconnect.myDataset("SP_ReportResultCampaign", "@CampaignId", cboCampaign.SelectedValue);

                    if (getDataAll.Tables[1].Rows.Count > 0)
                    {
                        //Tên chương trình khuyến mại
                        excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[2] + "5", Characters[2] + "5");
                        excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        excelCell.Value2 = getDataAll.Tables[1].Rows[0]["Name"].ToString();

                        //Khoảng thời gian
                        excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[2] + "6", Characters[2] + "6");
                        excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        excelCell.Value2 = Convert.ToDateTime(getDataAll.Tables[1].Rows[0]["StartOnUtc"]).ToString("dd/MM/yyyy") + " - " + Convert.ToDateTime(getDataAll.Tables[1].Rows[0]["EndOnUtc"]).ToString("dd/MM/yyyy");
                    }

                    //Dòng bắt đầu fill data
                    int startRowFillData = 10;
                    //Tổng số vé
                    int intTotalQuantity = 0;
                    //Tổng số tiền bán vé
                    decimal intTotalOrder = 0;
                    //Tổng số tiền khuyến mại
                    decimal intTotalCampaign = 0;

                    //Đổ dữ liệu
                    if (getDataAll.Tables[0].Rows.Count > 0)
                    {
                        for (int p = 0; p < getDataAll.Tables[0].Rows.Count; p++)
                        {
                            //Số thứ tự
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[0] + startRowFillData.ToString(), Characters[0] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = (p + 1).ToString();

                            //Cột họ khách hàng
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[1] + startRowFillData.ToString(), Characters[1] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = getDataAll.Tables[0].Rows[p]["CustomerLastName"].ToString();

                            //Cột tên khách hàng
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[2] + startRowFillData.ToString(), Characters[2] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = getDataAll.Tables[0].Rows[p]["CustomerFirstName"].ToString();

                            //Thời gian thực hiện giao dịch
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[3] + startRowFillData.ToString(), Characters[3] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = Convert.ToDateTime(getDataAll.Tables[0].Rows[p]["PrintedOnUtc"]).ToString("dd-MM-yyyy HH:mm:ss");

                            //Mức chi tiêu
                            //Số vé
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[4] + startRowFillData.ToString(), Characters[4] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = getDataAll.Tables[0].Rows[p]["Quantity"].ToString();
                            intTotalQuantity += (string.IsNullOrEmpty(getDataAll.Tables[0].Rows[p]["Quantity"].ToString()) ? 0 : Convert.ToInt32(getDataAll.Tables[0].Rows[p]["Quantity"]));

                            //Thành tiền
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[5] + startRowFillData.ToString(), Characters[5] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = string.Format("{0:#,0}", getDataAll.Tables[0].Rows[p]["OrderTotal"]);
                            intTotalOrder += (string.IsNullOrEmpty(getDataAll.Tables[0].Rows[p]["OrderTotal"].ToString()) ? 0 : Convert.ToDecimal(getDataAll.Tables[0].Rows[p]["OrderTotal"]));

                            //Mức khuyến mại được hưởng tính trên mức chi tiêu
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[6] + startRowFillData.ToString(), Characters[6] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = string.Format("{0:#,0}", getDataAll.Tables[0].Rows[p]["TotalCampaign"]);
                            intTotalCampaign += (string.IsNullOrEmpty(getDataAll.Tables[0].Rows[p]["TotalCampaign"].ToString()) ? 0 : Convert.ToDecimal(getDataAll.Tables[0].Rows[p]["TotalCampaign"]));

                            startRowFillData += 1;
                        }
                    }

                    //Hiển thị phần Tổng cộng
                    //Text "Tổng cộng" 
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[0] + startRowFillData.ToString(), Characters[3] + startRowFillData.ToString());
                    excelCell.Merge(Missing.Value);
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = "Tổng cộng";

                    //Tổng số vé
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[4] + startRowFillData.ToString(), Characters[4] + startRowFillData.ToString());
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = string.Format("{0:#,0}", intTotalQuantity);

                    //Tổng số tiền bán vé
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[5] + startRowFillData.ToString(), Characters[5] + startRowFillData.ToString());
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = string.Format("{0:#,0}", intTotalOrder);

                    //Tổng số vé
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[6] + startRowFillData.ToString(), Characters[6] + startRowFillData.ToString());
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = string.Format("{0:#,0}", intTotalCampaign);

                    //Hà Nội, ngày.... tháng ...  năm 2016  
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[5] + (startRowFillData + 2).ToString(), Characters[5] + (startRowFillData + 2).ToString());
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = "Hà Nội, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();

                    #endregion Báo cáo kết quả khuyến mại
                }
                else if (rbnRpt3.Checked)
                {
                    #region Báo cáo thông tin khách hàng
                    //Get data
                    DataSet getDataAll = crmdbconnect.myDataset("SP_ReportInfoGuest");

                    //Dòng bắt đầu fill data
                    int startRowFillData = 7;

                    //Đổ dữ liệu
                    if (getDataAll.Tables[0].Rows.Count > 0)
                    {
                        for (int p = 0; p < getDataAll.Tables[0].Rows.Count; p++)
                        {
                            //Số thứ tự
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[0] + startRowFillData.ToString(), Characters[0] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = (p + 1).ToString();

                            //Cột họ khách hàng
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[1] + startRowFillData.ToString(), Characters[1] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = getDataAll.Tables[0].Rows[p]["CustomerLastName"].ToString();

                            //Cột tên khách hàng
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[2] + startRowFillData.ToString(), Characters[2] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = getDataAll.Tables[0].Rows[p]["CustomerFirstName"].ToString();

                            //Điểm tích lũy
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[3] + startRowFillData.ToString(), Characters[3] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = string.Format("{0:#,0.0}", getDataAll.Tables[0].Rows[p]["PointCard"]);

                            //Điểm thưởng
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[4] + startRowFillData.ToString(), Characters[4] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = string.Format("{0:#,0.0}", getDataAll.Tables[0].Rows[p]["PointReward"]);

                            //Thẻ
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[5] + startRowFillData.ToString(), Characters[5] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = getDataAll.Tables[0].Rows[p]["CardCode"].ToString();

                            //Ngày kích hoạt
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[6] + startRowFillData.ToString(), Characters[6] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = (string.IsNullOrEmpty(getDataAll.Tables[0].Rows[p]["DateCreateCard"].ToString()) ? "" : Convert.ToDateTime(getDataAll.Tables[0].Rows[p]["DateCreateCard"]).ToString("dd/MM/yyyy"));

                            //Ngày hết hạn
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[7] + startRowFillData.ToString(), Characters[7] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = (string.IsNullOrEmpty(getDataAll.Tables[0].Rows[p]["DateExpireCard"].ToString()) ? "" : Convert.ToDateTime(getDataAll.Tables[0].Rows[p]["DateExpireCard"]).ToString("dd/MM/yyyy"));

                            //Phiên giao dịch cuối cùng
                            //Thời gian
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[8] + startRowFillData.ToString(), Characters[8] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = (string.IsNullOrEmpty(getDataAll.Tables[0].Rows[p]["LastActivityDateUtc"].ToString()) ? "" : (Convert.ToDateTime(getDataAll.Tables[0].Rows[p]["LastActivityDateUtc"]).ToString("dd/MM/yyyy HH:mm:ss")));

                            ////Giá trị
                            //excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[9] + startRowFillData.ToString(), Characters[9] + startRowFillData.ToString());
                            //excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            //excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            //excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            //excelCell.Value2 = string.Format("{0:#,0}", getDataAll.Tables[0].Rows[p]["OrderTotal"]);

                            startRowFillData += 1;
                        }
                    }

                    //Hà Nội, ngày.... tháng ...  năm 2016  
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[8] + (startRowFillData + 1).ToString(), Characters[8] + (startRowFillData + 1).ToString());
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = "Hà Nội, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();

                    #endregion Báo cáo thông tin khách hàng
                }
                else
                {
                    #region Báo cáo sử dụng điểm thưởng để đổi quà

                    //Get data
                    DataSet getDataAll = crmdbconnect.myDataset("SP_ReportUseReward", "@FromDate", dtpUseRewardFrom.Value.Date, "@ToDate", dtpUseRewardTo.Value.Date);

                    //Từ ngày....... đến ngày.......
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[4] + "5", Characters[4] + "5");
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = "Từ ngày " + dtpUseRewardFrom.Value.Date.ToString("dd/MM/yyyy") + " đến ngày " + dtpUseRewardTo.Value.Date.ToString("dd/MM/yyyy");

                    //Dòng bắt đầu fill data
                    int startRowFillData = 8;

                    //Đổ dữ liệu
                    if (getDataAll.Tables[0].Rows.Count > 0)
                    {
                        //Đổ dữ liệu giá vé (tạo các cột tương ứng các mức giá vé)
                        for (int p = 0; p < getDataAll.Tables[0].Rows.Count; p++)
                        {
                            //Số thứ tự
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[0] + startRowFillData.ToString(), Characters[0] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = (p + 1).ToString();

                            //Cột họ khách hàng
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[1] + startRowFillData.ToString(), Characters[1] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = getDataAll.Tables[0].Rows[p]["CustomerLastName"].ToString();

                            //Cột tên khách hàng
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[2] + startRowFillData.ToString(), Characters[2] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = getDataAll.Tables[0].Rows[p]["CustomerFirstName"].ToString();

                            //Điểm tích lũy hiện tại
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[3] + startRowFillData.ToString(), Characters[3] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = string.Format("{0:#,0.0}", getDataAll.Tables[0].Rows[p]["PointCard"]);

                            //Điểm thưởng hiện tại
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[4] + startRowFillData.ToString(), Characters[4] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = string.Format("{0:#,0.0}", getDataAll.Tables[0].Rows[p]["PointReward"]);

                            //Giá trị giao dịch trong khoảng thời gian báo cáo
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[5] + startRowFillData.ToString(), Characters[5] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = string.Format("{0:#,0}", getDataAll.Tables[0].Rows[p]["Total"]);

                            //Điểm thưởng đã sử dụng để đổi quà
                            excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[6] + startRowFillData.ToString(), Characters[6] + startRowFillData.ToString());
                            excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            excelCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            excelCell.Value2 = string.Format("{0:#,0.0}", (string.IsNullOrEmpty(getDataAll.Tables[0].Rows[p]["TotalUseReward"].ToString()) ? 0 : getDataAll.Tables[0].Rows[p]["TotalUseReward"]));

                            startRowFillData += 1;
                        }
                    }

                    //Hà Nội, ngày.... tháng ...  năm 2016  
                    excelCell = (Excel.Range)excelWorksheet.get_Range(Characters[5] + (startRowFillData + 1).ToString(), Characters[5] + (startRowFillData + 1).ToString());
                    excelCell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    excelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    excelCell.Font.Bold = true;
                    excelCell.Value2 = "Hà Nội, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();

                    #endregion Báo cáo sử dụng điểm thưởng để đổi quà
                }
                //Kết thúc quá trình xử lý dữ liệu báo cáo

                excelCell.Merge(Missing.Value);

                // Kế thúc việc xuất file
                excelWorkbook.Close(true, mPath, null);
                excApp.Quit();
                System.Diagnostics.Process.Start(mPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtpRpt2Day_Leave(object sender, EventArgs e)
        {
            //Lấy danh sách chương trình khuyến mại với điều kiện thời gian đã nhập vào.
            getDataCampaign();
        }

        /// <summary>
        /// Hiển thị danh sách chương trình khuyến mại
        /// </summary>
        private void getDataCampaign()
        {
            //Binding campaigns
            DataTable tblCampaigns = crmdbconnect.myTable("SP_CrmCampaign_GetByDate", "@Date", dtpRpt2Day.Value.Date);

            cboCampaign.DataSource = tblCampaigns;
            cboCampaign.ValueMember = "Id";
            cboCampaign.DisplayMember = "Name";
        }
    }
}
