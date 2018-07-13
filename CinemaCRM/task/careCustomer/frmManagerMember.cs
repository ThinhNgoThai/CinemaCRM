using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.taks;
using CinemaCRM.taks.careCustomer;


namespace CinemaCRM.task.careCustomer
{
    public partial class frmManagerMember : Form
    {
        private int _selectedRowIndex = 0;
        private int _id;
        DateTime birthdayStart;
        DateTime birthdayEnd;
        DateTime acceptedDate;
        DateTime acceptedEnd;

        public frmManagerMember()
        {
            InitializeComponent();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgCustomers.CurrentRow == null) return;
            var frm = new frmDetailsMember();

            var id = Convert.ToInt32(this.dgCustomers.CurrentRow.Cells["colId"].Value.ToString());
            frm.setCustomerId(id);
            frm.ShowDialog();

            btnSearch.PerformClick();
        }

        private void frmManagerMember_Load(object sender, EventArgs e)
        {
            this.LoadJob();
            this.LoadArea();
            this.LoadCardLevel();
            this.LoadData("", 0, 0, null, null, null, null, 0);

        }
        /// <summary>
        /// load all combox for jobs
        /// </summary>
        private void LoadJob()
        {

            var tblJob = new CrmDBConnect().myTable("SP_CrmJob_CRUD");
            if (tblJob.Rows.Count > 0)
            {
                DataRow newJobRow = tblJob.NewRow();
                newJobRow["Id"] = "0";
                newJobRow["JobName"] = "Tất cả";
                tblJob.Rows.Add(newJobRow);

                dgCustomers.AutoGenerateColumns = false;
                var binSource = new BindingSource { DataSource = tblJob };
                cbCusJobs.DataSource = binSource;
                cbCusJobs.DisplayMember = "JobName";
                cbCusJobs.ValueMember = "Id";
                cbCusJobs.SelectedValue = 0;
            }
        }

        private void LoadArea()
        {
            var tbmArea = new CrmDBConnect().myTable("SP_CrmArea_CRUD", "@flag", 6);
            if (tbmArea.Rows.Count > 0)
            {
                DataRow newAreaRow = tbmArea.NewRow();
                newAreaRow["Id"] = "0";
                newAreaRow["AreaName"] = "Tất cả";
                tbmArea.Rows.Add(newAreaRow);

                dgCustomers.AutoGenerateColumns = false;

                var binSource = new BindingSource { DataSource = tbmArea };

                cbCusAreas.DataSource = binSource;
                cbCusAreas.DisplayMember = "AreaName";
                cbCusAreas.ValueMember = "Id";
                cbCusAreas.SelectedValue = 0;
            }
        }

        private void LoadCardLevel()
        {

            var tbmCardlevel = new CrmDBConnect().myTable("SP_CrmCardLevel_CRUD", "@flag", 1);
            if (tbmCardlevel.Rows.Count > 0)
            {
                dgCustomers.AutoGenerateColumns = false;
                DataRow newCardLevelRow = tbmCardlevel.NewRow();
                newCardLevelRow["Id"] = "0";
                newCardLevelRow["CardLevelName"] = "Tất cả";
                tbmCardlevel.Rows.Add(newCardLevelRow);

                var binSource = new BindingSource { DataSource = tbmCardlevel };

                cbCusLevel.DataSource = binSource;
                cbCusLevel.DisplayMember = "CardLevelName";
                cbCusLevel.ValueMember = "Id";
                cbCusLevel.SelectedValue = 0;
            }
        }
        /// <summary>
        /// load first data 
        /// </summary>

        private void LoadData(string keyword = "", int jobId = 0, int areaId = 0, DateTime? startDate = null, DateTime? endDate = null, DateTime? acceptedDateStart = null, DateTime? acceptedEndDate = null, int CardLevelId = 0)
        {
            var tblCrmCustomer = new CrmDBConnect().myTable("SP_CrmCustomer_GetCardMembers", "@Keywords", keyword, "@JobId", jobId, "@AreaId", areaId, "@StartDate", startDate, "@EndDate", endDate, "@CarLevel ", CardLevelId, "@AcceptedDateStart", acceptedDateStart, "@AcceptedDateEnd", acceptedEndDate, "@flag", 0, "@NumRecords", string.IsNullOrWhiteSpace(txtNumberRecord.Text) ? 0 : Convert.ToInt64(txtNumberRecord.Text));
            dgCustomers.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmCustomer };
            bindingNavigator.BindingSource = binSource;
            dgCustomers.DataSource = binSource;

            var tblCrmCustomerCount = new CrmDBConnect().myTable("SP_CrmCustomer_CountMembers");
            txtTotalRowCount.Text = tblCrmCustomerCount.Rows[0][0].ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var jobId = Convert.ToInt32(cbCusJobs.SelectedValue);
            var areaId = Convert.ToInt32(cbCusAreas.SelectedValue);
            var cardLevelId = Convert.ToInt32(cbCusLevel.SelectedValue);
            var keyword = txtCusSearch.Text.Trim();

            DateTime dateDefault = Convert.ToDateTime("01/01/0001");
            List<DateTime?> lstDateInput = new List<DateTime?>();

            lstDateInput.Add(dtpCusBirthSart.Checked ? dtpCusBirthSart.Value : dateDefault);
            lstDateInput.Add(dtpCusBirthEnd.Checked ? dtpCusBirthEnd.Value : dateDefault);
            lstDateInput.Add(dtpCusAcceptDateStart.Checked ? dtpCusAcceptDateStart.Value : dateDefault);
            lstDateInput.Add(dtCusAceptedEnd.Checked ? dtCusAceptedEnd.Value : dateDefault);

            for (int i = 0; i < lstDateInput.Count; i++)
            {
                if (Convert.ToDateTime(lstDateInput[i]).ToString("dd/MM/yyyy") == dateDefault.ToString("dd/MM/yyyy"))
                    lstDateInput[i] = null;
            }

            LoadData(keyword, jobId, areaId, lstDateInput[0], lstDateInput[1], lstDateInput[2], lstDateInput[3], cardLevelId);
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {

            var frm = new frmAddCardMember();
            frm.ShowDialog();
            btnSearch.PerformClick();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            _id = Convert.ToInt32(this.dgCustomers.CurrentRow.Cells["colId"].Value.ToString());
            if (_id <= 0) return;

            if (
                MessageBox.Show(@"Bạn thực sự muốn xóa khách hàng này?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmCustomer_Delete", "@Id", _id);

            btnSearch.PerformClick();
        }

        private void dgCustomers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dgCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var frm = new frmDetailsMember();

            var id = Convert.ToInt32(this.dgCustomers.CurrentRow.Cells["colId"].Value.ToString());
            frm.setCustomerId(id);
            frm.ShowDialog();

            //2016/06/07 ThienNQ( Added) Reload form by điều kiện search
            btnSearch.PerformClick();
        }

        /// <summary>
        /// Only input integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
