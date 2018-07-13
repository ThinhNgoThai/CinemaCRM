using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.task.survey
{
    public partial class frmQuestionType : Form
    {
        private string _operationMode = "UPDATE";
        private static int _selectedRowIndex;
        private static DataTable _dataSource;
        private static BindingSource _bindingSource;
        private int _id;

        public frmQuestionType()
        {
            InitializeComponent();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmQuestionType_Load(object sender, EventArgs e)
        {
            __loadData();
        }

        private void __loadData()
        {
            _dataSource = new CrmDBConnect().myTable("SP_CrmQuestionType_CRUD");
            dgvCardClass.AutoGenerateColumns = false;

            _bindingSource = new BindingSource { DataSource = _dataSource };
            bindingNavigator.BindingSource = _bindingSource;
            dgvCardClass.DataSource = _bindingSource;

            EnableText(false, false, false);
        }

        //Bật tắt các nút
        private void EnableBtn(bool btnAdd, bool btnEdit, bool btnSave, bool btnDelete)
        {
            this.btnAdd.Enabled = btnAdd;
            this.btnEdit.Enabled = btnEdit;
            this.btnSave.Enabled = btnSave;
            this.btnDelete.Enabled = btnDelete;
        }

        private void EnableText(bool Code, bool QuestionName, bool description)
        {
            txtCode.Enabled = Code;
            txtQuestionName.Enabled = QuestionName;
            rtDesciption.Enabled = description;
        }

        private void ClearText(string code, string QuestionName, string desciption)
        {
            txtCode.Text = "";
            txtQuestionName.Text = "";
            rtDesciption.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            EnableText(true, true, true);
            ClearText(string.Empty, string.Empty, string.Empty);
            EnableBtn(false, false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            EnableText(true, true, true);
            EnableBtn(true, true, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmQuestionType_CRUD", "@Id", _id, "@flag", 3);
            __loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtCode, txtQuestionName, rtDesciption)) return;

            if (_operationMode == "ADD")
            {
                //Check Mã loại tồn tại
                if (new CrmDBConnect().myTable("SP_CrmQuestionType_CRUD", "@QuestionCode", txtCode.Text.Trim()).Rows.Count != 0)
                {
                    MessageBox.Show("Mã loại đã tồn tại.", "Cảnh báo");
                    return;
                }
                CrmDBConnect.RunQuery("SP_CrmQuestionType_CRUD", "@QuestionCode", txtCode.Text.Trim(),
                    "@QuestionName", txtQuestionName.Text, "@Description", rtDesciption.Text, "@flag", 1);
                __loadData();
                dgvCardClass.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("SP_CrmQuestionType_CRUD", "@Id", _id, "@QuestionCode", txtCode.Text.Trim(),
                    "@QuestionName", txtQuestionName.Text, "@Description", rtDesciption.Text, "@flag", 2);
                __loadData();
                dgvCardClass.Rows[0].Selected = false;
                dgvCardClass.Rows[_selectedRowIndex].Selected = true;
                MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = new List<string>();

            if (!String.IsNullOrEmpty(txtSearchCode.Text.Trim()))
                filter.Add("[QuestionCode] LIKE '%" + txtSearchCode.Text.Trim() + "%'");

            if (!String.IsNullOrEmpty(txtSearchName.Text.Trim()))
                filter.Add("[QuestionName] LIKE '%" + txtSearchName.Text.Trim() + "%'");

            _bindingSource.Filter = String.Join(" AND ", filter);
        }

        private void dgvQuestionType_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCardClass.CurrentRow == null) return;
            _selectedRowIndex = dgvCardClass.CurrentRow.Index;
            _id = Convert.ToInt32(dgvCardClass.CurrentRow.Cells["Id"].Value);
            txtCode.Text = dgvCardClass.CurrentRow.Cells["QuestionCode"].Value.ToString();
            txtQuestionName.Text = dgvCardClass.CurrentRow.Cells["QuestionName"].Value.ToString();
            rtDesciption.Text = dgvCardClass.CurrentRow.Cells["Description"].Value.ToString();
            EnableText(false, false, false);
            EnableBtn(true, true, false, true);
        }

    }
}
