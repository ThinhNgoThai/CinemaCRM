using System;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmFrequencyReview : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmFrequencyReview()
        {
            InitializeComponent();
        }

        private void frmFrequencyReview_Load(object sender, EventArgs e)
        {
            LoadData();

            //2016/06/03 ThienNQ( Added)
            txtSearchStart.Focus();
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
            var dataSource = new CrmDBConnect().myTable("CRM_Dir_FrequencyReview_CRUD");
            dgvFrequencyReview.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvFrequencyReview.DataSource = binSource;

            txtStartReview.Enabled = false;
            txtEndReview.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtStartReview.Text = "";
            txtStartReview.Enabled = true;
            txtEndReview.Text = "";
            txtEndReview.Enabled = true;
            EnableBtn(false, false, true, false);

            //2016/06/03 ThienNQ( Added)
            txtStartReview.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtStartReview.Enabled = true;
            txtEndReview.Enabled = true;
            EnableBtn(true, true, true, false);

            //2016/06/03 ThienNQ( Added)
            txtStartReview.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //2016/06/06 ThienNQ( Start Delete)
            //if (Public.IsNullTextBox(txtStartReview, txtEndReview))
            //{
            //    return;
            //}
            //if (int.Parse(txtStartReview.Text) > int.Parse(txtEndReview.Text))
            //{
            //    MessageBox.Show("Giá trị của điểm không hợp lệ!");
            //    return;
            //}
            //2016/06/06 ThienNQ( End Delete)

            //2016/06/06 ThienNQ( Start Add)
            try
            {
                if (int.Parse(txtStartReview.Text) > int.Parse(txtEndReview.Text))
                {
                    MessageBox.Show("Tần suất nhập vào không hợp lệ!");
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
                CrmDBConnect.RunQuery("CRM_Dir_FrequencyReview_CRUD", "@startReview", Convert.ToInt32(txtStartReview.Text.Trim()),
                    "@endReview", Convert.ToInt32(txtEndReview.Text.Trim()), "@flag", 1);
                LoadData();
                dgvFrequencyReview.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("CRM_Dir_FrequencyReview_CRUD", "@startReview", Convert.ToInt32(txtStartReview.Text.Trim()),
                    "@endReview", Convert.ToInt32(txtEndReview.Text.Trim()), "@Id", _id, "@flag", 2);
                LoadData();
                dgvFrequencyReview.Rows[0].Selected = false;
                dgvFrequencyReview.Rows[_selectedRowIndex].Selected = true;
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
            CrmDBConnect.RunQuery("CRM_Dir_FrequencyReview_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //2016/06/03 ThienNQ( Start Delete)
            //if (txtSearchStart.Text.Trim() == "" || txtSearchEnd.Text.Trim() == "")
            //{
            //    MessageBox.Show("Hãy nhập tần suất!");
            //    return;
            //}
            //try
            //{
            //    if (int.Parse(txtSearchStart.Text.Trim()) > int.Parse(txtSearchEnd.Text.Trim()))
            //    {
            //        MessageBox.Show("Tần suất nhập vào không hợp lệ!");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Định dạng không hợp lệ!");
            //    return;
            //}
            //var dataSource = new DBConnect().myTable("CRM_Dir_FrequencyReview_CRUD", "@startReview", txtSearchStart.Text.Trim(),
            //    "@endReview", txtSearchEnd.Text.Trim());
            //dgvFrequencyReview.AutoGenerateColumns = false;

            //var binSource = new BindingSource { DataSource = dataSource };
            //bindingNavigator.BindingSource = binSource;
            //dgvFrequencyReview.DataSource = binSource;
            //2016/06/03 ThienNQ( Start Delete)

            //2016/06/03 ThienNQ( Start Add)
            if (string.IsNullOrWhiteSpace(txtSearchStart.Text) == string.IsNullOrWhiteSpace(txtSearchEnd.Text))
            {
                var dataSource = new System.Data.DataTable();
                try
                {
                    if (string.IsNullOrWhiteSpace(txtSearchStart.Text)
                        || (int.Parse(txtSearchStart.Text.Trim()) == 0 && int.Parse(txtSearchEnd.Text.Trim()) == 0)) // Get All
                    {
                        dataSource = new CrmDBConnect().myTable("CRM_Dir_FrequencyReview_CRUD");
                    }
                    else //Have input data search
                    {
                        //Have input value for txtSearchStartAge and txtSearchEndAge
                        if (int.Parse(txtSearchStart.Text.Trim()) > int.Parse(txtSearchEnd.Text.Trim()))
                        {
                            MessageBox.Show("Tần suất nhập vào không hợp lệ!");
                            return;
                        }
                        else //Search có điều kiện.
                            dataSource = new CrmDBConnect().myTable("CRM_Dir_FrequencyReview_CRUD", "@startReview", txtSearchStart.Text.Trim(), "@endReview", txtSearchEnd.Text.Trim());
                    }
                }
                catch   //Trường hợp input không phải numeric
                {
                    MessageBox.Show("Định dạng không hợp lệ!");
                    return;
                }

                dgvFrequencyReview.AutoGenerateColumns = false;

                var binSource = new BindingSource { DataSource = dataSource };
                bindingNavigator.BindingSource = binSource;
                dgvFrequencyReview.DataSource = binSource;
            }
            else MessageBox.Show("Hãy nhập tần suất!"); //1 in 2 TextBox not input value
            //2016/06/03 ThienNQ( Start Add)
        }

        private void dgvFrequencyReview_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFrequencyReview.CurrentRow == null) return;
            _selectedRowIndex = dgvFrequencyReview.CurrentRow.Index;
            _id = Convert.ToInt32(dgvFrequencyReview.CurrentRow.Cells["Id"].Value);
            txtStartReview.Text = dgvFrequencyReview.CurrentRow.Cells["FromFrequency"].Value.ToString();
            txtStartReview.Enabled = false;
            txtEndReview.Text = dgvFrequencyReview.CurrentRow.Cells["ToFrequency"].Value.ToString();
            txtEndReview.Enabled = false;

            EnableBtn(true, true, false, true);
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
    }
}
