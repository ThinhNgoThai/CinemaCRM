
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CinemaCRM.dir
{
    public partial class frmHoliday : Form
    {
        DateTime _SelectedDate = DateTime.MinValue;
        private bool _IsDataLoaded = false;

        public CrmDBConnect crmdbconnect = new CrmDBConnect();
        public TicketDBConnect ticketdbconnect = new TicketDBConnect();

        public frmHoliday()
        {
            InitializeComponent();
        }

        private void frmHoliday_Load(object sender, EventArgs e)
        {
            this.BindControls();

            cbxYear.SelectedItem = DateTime.Now.Year.ToString();
            cbxDateType.SelectedIndex = 0;
            LoadDates(Convert.ToInt32(cbxYear.SelectedItem), Convert.ToInt32(cbxDateType.SelectedValue));
            _IsDataLoaded = true;
        }

        private void BindControls()
        {
            //Hiển thị danh sách năm
            int CurrentYear = DateTime.Now.Year;
            for (int i = CurrentYear + 1; i > 2013; i--)
            {
                cbxYear.Items.Add(i.ToString());
            }

            //Hiển thị danh sách loại ngày
            DataTable tblDateTypes = ticketdbconnect.myTable("SP_DateType_GetAll");
            this.cbxDateType.DataSource = tblDateTypes;
            this.cbxDateType.ValueMember = "Id";
            this.cbxDateType.DisplayMember = "DateType";
        }

        private void LoadDates(int Year, int DateTypeId)
        {
            DataTable tblDates = ticketdbconnect.myTable("SP_DateInYear_GetDates", "@Year", Year, "@DateTypeId", DateTypeId);
            grDateInYear.AutoGenerateColumns = false;
            grDateInYear.DataSource = tblDates;
        }

        private string VietnameseWeekDay(string EnglishWeekDay)
        {
            string ReturnWeekDay = "";
            switch (EnglishWeekDay)
            {
                case "Monday":
                    ReturnWeekDay = "Thứ 2";
                    break;
                case "Tuesday":
                    ReturnWeekDay = "Thứ 3";
                    break;
                case "Wednesday":
                    ReturnWeekDay = "Thứ 4";
                    break;
                case "Thursday":
                    ReturnWeekDay = "Thứ 5";
                    break;
                case "Friday":
                    ReturnWeekDay = "Thứ 6";
                    break;
                case "Saturday":
                    ReturnWeekDay = "Thứ 7";
                    break;
                case "Sunday":
                    ReturnWeekDay = "Chủ nhật";
                    break;
            }

            return ReturnWeekDay;
        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsDataLoaded == true) LoadDates(Convert.ToInt32(cbxYear.SelectedItem), Convert.ToInt32(cbxDateType.SelectedValue));

        }

        private void cbxDateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsDataLoaded == true) LoadDates(Convert.ToInt32(cbxYear.SelectedItem), Convert.ToInt32(cbxDateType.SelectedValue));
        }

        private void grDateInYear_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _SelectedDate = Convert.ToDateTime(grDateInYear.CurrentRow.Cells["colDateValue"].Value);
        }

        private void grDateInYear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    gridView.Rows[r.Index].Cells[1].Value = VietnameseWeekDay(Convert.ToDateTime(gridView.Rows[r.Index].Cells[0].Value).DayOfWeek.ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grDateInYear.Enabled = false;       
            grpUpdate.Enabled = true;

            //
            chkMonday.Checked = false;
            chkTuesday.Checked = false;
            chkWednesday.Checked = false;
            chkThursday.Checked = false;
            chkFriday.Checked = false;
            chkSaturday.Checked = false;
            chkSunday.Checked = false;
            chkValentine.Checked = false;
            chkWomenDay.Checked = false;
            chkFreedomDay.Checked = false;
            chkLaborDay.Checked = false;
            chkNationalDay.Checked = false;
            chkChristmas.Checked = false;
            dtpSelectDate.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_SelectedDate != DateTime.MinValue)
            {
                string WarningMessage = "Bạn có chắc chắn muốn xoá ngày ";
                WarningMessage = WarningMessage + _SelectedDate.ToString("dd-MM-yyyy") + " ";
                WarningMessage = WarningMessage + "khỏi danh sách " + cbxDateType.Text + " ?";

                if (MessageBox.Show(WarningMessage, "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TicketDBConnect.RunQuery("SP_DateInYear_Delete", "@DateValue", _SelectedDate);
                    LoadDates(Convert.ToInt32(cbxYear.SelectedItem), Convert.ToInt32(cbxDateType.SelectedValue));
                }
            }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnNoSave_Click(object sender, EventArgs e)
        {
            grDateInYear.Enabled = true;         
            grpUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int DayCount = 0;
            bool UpdateOK = true;
            int DateTypeId = Convert.ToInt32(cbxDateType.SelectedValue);

            for (int i = 1; i <= 12; i++)
            {
                DayCount += DateTime.DaysInMonth(Convert.ToInt32(cbxYear.SelectedItem), i);
            }

            DateTime StartDateOfYear = new DateTime(Convert.ToInt32(cbxYear.SelectedItem), 1, 1);

            //Duyệt tất cả các ngày trong năm và kiểm tra điều kiện để thêm vào bảng
            for (int i = 0; i < DayCount; i++)
            {
                DateTime CheckDate = StartDateOfYear.AddDays(i);

                //Kiểm tra cho ngày thứ 2
                if (chkMonday.Checked && CheckDate.DayOfWeek == DayOfWeek.Monday)
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra cho ngày thứ 3
                if (chkTuesday.Checked && CheckDate.DayOfWeek == DayOfWeek.Tuesday)
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra cho ngày thứ 4
                if (chkWednesday.Checked && CheckDate.DayOfWeek == DayOfWeek.Wednesday)
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra cho ngày thứ 5
                if (chkThursday.Checked && CheckDate.DayOfWeek == DayOfWeek.Thursday)
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra cho ngày thứ 6
                if (chkFriday.Checked && CheckDate.DayOfWeek == DayOfWeek.Friday)
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra cho ngày thứ 7
                if (chkSaturday.Checked && CheckDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra cho ngày Chủ nhật
                if (chkSunday.Checked && CheckDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra ngày Valentine
                if (chkValentine.Checked && CheckDate.ToString("dd-MM") == "14-02" )
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra ngày Quốc tế phụ nữ
                if (chkWomenDay.Checked && CheckDate.ToString("dd-MM") == "08-03")
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra ngày Giải phóng Miền Nam
                if (chkFreedomDay.Checked && CheckDate.ToString("dd-MM") == "30-04")
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra ngày Quốc tế Lao động
                if (chkLaborDay.Checked && CheckDate.ToString("dd-MM") == "01-05")
                {
                    UpdateOK = UpdateOK & CrmDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra ngày Quốc Khánh
                if (chkNationalDay.Checked && CheckDate.ToString("dd-MM") == "02-09")
                {
                    UpdateOK = UpdateOK & CrmDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }

                //Kiểm tra ngày Noel
                if (chkChristmas.Checked && CheckDate.ToString("dd-MM") == "24-12")
                {
                    UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", CheckDate.Date, "@DateTypeId", DateTypeId);
                    continue;
                }
            }

            //Thêm vào bảng ngày được chọn cụ thể
            if (dtpSelectDate.Checked == true) UpdateOK = UpdateOK & TicketDBConnect.RunQuery("SP_DateInYear_Insert", "@DateValue", dtpSelectDate.Value.Date, "@DateTypeId", DateTypeId);

            if (UpdateOK == true) MessageBox.Show("Cập nhật dữ liệu vào danh sách " + cbxDateType.Text + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có lỗi, hãy kiểm tra lại danh sách.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDates(Convert.ToInt32(cbxYear.SelectedItem), Convert.ToInt32(cbxDateType.SelectedValue));
            grDateInYear.Enabled = true;       
            grpUpdate.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}