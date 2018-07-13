using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.taks.customer;
using CinemaCRM.Core;
using PresentationControls;
using System.Text.RegularExpressions;
namespace CinemaCRM.taks.careCustomer
{
    public partial class frmDetailsMember : Form
    {
        private int _CustomerId;
        private int _id;
        private DataSet _dataSet;
        private string memberCard = "";

        public void setCustomerId(int customerId)
        {
            this._CustomerId = customerId;
        }

        #region Thông tin chi tiết
        private void butCustomerActive_Click(object sender, EventArgs e)
        {
            if (_CustomerId <= 0) return;
            if (
                MessageBox.Show(@"Kích hoạt tài khoản này bằng phần mềm?", @"Chú ý!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;

            CrmDBConnect.RunQuery("SP_CrmCustomer_Update", "@Id", _CustomerId, "@flag", 1);
            MessageBox.Show(@"Cập nhật thông tin khách hàng thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // load data
        private void LoadData()
        {
            var tblCustomer = new CrmDBConnect().myTable("SP_CrmCustomer_GetOne", "@Id", _CustomerId);

            if (tblCustomer.Rows.Count > 0)
            {
                txtFirstName.Text = tblCustomer.Rows[0]["CustomerFirstName"].ToString();
                txtLastName.Text = tblCustomer.Rows[0]["CustomerLastName"].ToString();
                txtPhone.Text = tblCustomer.Rows[0]["Mobile"].ToString();
                txtEmail.Text = tblCustomer.Rows[0]["Email"].ToString();
                txtAddress.Text = tblCustomer.Rows[0]["Address"].ToString();

                if (!String.IsNullOrEmpty(tblCustomer.Rows[0]["Birthday"].ToString()))
                {
                    dtBirthDay.Value = (DateTime)tblCustomer.Rows[0]["Birthday"];
                }

                if (!String.IsNullOrEmpty(tblCustomer.Rows[0]["Job_Id"].ToString()))
                {
                    cbCustomerJobs.SelectedValue = (int)tblCustomer.Rows[0]["Job_Id"];
                }

                if (!String.IsNullOrEmpty(tblCustomer.Rows[0]["Birthday"].ToString()))
                {
                    var sex = Convert.ToInt32(tblCustomer.Rows[0]["Sex"]);

                    if (sex == 1)
                    {
                        rdoSexMale.Checked = true;
                        rdoSexFemale.Checked = false;
                    }
                    else
                    {
                        rdoSexMale.Checked = false;
                        rdoSexFemale.Checked = true;
                    }
                }

                if (!String.IsNullOrEmpty(tblCustomer.Rows[0]["Marriage"].ToString()))
                {
                    var marriage = Convert.ToInt32(tblCustomer.Rows[0]["Marriage"]);
                    if (marriage == 1)
                    {
                        rdoMarried.Checked = true;
                        rdoSingle.Checked = false;
                    }
                    else
                    {
                        rdoMarried.Checked = false;
                        rdoSingle.Checked = true;
                    }
                }
                memberCard = tblCustomer.Rows[0]["CardCode"].ToString();
                txtCardCode.Text = memberCard;
                txtPointReword.Text = tblCustomer.Rows[0]["PointReward"].ToString();
                txtPoinCard.Text = tblCustomer.Rows[0]["PointCard"].ToString();
                txtPosition.Text = tblCustomer.Rows[0]["Position"].ToString();

                // So thich
                string strFavour = "";
                var tblFavour = new CrmDBConnect().myTable("SP_CrmCustomer_GetFavours", "@Ids", tblCustomer.Rows[0]["Favour"].ToString());

                //2016/06/08 ThienNQ( Updated) 
                List<string> lstIdType = new List<string>();

                if (tblFavour.Rows.Count > 0 && tblFavour != null)
                {
                    foreach (DataRow row in tblFavour.Rows)
                    {
                        lstIdType.Add(row[0].ToString());

                        if (!string.IsNullOrWhiteSpace(strFavour)) strFavour += ", ";
                        strFavour += row["Name"].ToString();
                    }
                }
                txtFavour.Text = strFavour;

                //2016/06/08 ThienNQ( Added) Load data check box cbcType
                if (lstIdType.Count() != 0)
                {
                    foreach (var chkItem in cbcFavorites.CheckBoxItems)
                    {
                        string nameChk = ((ObjectSelectionWrapper<DataRow>)(chkItem.ComboBoxItem)).Item.ItemArray[0].ToString();
                        if (lstIdType.Exists(x => x == nameChk))
                        {
                            chkItem.Checked = true;
                        }
                    }
                }

                chkCard.Checked = (tblCustomer.Rows[0]["CardIssued"].ToString() == "") ? false : (Boolean)tblCustomer.Rows[0]["CardIssued"];
                dtAccpetedCardDate.Value = !String.IsNullOrEmpty(tblCustomer.Rows[0]["DateCreateCard"].ToString()) ? DateTime.Parse(tblCustomer.Rows[0]["DateCreateCard"].ToString()) : DateTime.Now;
                dtExpireCardDate.Value = !String.IsNullOrEmpty(tblCustomer.Rows[0]["DateExpireCard"].ToString()) ? DateTime.Parse(tblCustomer.Rows[0]["DateExpireCard"].ToString()) : DateTime.Now;
                if (!String.IsNullOrEmpty(tblCustomer.Rows[0]["CurrentCardId"].ToString()))
                {
                    cbCardLevel.SelectedValue = (int)tblCustomer.Rows[0]["CurrentCardId"];
                }
                txtAddress.Text = tblCustomer.Rows[0]["Address"].ToString();
                var distinctId = Convert.ToInt32(tblCustomer.Rows[0].IsNull("District_Id") ? "0" : tblCustomer.Rows[0]["District_Id"].ToString());
                var cityId = Convert.ToInt32(tblCustomer.Rows[0].IsNull("City_Id") ? "0" : tblCustomer.Rows[0]["City_Id"].ToString());
                var countryId = !String.IsNullOrEmpty(tblCustomer.Rows[0]["Country_Id"].ToString()) ? Convert.ToInt32(tblCustomer.Rows[0]["Country_Id"] == null ? "0" : tblCustomer.Rows[0]["Country_Id"].ToString()) : 230;

                if (countryId > 0)
                {
                    cbCountry.SelectedValue = countryId;
                }

                if (cityId > 0)
                {
                    cbCities.SelectedValue = cityId;
                }

                if (distinctId > 0)
                {
                    cbDistrict.SelectedValue = distinctId;
                }
            }

        }
        /// <summary>
        /// Load job for combox
        /// </summary>
        private void LoadJob()
        {
            var tblCrmCustomer = new CrmDBConnect().myTable("SP_CrmJob_CRUD");
            DataRow rowNothing = tblCrmCustomer.NewRow();
            rowNothing["JobName"] = "--Chọn nghề nghiệp--";
            rowNothing["Id"] = "0";
            tblCrmCustomer.Rows.InsertAt(rowNothing, 0);

            var binSource = new BindingSource { DataSource = tblCrmCustomer };
            cbCustomerJobs.DataSource = binSource;
            cbCustomerJobs.DisplayMember = "JobName";
            cbCustomerJobs.ValueMember = "Id";
        }

        private void LoadCardLevel()
        {

            var tblCrmCustomer = new CrmDBConnect().myTable("SP_CrmCardLevel_CRUD", "@flag", 1);
            var binSource = new BindingSource { DataSource = tblCrmCustomer };
            cbCardLevel.DataSource = binSource;
            cbCardLevel.DisplayMember = "CardLevelName";
            cbCardLevel.ValueMember = "Id";
        }
        /// <summary>
        /// Load country for combox
        /// </summary>
        private void LoadCountry()
        {
            var tbl = new CrmDBConnect().myTable("SP_CrmCountry_GetAll");

            //2016/06/27 ThienNQ( Edited) Add thêm Items nothing.
            DataRow rowNothing = tbl.NewRow();
            rowNothing["Name"] = "--Chọn quốc gia--";
            rowNothing["Id"] = "0";
            tbl.Rows.InsertAt(rowNothing, 0);

            var binSource = new BindingSource { DataSource = tbl };
            cbCountry.DataSource = binSource;
            cbCountry.DisplayMember = "Name";
            cbCountry.ValueMember = "Id";
        }

        /// <summary>
        /// Load city by define defenitly country Id
        /// </summary>
        /// <param name="countryId"></param>
        private void LoadCityByCountryId(int countryId)
        {
            var tbl = new CrmDBConnect().myTable("SP_CrmStateProvince_GetByCountry", "@CountryId", countryId);
            DataRow rowNothing = tbl.NewRow();
            rowNothing["Name"] = "--Chọn thành phố--";
            rowNothing["Id"] = "0";
            tbl.Rows.InsertAt(rowNothing, 0);

            var binSource = new BindingSource { DataSource = tbl };
            cbCities.DataSource = binSource;
            cbCities.DisplayMember = "Name";
            cbCities.ValueMember = "Id";
        }

        /// <summary>
        /// Load distric by define defenitly city Id
        /// </summary>
        /// <param name="cityId"></param>
        private void LoadDistrictByCityId(int cityId)
        {
            var tbl = new CrmDBConnect().myTable("SP_CrmDistrict_GetByCity", "@CityId", cityId);
            DataRow rowNothing = tbl.NewRow();
            rowNothing["Name"] = "--Chọn quận huyện--";
            rowNothing["Id"] = "0";
            tbl.Rows.InsertAt(rowNothing, 0);

            var binSource = new BindingSource { DataSource = tbl };
            cbDistrict.DataSource = binSource;
            cbDistrict.DisplayMember = "Name";
            cbDistrict.ValueMember = "Id";
        }

        public frmDetailsMember()
        {
            InitializeComponent();
        }

        private void frmDetailsMember_Load(object sender, EventArgs e)
        {
            this.LoadJob();
            this.LoadCountry();
            this.LoadCardLevel();
            this.LoadFavourite(cbcFavorites);
            this.LoadCustomerPointHistory(_CustomerId);
            this.LoadCustomerCardHistory(_CustomerId);
            this.LoadData();
        }

        private void LoadFavourite(params CheckBoxComboBox[] checkBoxComboBoxes)
        {
            //_dataSet = new DBConnect().myDataset("SP_CrmCustomer_AnalyzeAdvance", "@flag", 0);
            //var i = 0;

            //foreach (var checkBoxComboBox in checkBoxComboBoxes)
            //{
            //    var text = checkBoxComboBox.Text;
            //    checkBoxComboBox.Items.Clear();
            //    checkBoxComboBox.DataSource = new ListSelectionWrapper<DataRow>(_dataSet.Tables[5].Rows, "Text");
            //    checkBoxComboBox.DisplayMemberSingleItem = "Name";
            //    checkBoxComboBox.DisplayMember = "NameConcatenated";
            //    checkBoxComboBox.ValueMember = "Selected";
            //    checkBoxComboBox.Text = text;
            //    i++;
            //}
        }

        private CheckBoxComboBox __getCbc(string value)
        {
            switch (value)
            {
                case "6":
                    return cbcFavorites;
                default:
                    return null;
            }
        }

        // lấy về các giá trị thù combox sở thích
        private string __getCheckedItems(CheckBoxComboBox checkBoxComboBox)
        {
            return String.Join(",", checkBoxComboBox.CheckBoxItems.
                Where(c => c.Checked).
                Select(c => ((ObjectSelectionWrapper<DataRow>)(c.ComboBoxItem)).Item.ItemArray[0]));
        }
        #endregion

        #region CustomerPoint
        /// <summary>
        /// Load customer point and search codition
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        private void LoadCustomerPointHistory(int CustomerId)
        {
            var tblCustomerPointHistory = new CrmDBConnect().myTable("SP_CrmCustomer_GetPointHistory", "@CustomerId", CustomerId);
            grdCustomerPoint.AutoGenerateColumns = false;
            grdCustomerPoint.DataSource = tblCustomerPointHistory;
        }

        private void grdCustomerPoint_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
        #endregion

        #region CardLevel
        private void LoadCustomerCardHistory(int customerId)
        {
            var tblHistoryCard = new CrmDBConnect().myTable("SP_CrmCustomerCardLevel_GetCards", "@CustomerId", customerId);
            grdCustomerCardList.AutoGenerateColumns = false;
            grdCustomerCardList.DataSource = tblHistoryCard;
        }

        private void LoadCardLevel_Dynamic(ComboBox cbCardLevel)
        {
            var tblCrmCustomer = new CrmDBConnect().myTable("SP_CrmCardLevel_CRUD", "@flag", 1);
            var binSource = new BindingSource { DataSource = tblCrmCustomer };

            cbCardLevel.DataSource = binSource;
            cbCardLevel.DisplayMember = "CardLevelName";
            cbCardLevel.ValueMember = "Id";
        }

        private void grdCustomerCardList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (grdCustomerCardList.CurrentRow == null) return;
            _id = Convert.ToInt32(grdCustomerCardList.CurrentRow.Cells["Id_New"].Value);
        }
        #endregion

        // valid text number
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

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            var fName = txtFirstName.Text.Trim();
            var lName = txtLastName.Text.Trim();
            var phone = txtPhone.Text.Trim();
            var email = txtEmail.Text.Trim();
            var address = txtAddress.Text;
            var birtday = dtBirthDay.Value;
            var jobId = Convert.ToInt32(cbCustomerJobs.SelectedValue);

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Trường email không để trống", "Thông báo");
                return;
            }

            Match match = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(txtEmail.Text);
            if (!match.Success)
            {
                MessageBox.Show("Email không đúng định dạng, vui lòng kiểm tra lại", "Thông báo");
                return;
            }

            var sex = true;
            if (rdoSexMale.Checked)
            {
                sex = true;
            }
            else
            {
                sex = false;
            }
            var marriage = true;
            if (rdoMarried.Checked)
            {
                marriage = true;
            }
            else
            {
                marriage = false;
            }

            // check huy the
            var isCard = false;
            if (chkCard.Checked == true) isCard = true;

            var carCode = txtCardCode.Text.Trim();

            // 2017/02/18 NguyenNT: Check card >>>
            carCode.Replace("%", "").Replace("?", "");
            if (carCode != "")
            {
                if (carCode != memberCard)
                {
                    if (new CrmDBConnect().isExist("SP_CrmCustomer_CheckCardCode", "@CardCode", carCode))
                    {
                        MessageBox.Show("Mã thẻ đã tồn tại!", "Thông báo");
                        return;
                    }
                }
            }
            // 2017/02/18 NguyenNT: Check card <<<

            var districtId = Convert.ToInt32(cbDistrict.SelectedValue);
            var cityId = Convert.ToInt32(cbCities.SelectedValue);
            var countryId = Convert.ToInt32(cbCountry.SelectedValue);
            var cardLevelid = Convert.ToInt32(cbCardLevel.SelectedValue);
            var position = txtPosition.Text;
            var pointReward = string.IsNullOrWhiteSpace(txtPointReword.Text) ? 0 : Convert.ToDecimal(txtPointReword.Text);
            var pointCard = string.IsNullOrWhiteSpace(txtPoinCard.Text) ? 0 : Convert.ToDecimal(txtPoinCard.Text);
            var Favour = txtFavour.Text.Trim();
            var datecreatecard = dtAccpetedCardDate.Value;
            var dateexpirecard = dtExpireCardDate.Value;

            CrmDBConnect.RunQuery("SP_CrmCustomer_Update", "@Id", _CustomerId
                        , "@CustomerLastName", lName, "@CustomerFirstName", fName, "@Email", email, "@Mobile", phone, "@Sex", sex, "@Marriage", marriage, "@BirthDay", birtday, "@Job_Id", jobId, "@Address", address, "@DistrictId", districtId, "@CityId", cityId, "@Country_Id", countryId, "@Postion", position, "@CardCode", carCode, "@PointReward ", pointReward,
             "@PointCard", pointCard, "@CardLevelName", cbCardLevel.Text, "@CurrentCardId", cardLevelid, "@Favour", __getCheckedItems(cbcFavorites), "@DateCreateCard", datecreatecard, "@DateExpireCard", dateexpirecard, "@CardIssued", isCard, "@flag", 2);

            MessageBox.Show("Cập nhật thành công", "Thông báo");
            this.Close();
        }

        // 2016/04/14 - NguyenNT >>>
        //private void cbCardLevel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var cardId = Convert.ToInt32(cbCardLevel.SelectedValue);
        //        DataTable tbl = new DBConnect().myTable("SP_CrmCardLevel_CRUD", "@Id", cardId, "@flag", 2);
        //        if (tbl.Rows.Count > 0)
        //        {
        //            //String.Format("{0:0.##}", 123.4567);
        //            txtPointReword.Text = String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["MinPointCard"]));
        //            lbPoint.Text = cbCardLevel.Text + " Có điểm từ " + String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["MinPointCard"]).ToString()) + " đến " + String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["NeededPointCard"]).ToString()) + " .";

        //            //String.Format("{0:0.##}", 123.4567);
        //            txtPoinCard.Text = String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["BuyTicketPointReward"]));
        //            lbPointCard.Text = "Điểm tích lũy nhận được " + String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["BuyTicketPointReward"]).ToString()) + " .";
        //        }
        //    }
        //    catch { }
        //}
        // 2016/04/14 - NguyenNT <<<

        private void cbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var countryId = Convert.ToInt32(cbCountry.SelectedValue);
                this.LoadCityByCountryId(countryId);
            }
            catch { }
        }

        private void cbCities_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var CityId = Convert.ToInt32(cbCities.SelectedValue);
                this.LoadDistrictByCityId(CityId);
            }
            catch { }
        }

        //2016/06/08 ThienNQ( Added) ReLoad text  when checkedChaged
        private void cbcType_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            txtFavour.Text = String.Join(", ", cbcFavorites.CheckBoxItems.Where(c => c.Checked).Select(c => ((ObjectSelectionWrapper<DataRow>)(c.ComboBoxItem)).Item.ItemArray[1]));
        }

        private void TextBoxInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only input numeric
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }

        private void TextBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))) e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private void txtCardCode_TextChanged(object sender, EventArgs e)
        {
            txtCardCode.Text.Replace("E", "");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
