using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.taks.customer;
using CinemaCRM.taks;
using System.Globalization;

namespace CinemaCRM.task.customer
{
    public partial class frmManagerCustomer : Form
    {
        private int rangeDateLoad = 10;
        private int _selectedRowIndex = 0;
        private int _id;
        DateTime startDate;
        DateTime endDate;
        #region Helper

        /// <summary>
        /// load first data 
        /// </summary>
        private void LoadData(string keyword = "", int jobId = 0, int areaId = 0, DateTime? startDate = null, DateTime? endDate = null)
        {
            var tblCrmCustomer = new CrmDBConnect().myTable("SP_CrmCustomer_GetCustomers",
                "@Keywords", keyword, "@JobId", jobId, "@AreaId", areaId, "@StartDate", startDate, "@EndDate", endDate, "@flag", 0,
                "@NumRecords", string.IsNullOrWhiteSpace(txtNumberRecord.Text) ? 0 : Convert.ToInt64(txtNumberRecord.Text));

            dgCustomers.AutoGenerateColumns = false;
            var binSource = new BindingSource { DataSource = tblCrmCustomer };
            bindingNavigator.BindingSource = binSource;
            dgCustomers.DataSource = binSource;

            var tblCrmCustomerCount = new CrmDBConnect().myTable("SP_CrmCustomer_CountCustomers");
            txtTotalRowCount.Text = tblCrmCustomerCount.Rows[0][0].ToString();
        }

        /// <summary>
        /// load all combox for jobs
        /// </summary>
        private void LoadJob()
        {
            var tblJob = new CrmDBConnect().myTable("SP_CrmJob_CRUD");
            dgCustomers.AutoGenerateColumns = false;
            if (tblJob.Rows.Count > 0)
            {
                DataRow newJobRow = tblJob.NewRow();
                newJobRow["Id"] = "0";
                newJobRow["JobName"] = "Tất cả";
                tblJob.Rows.Add(newJobRow);

                var binSource = new BindingSource { DataSource = tblJob };

                cbCustomerJobs.DataSource = binSource;
                cbCustomerJobs.DisplayMember = "JobName";
                cbCustomerJobs.ValueMember = "Id";
                cbCustomerJobs.SelectedValue = 0;
            }
        }

        /// <summary>
        /// load area for search ching
        /// </summary>
        private void LoadArea()
        {
            var tbmArea = new CrmDBConnect().myTable("SP_CrmArea_CRUD", "@flag", 6);

            if (tbmArea.Rows.Count > 0)
            {
                DataRow newAreasRow = tbmArea.NewRow();
                newAreasRow["Id"] = "0";
                newAreasRow["AreaName"] = "Tất cả";
                tbmArea.Rows.Add(newAreasRow);

                dgCustomers.AutoGenerateColumns = false;
                var binSource = new BindingSource { DataSource = tbmArea };

                cbCustomerAreas.DataSource = binSource;
                cbCustomerAreas.DisplayMember = "AreaName";
                cbCustomerAreas.ValueMember = "Id";
                cbCustomerAreas.SelectedValue = 0;
            }
        }

        #endregion

        #region ctor
        /// <summary>
        /// ctor
        /// </summary>
        public frmManagerCustomer()
        {
            InitializeComponent();
        }
        #endregion


        private void frmManagerCustomer_Load(object sender, EventArgs e)
        {

            this.LoadJob();
            this.LoadArea();
            this.dtpStartDate.Value.AddYears((-1) * rangeDateLoad);
            this.dtpEndDate.Value.AddYears((1) * rangeDateLoad);
            this.LoadData("", 0, 0, null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmDetails();
                var id = Convert.ToInt32(this.dgCustomers.CurrentRow.Cells["colId"].Value.ToString());
                frm.setCustomerId(id);
                frm.ShowDialog();
                this.LoadData("", 0, 0, null, null);
            }
            catch { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var textSearch = txtOrderSearchText.Text.Trim();
                if (cbCustomerJobs.SelectedValue == null) cbCustomerJobs.SelectedValue = 0; //Nếu input đối tượng không tồn tại trong combobox thì trả về "Tất cả"
                var job = Convert.ToInt32(cbCustomerJobs.SelectedValue);
                if (cbCustomerAreas.SelectedValue == null) cbCustomerAreas.SelectedValue = 0; //Nếu input đối tượng không tồn tại trong combobox thì trả về "Tất cả"
                var area = Convert.ToInt32(cbCustomerAreas.SelectedValue);

                if (!dtpStartDate.Checked || !dtpEndDate.Checked)
                {
                    this.LoadData(textSearch, job, area, null, null);
                }
                else
                {
                    this.LoadData(textSearch, job, area, startDate, endDate);
                }
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn xóa khách hàng này?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmCustomer_Delete", "@Id", _id);
            LoadData();
        }

        private void dgCustomers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgCustomers.CurrentRow == null) return;
            _selectedRowIndex = dgCustomers.CurrentRow.Index;
            _id = Convert.ToInt32(dgCustomers.CurrentRow.Cells["colId"].Value);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                startDate = dtpStartDate.Value;
            }
            catch { }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                endDate = dtpEndDate.Value;
            }
            catch { }
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
            try
            {
                var frm = new frmDetails();
                var id = Convert.ToInt32(this.dgCustomers.CurrentRow.Cells["colId"].Value.ToString());
                frm.setCustomerId(id);
                frm.ShowDialog();
                this.LoadData("", 0, 0, null, null);
            }
            catch { }
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

        private void butAdd_Click(object sender, EventArgs e)
        {
            frmContactCustomer frm = new frmContactCustomer();
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            this.Close();
        }
    }
}
