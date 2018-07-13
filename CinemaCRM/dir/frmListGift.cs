using System;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmListGift : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;


        public frmListGift()
        {
            InitializeComponent();
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

        private void frmListGift_Load(object sender, EventArgs e)
        {
            LoadData();
            EnableBtn(true, true, false, false);
        }

        private void LoadData()
        {
            var tblGift = new CrmDBConnect().myTable("SP_CrmGiftProduct_CRUD");
            dgvGift.AutoGenerateColumns = false;

            var bindSource = new BindingSource { DataSource = tblGift };
            bindingNavigator.BindingSource = bindSource;
            dgvGift.DataSource = bindSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";

            txtGiftName.Text = "";
            txtPoint.Text = "";
            txtPrice.Text = "";

            txtGiftName.Enabled = true;
            groupBox3.Enabled = true;
            txtPrice.Enabled = true;
            txtPoint.Enabled = true;

            EnableBtn(false, false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";

            txtGiftName.Enabled = true;
            groupBox3.Enabled = true;
            txtPrice.Enabled = true;
            txtPoint.Enabled = true;

            EnableBtn(true, false, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int voucherType = 0;
            // Voucher đổi nước
            if (rdbDoiNuoc.Checked)
                voucherType = 0;
            else if (rdbDoiBap.Checked)
                // Voucher đổi bắp
                voucherType = 1;
            else if (rdb2D.Checked)
                // Voucher 2D
                voucherType = 2;
            else if (rdb3D.Checked)
                // Voucher 3D
                voucherType = 3;
            else if (rdb4D.Checked)
                // Voucher 4D
                voucherType = 4;

            if (Public.IsNullTextBox(txtGiftName, txtPrice, txtPoint)) return;

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("SP_CrmGiftProduct_CRUD", "@Name", txtGiftName.Text, "@Price", Convert.ToDecimal(txtPrice.Text.Trim()),
                    "@Point", Convert.ToInt32(txtPoint.Text.Trim()), "@UserName", Contanst.Contanst.UserName, "@VoucherType", voucherType, "@flag", 1);
                LoadData();
                dgvGift.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("SP_CrmGiftProduct_CRUD", "@Name", txtGiftName.Text, "@Price", Convert.ToDecimal(txtPrice.Text.Trim()),
                    "@Point", Convert.ToDecimal(txtPoint.Text.Trim()), "@UserName", Contanst.Contanst.UserName, "@Id", _id, "@VoucherType", voucherType, "@flag", 2);
                LoadData();
                dgvGift.Rows[0].Selected = false;
                dgvGift.Rows[_selectedRowIndex].Selected = true;
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
            CrmDBConnect.RunQuery("SP_CrmGiftProduct_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void dgvGift_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGift.CurrentRow == null) return;
            _selectedRowIndex = dgvGift.CurrentRow.Index;
            _id = Convert.ToInt32(dgvGift.CurrentRow.Cells["Id"].Value);
            var value = dgvGift.CurrentRow.Cells["Name"].Value;
            if (value != null)
            {
                txtGiftName.Text = value.ToString();
                txtPrice.Text = dgvGift.CurrentRow.Cells["Price"].Value.ToString();
                txtPoint.Text = dgvGift.CurrentRow.Cells["Point"].Value.ToString();
                int voucherType = Convert.ToInt32(dgvGift.CurrentRow.Cells["VoucherType"].Value.ToString());

                // Voucher đổi nước
                if (voucherType == 0)
                    rdbDoiNuoc.Checked = true;
                else if (voucherType == 1)
                    // Voucher đổi bắp
                    rdbDoiBap.Checked = true;
                else if (voucherType == 2)
                    // Voucher 2D
                    rdb2D.Checked = true;
                else if (voucherType == 3)
                    // Voucher 3D
                    rdb3D.Checked = true;
                else if (voucherType == 4)
                    // Voucher 4D
                    rdb4D.Checked = true;
            }

            txtGiftName.Enabled = false;
            txtPrice.Enabled = false;
            txtPoint.Enabled = false;
            groupBox3.Enabled = false;

            EnableBtn(true, true, false, true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dataSource = new CrmDBConnect().myTable("SP_CrmGiftProduct_CRUD", "@Name", txtSearchName.Text.Trim());
            dgvGift.AutoGenerateColumns = false;

            var bindSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = bindSource;
            dgvGift.DataSource = bindSource;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void validateTextInteger(object sender, EventArgs e)
        {
            Exception X = new Exception();
            TextBox T = (TextBox)sender;
            try
            {
                int x = int.Parse(T.Text);
                //Customizing Condition
                if (x <= 0)
                    throw X;
            }
            catch (Exception)
            {
                try
                {
                    int CursorIndex = T.SelectionStart - 1;
                    T.Text = T.Text.Remove(CursorIndex, 1);
                    //Align Cursor to same index
                    T.SelectionStart = CursorIndex;
                    T.SelectionLength = 0;
                }
                catch (Exception) { }

            }
        }

        private void dgvGift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _id = Convert.ToInt32(dgvGift.CurrentRow.Cells["Id"].Value);
            }
            catch { }
        }

    }
}
