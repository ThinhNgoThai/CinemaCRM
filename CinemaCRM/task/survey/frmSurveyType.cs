using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.task.survey
{
    public partial class frmSurveyType : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmSurveyType()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSurveyType_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            var tblCrmJob = new CrmDBConnect().myTable("SP_CrmSurveyType_CRUD");
            dgvSurveyType.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmJob };
            bindingNavigator.BindingSource = binSource;
            dgvSurveyType.DataSource = binSource;

            txtSuveryType.Enabled = false;
            rtDesciption.Enabled = false;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtSuveryType.Text = "";
            txtSuveryType.Enabled = true;
            rtDesciption.Text = "";
            rtDesciption.Enabled = true;
            EnableBtn(false, false, true, false);
        }

        //Bật tắt các nút
        private void EnableBtn(bool btnAdd, bool btnEdit, bool btnSave, bool btnDelete)
        {
            this.btnAdd.Enabled = btnAdd;
            this.btnEdit.Enabled = btnEdit;
            this.btnSave.Enabled = btnSave;
            this.btnDelete.Enabled = btnDelete;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtSuveryType.Enabled = true;
            rtDesciption.Enabled = true;
            EnableBtn(true, true, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtSuveryType)) return;

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("SP_CrmSurveyType_CRUD", "@SurveyName", txtSuveryType.Text.Trim(), "@Description", rtDesciption.Text, "@flag", 1);
                LoadData();
                dgvSurveyType.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("SP_CrmSurveyType_CRUD", "@Id", _id, "@SurveyName", txtSuveryType.Text.Trim(), "@Description", rtDesciption.Text, "@flag", 2);
                LoadData();
                dgvSurveyType.Rows[0].Selected = false;
                dgvSurveyType.Rows[_selectedRowIndex].Selected = true;
                MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmSurveyType_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dataSource = new CrmDBConnect().myTable("SP_CrmSurveyType_CRUD", "@SurveyName", txtSearch.Text.Trim());
            dgvSurveyType.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvSurveyType.DataSource = binSource;
        }

        private void dgvSurveyType_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSurveyType.CurrentRow == null) return;
            _selectedRowIndex = dgvSurveyType.CurrentRow.Index;
            _id = Convert.ToInt32(dgvSurveyType.CurrentRow.Cells["Id"].Value);
            txtSuveryType.Text = dgvSurveyType.CurrentRow.Cells["SurveyName"].Value.ToString();         
            rtDesciption.Text = dgvSurveyType.CurrentRow.Cells["Description"].Value.ToString();
            txtSuveryType.Enabled = true;
            rtDesciption.Enabled = true;
            EnableBtn(true, true, false, true);
        }
    }
}
