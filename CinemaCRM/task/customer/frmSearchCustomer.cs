using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.taks.customer;
using PresentationControls;
using CinemaCRM.Core;
using CinemaCRM.Contanst;
using System.Globalization;

namespace CinemaCRM.task.customer
{
    public partial class frmSearchCustomer : Form
    {
        private int rangeDateLoad = 10;
        private DataTable tblCrmCustomer;
        private bool _IsAddedToSendEmail = false;
        private bool _IsAddedToSendSms = false;

        public DataTable CustomerList
        {
            get { return tblCrmCustomer; }
            set { tblCrmCustomer = value; }
        }

        public bool IsAddedToSendEmail
        {
            get { return _IsAddedToSendEmail; }
            set { _IsAddedToSendEmail = value; }
        }

        public bool IsAddedToSendSms
        {
            get { return _IsAddedToSendSms; }
            set { _IsAddedToSendSms = value; }
        }

        public frmSearchCustomer()
        {
            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region Initial Form
        private void frmExportExcel_Load(object sender, EventArgs e)
        {
            this.LoadJob();
            this.LoadCardLevel();
            //  this.LoadPaymentStatus();
            this.LoadAreas();

            //  BindDefaultValue();
            btnExportExelSearch_Click(null, null);
        }
        /// <summary>
        /// Load Job
        /// </summary>

        private void LoadJob()
        {

            var tblJob = new CrmDBConnect().myTable("SP_CrmJob_CRUD");
            cbExportExcelJob.DataSource = new ListSelectionWrapper<DataRow>(
                tblJob.Rows,
                    "JobName" // "SomePropertyOrColumnName" will populate the Name on ObjectSelectionWrapper.
                );
            cbExportExcelJob.DisplayMemberSingleItem = "Name";

            cbExportExcelJob.DisplayMember = "NameConcatenated";
            cbExportExcelJob.ValueMember = "Selected";
            cbExportExcelJob.SelectedValue = 0;

        }
        //Load Card Level
        private void LoadCardLevel()
        {

            var tblCrmCustomer = new CrmDBConnect().myTable("SP_CrmCardLevel_CRUD", "@flag", 1);
            cbExportExcelCustomerLevel.DataSource = new ListSelectionWrapper<DataRow>(
                tblCrmCustomer.Rows,
                    "CardLevelName" // "SomePropertyOrColumnName" will populate the Name on ObjectSelectionWrapper.
                );
            cbExportExcelCustomerLevel.DisplayMemberSingleItem = "Name";
            cbExportExcelCustomerLevel.DisplayMember = "NameConcatenated";
            cbExportExcelCustomerLevel.ValueMember = "Selected";


        }
        /// <summary>
        /// Load payment status
        /// </summary>
        //private void LoadPaymentStatus()
        //{
        //    var status = new StatusExtension();
        //    var payments = status.pStatus.ToPaymentList();


        //    var list = new ListSelectionWrapper<StatusFeature>(payments, "Des");

        //    cbExportExcelPaymentStatus.DataSource = list;
        //    cbExportExcelPaymentStatus.DisplayMemberSingleItem = "Name";
        //    cbExportExcelPaymentStatus.DisplayMember = "NameConcatenated";
        //    cbExportExcelPaymentStatus.ValueMember = "Selected";


        //}
        //Load Card Level
        private void LoadAreas()
        {

            var tbm = new CrmDBConnect().myTable("SP_CrmArea_CRUD", "@flag", 6);

            if (tbm.Rows.Count > 0)
            {
                var binSource = new BindingSource { DataSource = tbm };

                clboxExportExcelArea.DataSource = binSource;
                clboxExportExcelArea.DisplayMember = "AreaName";
                clboxExportExcelArea.ValueMember = "Id";
            }

        }
        /// <summary>
        /// Load Current Columns
        /// </summary>
        //private void LoadColumns() {
        //    DataTable DT = new DataTable("ColumnsName");
        //    DT.Columns.AddRange(
        //        new DataColumn[]
        //        {
        //            new DataColumn("Id", typeof(int)),
        //            new DataColumn("Name", typeof(string)),                    

        //        });
        //    DT.Rows.Add(1, "CustomerFirstName");
        //    DT.Rows.Add(2, "CustomerLastName");
        //    DT.Rows.Add(3, "BirthDay");
        //    DT.Rows.Add(4, "Mobile");
        //    DT.Rows.Add(5, "Sex");
        //    DT.Rows.Add(6, "Marriage");
        //    DT.Rows.Add(7, "Addess");



        //    cbExportExcelChooseColumns.DataSource =
        //        new ListSelectionWrapper<DataRow>(
        //            DT.Rows,
        //            "Name" // "SomePropertyOrColumnName" will populate the Name on ObjectSelectionWrapper.
        //            );
        //    cbExportExcelChooseColumns.DisplayMemberSingleItem = "Name";
        //    cbExportExcelChooseColumns.DisplayMember = "NameConcatenated";
        //    cbExportExcelChooseColumns.ValueMember = "Selected";


        //}
        #endregion

        private void btnExportExel_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Contanst.Contanst.gCurrentDirectory + "Report\\Danhsachkhachhang.xls";
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;


                // xuất file
                String mPath;
                saveFileDialog1.Filter = "(*.xls)|*.xls";
                saveFileDialog1.ShowDialog();
                mPath = saveFileDialog1.FileName;

                if (string.IsNullOrEmpty(mPath))
                {
                    MessageBox.Show("Chưa nhập tên file !");
                    return;
                }

                Int32 i, j;

                xlApp = new Excel.Application();
                xlApp.DisplayAlerts = false;
                Excel.Workbook excelWorkbook = xlApp.Workbooks.Open(fileName, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, false, true, false, false);
                excelWorkbook.SaveCopyAs(mPath);
                Excel.Sheets excelSheet = excelWorkbook.Worksheets;
                String SheetName = "Sheet1";
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheet.get_Item(SheetName);
                Excel.Range excelCell = null;

                // Xử lý dữ liệu báo cáo      
                int k = 9;
                for (i = 0; i <= dgvExportExcelCustomers.RowCount - 1; i++)
                {
                    for (j = 0; j <= dgvExportExcelCustomers.ColumnCount - 1; j++)
                    {
                        string value = "";
                        if (dgvExportExcelCustomers[j, i].Value == null) value = null; else value = dgvExportExcelCustomers[j, i].Value.ToString();
                        excelWorksheet.Cells[k + 1, j + 1] = value;
                    }
                    k++;
                }

                excelWorkbook.SaveAs(mPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                excelWorkbook.Close(true, misValue, misValue);
                xlApp.Quit();

                MessageBox.Show("Xuất file Excel danh sách khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi. Xuất file Excel danh sách khách hàng không thành công." + "\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExelSearch_Click(object sender, EventArgs e)
        {

            var items = cbExportExcelJob.CheckBoxItems.FindAll(c => c.Checked);
            var selectedJobIds = new List<int>();
            foreach (var ite in items)
            {

                var id = Convert.ToInt32(((ObjectSelectionWrapper<DataRow>)(ite.ComboBoxItem)).Item.ItemArray[1].ToString());
                selectedJobIds.Add(id);
            }

            //current customer card level
            var itemCards = cbExportExcelCustomerLevel.CheckBoxItems.FindAll(c => c.Checked);
            var selectedCardIds = new List<int>();
            foreach (var ite in itemCards)
            {

                var id = Convert.ToInt32(((ObjectSelectionWrapper<DataRow>)(ite.ComboBoxItem)).Item.ItemArray[0].ToString());
                selectedCardIds.Add(id);
            }
            //ages
            var startage = Convert.ToInt32(String.IsNullOrEmpty(txtExportExcelAgeStart.Text.Trim()) ? "0" : txtExportExcelAgeStart.Text.Trim());
            var endage = Convert.ToInt32(String.IsNullOrEmpty(txtExportExcelAgeEnd.Text.Trim()) ? "0" : txtExportExcelAgeEnd.Text.Trim());
            //sex
            int sex = 2;
            if (rdoExportExcelSexAll.Checked)
                sex = 2;
            else if (rdoExportExcelSexMale.Checked)
                sex = 1;
            else
                sex = 0;
            //marital status
            int married = 2;
            if (rdoExportExcelMaritalStatusAll.Checked)
                married = 2;
            else if (rdoExportExelMaritalStatusMarried.Checked)
                married = 1;
            else
                married = 0;

            //order status
            //  var itemsStatus = cbExportExcelPaymentStatus.CheckBoxItems.FindAll(c => c.Checked);
            //var selectedStatus = new List<int>();
            //foreach (var ite in itemsStatus)
            //{
            //    var cb = (ObjectSelectionWrapper<CinemaCRM.Core.StatusFeature>)(ite.ComboBoxItem);
            //   var id = Convert.ToInt32(cb.Item.Code);
            //  selectedStatus.Add(id);
            //}

            //areas
            var selectedAreas = new List<int>();
            foreach (var item in clboxExportExcelArea.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                int id = row.Field<int>("Id");
                selectedAreas.Add(id);
            }
            //columns
            //var columns = cbExportExcelChooseColumns.CheckBoxItems.FindAll(c => c.Checked);
            //var selectedColumns = new List<int>();
            //foreach (var ite in items)
            //{

            //    var id = Convert.ToInt32(((ObjectSelectionWrapper<DataRow>)(ite.ComboBoxItem)).Item.ItemArray[1].ToString());
            //    selectedColumns.Add(id);
            //}
            //number record
            var numberRecord = Convert.ToInt64(String.IsNullOrEmpty(txtExportExcelNumberRecords.Text.Trim()) ? "1000" : txtExportExcelNumberRecords.Text.Trim());
            //email

            var email = txtExportExelEmail.Text.Trim();
            tblCrmCustomer = null;

            //if (dtpExportExcelStartDate.Checked || dtpExportExcelEnddate.Checked)
            //{

            //    //order dates
            //    var fromdate = (dtpExportExcelStartDate.Checked) ? dtpExportExcelStartDate.Value : DateTime.ParseExact("1900-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //    var todate = (dtpExportExcelEnddate.Checked) ? dtpExportExcelEnddate.Value : DateTime.ParseExact("2999-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            //    //prices
            //    var order_minprice = Convert.ToDouble(String.IsNullOrEmpty(txtExportExcelMinPrice.Text.Trim()) ? null : txtExportExcelMinPrice.Text.Trim());
            //    var order_maxprice = Convert.ToDouble(String.IsNullOrEmpty(txtExportExcelMaxPrice.Text.Trim()) ? null : txtExportExcelMaxPrice.Text.Trim());

            //    tblCrmCustomer = new DBConnect().myTable("SP_CrmCustomer_ExportExcel", "@JobIds", StringExtension.ListIntToStringByCommas(selectedJobIds), "@CardIds", StringExtension.ListIntToStringByCommas(selectedCardIds),
            //        "@FromAge", startage, "@ToAge", endage, "@Email", email, "@Sex", sex, "@Married", married, "@FromDate", fromdate, "@ToDate", todate, "@PriceMin", order_minprice,
            //      "@PriceMax", order_maxprice, "@AreaIds", StringExtension.ListIntToStringByCommas(selectedAreas), "@ColumnsIds", "", "@PointRewardForm", txtPointRewardForm.Text, "@PointRewardTo", txtPointRewardTo.Text, "@NumberRecords", numberRecord);
            //}
            //else
            //{
            //    tblCrmCustomer = new DBConnect().myTable("SP_CrmCustomer_ExportExcel", "@JobIds", StringExtension.ListIntToStringByCommas(selectedJobIds), "@CardIds", StringExtension.ListIntToStringByCommas(selectedCardIds),
            //        "@FromAge", startage, "@ToAge", endage, "@Email", email, "@Sex", sex, "@Married", married, "@FromDate", null, "@ToDate", null, "@PriceMin", null,
            //      "@PriceMax", null, "@AreaIds", StringExtension.ListIntToStringByCommas(selectedAreas), "@ColumnsIds", "", "@PointRewardForm", txtPointRewardForm.Text, "@PointRewardTo", txtPointRewardTo.Text, "@NumberRecords", numberRecord);
            //}

            //2016/06/22 ThienNQ( Start Edit)
            //order dates
            string fromDate = null;
            if (dtpExportExcelStartDate.Checked)
                fromDate = dtpExportExcelStartDate.Value.ToString("dd/MM/yyyy");

            string toDate = null;
            if (dtpExportExcelEnddate.Checked)
                toDate = dtpExportExcelEnddate.Value.ToString("dd/MM/yyyy");

            //prices
            var order_minprice = Convert.ToDouble(string.IsNullOrWhiteSpace(txtExportExcelMinPrice.Text) ? null : txtExportExcelMinPrice.Text.Trim());
            var order_maxprice = Convert.ToDouble(string.IsNullOrWhiteSpace(txtExportExcelMaxPrice.Text) ? null : txtExportExcelMaxPrice.Text.Trim());

            tblCrmCustomer = new CrmDBConnect().myTable("SP_CrmCustomer_ExportExcel",
                "@JobIds", StringExtension.ListIntToStringByCommas(selectedJobIds),
                "@CardIds", StringExtension.ListIntToStringByCommas(selectedCardIds),
                "@FromAge", startage, "@ToAge", endage, "@Email", email, "@Sex", sex, "@Married", married,
                "@FromDate", fromDate, "@ToDate", toDate, "@PriceMin", order_minprice, "@PriceMax", order_maxprice,
                "@AreaIds", StringExtension.ListIntToStringByCommas(selectedAreas), "@ColumnsIds", "", "@NumberRecords", numberRecord,
                "@PointRewardForm", string.IsNullOrWhiteSpace(txtPointRewardForm.Text) ? 0 : Convert.ToInt64(txtPointRewardForm.Text),
                "@PointRewardTo", string.IsNullOrWhiteSpace(txtPointRewardTo.Text) ? 0 : Convert.ToInt64(txtPointRewardTo.Text));

            dgvExportExcelCustomers.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmCustomer };
            bindingNavigator.BindingSource = binSource;
            dgvExportExcelCustomers.DataSource = binSource;

        }

        private void BindDefaultValue()
        {

            txtExportExcelAgeStart.Text = "0";
            txtExportExcelAgeEnd.Text = "100";
            txtExportExcelMinPrice.Text = "0";
            txtExportExcelMaxPrice.Text = "100000";
            //  txtExportExcelNumberRecords.Text = "10000";
            dtpExportExcelStartDate.Value = DateTime.Now.AddDays((-1) * rangeDateLoad);
            dtpExportExcelEnddate.Value = DateTime.Now.AddDays((1) * rangeDateLoad);
            foreach (var ie in cbExportExcelJob.CheckBoxItems)
            {
                ie.Checked = true;
            }
            //foreach (var ie in cbExportExcelPaymentStatus.CheckBoxItems)
            //{
            //    ie.Checked = true;
            //}
            foreach (var ie in cbExportExcelCustomerLevel.CheckBoxItems)
            {
                ie.Checked = true;
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (tblCrmCustomer.Rows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn chọn danh sách khách hàng này để gửi e-mail không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                _IsAddedToSendEmail = true;
                this.Close();
            }
        }

        private void btnSendSms_Click(object sender, EventArgs e)
        {
            if (tblCrmCustomer.Rows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn chọn danh sách khách hàng này để gửi SMS không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                _IsAddedToSendSms = true;
                this.Close();
            }
        }

        // 2016/06/06 NguyenNT Fix loi nhap duoc chu vao cac o text
        private void txtPointRewardForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPointRewardTo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtExportExcelMinPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtExportExcelMaxPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        //private void txtExportExcelAgeStart_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }

        //    // only allow one decimal point
        //    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void txtExportExcelAgeEnd_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }

        //    // only allow one decimal point
        //    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        //    {
        //        e.Handled = true;
        //    }
        //}
        // 2016/06/06 NguyenNT <<<

        /// <summary>
        /// Only input integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
