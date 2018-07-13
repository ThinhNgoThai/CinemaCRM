using System;
using System.Linq;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmTimeSellTicket : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;

        public frmTimeSellTicket()
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
            var dataSource = new CrmDBConnect().myTable("SP_CrmTimeSellTicket_CRUD", "@flag", 0);
            dgvTimeSellTicket.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvTimeSellTicket.DataSource = binSource;

            txtFromTime.Enabled = false;
            txtToTime.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            txtFromTime.Text = "";
            txtFromTime.Enabled = true;
            txtToTime.Text = "";
            txtToTime.Enabled = true;
            EnableBtn(false, false, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            txtFromTime.Enabled = true;
            txtToTime.Enabled = true;
            EnableBtn(true, true, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtFromTime, txtToTime)) return;

            try
            {
                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                DateTime start_dt = DateTime.ParseExact(txtFromTime.Text, "HH:mm", provider);
                DateTime end_dt = DateTime.ParseExact(txtToTime.Text, "HH:mm", provider);
                if (start_dt > end_dt)
                {
                    MessageBox.Show("Lỗi nhập thời gian!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập thời gian!");
                return;
            }

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("SP_CrmTimeSellTicket_CRUD", "@FromTime", txtFromTime.Text.Trim(), "@ToTime", txtToTime.Text.Trim(), "@flag", 1);

                dgvTimeSellTicket.Enabled = true;
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("SP_CrmTimeSellTicket_CRUD", "@FromTime", txtFromTime.Text.Trim(), "@ToTime", txtToTime.Text.Trim(), "@Id", _id, "@flag", 2);

                dgvTimeSellTicket.Rows[0].Selected = false;
                dgvTimeSellTicket.Rows[_selectedRowIndex].Selected = true;
                MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmTimeSellTicket_CRUD", "@Id", _id, "@flag", 3);
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void dgvConfigRevenue_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTimeSellTicket.CurrentRow == null) return;
            _selectedRowIndex = dgvTimeSellTicket.CurrentRow.Index;
            _id = Convert.ToInt32(dgvTimeSellTicket.CurrentRow.Cells["Id"].Value);
            txtFromTime.Text = dgvTimeSellTicket.CurrentRow.Cells["FromTime"].Value.ToString();
            txtFromTime.Enabled = false;
            txtToTime.Text = dgvTimeSellTicket.CurrentRow.Cells["ToTime"].Value.ToString();
            txtToTime.Enabled = false;

            EnableBtn(true, true, false, true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchStart.Text) != string.IsNullOrWhiteSpace(txtSearchEnd.Text))
            {
                MessageBox.Show("Hãy nhập đủ thông tin để tìm kiếm.", "Thông báo");
                return;
            }
            var dataSource = new CrmDBConnect().myTable("SP_CrmTimeSellTicket_CRUD", "@FromTime", txtSearchStart.Text.Trim(),
                "@ToTime", txtSearchEnd.Text.Trim());
            dgvTimeSellTicket.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvTimeSellTicket.DataSource = binSource;
        }


        //2016/06/-- ThienNQ Added - Input time by format
        private void TextBoxTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Format #0:#0
            var txt = (TextBox)sender;
            //Không cho phép input khác ":" or numeric và chỉ cho phép input 1 kí tự ":"
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && (e.KeyChar != ':' || ((e.KeyChar == ':') && txt.Text.Contains(":"))))
            {
                e.Handled = true;
            }
            else //Trường hợp cho phép
            {
                if (char.IsDigit(e.KeyChar))    //is numeric
                {
                    if (string.IsNullOrEmpty(txt.Text)) return; //nếu text chưa có kí tự nào --> input số

                    string[] strTemp = txt.Text.Substring(0, txt.SelectionStart).Split(new char[] { ':' }); //Split theo dấu ":" những kí tự trước vị trí con trỏ
                    string strInput = strTemp.LastOrDefault();   // string đang input hour or minute chia cắt bởi dấu ":"

                    if (strInput.Length == 1)
                    {
                        if (strTemp.Count() == 1) //chỉ cho phép input hour < 24
                        {
                            if ((Convert.ToInt32(strInput) == 2 && (int)char.GetNumericValue(e.KeyChar) > 3)
                                || (Convert.ToInt32(strInput) > 2))
                                e.Handled = true;
                        }
                        else if (strTemp.Count() == 2) //chỉ cho phép input minute < 60
                        {
                            if (Convert.ToInt32(strInput) > 5)
                                e.Handled = true;
                        }
                    }
                    else if (strInput.Length == 2) // giờ hoặc phút không được vượt quá 2 kí tự
                        e.Handled = true;
                }
                else if (e.KeyChar == ':') // is ":"
                {
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        if (txt.Text.Length == 1)
                        {
                            txt.Text = "0" + txt.Text;
                            txt.SelectionStart = txt.Text.Length;
                        }
                    }
                }
            }
        }
    }
}
