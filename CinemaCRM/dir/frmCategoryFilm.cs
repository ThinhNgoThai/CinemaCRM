using System;
using System.Globalization;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmCategoryFilm : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmCategoryFilm()
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

        private void frmCategoryFilm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var tblCrmCategoryFilm = new TicketDBConnect().myTable("SP_Category_GetAll");
            dgvCategoryFilm.AutoGenerateColumns = false;

            var bindSource = new BindingSource { DataSource = tblCrmCategoryFilm };
            bindingNavigator.BindingSource = bindSource;
            dgvCategoryFilm.DataSource = bindSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";

            txtName.Text = "";
            txtDisplayOrder.Text = "";
            txtDescription.Text = "";

            txtName.Enabled = true;
            txtDisplayOrder.Enabled = true;
            txtDescription.Enabled = true;

            EnableBtn(false, false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";

            txtName.Enabled = true;
            txtDisplayOrder.Enabled = true;
            txtDescription.Enabled = true;

            EnableBtn(true, false, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtName, txtDisplayOrder)) return;

            if (_operationMode == "ADD")
            {
                TicketDBConnect.RunQuery("SP_Category_CRUD", "@Name", txtName.Text, "@Description", txtDescription.Text,
                    "@DisplayOrder", txtDisplayOrder.Text, "@flag", 1);
                LoadData();
                dgvCategoryFilm.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                TicketDBConnect.RunQuery("SP_Category_CRUD", "@Name", txtName.Text, "@Description", txtDescription.Text,
                    "@DisplayOrder", txtDisplayOrder.Text, "@Id", _id, "@flag", 2);
                LoadData();
                dgvCategoryFilm.Rows[0].Selected = false;
                dgvCategoryFilm.Rows[_selectedRowIndex].Selected = true;
                MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }
        }

        private void dgvCategoryFilm_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoryFilm.CurrentRow == null) return;
            _selectedRowIndex = dgvCategoryFilm.CurrentRow.Index;
            _id = Convert.ToInt32(dgvCategoryFilm.CurrentRow.Cells["Id"].Value);
            txtName.Text = dgvCategoryFilm.CurrentRow.Cells["Name"].Value.ToString();
            txtDisplayOrder.Text = dgvCategoryFilm.CurrentRow.Cells["DisplayOrder"].Value.ToString();
            var description = dgvCategoryFilm.CurrentRow.Cells["Description"].Value;
            if (description != null)
                txtDescription.Text = description.ToString();

            txtName.Enabled = false;
            txtDisplayOrder.Enabled = false;
            txtDescription.Enabled = false;

            EnableBtn(true, true, false, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            TicketDBConnect.RunQuery("SP_Category_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void dgvCategoryFilm_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = sender as DataGridView;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dataSource = new TicketDBConnect().myTable("SP_Category_CRUD", "@Name", txtSearchName.Text.Trim());
            dgvCategoryFilm.AutoGenerateColumns = false;

            var bindSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = bindSource;
            dgvCategoryFilm.DataSource = bindSource;
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
