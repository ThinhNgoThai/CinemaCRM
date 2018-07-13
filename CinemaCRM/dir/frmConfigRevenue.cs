using System;
using System.Linq;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmConfigRevenue : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmConfigRevenue()
        {
            InitializeComponent();
        }

        private void frmConfigRevenue_Load(object sender, EventArgs e)
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
            var dataSource = new CrmDBConnect().myTable("SP_CrmRevenue_CRUD");
            dgvConfigRevenue.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvConfigRevenue.DataSource = binSource;

            txtStartRevenue.Enabled = false;
            txtEndRevenue.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtStartRevenue.Text = "";
            txtStartRevenue.Enabled = true;
            txtEndRevenue.Text = "";
            txtEndRevenue.Enabled = true;
            EnableBtn(false, false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtStartRevenue.Enabled = true;
            txtEndRevenue.Enabled = true;
            EnableBtn(true, true, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //2016/06/06 ThienNQ( Start Delete)
            //if (Public.IsNullTextBox(txtStartRevenue, txtEndRevenue))
            //{
            //    return;
            //}
            //if (int.Parse(txtStartRevenue.Text) > int.Parse(txtEndRevenue.Text))
            //{
            //    MessageBox.Show("Giá trị của điểm không hợp lệ!");
            //    return;
            //}
            //2016/06/06 ThienNQ( End Delete)

            //2016/06/06 ThienNQ( Start Add)
            try
            {
                if (decimal.Parse(txtStartRevenue.Text) > decimal.Parse(txtEndRevenue.Text))
                {
                    MessageBox.Show("Số tiền nhập vào không hợp lệ!");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Định dạng không hợp lệ!");
                return;
            }
            //2016/06/06 ThienNQ( End Add)

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("SP_CrmRevenue_CRUD", "@startRevenue", Convert.ToDecimal(txtStartRevenue.Text.Trim()),
                    "@endRevenue", Convert.ToDecimal(txtEndRevenue.Text.Trim()), "@flag", 1);
                LoadData();
                dgvConfigRevenue.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("SP_CrmRevenue_CRUD", "@startRevenue", Convert.ToDecimal(txtStartRevenue.Text.Trim()),
                    "@endRevenue", Convert.ToDecimal(txtEndRevenue.Text.Trim()), "@Id", _id, "@flag", 2);
                LoadData();
                dgvConfigRevenue.Rows[0].Selected = false;
                dgvConfigRevenue.Rows[_selectedRowIndex].Selected = true;
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
            CrmDBConnect.RunQuery("SP_CrmRevenue_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void dgvConfigRevenue_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConfigRevenue.CurrentRow == null) return;
            _selectedRowIndex = dgvConfigRevenue.CurrentRow.Index;
            _id = Convert.ToInt32(dgvConfigRevenue.CurrentRow.Cells["Id"].Value);
            txtStartRevenue.Text = dgvConfigRevenue.CurrentRow.Cells["FromRevenue"].Value.ToString();
            txtStartRevenue.Enabled = false;
            txtEndRevenue.Text = dgvConfigRevenue.CurrentRow.Cells["ToRevenue"].Value.ToString();
            txtEndRevenue.Enabled = false;

            EnableBtn(true, true, false, true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //2016/06/06 ThienNQ( Start Delete)
            //if (txtSearchStart.Text.Trim() == "" || txtSearchEnd.Text.Trim() == "")
            //{
            //    MessageBox.Show("Hãy nhập số tiền!");
            //    return;
            //}
            //try
            //{
            //    if (int.Parse(txtSearchStart.Text.Trim()) > int.Parse(txtSearchEnd.Text.Trim()))
            //    {
            //        MessageBox.Show("Số tiền nhập vào không hợp lệ!");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Định dạng không hợp lệ!");
            //    return;
            //}
            //var dataSource = new DBConnect().myTable("SP_CrmRevenue_CRUD", "@startRevenue", txtSearchStart.Text.Trim(),
            //    "@endRevenue", txtSearchEnd.Text.Trim());
            //dgvConfigRevenue.AutoGenerateColumns = false;

            //var binSource = new BindingSource { DataSource = dataSource };
            //bindingNavigator.BindingSource = binSource;
            //dgvConfigRevenue.DataSource = binSource;
            //2016/06/06 ThienNQ( End Delete)

            //2016/06/06 ThienNQ( Start Add)
            if (string.IsNullOrWhiteSpace(txtSearchStart.Text) == string.IsNullOrWhiteSpace(txtSearchEnd.Text))
            {
                var dataSource = new System.Data.DataTable();
                try
                {
                    if (string.IsNullOrWhiteSpace(txtSearchStart.Text)
                        || (decimal.Parse(txtSearchStart.Text.Trim()) == 0 && decimal.Parse(txtSearchEnd.Text.Trim()) == 0)) // Get All
                    {
                        dataSource = new CrmDBConnect().myTable("SP_CrmRevenue_CRUD");
                    }
                    else //Have input data search
                    {
                        if (decimal.Parse(txtSearchStart.Text.Trim()) > decimal.Parse(txtSearchEnd.Text.Trim()))
                        {
                            MessageBox.Show("Số tiền nhập vào không hợp lệ!");
                            return;
                        }
                        else //Search có điều kiện.
                            dataSource = new CrmDBConnect().myTable("SP_CrmRevenue_CRUD", "@startRevenue", txtSearchStart.Text.Trim(), "@endRevenue", txtSearchEnd.Text.Trim());
                    }
                }
                catch   //Trường hợp input không phải numeric
                {
                    MessageBox.Show("Định dạng không hợp lệ!");
                    return;
                }

                dgvConfigRevenue.AutoGenerateColumns = false;

                var binSource = new BindingSource { DataSource = dataSource };
                bindingNavigator.BindingSource = binSource;
                dgvConfigRevenue.DataSource = binSource;
            }
            else MessageBox.Show("Hãy nhập số tiền!"); //1 in 2 TextBox not input value
            //2016/06/06 ThienNQ( End Add)
        }

        private void validateTextDouble(object sender, EventArgs e)
        {
            Exception X = new Exception();
            TextBox T = (TextBox)sender;
            try
            {
                double x = double.Parse(T.Text);
                //Customizing Condition (Only numbers larger than or 
                //equal to zero are permitted)
                if (x < 0 || T.Text.Contains(','))
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
    }
}
