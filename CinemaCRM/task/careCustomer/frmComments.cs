using System;
using System.Data;
using System.Windows.Forms;
using CinemaCRM.taks.careCustomer;

namespace CinemaCRM.task.careCustomer
{
    public partial class frmComments : Form
    {
        private int? _id;
        private BindingSource _binSource;
        private DataTable _dataSource;
        //private int _index = 0;

        public frmComments()
        {
            InitializeComponent();
        }

        //Load dữ liệu
        private void frmComments_Load(object sender, EventArgs e)
        {
            LoadData(dtpStartNew, dtpEndNew);
        }

        #region Các method hỗ trợ
        private void __detailClick(DataGridView dtg)
        {
            if (dtg == null || dtg.CurrentRow == null || _id == null)
            {
                MessageBox.Show("Hãy chọn đối tượng trong lưới dữ liệu.", "Cảnh báo");
                return;
            }

            var currentRow = dtg.CurrentRow;

            var frm = new frmCommentDetails
            {
                Id = Convert.ToInt32(_id),
                txtFilmName = { Text = currentRow.Cells[1].Value.ToString() },
                txtTitle = { Text = currentRow.Cells[2].Value.ToString() },
                txtContent = { Text = currentRow.Cells[3].Value.ToString() },
                txtUsername = { Text = currentRow.Cells[5].Value.ToString() },
                SelectedStatus = currentRow.Cells[7].Value.ToString()
            };

            frm.ShowDialog();
            LoadData(dtpStartNew, dtpEndNew);
        }

        private void __searchClick(DataGridView dataGridView, TextBox textBox)
        {
            _binSource = new BindingSource
            {
                DataSource = dataGridView.DataSource,
                //EDIT HUNGNT 2016/03/31 >>>	
                //Filter = "Content_New" + " LIKE '%" + textBox.Text + "%'"
                Filter = "Content_New" + " LIKE '%" + textBox.Text + "%' OR FilmName_New" + " LIKE '%" + textBox.Text + "%'"
                //<<< EDIT HUNGNT 2016/03/31
            };
            dataGridView.DataSource = _binSource;
        }

        private void __executeQuery(string notice, int flag)
        {
            if (_id == null)
            {
                MessageBox.Show("Hãy chọn đối tượng trong lưới dữ liệu.", "Cảnh báo");
            }
            else
            {
                var result = CrmDBConnect.RunQuery("SP_CrmFilmComment", "@Id", _id, "@operation", flag);
                if (result) MessageBox.Show(notice, @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(dtpStartNew, dtpEndNew);
            }
        }

        //2016/06/06 ThienNQ( Edited)
        private void LoadData(DateTimePicker start, DateTimePicker end)
        {
            DataGridView dataGridView = new DataGridView();
            BindingNavigator bindingNavigator = new BindingNavigator();
            int flag = 0;

            switch (tabComments.SelectedIndex)
            {
                case 0:
                    dataGridView = dgvPageNew;
                    bindingNavigator = bindingNavigatorNew;
                    flag = 0;
                    break;
                case 1:
                    dataGridView = dgvPageApproved;
                    bindingNavigator = bindingNavigatorApproved;
                    flag = 1;
                    break;
                case 2:
                    dataGridView = dgvPagePending;
                    bindingNavigator = bindingNavigatorPending;
                    flag = 2;
                    break;
                case 3:
                    dataGridView = dgvPageDeny;
                    bindingNavigator = bindingNavigatorDeny;
                    flag = 3;
                    break;
            }

            _dataSource = new CrmDBConnect().myTable("SP_CrmFilmComment", "@flag", flag);

            _binSource = new BindingSource { DataSource = _dataSource };
            bindingNavigator.BindingSource = _binSource;
            dataGridView.DataSource = _binSource;

            //Check index
            if (dataGridView == null || dataGridView.RowCount == 0)
                _id = null;//không có row nào được chọn.

            //dataGridView.ClearSelection();
            //dataGridView.Rows[_index].Selected = true;
            //dataGridView.FirstDisplayedScrollingRowIndex = _index;

            end.MinDate = start.Value;
        }
        #endregion

        #region Buttons
        //Duyệt
        private void btnAccept_Click(object sender, EventArgs e)
        {
            __executeQuery("Đã duyệt", 1);
        }

        //Chờ duyệt
        private void btnPending_Click(object sender, EventArgs e)
        {
            __executeQuery("Đang chờ duyệt", 2);
        }

        //Từ chối
        private void btnDeny_Click(object sender, EventArgs e)
        {
            __executeQuery("Đã từ chối", 3);
        }

        //Chi tiết
        private void btnDetail_Click(object sender, EventArgs e)
        {
            var selectedTab = tabComments.SelectedTab;

            if (selectedTab == tabPageNew)
                __detailClick(dgvPageNew);
            else if (selectedTab == tabPageApproved)
                __detailClick(dgvPageApproved);
            else if (selectedTab == tabPagePending)
                __detailClick(dgvPagePending);
            else if (selectedTab == tabPageReject)
                __detailClick(dgvPageDeny);
        }

        //Thoát
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }
        #endregion

        #region DTG_ValueChanged
        private void dtpStartNew_ValueChanged(object sender, EventArgs e)
        {
            dtpEndNew.MinDate = dtpStartNew.Value;
        }

        private void dtpStartApproved_ValueChanged(object sender, EventArgs e)
        {
            dtpEndApproved.MinDate = dtpStartApproved.Value;
        }

        private void dtpStartPending_ValueChanged(object sender, EventArgs e)
        {
            dtpEndPending.MinDate = dtpStartPending.Value;
        }

        private void dtpStartDeny_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDeny.MinDate = dtpStartDeny.Value;
        }
        #endregion

        #region Tìm kiếm
        private void btnSearchApproved_Click(object sender, EventArgs e)
        {
            __searchClick(dgvPageApproved, txtSearchApproved);
        }

        private void btnSearchNew_Click(object sender, EventArgs e)
        {
            __searchClick(dgvPageNew, txtSearchNew);
        }

        private void btnSearchPending_Click(object sender, EventArgs e)
        {
            __searchClick(dgvPagePending, txtSearchPending);
        }

        private void btnSearchDeny_Click(object sender, EventArgs e)
        {
            __searchClick(dgvPageDeny, txtSearchDeny);
        }
        #endregion

        //2016/06/06 ThienNQ( Edited)
        private void dgvPageNew_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender == null) return;
            __detailClick((DataGridView)sender);
        }

        //2016/06/06 ThienNQ( Added)
        private void dtg_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (sender == null) return;
            var dtg = (DataGridView)sender;

            if (dtg.CurrentRow == null) return;

            _id = Convert.ToInt32(dtg.CurrentRow.Cells[0].Value);
        }

        //2016/06/06 ThienNQ( Added)
        private void tabComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(dtpStartNew, dtpEndNew);
        }
    }
}
