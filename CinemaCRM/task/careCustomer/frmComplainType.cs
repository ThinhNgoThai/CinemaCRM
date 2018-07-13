using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinemaCRM.task.careCustomer
{
    public partial class frmComplainType : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmComplainType()
        {
            InitializeComponent();
        }

        private void frmComplainType_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void EnabedText(bool questionName, bool description)
        {
            txtComplainName.Enabled = questionName;
            rtDescription.Enabled = description;
        }

        //Bật tắt các nút
        private void EnableBtn(bool btnAdd, bool btnEdit, bool btnSave, bool btnDelete)
        {
            this.btnAdd.Enabled = btnAdd;
            this.btnEdit.Enabled = btnEdit;
            this.btnSave.Enabled = btnSave;
            this.btnDelete.Enabled = btnDelete;
        }

        private void ClearText(string questionName, string description)
        {
            txtComplainName.Text = questionName;
            rtDescription.Text = description;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn xóa loại khiếu nại này?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("[SP_CrmComplainType_CRUD]", "@Id", _id, "@flag", 3);
            LoadData();
        }


        private void LoadData()
        {
            var tblCrmJob = new CrmDBConnect().myTable("[SP_CrmComplainType_CRUD]");
            dgvComplain.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmJob };
            bindingNavigator.BindingSource = binSource;
            dgvComplain.DataSource = binSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            EnabedText(true, true);
            ClearText(string.Empty, string.Empty);
            EnableBtn(false, false, true, false);
        }

        private void dtComplain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvComplain.CurrentRow == null) return;
            _selectedRowIndex = dgvComplain.CurrentRow.Index;
            _id = Convert.ToInt32(dgvComplain.CurrentRow.Cells["Id"].Value);
            txtComplainName.Text = dgvComplain.CurrentRow.Cells["ComplainName"].Value.ToString();
            rtDescription.Text = dgvComplain.CurrentRow.Cells["Description"].Value.ToString();
            EnabedText(true, true);
            EnableBtn(true, true, false, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dataSource = new CrmDBConnect().myTable("[SP_CrmComplainType_CRUD]", "@ComplainName", txtSearch.Text);
            dgvComplain.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvComplain.DataSource = binSource;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtComplainName.Text.Trim() == "")
            {
                MessageBox.Show(@"Chưa nhập tên nhóm câu hỏi", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("[SP_CrmComplainType_CRUD]", "@ComplainName", txtComplainName.Text, "@Description", rtDescription.Text, "@flag", 1);
                LoadData();
                dgvComplain.Enabled = true;
                MessageBox.Show(@"Thêm mới thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("[SP_CrmComplainType_CRUD]", "@Id", _id, "@ComplainName", txtComplainName.Text.Trim(), "@Description", rtDescription.Text, "@flag", 2);
                LoadData();
                dgvComplain.Rows[0].Selected = false;
                dgvComplain.Rows[_selectedRowIndex].Selected = true;
                MessageBox.Show(@"Sửa thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }
            txtComplainName.Text = String.Empty;
            rtDescription.Text = String.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            EnabedText(true, true);
            EnableBtn(true, true, true, false);
        }

    }
}
