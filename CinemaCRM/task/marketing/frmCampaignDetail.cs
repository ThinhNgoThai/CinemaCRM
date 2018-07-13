using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.task.marketing
{
    public partial class frmCampaignDetail : Form
    {
        private string _OperationMode = "UPDATE";
        private int _CampaignId = 0;
        private int _FilmAppliedId = 0;
        private int _GiftAppliedId = 0;
        private int _GiftId = 0;
        private int _EmailTemplateId = 0;
        private int _SmsTemplateId = 0;
        private int _EmailCustomerId = 0;
        private int _SmsCustomerId = 0;
        private bool _IsDataLoaded = false;
        private bool _IsFilmAppliedLoaded = false;
        private bool _IsGiftAppliedLoaded = false;
        private bool _IsGiftLoaded = false;
        private bool _IsEmailTemplateLoaded = false;
        private bool _IsSmsTemplateLoaded = false;
        private bool _IsEmailCustomerLoaded = false;
        private bool _IsSmsCustomerLoaded = false;
        private bool _IsCheckBoxAllClicked = false;
        private int _TotalCheckedCheckBoxes = 0;
        private int _TotalCheckBoxes = 0;
        private bool _IsLoadComplete = false;

        private CrmDBConnect dbconnect = new CrmDBConnect();
        private SendEmail email = new SendEmail();
        public int CampaignId
        {
            get { return _CampaignId; }
            set { _CampaignId = value; }
        }

        public string OperationMode
        {
            get { return _OperationMode; }
            set { _OperationMode = value; }
        }

        public frmCampaignDetail()
        {
            InitializeComponent();
        }

        private void frmCampaignDetail_Load(object sender, EventArgs e)
        {
            //Hiển thị danh sách mẫu chiến dịch khuyến mại
            BindControls();
            _IsDataLoaded = true;
            _IsEmailTemplateLoaded = true;
            _IsSmsTemplateLoaded = true;
            _IsGiftLoaded = true;

            if (_CampaignId > 0)
            {
                //Hiển thị thông tin chi tiết của chương trình khuyến mại
                this.DisplayCampaignData(_CampaignId);

                //Hiển thị danh sách các phim đang áp dụng khuyến mại
                this.LoadFilmApplied(_CampaignId);
                this.LoadFilmList(_CampaignId);
                _IsFilmAppliedLoaded = true;

                //Hiển thị danh sách quà tặng đang áp dụng trong khuyến mại
                this.LoadGiftApplied(_CampaignId);
                _IsGiftAppliedLoaded = true;

                //Hiển thị danh sách khách hàng nhận E-mail
                this.LoadEmailCustomer(_CampaignId, _EmailTemplateId);
                _IsEmailCustomerLoaded = true;

                //Hiển thị danh sách khách hàng nhận SMS
                this.LoadSmsCustomer(_CampaignId, _SmsTemplateId);
                _IsSmsCustomerLoaded = true;
            }

            //mappv add start
            _TotalCheckBoxes = grdEmailCustomer.RowCount;
            _TotalCheckedCheckBoxes = 0;
            //_IsCheckBoxAllClicked = true;
            //_IsLoadComplete = true;
            //mappv add end
        }

        private void BindControls()
        {
            //Danh sách mẫu chương trình khuyến mại
            DataTable tblPaterns = dbconnect.myTable("SP_CrmCampaignPatern_GetAll");
            if (tblPaterns.Rows.Count > 0)
            {
                DataRow rowPatern = tblPaterns.NewRow();
                rowPatern["PaternCode"] = "";
                rowPatern["PaternString"] = "";
                tblPaterns.Rows.InsertAt(rowPatern, 0);
                this.cboCampaignPatern.DataSource = tblPaterns;
                this.cboCampaignPatern.ValueMember = "PaternCode";
                this.cboCampaignPatern.DisplayMember = "PaternString";
            }
            //Danh sách mẫu E-mail quảng cáo
            DataTable tblEmailTemplate = dbconnect.myTable("SP_CrmTemplateEmail_CRUD", "@TemplateName", "", "@flag", 0);
            if (tblEmailTemplate.Rows.Count > 0)
            {
                DataRow rowEmailTemplate = tblEmailTemplate.NewRow();
                rowEmailTemplate["Id"] = 0;
                rowEmailTemplate["TemplateName"] = "";
                tblEmailTemplate.Rows.InsertAt(rowEmailTemplate, 0);
                this.cboEmailTemplate.DataSource = tblEmailTemplate;
                this.cboEmailTemplate.ValueMember = "Id";
                this.cboEmailTemplate.DisplayMember = "TemplateName";
            }
            //Danh sách mẫu SMS quảng cáo
            DataTable tblSmsTemplate = dbconnect.myTable("SP_CrmTemplateSMS_CRUD", "@TemplateName", "", "@flag", 0);
            if (tblSmsTemplate.Rows.Count > 0)
            {
                DataRow rowSmsTemplate = tblSmsTemplate.NewRow();
                rowSmsTemplate["Id"] = 0;
                rowSmsTemplate["TemplateName"] = "";
                tblSmsTemplate.Rows.InsertAt(rowSmsTemplate, 0);
                this.cboSmsTemplate.DataSource = tblSmsTemplate;
                this.cboSmsTemplate.ValueMember = "Id";
                this.cboSmsTemplate.DisplayMember = "TemplateName";
            }
            //Danh sách sản phẩm quà tặng dùng cho khuyến mại
            DataTable tblGifts = dbconnect.myTable("SP_CrmCampaign_GetGifts");
            if (tblGifts.Rows.Count > 0)
            {
                DataRow rowGift = tblGifts.NewRow();
                rowGift["Id"] = 0;
                rowGift["Name"] = "";
                tblGifts.Rows.InsertAt(rowGift, 0);
                this.cboGiftProduct.DataSource = tblGifts;
                this.cboGiftProduct.ValueMember = "Id";
                this.cboGiftProduct.DisplayMember = "Name";
            }
            // 2016/06/03 NguyenNT hiển thị danh sách Film >>>
            if (_CampaignId == 0)
                this.LoadAllFilmList();
            // 2016/06/03 NguyenNT <<<
        }

        private void DisplayCampaignData(int CampaignId)
        {
            DataTable tblCampaign = dbconnect.myTable("SP_CrmCampaign_GetOne", "@Id", CampaignId);
            if (tblCampaign.Rows.Count > 0)
            {
                cboCampaignPatern.SelectedValue = tblCampaign.Rows[0]["PaternCode"].ToString();
                txtCampaignName.Text = tblCampaign.Rows[0]["Name"].ToString();
                chkPeriodicalCampaign.Checked = System.Convert.ToBoolean(tblCampaign.Rows[0]["IsContinuous"]);
                dtpStartDate.Value = System.Convert.ToDateTime(tblCampaign.Rows[0]["StartOnUtc"]);
                dtpEndDate.Value = System.Convert.ToDateTime(tblCampaign.Rows[0]["EndOnUtc"]);
                txtParameterCount.Text = tblCampaign.Rows[0]["ParameterCount"].ToString();
                txtParamValue1.Text = tblCampaign.Rows[0]["ParamValue1"].ToString();
                txtParamValue2.Text = tblCampaign.Rows[0]["ParamValue2"].ToString();
                txtParamValue3.Text = tblCampaign.Rows[0]["ParamValue3"].ToString();
                txtParamValue4.Text = tblCampaign.Rows[0]["ParamValue4"].ToString();
                txtParamValue5.Text = tblCampaign.Rows[0]["ParamValue5"].ToString();
                chkClosed.Checked = System.Convert.ToBoolean(tblCampaign.Rows[0]["Closed"]);
                // 2016/06/03 NguyenNT Fix loi chua check null >>>
                // _EmailTemplateId = System.Convert.ToInt32(tblCampaign.Rows[0]["EmailTemplateId"]);
                // cboEmailTemplate.SelectedValue = _EmailTemplateId;
                // _SmsTemplateId = System.Convert.ToInt32(tblCampaign.Rows[0]["SmsTemplateId"]);
                // cboSmsTemplate.SelectedValue = _SmsTemplateId;
                if (tblCampaign.Rows[0]["EmailTemplateId"].ToString() != "")
                {
                    _EmailTemplateId = System.Convert.ToInt32(tblCampaign.Rows[0]["EmailTemplateId"]);
                    cboEmailTemplate.SelectedValue = _EmailTemplateId;
                }
                if (tblCampaign.Rows[0]["SmsTemplateId"].ToString() != "")
                {
                    _SmsTemplateId = System.Convert.ToInt32(tblCampaign.Rows[0]["SmsTemplateId"]);
                    cboSmsTemplate.SelectedValue = _SmsTemplateId;
                }
                // 2016/06/03 NguyenNT <<<
            }
        }

        private void LoadFilmApplied(int CampaignId)
        {
            DataTable tblFilmApplied = dbconnect.myTable("SP_CrmCampaign_GetFilmApplied", "@Id", CampaignId);
            this.dgrFilmApplied.AutoGenerateColumns = false;
            this.dgrFilmApplied.DataSource = tblFilmApplied;
        }

        private void LoadFilmList(int CampaignId)
        {
            DataTable tblFilmUnApplied = dbconnect.myTable("SP_CrmCampaign_GetFilmUnApplied", "@Id", CampaignId);
            this.lstFilmList.DataSource = tblFilmUnApplied;
            this.lstFilmList.ValueMember = "Id";
            this.lstFilmList.DisplayMember = "FilmName";
        }

        // 2016/06/03 NguyenNT load film khi them moi 1 chuong trinh khuyen mai >>>
        private void LoadAllFilmList()
        {
            DataTable tblFilmUnApplied = dbconnect.myTable("SP_CrmCampaign_GetFilmUnApplied", "@Id", 0);
            this.lstFilmList.DataSource = tblFilmUnApplied;
            this.lstFilmList.ValueMember = "Id";
            this.lstFilmList.DisplayMember = "FilmName";
        }
        // 2016/06/03 NguyenNT <<<

        private void LoadGiftApplied(int CampaignId)
        {
            DataTable tblGiftApplied = dbconnect.myTable("SP_CrmCampaign_GetGiftApplied", "@CampaignId", CampaignId);
            this.grdGiftApplied.AutoGenerateColumns = false;
            this.grdGiftApplied.DataSource = tblGiftApplied;
        }

        private void LoadEmailCustomer(int CampaignId, int EmailTemplateId)
        {
            DataTable tblEmailCustomer = dbconnect.myTable("SP_CrmCampaign_GetEmailCustomer", "@CampaignId", CampaignId, "@EmailTemplateId", EmailTemplateId);
            this.grdEmailCustomer.AutoGenerateColumns = false;
            this.grdEmailCustomer.DataSource = tblEmailCustomer;
        }

        private void LoadSmsCustomer(int CampaignId, int SmsTemplateId)
        {
            DataTable tblSmsCustomer = dbconnect.myTable("SP_CrmCampaign_GetSmsCustomer", "@CampaignId", CampaignId, "@SmsTemplateId", SmsTemplateId);
            this.grdSmsCustomer.AutoGenerateColumns = false;
            this.grdSmsCustomer.DataSource = tblSmsCustomer;
        }

        private void cboCampaignPatern_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsDataLoaded == true)
            {
                this.txtParamValue1.Enabled = false;
                this.txtParamValue2.Enabled = false;
                this.txtParamValue3.Enabled = false;
                this.txtParamValue4.Enabled = false;
                this.txtParamValue5.Enabled = false;

                this.txtParameterCount.Text = "";
                this.txtParamValue1.Text = "";
                this.txtParamValue2.Text = "";
                this.txtParamValue3.Text = "";
                this.txtParamValue4.Text = "";
                this.txtParamValue5.Text = "";

                string PaternCode = cboCampaignPatern.SelectedValue.ToString();

                if (PaternCode != "")
                {
                    DataTable tblCampaignPatern = dbconnect.myTable("SP_CrmCampaignPatern_GetOne", "@PaternCode", PaternCode);
                    if (tblCampaignPatern.Rows.Count > 0)
                    {
                        this.txtParameterCount.Text = tblCampaignPatern.Rows[0]["ParameterCount"].ToString();
                        this.txtCampaignName.Text = tblCampaignPatern.Rows[0]["PaternString"].ToString();

                        switch (this.txtParameterCount.Text)
                        {
                            case "1":
                                this.txtParamValue1.Enabled = true;
                                break;
                            case "2":
                                this.txtParamValue1.Enabled = true;
                                this.txtParamValue2.Enabled = true;
                                break;
                            case "3":
                                this.txtParamValue1.Enabled = true;
                                this.txtParamValue2.Enabled = true;
                                this.txtParamValue3.Enabled = true;
                                break;
                            case "4":
                                this.txtParamValue1.Enabled = true;
                                this.txtParamValue2.Enabled = true;
                                this.txtParamValue3.Enabled = true;
                                this.txtParamValue4.Enabled = true;
                                break;
                            case "5":
                                this.txtParamValue1.Enabled = true;
                                this.txtParamValue2.Enabled = true;
                                this.txtParamValue3.Enabled = true;
                                this.txtParamValue4.Enabled = true;
                                this.txtParamValue5.Enabled = true;
                                break;
                        }
                    }
                }
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            _CampaignId = 0;
            _OperationMode = "ADD";
            cboCampaignPatern.SelectedIndex = 0;
            txtCampaignName.Text = "";
            chkPeriodicalCampaign.Checked = true;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            chkClosed.Checked = false;
        }

        private bool ValidateData()
        {
            if (this.cboCampaignPatern.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Bạn chưa chọn mẫu chiến dịch khuyến mại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCampaignPatern.Focus();
                return false;
            }

            if (this.txtCampaignName.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên chương trình khuyến mại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCampaignName.Focus();
                return false;
            }

            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn Ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartDate.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 2016/06/06 NguyenNT check null >>>
            if (this.txtParamValue1.Enabled == true) 
            {
                if (this.txtParamValue1.Text.Trim() == "")
                {
                    MessageBox.Show("Giá trị thứ 1 không được để trống!");
                    this.txtParamValue1.Focus();
                    return;
                }
            }
            if (this.txtParamValue2.Enabled == true)
            {
                if (this.txtParamValue2.Text.Trim() == "")
                {
                    MessageBox.Show("Giá trị thứ 2 không được để trống!");
                    this.txtParamValue2.Focus();
                    return;
                }
            }
            if (this.txtParamValue3.Enabled == true)
            {
                if (this.txtParamValue3.Text.Trim() == "")
                {
                    MessageBox.Show("Giá trị thứ 3 không được để trống!");
                    this.txtParamValue3.Focus();
                    return;
                }
            }
            if (this.txtParamValue4.Enabled == true)
            {
                if (this.txtParamValue4.Text.Trim() == "")
                {
                    MessageBox.Show("Giá trị thứ 4 không được để trống!");
                    this.txtParamValue4.Focus();
                    return;
                }
            }
            if (this.txtParamValue5.Enabled == true)
            {
                if (this.txtParamValue5.Text.Trim() == "")
                {
                    MessageBox.Show("Giá trị thứ 5 không được để trống!");
                    this.txtParamValue5.Focus();
                    return;
                }
            }
            // 2016/06/06 NguyenNT <<<
            try
            {
                //Kiểm tra các giá trị được nhập trên form
                if (ValidateData() == false) return;

                bool SaveOK = true;
                string StringQuery = (this._OperationMode == "ADD") ? "SP_CrmCampaign_Insert" : "SP_CrmCampaign_Update";
                object[] Params = { 
                                "@Id", _CampaignId,
                                "@Name", this.txtCampaignName.Text.Trim(),
                                "@PaternCode", this.cboCampaignPatern.SelectedValue.ToString(),
                                "@IsContinuous", this.chkPeriodicalCampaign.Checked,
                                "@StartOnUtc", this.dtpStartDate.Value,
                                "@EndOnUtc", this.dtpEndDate.Value,
                                "@ParameterCount", this.txtParameterCount.Text,
                                "@ParamValue1", this.txtParamValue1.Text.Trim(),
                                "@ParamValue2", this.txtParamValue2.Text.Trim(),
                                "@ParamValue3", this.txtParamValue3.Text.Trim(),
                                "@ParamValue4", this.txtParamValue4.Text.Trim(),
                                "@ParamValue5", this.txtParamValue5.Text.Trim(),
                                "@Closed", this.chkClosed.Checked,
                                "@UserName", CinemaCRM.Contanst.Contanst.UserName,
                };

                if (this._OperationMode == "ADD")
                {
                    _CampaignId = CrmDBConnect.RunQueryReturnID(StringQuery, Params);
                    _OperationMode = "UPDATE";
                }
                else
                    SaveOK = SaveOK & CrmDBConnect.RunQuery(StringQuery, Params);

                if (SaveOK && _CampaignId > 0)
                    MessageBox.Show("Ghi dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Ghi dữ liệu bị lỗi. Hãy liên hệ với quản trị hệ thống để xử lý", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ghi dữ liệu bị lỗi. Hãy liên hệ với quản trị hệ thống để xử lý" + "\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_CampaignId <= 0)
            {
                MessageBox.Show("Bạn phải chọn một chương trình khuyến mại để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá chương trình khuyến mại này không?", "Cảnh báo xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            //Thực hiện xoá và thông báo sau khi xoá, hiển thị lại danh sách chương trình
            try
            {
                CrmDBConnect.RunQuery("SP_CrmCampaign_Delete", "@Id", _CampaignId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                MessageBox.Show("Xoá mẫu chương trình khuyến mại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClose.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá chương trình khuyến mại  bị lỗi. Hãy liên hệ với quản trị hệ thống để xử lý" + "\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void dgrFilmApplied_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void dgrFilmApplied_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_IsFilmAppliedLoaded)
            {
                _FilmAppliedId = System.Convert.ToInt32(dgrFilmApplied.CurrentRow.Cells["colFilmId"].Value);
            }
        }

        private void btnApplyFilm_Click(object sender, EventArgs e)
        {
            if (_CampaignId <= 0)
            {
                MessageBox.Show("Bạn chưa chọn chương trình khuyến mại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (int idx in lstFilmList.SelectedIndices)
            {
                DataRowView dr = (DataRowView)lstFilmList.Items[idx];
                int FilmId = System.Convert.ToInt32(dr["Id"]);
                CrmDBConnect.RunQuery("SP_CrmCampaign_ApplyFilm", "@Id", _CampaignId, "@FilmId", FilmId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
            }

            this.LoadFilmApplied(_CampaignId);
            this.LoadFilmList(_CampaignId);
        }

        private void btnRemoveFilmApplied_Click(object sender, EventArgs e)
        {
            if (_FilmAppliedId > 0)
            {
                CrmDBConnect.RunQuery("SP_CrmCampaign_RemoveFilm", "@Id", _CampaignId, "@FilmId", _FilmAppliedId);
                this.LoadFilmApplied(_CampaignId);
                this.LoadFilmList(_CampaignId);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phim để xoá khỏi danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFilmClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void grdGiftApplied_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void grdGiftApplied_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_IsGiftAppliedLoaded)
            {
                _GiftAppliedId = System.Convert.ToInt32(grdGiftApplied.CurrentRow.Cells["colGiftAppliedId"].Value);
            }
        }

        private void cboGiftProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsGiftLoaded == true)
            {
                _GiftId = System.Convert.ToInt32(cboGiftProduct.SelectedValue);
                if (_GiftId > 0)
                {
                    //Hiển thị thông tin chi tiết sản phẩm
                    DataTable tblCampaignGift = dbconnect.myTable("SP_CrmGiftProduct_GetOne", "@CampaignId", _CampaignId, "@GiftProductId", _GiftId);
                    if (tblCampaignGift.Rows.Count > 0)
                    {
                        txtGiftPrice.Text = tblCampaignGift.Rows[0]["GiftPrice"].ToString();
                        txtGiftPoint.Text = tblCampaignGift.Rows[0]["GiftPoint"].ToString();
                        txtTotalQuantity.Text = tblCampaignGift.Rows[0]["TotalQuantity"].ToString();
                        txtRemainQuantity.Text = tblCampaignGift.Rows[0]["RemainQuantity"].ToString();
                    }
                }
                else
                {
                    txtGiftPrice.Text = "";
                    txtGiftPoint.Text = "";
                    txtTotalQuantity.Text = "";
                    txtRemainQuantity.Text = "";
                }
            }
        }

        private void btnApplyGift_Click(object sender, EventArgs e)
        {
            if (_GiftId > 0)
            {
                string StringQuery = "SP_CrmCampaign_ApplyGift";
                object[] Params = { 
                                    "@CampaignId", _CampaignId,
                                    "@GiftProductId", _GiftId,
                                    "@GiftPrice", (txtGiftPrice.Text.Trim()=="")?"0":txtGiftPrice.Text.Trim(),
                                    "@GiftPoint", (txtGiftPoint.Text.Trim()=="")?"0":txtGiftPoint.Text.Trim(),
                                    "@TotalQuantity", (txtTotalQuantity.Text.Trim()=="")?"0":txtTotalQuantity.Text.Trim(),
                                    "@RemainQuantity", (txtRemainQuantity.Text.Trim()=="")?"0":txtRemainQuantity.Text.Trim(),
                                    "@UserName", CinemaCRM.Contanst.Contanst.UserName,
                    };

                CrmDBConnect.RunQuery(StringQuery, Params);
                this.LoadGiftApplied(_CampaignId);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để thêm vào danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnRemoveGiftApplied_Click(object sender, EventArgs e)
        {
            if (_GiftAppliedId > 0)
            {
                CrmDBConnect.RunQuery("SP_CrmCampaign_RemoveGift", "@CampaignId", _CampaignId, "@GiftProductId", _GiftAppliedId);
                this.LoadGiftApplied(_CampaignId);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để xoá khỏi danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGiftClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void cboEmailTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsEmailTemplateLoaded == true)
            {
                _EmailTemplateId = System.Convert.ToInt32(cboEmailTemplate.SelectedValue);
                if (_EmailTemplateId > 0)
                {
                    var tblEmailTemplate = new CrmDBConnect().myTable("SP_CrmTemplateEmail_CRUD", "@Id", _EmailTemplateId, "@flag", 4);
                    if (tblEmailTemplate.Rows.Count > 0)
                    {
                        txtEmailTemplateCode.Text = tblEmailTemplate.Rows[0]["TemplateCode"].ToString();
                        txtEmailSubject.Text = tblEmailTemplate.Rows[0]["TemplateTitle"].ToString();
                        txtEmailContent.BodyText = tblEmailTemplate.Rows[0]["Description"].ToString();
                    }
                }
            }
        }

        private void btnApplyEmailTemplate_Click(object sender, EventArgs e)
        {
            if (_EmailTemplateId > 0)
            {
                CrmDBConnect.RunQuery("SP_CrmCampaign_ApplyEmailTemplate", "@Id", _CampaignId, "@EmailTemplateId", _EmailTemplateId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                MessageBox.Show("Đã cập nhật mẫu E-mail cho chương trình khuyến mại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSmsCustomer(_CampaignId, _EmailTemplateId);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mẫu E-mail.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEmailTemplateClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void grdEmailCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void grdEmailCustomer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_IsEmailCustomerLoaded)
            {
                _EmailCustomerId = System.Convert.ToInt32(grdEmailCustomer.CurrentRow.Cells["colEmailCustomerId"].Value);
            }
        }

        private void btnAddEmailCustomer_Click(object sender, EventArgs e)
        {
            customer.frmSearchCustomer frmSearchCustomer = new customer.frmSearchCustomer();
            frmSearchCustomer.ShowDialog();

            if (frmSearchCustomer.IsAddedToSendEmail)
            {
                DataTable tblCustomers = frmSearchCustomer.CustomerList;
                for (int i = 0; i < tblCustomers.Rows.Count; i++)
                {
                    int CustomerId = System.Convert.ToInt32(tblCustomers.Rows[i]["Id"]);
                    CrmDBConnect.RunQuery("SP_CrmCampaignEmailCustomer_Insert", "@CampaignId", _CampaignId, "@CustomerId", CustomerId, "@EmailTemplateId", _EmailTemplateId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                }
                this.LoadEmailCustomer(_CampaignId, _EmailTemplateId);
            }
        }

        private void btnRemoveEmailCustomer_Click(object sender, EventArgs e)
        {
            if (_IsEmailCustomerLoaded)
            {
                if (MessageBox.Show("Bạn có chắc chắn xoá khỏi danh sách nhận e-mail các khách hàng đang chọn hay không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                for (int i = 0; i < grdEmailCustomer.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdEmailCustomer.Rows[i].Cells["colEmailCustomerCheck"].Value) == true)
                    {
                        int CheckedCustomerId = System.Convert.ToInt32(grdEmailCustomer.Rows[i].Cells["colEmailCustomerId"].Value);
                        CrmDBConnect.RunQuery("SP_CrmCampaignEmailCustomer_Delete", "@CampaignId", _CampaignId, "@CustomerId", CheckedCustomerId, "@EmailTemplateId", _EmailTemplateId);
                    }
                }
                this.LoadEmailCustomer(_CampaignId, _EmailTemplateId);
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            //Cập nhật cờ thực hiện gửi mail cho danh sách khách hàng
            CrmDBConnect.RunQuery("SP_CrmCampaignEmailCustomer_UpdateStatus", "@CampaignId", _CampaignId, "@EmailTemplateId", _EmailTemplateId, "@OldStatus", 0, "@NewStatus", 1, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
            this.LoadEmailCustomer(_CampaignId, _EmailTemplateId);
            MessageBox.Show("Đã bắt đầu thực hiện gửi email cho danh sách khách hàng trên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEmailCustomerClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void cboSmsTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsSmsTemplateLoaded == true)
            {
                _SmsTemplateId = System.Convert.ToInt32(cboSmsTemplate.SelectedValue);
                if (_SmsTemplateId > 0)
                {
                    var tblSmsTemplate = new CrmDBConnect().myTable("SP_CrmTemplateSMS_CRUD", "@Id", _SmsTemplateId, "@flag", 4);
                    if (tblSmsTemplate.Rows.Count > 0)
                    {
                        txtSmsTemplateCode.Text = tblSmsTemplate.Rows[0]["TemplateCode"].ToString();
                        txtSmsContent.Text = tblSmsTemplate.Rows[0]["Description"].ToString();
                    }
                }
            }
        }

        private void grdSmsCustomer_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void grdSmsCustomer_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_IsSmsCustomerLoaded)
            {
                _SmsCustomerId = System.Convert.ToInt32(grdSmsCustomer.CurrentRow.Cells["colSmsCustomerId"].Value);
            }
        }

        private void btnApplySmsTemplate_Click(object sender, EventArgs e)
        {
            if (_SmsTemplateId > 0)
            {
                CrmDBConnect.RunQuery("SP_CrmCampaign_ApplySmsTemplate", "@Id", _CampaignId, "@SmsTemplateId", _SmsTemplateId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                MessageBox.Show("Đã cập nhật mẫu gửi SMS cho chương trình khuyến mại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSmsCustomer(_CampaignId, _SmsTemplateId);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn mẫu SMS để sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddSmsCustomer_Click(object sender, EventArgs e)
        {
            customer.frmSearchCustomer frmSearchCustomer = new customer.frmSearchCustomer();
            frmSearchCustomer.ShowDialog();

            if (frmSearchCustomer.IsAddedToSendSms)
            {
                DataTable tblCustomers = frmSearchCustomer.CustomerList;
                for (int i = 0; i < tblCustomers.Rows.Count; i++)
                {
                    // 2016/06/06 NguyenNT Fix loi khach hang khong co sdt cung hien thi len >>>
                    if (Convert.ToString(tblCustomers.Rows[i]["Mobile"]) != "") {
                        int CustomerId = System.Convert.ToInt32(tblCustomers.Rows[i]["Id"]);
                        CrmDBConnect.RunQuery("SP_CrmCampaignSmsCustomer_Insert", "@CampaignId", _CampaignId, "@CustomerId", CustomerId, "@SmsTemplateId", _SmsTemplateId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                    }
                    // 2016/06/06 NguyenNT <<<
                }
                this.LoadSmsCustomer(_CampaignId, _SmsTemplateId);
            }
        }

        private void btnRemoveSmsCustomer_Click(object sender, EventArgs e)
        {
            if (_IsSmsCustomerLoaded)
            {
                if (MessageBox.Show("Bạn có chắc chắn xoá khỏi danh sách nhận SMS các khách hàng đang chọn hay không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                for (int i = 0; i < grdSmsCustomer.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grdSmsCustomer.Rows[i].Cells["colSmsCustomerCheck"].Value) == true)
                    {
                        int CheckedCustomerId = System.Convert.ToInt32(grdSmsCustomer.Rows[i].Cells["colSmsCustomerId"].Value);
                        CrmDBConnect.RunQuery("SP_CrmCampaignSmsCustomer_Delete", "@CampaignId", _CampaignId, "@CustomerId", CheckedCustomerId, "@SmsTemplateId", _SmsTemplateId);
                    }
                }
                this.LoadSmsCustomer(_CampaignId, _SmsTemplateId);
            }
        }

        private void btnSendSms_Click(object sender, EventArgs e)
        {
            //Cập nhật cờ thực hiện gửi SMS cho danh sách khách hàng
            CrmDBConnect.RunQuery("SP_CrmCampaignSmsCustomer_UpdateStatus", "@CampaignId", _CampaignId, "@SmsTemplateId", _SmsTemplateId, "@OldStatus", 0, "@NewStatus", 1, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
            this.LoadSmsCustomer(_CampaignId, _SmsTemplateId);
            MessageBox.Show("Đã bắt đầu thực hiện gửi SMS cho danh sách khách hàng trên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSmsClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void grdEmailCustomer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (!_IsCheckBoxAllClicked && _IsLoadComplete)
            //    RowCheckBoxClick((DataGridViewCheckBoxCell)grdEmailCustomer[e.ColumnIndex, e.RowIndex]);


            //_isCheckAll = false;
            //if (e.ColumnIndex == colEmailCustomerCheck.Index && e.RowIndex != -1)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)grdEmailCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    if (chk.Value.ToString().Equals("true"))
            //    {

            //    }
            //    chkSelectAllEmailCustomer.CheckState = CheckState.Unchecked;

            //}
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            if (RCheckBox != null)
            {
                //Modify Counter;            
                //if ((bool)RCheckBox.Value && _TotalCheckedCheckBoxes.Equals(_TotalCheckBoxes))
                if (RCheckBox.Value.Equals(CheckState.Checked) && _TotalCheckedCheckBoxes < _TotalCheckBoxes)
                    _TotalCheckedCheckBoxes++;
                else if (_TotalCheckedCheckBoxes > 0)
                    _TotalCheckedCheckBoxes--;

                //Change state of the header CheckBox.
                if (_TotalCheckedCheckBoxes < _TotalCheckBoxes)
                {
                    chkSelectAllEmailCustomer.Checked = false;
                }
                else if (_TotalCheckedCheckBoxes == _TotalCheckBoxes)
                {
                    chkSelectAllEmailCustomer.Checked = true;
                }
            }
        }

        private void chkSelectAllEmailCustomer_Click(object sender, EventArgs e)
        {
            _IsLoadComplete = true;
            _IsCheckBoxAllClicked = true;

            foreach (DataGridViewRow Row in grdEmailCustomer.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["colEmailCustomerCheck"]).Value = chkSelectAllEmailCustomer.Checked;

            grdEmailCustomer.RefreshEdit();

            _TotalCheckedCheckBoxes = chkSelectAllEmailCustomer.Checked ? _TotalCheckBoxes : 0;
            _IsCheckBoxAllClicked = false;
        }

        private void grdEmailCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewCheckBoxCell cell;

                cell = (DataGridViewCheckBoxCell)grdEmailCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (grdEmailCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || grdEmailCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("false")
                    || grdEmailCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(CheckState.Unchecked) || grdEmailCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals(false))
                {
                    cell.Value = CheckState.Checked;
                    //grdEmailCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "true";

                    RowCheckBoxClick(cell);
                }
                else
                {
                    cell.Value = CheckState.Unchecked;
                    RowCheckBoxClick(cell);


                    //grdEmailCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "false";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

        // 2016/06/06 NguyenNT Fix lỗi nhập được chữ >>>
        private void txtParamValue1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtParamValue2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtParamValue3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtParamValue4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtParamValue5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiftPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiftPoint_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtRemainQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
