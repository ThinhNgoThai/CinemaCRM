using System;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmConfigAges : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmConfigAges()
        {
            InitializeComponent();
        }

        private void frmConfigAges_Load(object sender, EventArgs e)
        {
            LoadData();

            //2016/06/03 ThienNQ( Added)
            txtSearchStartAge.Focus();
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
            var dataSource = new CrmDBConnect().myTable("SP_CrmAge_CRUD");
            dgvConfigAges.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvConfigAges.DataSource = binSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtStartAge.Text = "";
            txtStartAge.Enabled = true;
            txtEndAge.Text = "";
            txtEndAge.Enabled = true;
            txtDescription.Text = "";
            txtDescription.Enabled = true;
            EnableBtn(false, false, true, false);

            //2016/06/03 ThienNQ( Added)
            txtStartAge.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtStartAge.Enabled = true;
            txtEndAge.Enabled = true;
            txtDescription.Enabled = true;
            EnableBtn(true, true, true, false);

            //2016/06/03 ThienNQ( Added)
            txtStartAge.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtStartAge, txtEndAge)) return;

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("SP_CrmAge_CRUD", "@startAge", txtStartAge.Text.Trim(), "@endAge", txtEndAge.Text,
                    "@Description", txtDescription.Text, "@flag", 1);
                LoadData();
                dgvConfigAges.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("SP_CrmAge_CRUD", "@startAge", txtStartAge.Text.Trim(), "@endAge", txtEndAge.Text,
                    "@Description", txtDescription.Text, "@Id", _id, "@flag", 2);
                LoadData();
                dgvConfigAges.Rows[0].Selected = false;
                dgvConfigAges.Rows[_selectedRowIndex].Selected = true;
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
            CrmDBConnect.RunQuery("SP_CrmAge_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //2016/06/03 ThienNQ( Start Delete)
            //if (txtSearchStartAge.Text.Trim() == "" || txtSearchEndAge.Text.Trim() == "")
            //{
            //    MessageBox.Show("Hãy nhập độ tuổi!");
            //    return;
            //}
            //try
            //{
            //    if (int.Parse(txtSearchStartAge.Text.Trim()) > int.Parse(txtSearchEndAge.Text.Trim()))
            //    {
            //        MessageBox.Show("Tuổi nhập vào không hợp lệ!");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Định dạng không hợp lệ!");
            //    return;
            //}
            //var dataSource = new DBConnect().myTable("SP_CrmAge_CRUD", "@startAge", txtSearchStartAge.Text.Trim(),
            //    "@endAge", txtSearchEndAge.Text.Trim());
            //dgvConfigAges.AutoGenerateColumns = false;

            //var binSource = new BindingSource { DataSource = dataSource };
            //bindingNavigator.BindingSource = binSource;
            //dgvConfigAges.DataSource = binSource;
            //2016/06/03 ThienNQ( End Delete)

            //2016/06/03 ThienNQ( Start Add)
            //Search
            if (string.IsNullOrWhiteSpace(txtSearchStartAge.Text) == string.IsNullOrWhiteSpace(txtSearchEndAge.Text))
            {
                var flag = 0;   //Default GetAll

                if (!string.IsNullOrWhiteSpace(txtSearchStartAge.Text)) //Have input value for txtSearchStartAge and txtSearchEndAge
                {
                    try
                    {
                        if (int.Parse(txtSearchStartAge.Text.Trim()) > int.Parse(txtSearchEndAge.Text.Trim()))
                        {
                            MessageBox.Show("Tuổi nhập vào không hợp lệ!");
                            return;
                        }
                        else flag = 4; //Search có điều kiện
                    }
                    catch   //Trường hợp input không phải numeric
                    {
                        MessageBox.Show("Định dạng không hợp lệ!");
                        return;
                    }
                }
                //Get data
                var dataSource = new CrmDBConnect().myTable("SP_CrmAge_CRUD", "@startAge", txtSearchStartAge.Text.Trim(), "@endAge", txtSearchEndAge.Text.Trim(), "@flag", flag);
                dgvConfigAges.AutoGenerateColumns = false;

                var binSource = new BindingSource { DataSource = dataSource };
                bindingNavigator.BindingSource = binSource;
                dgvConfigAges.DataSource = binSource;
            }
            else
                MessageBox.Show("Hãy nhập độ tuổi!");
            //2016/06/03 ThienNQ( End Add)
        }

        private void dgvConfigAges_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConfigAges.CurrentRow == null) return;
            _selectedRowIndex = dgvConfigAges.CurrentRow.Index;
            _id = Convert.ToInt32(dgvConfigAges.CurrentRow.Cells["Id"].Value);
            txtStartAge.Text = dgvConfigAges.CurrentRow.Cells["FromAge"].Value.ToString();
            txtStartAge.Enabled = false;
            txtEndAge.Text = dgvConfigAges.CurrentRow.Cells["ToAge"].Value.ToString();
            txtEndAge.Enabled = false;
            var value = dgvConfigAges.CurrentRow.Cells["Description"].Value;
            if (value != null)
                txtDescription.Text = value.ToString();
            txtDescription.Enabled = false;

            EnableBtn(true, true, false, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
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

        // 2016/06/06 NguyenNT Fix lỗi nhập được chữ >>>
        private void txtSearchStartAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSearchEndAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        // 2016/06/06 NguyenNT <<<
    }
}
