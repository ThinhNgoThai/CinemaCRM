using System;
using System.Windows.Forms;
using CinemaCRM.task.carecustomer;

namespace CinemaCRM.task.careCustomer
{
    public partial class frmManagerCardClass : Form
    {
        private string _operationMode = "UPDATE";
        private int _CardLevelId = 0;

        public frmManagerCardClass()
        {
            InitializeComponent();
        }

        private void frmManagerCardClass_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var tblCrmJob = new CrmDBConnect().myTable("SP_CrmCardLevel_GetAll");
            dgvCardClass.AutoGenerateColumns = false;
            dgvCardClass.DataSource = tblCrmJob;
            dgvCardClass.Rows[0].Selected = false;

        }

        private void DisplayCardLevelInfo(int CardLevelId)
        {
            var tblCardLevel = new CrmDBConnect().myTable("SP_CrmCardLevel_GetOne", "@Id", CardLevelId);
            if (tblCardLevel.Rows.Count > 0)
            {
                txtCardLevelNo.Text = tblCardLevel.Rows[0]["CardLevelNo"].ToString();
                txtCardLevelName.Text = tblCardLevel.Rows[0]["CardLevelName"].ToString();
                dtpActiveDate.Value = System.Convert.ToDateTime(tblCardLevel.Rows[0]["ActiveDate"]);
                txtNeededPointCard.Text = tblCardLevel.Rows[0]["NeededPointCard"].ToString();
                txtMinPointCard.Text = tblCardLevel.Rows[0]["MinPointCard"].ToString();
                txtTimeDuration.Text = tblCardLevel.Rows[0]["TimeDuration"].ToString();
                txtBuyTicketPointReward.Text = tblCardLevel.Rows[0]["BuyTicketPointReward"].ToString();
                txtBuyTicketPointCard.Text = tblCardLevel.Rows[0]["BuyTicketPointCard"].ToString();
                // 2016/04/20 - NguyenNT >>>
                // txtBuyGiftPointReward.Text = tblCardLevel.Rows[0]["BuyGiftPointReward"].ToString();
                // txtBuyGiftPointCard.Text = tblCardLevel.Rows[0]["BuyGiftPointCard"].ToString();
                // 2016/04/20 - NguyenNT <<<
                txtDescription.Text = tblCardLevel.Rows[0]["Description"].ToString();
            }
        }

        private void dgvCardClass_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCardClass.CurrentRow == null) return;
            _CardLevelId = Convert.ToInt32(dgvCardClass.CurrentRow.Cells["colId"].Value);
            this.DisplayCardLevelInfo(_CardLevelId);
            _operationMode = "UPDATE";
        }

        private void dgvCardClass_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            _CardLevelId = 0;

            //clear text
            txtCardLevelNo.Text = "";
            txtCardLevelName.Text = "";
            dtpActiveDate.Value = DateTime.Now;
            txtNeededPointCard.Text = "";
            txtMinPointCard.Text = "";
            txtTimeDuration.Text = "";
            txtBuyTicketPointReward.Text = "";
            txtBuyTicketPointCard.Text = "";
            txtDescription.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCardLevelNo.Text.Trim() == "")
                {
                    MessageBox.Show(@"Bạn chưa nhập thứ tự hạng thẻ", @" Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtCardLevelName.Text.Trim() == "")
                {
                    MessageBox.Show(@"Bạn chưa nhập tên hạng thẻ", @" Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool SaveOK = true;
                //Check decimal input null
                if (string.IsNullOrWhiteSpace(txtBuyTicketPointReward.Text))
                    txtBuyTicketPointReward.Text = "0.0";
                if (string.IsNullOrWhiteSpace(txtBuyTicketPointCard.Text))
                    txtBuyTicketPointCard.Text = "0.0";

                string StringQuery = (this._operationMode == "ADD") ? "SP_CrmCardLevel_Insert" : "SP_CrmCardLevel_Update";
                object[] Params = { 
                                    "@Id", _CardLevelId,
                                    "@CardLevelNo", this.txtCardLevelNo.Text.Trim(),
                                    "@CardLevelName", this.txtCardLevelName.Text.Trim(),
                                    "@ActiveDate", this.dtpActiveDate.Value,
                                    "@NeededPointCard", this.txtNeededPointCard.Text.Trim(),
                                    "@MinPointCard", this.txtMinPointCard.Text.Trim(),
                                    "@TimeDuration", this.txtTimeDuration.Text.Trim(),
                                    "@BuyTicketPointReward", this.txtBuyTicketPointReward.Text.Trim(),
                                    "@BuyTicketPointCard", this.txtBuyTicketPointCard.Text.Trim(),
                                    "@Description", this.txtDescription.Text.Trim(),
                                    "@UserName", CinemaCRM.Contanst.Contanst.UserName,
                    };

                if (this._operationMode == "ADD")
                    _CardLevelId = CrmDBConnect.RunQueryReturnID(StringQuery, Params);
                else
                    SaveOK = SaveOK & CrmDBConnect.RunQuery(StringQuery, Params);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi. Thêm hạng thẻ không thành công." + "\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Hiển thị lại danh sách hạng thẻ
                LoadData();
                _operationMode = "UPDATE";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_CardLevelId <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn xóa hạng thẻ này?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmCardLevel_Delete", "@Id", _CardLevelId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
            LoadData();
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
                if (x < 0) // || T.Text.Contains(','))
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBoxInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only input numeric
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TextBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}