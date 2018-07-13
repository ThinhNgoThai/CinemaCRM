using System;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmConfigTicketsPerBuy : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmConfigTicketsPerBuy()
        {
            InitializeComponent();
        }

        private void frmConfigTicketsPerBuy_Load(object sender, EventArgs e)
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
            var tblCrmJob = new CrmDBConnect().myTable("CRM_Dir_TicketBuy_CRUD");
            dgvTicketBuy.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmJob };
            bindingNavigator.BindingSource = binSource;
            dgvTicketBuy.DataSource = binSource;

            txtStartTicket.Enabled = false;
            txtEndTicket.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtStartTicket.Text = "";
            txtStartTicket.Enabled = true;
            txtEndTicket.Text = "";
            txtEndTicket.Enabled = true;
            EnableBtn(false, false, true, false);

            //2016/06/03 ThienNQ( Added)
            txtStartTicket.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtStartTicket.Enabled = true;
            txtEndTicket.Enabled = true;
            EnableBtn(true, false, true, false);

            //2016/06/03 ThienNQ( Added)
            txtStartTicket.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //2016/06/06 ThienNQ( Start Delete)
            //if (Public.IsNullTextBox(txtStartTicket, txtEndTicket))
            //{
            //    return;
            //}

            //if (int.Parse(txtStartTicket.Text) > int.Parse(txtEndTicket.Text))
            //{
            //    MessageBox.Show("Giá trị của điểm không hợp lệ!");
            //    return;
            //}
            //2016/06/06 ThienNQ( End Delete)

            //2016/06/06 ThienNQ( Start Add)
            try
            {
                if (int.Parse(txtStartTicket.Text) > int.Parse(txtEndTicket.Text))
                {
                    MessageBox.Show("Giá trị của điểm không hợp lệ!");
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
                CrmDBConnect.RunQuery("CRM_Dir_TicketBuy_CRUD", "@startTicket", Convert.ToInt32(txtStartTicket.Text.Trim()),
                    "@endTicket", Convert.ToInt32(txtEndTicket.Text.Trim()), "@flag", 1);
                LoadData();
                dgvTicketBuy.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE" + "")
            {
                CrmDBConnect.RunQuery("CRM_Dir_TicketBuy_CRUD", "@startTicket", Convert.ToDecimal(txtStartTicket.Text.Trim()),
                    "@endTicket", Convert.ToDecimal(txtEndTicket.Text.Trim()), "@Id", _id, "@flag", 2);
                LoadData();
                dgvTicketBuy.Rows[0].Selected = false;
                dgvTicketBuy.Rows[_selectedRowIndex].Selected = true;
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
            CrmDBConnect.RunQuery("CRM_Dir_TicketBuy_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void dgvTicketBuy_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTicketBuy.CurrentRow == null) return;
            _selectedRowIndex = dgvTicketBuy.CurrentRow.Index;
            _id = Convert.ToInt32(dgvTicketBuy.CurrentRow.Cells["Id"].Value);
            txtStartTicket.Text = dgvTicketBuy.CurrentRow.Cells["FromTicketBuy"].Value.ToString();
            txtStartTicket.Enabled = false;
            txtEndTicket.Text = dgvTicketBuy.CurrentRow.Cells["ToTicketBuy"].Value.ToString();
            txtEndTicket.Enabled = false;

            EnableBtn(true, true, false, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //2016/06/06 ThienNQ( Start Delete)
            //if (txtSearchStart.Text.Trim() == "" || txtSearchEnd.Text.Trim() == "")
            //{
            //    MessageBox.Show("Hãy nhập số lượng!");
            //    return;
            //}
            //try
            //{
            //    if (int.Parse(txtSearchStart.Text.Trim()) > int.Parse(txtSearchEnd.Text.Trim()))
            //    {
            //        MessageBox.Show("Số lượng nhập vào không hợp lệ!");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Định dạng không hợp lệ!");
            //    return;
            //}
            //var tblCrmJob = new DBConnect().myTable("CRM_Dir_TicketBuy_CRUD", "@startTicket", txtSearchStart.Text.Trim(),
            //    "@endTicket", txtSearchEnd.Text.Trim());
            //dgvTicketBuy.AutoGenerateColumns = false;

            //var binSource = new BindingSource { DataSource = tblCrmJob };
            //bindingNavigator.BindingSource = binSource;
            //dgvTicketBuy.DataSource = binSource;
            //2016/06/06 ThienNQ( End Delete)

            //2016/06/06 ThienNQ( Start Add)
            if (string.IsNullOrWhiteSpace(txtSearchStart.Text) == string.IsNullOrWhiteSpace(txtSearchEnd.Text))
            {
                var tblCrmJob = new System.Data.DataTable();
                try
                {
                    if (string.IsNullOrWhiteSpace(txtSearchStart.Text)
                        || (int.Parse(txtSearchStart.Text.Trim()) == 0 && int.Parse(txtSearchEnd.Text.Trim()) == 0)) // Get All
                    {
                        tblCrmJob = new CrmDBConnect().myTable("CRM_Dir_TicketBuy_CRUD");
                    }
                    else //Have input data search
                    {
                        if (int.Parse(txtSearchStart.Text.Trim()) > int.Parse(txtSearchEnd.Text.Trim()))
                        {
                            MessageBox.Show("Số lượng nhập vào không hợp lệ!");
                            return;
                        }
                        else //Search có điều kiện.
                            tblCrmJob = new CrmDBConnect().myTable("CRM_Dir_TicketBuy_CRUD", "@startTicket", txtSearchStart.Text.Trim(), "@endTicket", txtSearchEnd.Text.Trim());
                    }
                }
                catch   //Trường hợp input không phải numeric
                {
                    MessageBox.Show("Định dạng không hợp lệ!");
                    return;
                }

                dgvTicketBuy.AutoGenerateColumns = false;

                var binSource = new BindingSource { DataSource = tblCrmJob };
                bindingNavigator.BindingSource = binSource;
                dgvTicketBuy.DataSource = binSource;
            }
            else MessageBox.Show("Hãy nhập số lượng!");   //1 in 2 TextBox not input value
            //2016/06/06 ThienNQ( End Add)
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
