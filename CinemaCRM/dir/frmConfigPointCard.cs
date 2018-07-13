using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmConfigPointCard : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmConfigPointCard()
        {
            InitializeComponent();
        }

        private void frmConfigPointCard_Load(object sender, EventArgs e)
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
            var tblCrmJob = new CrmDBConnect().myTable("CRM_Dir_PointCard_CRUD");
            dgvConfigPointCard.AutoGenerateColumns = false;
            dgvConfigPointCard.DataSource = tblCrmJob;

            txtStartPoint.Enabled = false;
            txtEndPoint.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtStartPoint.Text = "";
            txtStartPoint.Enabled = true;
            txtEndPoint.Text = "";
            txtEndPoint.Enabled = true;
            EnableBtn(false, false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtStartPoint.Enabled = true;
            txtEndPoint.Enabled = true;
            EnableBtn(true, true, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtStartPoint, txtEndPoint))
            {
                return;
            }
            if (int.Parse(txtStartPoint.Text) > int.Parse(txtEndPoint.Text))
            {
                MessageBox.Show("Giá trị của điểm không hợp lệ!");
                return;
            }
            
            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("CRM_Dir_PointCard_CRUD", "@startPoint",Convert.ToDecimal(txtStartPoint.Text.Trim()),
                    "@endPoint",Convert.ToDecimal(txtEndPoint.Text.Trim()), "@flag", 1);
                LoadData();
                dgvConfigPointCard.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("CRM_Dir_PointCard_CRUD", "@startPoint",Convert.ToDecimal(txtStartPoint.Text.Trim()),
                    "@endPoint",Convert.ToDecimal(txtEndPoint.Text.Trim()), "@Id", _id, "@flag", 2);
                LoadData();
                dgvConfigPointCard.Rows[0].Selected = false;
                dgvConfigPointCard.Rows[_selectedRowIndex].Selected = true;
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
            CrmDBConnect.RunQuery("CRM_Dir_PointCard_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void dgvConfigPointCard_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConfigPointCard.CurrentRow == null) return;
            _selectedRowIndex = dgvConfigPointCard.CurrentRow.Index;
            _id = Convert.ToInt32(dgvConfigPointCard.CurrentRow.Cells["Id"].Value);
            txtStartPoint.Text = dgvConfigPointCard.CurrentRow.Cells["FromPoint"].Value.ToString();
            txtStartPoint.Enabled = false;
            txtEndPoint.Text = dgvConfigPointCard.CurrentRow.Cells["ToPoint"].Value.ToString();
            txtEndPoint.Enabled = false;

            EnableBtn(true, true, false, true);
        }


        private void dgvConfigPointCard_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchFrom.Text.Trim() == "" || txtSearchTo.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập điểm!");
                return;
            }
            try
            {
                if (int.Parse(txtSearchFrom.Text.Trim()) > int.Parse(txtSearchTo.Text.Trim()))
                {
                    MessageBox.Show("Điểm nhập vào không hợp lệ!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Định dạng không hợp lệ!");
                return;
            }
            var tblCrmJob = new CrmDBConnect().myTable("CRM_Dir_PointCard_CRUD", "@startPoint", txtSearchFrom.Text.Trim(), "@endPoint", txtSearchTo.Text.Trim());
            dgvConfigPointCard.AutoGenerateColumns = false;
            dgvConfigPointCard.DataSource = tblCrmJob;
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
