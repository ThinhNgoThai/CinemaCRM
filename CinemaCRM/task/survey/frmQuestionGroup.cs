using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.task.survey
{
    public partial class frmQuestionGroup : Form
    {
        private string _operationMode = "UPDATE";
        private static int _selectedRowIndex;
        private static DataTable _dataSource;
        private static BindingSource _bindingSource;
        private int _id;

        public frmQuestionGroup()
        {
            InitializeComponent();
        }

        private void frmQuestionGroup_Load(object sender, EventArgs e)
        {
            __loadData();
        }

        private void __loadData()
        {
            _dataSource = new CrmDBConnect().myTable("SP_CrmQuestionGroup_CRUD");
            dgvQuestionGroup.AutoGenerateColumns = false;

            _bindingSource = new BindingSource { DataSource = _dataSource };
            bindingNavigator.BindingSource = _bindingSource;
            dgvQuestionGroup.DataSource = _bindingSource;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = new List<string>();

            if (!String.IsNullOrEmpty(txtSearchName.Text.Trim()))
                filter.Add("[GroupName] LIKE '%" + txtSearchName.Text.Trim() + "%'");

            _bindingSource.Filter = String.Join(" AND ", filter);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            EnableText(true, true);           
            EnableBtn(true, true, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtGroupName)) return;
            var currentRow = _selectedRowIndex;
         
            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("SP_CrmQuestionGroup_CRUD", "@GroupName", txtGroupName.Text, "@Description",
                    rtDesciption.Text, "@flag", 1);
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                __loadData();
                dgvQuestionGroup.Enabled = true;

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("SP_CrmQuestionGroup_CRUD", "@Id", _id, "@GroupName", txtGroupName.Text.Trim(),
                    "@Description", rtDesciption.Text, "@flag", 2);
                MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                __loadData();
                EnableBtn(true, true, false, true);
            }

            dgvQuestionGroup.Rows[currentRow].Selected = true;
        }

        #region Các method hỗ trợ
        private void EnableText(bool questionName, bool description)
        {
            txtGroupName.Enabled = questionName;
            rtDesciption.Enabled = description;
        }

        private void EnableBtn(bool btnAdd, bool btnEdit, bool btnSave, bool btnDelete)
        {
            this.btnAdd.Enabled = btnAdd;
            this.btnEdit.Enabled = btnEdit;
            this.btnSave.Enabled = btnSave;
            this.btnDelete.Enabled = btnDelete;
        }

        private void ClearText(string questionName, string description)
        {
            txtGroupName.Text = questionName;
            rtDesciption.Text = description;
        } 
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmQuestionGroup_CRUD", "@Id", _id, "@flag", 3);
            __loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            EnableText(true, true);
            ClearText(string.Empty, string.Empty);
            EnableBtn(false, false, true, false);
        }

        private void dgvQuestionGroup_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuestionGroup.CurrentRow == null) return;
            _selectedRowIndex = dgvQuestionGroup.CurrentRow.Index;
            _id = Convert.ToInt32(dgvQuestionGroup.CurrentRow.Cells["Id"].Value);
            txtGroupName.Text = dgvQuestionGroup.CurrentRow.Cells["GroupName"].Value.ToString();
            rtDesciption.Text = dgvQuestionGroup.CurrentRow.Cells["Description"].Value.ToString();
            EnableText(false, false);
            EnableBtn(true, true, false, true);
        }
    }
}
