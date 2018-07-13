using System;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmJob : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmJob()
        {
            InitializeComponent();
        }
        /// <summary>
        /// first load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmJob_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// load data
        /// </summary>
        private void LoadData()
        {
            var tblCrmJob = new CrmDBConnect().myTable("SP_CrmJob_CRUD", "@JobName", txtSearchJob.Text, "@flag", 0);
            dgvJobs.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmJob };
            bindingNavigator.BindingSource = binSource;
            dgvJobs.DataSource = binSource;

            txtJobName.Enabled = false;
        }
        //2016/06/08 ThienNQ( Start Update) Check tồn tại tên ngành nghề trong DB hoặc txtJobName.Text trắng thì không cho add và hiển thị thông báo.

        /// <summary>
        /// add button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtJobName.Text = "";
            txtJobName.Enabled = true;
            EnableBtn(false, false, true, false);

            checkJobNameOld = string.Empty;
            txtJobName.Focus();
        }
        /// <summary>
        /// edit button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtJobName.Enabled = true;
            EnableBtn(true, true, true, false);

            checkJobNameOld = txtJobName.Text;
            txtJobName.Focus();
            txtJobName.SelectAll();
        }

        string checkJobNameOld = string.Empty;

        /// <summary>
        /// save button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (Public.IsNullTextBox(txtJobName)) return;
            if (string.IsNullOrWhiteSpace(txtJobName.Text))
            {
                MessageBox.Show("Hãy nhập tên ngành nghề.", "Thông báo");
                txtJobName.Focus();
                txtJobName.SelectAll();
                return;
            }

            if (txtJobName.Text.Trim() != checkJobNameOld)   //Check thay đổi tên thì thực hiện save vào DB
            {
                //Nếu Tên ngành nghề đã tồn tại ở bản ghi khác trong DB thì không cho Save.
                if (new CrmDBConnect().myTable("SP_CrmJob_CRUD", "@JobName", txtSearchJob.Text, "@flag", 0).Select("JobName= '" + txtJobName.Text + "'").Length > 0)
                {
                    MessageBox.Show("Tên ngành nghề đã tồn tại.", "Thông báo");
                    txtJobName.Focus();
                    txtJobName.SelectAll();
                    return;
                }

                if (_operationMode == "ADD")
                {
                    CrmDBConnect.RunQuery("SP_CrmJob_CRUD", "@JobName", txtJobName.Text.Trim(), "@flag", 1);
                    MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                if (_operationMode == "UPDATE")
                {
                    CrmDBConnect.RunQuery("SP_CrmJob_CRUD", "@Id", _id, "@JobName", txtJobName.Text.Trim(), "@flag", 2);
                    MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvJobs.Rows[0].Selected = false;
                    dgvJobs.Rows[_selectedRowIndex].Selected = true;
                }
            }
            else
                MessageBox.Show("Tên ngành nghề không thay đổi.", "Thông báo");

            LoadData();
            dgvJobs.Enabled = true;
            EnableBtn(true, true, false, true);
        }
        //2016/06/08 ThienNQ( End Update) Check tồn tại tên ngành nghề trong DB hoặc txtJobName.Text trắng thì không cho add và hiển thị thông báo.

        /// <summary>
        /// delete button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmJob_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }
        /// <summary>
        /// cell enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJobs_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJobs.CurrentRow == null) return;
            _selectedRowIndex = dgvJobs.CurrentRow.Index;
            _id = Convert.ToInt32(dgvJobs.CurrentRow.Cells["Id"].Value);
            txtJobName.Text = dgvJobs.CurrentRow.Cells["JobName"].Value.ToString();
            txtJobName.Enabled = false;

            EnableBtn(true, true, false, true);
        }
        /// <summary>
        /// close button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
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
        /// <summary>
        /// search click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dataSource = new CrmDBConnect().myTable("SP_CrmJob_CRUD", "@JobName", txtSearchJob.Text.Trim());
            dgvJobs.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvJobs.DataSource = binSource;
        }
        /// <summary>
        /// key down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtJobName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
