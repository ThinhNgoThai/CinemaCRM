using System;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmFrequency : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmFrequency()
        {
            InitializeComponent();
        }

        private void frmFrequency_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Các funtion Hỗ trợ
        //Bật tắt các nút
        private void EnableBtn(bool btnAdd, bool btnEdit, bool btnSave, bool btnDelete)
        {
            this.btnAdd.Enabled = btnAdd;
            this.btnEdit.Enabled = btnEdit;
            this.btnSave.Enabled = btnSave;
            this.btnDelete.Enabled = btnDelete;
        }
        #endregion

        private void LoadData()
        {
            var tblCrmJob = new CrmDBConnect().myTable("CRM_Dir_Frequency_CRUD");
            dgvFrequency.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmJob };
            bindingNavigator.BindingSource = binSource;
            dgvFrequency.DataSource = binSource;

            txtFrequencyName.Enabled = false;
            txtFrequencyCode.Enabled = false;
            txtOrderView.Enabled = false;
            txtDescription.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtFrequencyName.Text = "";
            txtFrequencyName.Enabled = true;
            txtFrequencyCode.Text = "";
            txtFrequencyCode.Enabled = true;
            txtOrderView.Text = "";
            txtOrderView.Enabled = true;
            txtDescription.Text = "";
            txtDescription.Enabled = true;
            EnableBtn(false, false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtFrequencyName.Enabled = true;
            txtFrequencyCode.Enabled = true;
            txtOrderView.Enabled = true;
            txtDescription.Enabled = true;
            EnableBtn(true, true, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtFrequencyName, txtFrequencyCode)) return;

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("CRM_Dir_Frequency_CRUD", "@FrequencyName", txtFrequencyName.Text.Trim(),
                    "@FrequencyCode", txtFrequencyCode.Text.Trim(), "@OrderView", txtOrderView.Text.Trim(),
                    "@Description", txtDescription.Text.Trim(), "@flag", 1);
                LoadData();
                dgvFrequency.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("CRM_Dir_Frequency_CRUD", "@FrequencyName", txtFrequencyName.Text.Trim(),
                    "@FrequencyCode", txtFrequencyCode.Text.Trim(), "@OrderView", txtOrderView.Text.Trim(),
                    "@Description", txtDescription.Text.Trim(), "@Id", _id, "@flag", 2);
                LoadData();
                dgvFrequency.Rows[0].Selected = false;
                dgvFrequency.Rows[_selectedRowIndex].Selected = true;
                MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("CRM_Dir_Frequency_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void dgvFrequency_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFrequency.CurrentRow == null) return;
            _selectedRowIndex = dgvFrequency.CurrentRow.Index;
            _id = Convert.ToInt32(dgvFrequency.CurrentRow.Cells["Id"].Value);
            txtFrequencyName.Text = dgvFrequency.CurrentRow.Cells["FrequencyName"].Value.ToString();
            txtFrequencyName.Enabled = false;
            txtFrequencyCode.Text = dgvFrequency.CurrentRow.Cells["FrequencyCode"].Value.ToString();
            txtFrequencyCode.Enabled = false;
            txtOrderView.Text = dgvFrequency.CurrentRow.Cells["OrderView"].Value.ToString();
            txtOrderView.Enabled = false;
            txtDescription.Text = dgvFrequency.CurrentRow.Cells["Description"].Value.ToString();
            txtDescription.Enabled = false;

            EnableBtn(true, true, false, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dataSource = new CrmDBConnect().myTable("CRM_Dir_Frequency_CRUD", "@FrequencyName", txtSearchName.Text.Trim());
            dgvFrequency.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvFrequency.DataSource = binSource;
        }
    }
}
