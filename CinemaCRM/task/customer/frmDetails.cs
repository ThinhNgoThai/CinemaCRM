using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.Core;
using PresentationControls;
using System.Text.RegularExpressions;

namespace CinemaCRM.taks.customer
{
    public partial class frmDetails : Form
    {

        private int customerId;
        private DataSet _dataSet;
        private string memberCard = "";

        public void setCustomerId(int customerId)
        {
            this.customerId = customerId;
        }
        public frmDetails()
        {
            InitializeComponent();
        }

        #region FirstLoadTab
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        /// <summary>
        /// Load fist tab of data
        /// </summary>
        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            var fName = txtFirstName.Text.Trim();
            var lName = txtLastName.Text.Trim();
            var phone = txtPhone.Text.Trim();
            var email = txtEmail.Text.Trim();
            var address = txtAddress.Text;
            var birtday = dtBirthDay.Value;
            var jobId = Convert.ToInt32(cbCustomerJobs.SelectedValue);
            var sex = rdoSexMale.Checked;
            var marriage = rdoMarried.Checked;
            var isCard = false;
            if (chkCard.Checked == true) isCard = true;
            var carCode = txtCardCode.Text.Trim();
            var districtId = Convert.ToInt32(cbDistrict.SelectedValue);
            var cityId = Convert.ToInt32(cbCities.SelectedValue);
            var countryId = Convert.ToInt32(cbCountry.SelectedValue);
            var cardLevelid = Convert.ToInt32(cbCardLevel.SelectedValue);
            var position = txtPosition.Text;
            var pointReward = String.IsNullOrEmpty(txtPointReward.Text.Trim()) ? 0 : Convert.ToDecimal(txtPointReward.Text.Trim());
            var pointCard = String.IsNullOrEmpty(txtPointCard.Text.Trim()) ? 0 : Convert.ToDecimal(txtPointCard.Text.Trim());
            var Favour = __getCheckedItems(cbcType);
            var datecreatecard = dtAccpetedCardDate.Value;
            var dateexpirecard = dtExpireCardDate.Value;

            Match match = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(email);
            if (!match.Success)
            {
                MessageBox.Show("Email không đúng định dạng, vui lòng kiểm tra lại", "Thông báo");
                return;
            }

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

            CrmDBConnect.RunQuery("SP_CrmCustomer_Update", "@Id", customerId
                         , "@CustomerLastName", lName, "@CustomerFirstName", fName, "@Email", email, "@Mobile", phone, "@Sex", sex, "@Marriage", marriage, "@BirthDay", birtday, "@Job_Id", jobId, "@Address", address, "@DistrictId", districtId, "@CityId", cityId, "@Country_Id", countryId, "@Postion", position, "@CardCode", carCode, "@PointReward", pointReward,
              "@PointCard", pointCard, "@CardLevelName", cbCardLevel.Text, "@CurrentCardId", cardLevelid, "@Favour", Favour, "@DateCreateCard", datecreatecard, "@DateExpireCard", dateexpirecard, "@CardIssued", isCard, "@flag", 2);
            MessageBox.Show("Cập nhật thành công", "Thông báo");
            this.Close();
            // __getCheckedItems(cbcType)

        }

        private void butCustomerActive_Click(object sender, EventArgs e)
        {
            if (customerId <= 0) return;
            if (
                MessageBox.Show(@"Kích hoạt tài khoản này bằng phần mềm?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmCustomer_Update", "@Id", customerId, "@flag", 1);
            MessageBox.Show(@"Cập nhật  thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // load data
        private void LoadData()
        {
            var tblCustomer = new CrmDBConnect().myTable("SP_CrmCustomer_GetOne", "@Id", customerId);

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
                if (!String.IsNullOrEmpty(tblCustomer.Rows[0]["Sex"].ToString()))
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
                txtPointReward.Text = tblCustomer.Rows[0]["PointReward"].ToString();
                txtPointCard.Text = tblCustomer.Rows[0]["PointCard"].ToString();
                txtPosition.Text = tblCustomer.Rows[0]["Position"].ToString();

                string strFavour = "";
                var tblFavour = new CrmDBConnect().myTable("SP_CrmCustomer_GetFavours", "@Ids", tblCustomer.Rows[0]["Favour"].ToString());
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

                if (lstIdType.Count() != 0)
                {
                    foreach (var chkItem in cbcType.CheckBoxItems)
                    {
                        string nameChk = ((ObjectSelectionWrapper<DataRow>)(chkItem.ComboBoxItem)).Item.ItemArray[0].ToString();
                        if (lstIdType.Exists(x => x == nameChk))
                        {
                            chkItem.Checked = true;
                        }
                    }
                }

                chkCard.Checked = (tblCustomer.Rows[0]["CardIssued"].ToString() == "") ? false : (Boolean)tblCustomer.Rows[0]["CardIssued"];
                try
                {
                    dtAccpetedCardDate.Value = !String.IsNullOrEmpty(tblCustomer.Rows[0]["DateCreateCard"].ToString()) ? DateTime.Parse(tblCustomer.Rows[0]["DateCreateCard"].ToString()) : DateTime.Now;
                    dtExpireCardDate.Value = !String.IsNullOrEmpty(tblCustomer.Rows[0]["DateExpireCard"].ToString()) ? DateTime.Parse(tblCustomer.Rows[0]["DateExpireCard"].ToString()) : DateTime.Now;
                    cbCardLevel.SelectedValue = (int)tblCustomer.Rows[0]["CurrentCardId"];
                }
                catch { }

                txtAddress.Text = tblCustomer.Rows[0]["Address"].ToString();
                var cityId = Convert.ToInt32(tblCustomer.Rows[0].IsNull("City_Id") ? "0" : tblCustomer.Rows[0]["City_Id"].ToString());
                var countryId = !String.IsNullOrEmpty(tblCustomer.Rows[0]["Country_Id"].ToString()) ? Convert.ToInt32(tblCustomer.Rows[0]["Country_Id"] == null ? "0" : tblCustomer.Rows[0]["Country_Id"].ToString()) : 230;
                var districtId = Convert.ToInt32(tblCustomer.Rows[0].IsNull("District_Id") ? "0" : tblCustomer.Rows[0]["District_Id"].ToString());

                if (countryId > 0)
                {
                    if (cbCountry.SelectedValue != null)
                    {
                        if (int.Parse(cbCountry.SelectedValue.ToString()) != countryId)
                        {
                            cbCountry.SelectedValue = countryId;
                            cbCities.SelectedValue = cityId;
                            cbDistrict.SelectedValue = districtId;
                        }
                        else
                        {
                            if (cbCities.SelectedValue != null)
                            {
                                if (int.Parse(cbCities.SelectedValue.ToString()) != cityId)
                                {
                                    cbCities.SelectedValue = cityId;
                                    cbDistrict.SelectedValue = districtId;
                                }
                                else
                                {
                                    if (cbDistrict.SelectedValue != null)
                                    {
                                        cbDistrict.SelectedValue = districtId;
                                    }
                                    else
                                    {
                                        cbDistrict.DataSource = null;
                                    }
                                }
                            }
                            else
                            {
                                cbCities.DataSource = null;
                                cbDistrict.DataSource = null;
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Load job for combox
        /// </summary>
        private void LoadJob()
        {

            var tblCrmCustomer = new CrmDBConnect().myTable("SP_CrmJob_CRUD");
            var binSource = new BindingSource { DataSource = tblCrmCustomer };

            cbCustomerJobs.DataSource = binSource;
            cbCustomerJobs.DisplayMember = "JobName";
            cbCustomerJobs.ValueMember = "Id";
        }
        /// <summary>
        /// Load country for combox
        /// </summary>
        private void LoadCountry()
        {
            var tbl = new CrmDBConnect().myTable("SP_CrmCountry_GetAll");
            if (tbl.Rows.Count > 0)
            {
                var binSource = new BindingSource { DataSource = tbl };
                cbCountry.DisplayMember = "Name";
                cbCountry.ValueMember = "Id";
                cbCountry.DataSource = binSource;
            }
            else
            {
                cbCountry.Text = "";
            }
        }
        /// <summary>
        /// Load city by define defenitly country Id
        /// </summary>
        /// <param name="countryId"></param>
        private void LoadCityByCountryId(int countryId)
        {

            var tbl = new CrmDBConnect().myTable("SP_CrmStateProvince_GetByCountry", "@CountryId", countryId);
            if (tbl.Rows.Count > 0)
            {
                var binSource = new BindingSource { DataSource = tbl };
                cbCities.DisplayMember = "Name";
                cbCities.ValueMember = "Id";
                cbCities.DataSource = binSource;
            }
            else
            {
                cbCities.DataSource = null;
                cbCities.Text = "";
                cbDistrict.Text = "";
            }
        }
        /// <summary>
        /// Event change country and the result change combox of city
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        // Load hạng thẻ
        private void LoadCardLevel()
        {
            var tblCard = new CrmDBConnect().myTable("SP_CrmCardLevel_CRUD", "@flag", 1);
            var binSource = new BindingSource { DataSource = tblCard };
            cbCardLevel.DataSource = binSource;
            cbCardLevel.DisplayMember = "CardLevelName";
            cbCardLevel.ValueMember = "Id";
        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            this.LoadJob();
            this.LoadCountry();
            this.LoadCardLevel();
            __loadData(cbcType);
            this.LoadData();
            this.LoadOrderHistory(customerId);
            enableCardInfo(false, false, false, false, false, false);
        }

        private void __loadData(params CheckBoxComboBox[] checkBoxComboBoxes)
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

        //2016/06/09 ThienNQ( Deleted) Không dùng
        //private CheckBoxComboBox __getCbc(string value)
        //{
        //    switch (value)
        //    {
        //        case "6":
        //            return cbcType;
        //        default:
        //            return null;
        //    }
        //}

        // lấy về các giá trị thù combox sở thích
        private string __getCheckedItems(CheckBoxComboBox checkBoxComboBox)
        {
            return String.Join(",", checkBoxComboBox.CheckBoxItems.
                Where(c => c.Checked).
                Select(c => ((ObjectSelectionWrapper<DataRow>)(c.ComboBoxItem)).Item.ItemArray[0]));
        }

        #endregion

        #region OnePayLoad
        /// <summary>
        /// Load onepay data ,attacking some search condition
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="onePayStatatus"></param>
        /// <param name="orderInforId"></param>
        /// <param name="vpcMerchTexnRef"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        private void LoadOrderHistory(int customerId)
        {
            var tblOrders = new TicketDBConnect().myTable("SP_Customer_GetOrders", "@CustomerId", customerId);
            grdOrderHistories.AutoGenerateColumns = false;
            grdOrderHistories.DataSource = tblOrders;
        }
        #endregion

        // select City by country
        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCountry.SelectedValue != null)
            {
                var selectedCountry = Convert.ToInt32(cbCountry.SelectedValue);
                this.LoadCityByCountryId(selectedCountry);
            }
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            enableCardInfo(true, true, true, true, true, true);
        }

        // ennable the
        private void enableCardInfo(bool cardcode, bool cardlevel, bool datestart, bool dateend, bool pointreword, bool pointcard)
        {
            txtCardCode.Enabled = cardcode;
            cbCardLevel.Enabled = cardlevel;
            dtAccpetedCardDate.Enabled = datestart;
            dtExpireCardDate.Enabled = dateend;
            txtPointReward.Enabled = pointreword;
            txtPointCard.Enabled = pointcard;
        }

        private void cbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCities.SelectedValue != null)
            {
                var CityId = Convert.ToInt32(cbCities.SelectedValue);
                this.LoadDistrictByCityId(CityId);
            }
        }

        /// <summary>
        /// Load distric by define defenitly city Id
        /// </summary>
        /// <param name="countryId"></param>
        private void LoadDistrictByCityId(int cityId)
        {
            var tbl = new CrmDBConnect().myTable("SP_CrmDistrict_GetByCity", "@CityId", cityId);
            if (tbl.Rows.Count > 0)
            {
                var binSource = new BindingSource { DataSource = tbl };
                cbDistrict.DataSource = binSource;
                cbDistrict.DisplayMember = "Name";
                cbDistrict.ValueMember = "Id";
            }
            else
            {
                cbDistrict.DataSource = null;
                cbDistrict.Text = "";
            }
        }

        // 2016/06/06 NguyenNT Fix lỗi nhập được chữ >>>
        private void txtPointReward_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPointCard_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbcType_CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            txtFavour.Text = String.Join(", ", cbcType.CheckBoxItems.Where(c => c.Checked).Select(c => ((ObjectSelectionWrapper<DataRow>)(c.ComboBoxItem)).Item.ItemArray[1]));
        }

        /// <summary>
        /// Loại bỏ kí tự không phải số và chữ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCardCode_TextChanged(object sender, EventArgs e)
        {
            txtCardCode.Text.Replace("E", "");
            txtCardCode.Text = Regex.Replace(txtCardCode.Text, "[^.a-zA-Z0-9]", "");
            txtCardCode.SelectionStart = txtCardCode.Text.Length;
        }
    }
}
