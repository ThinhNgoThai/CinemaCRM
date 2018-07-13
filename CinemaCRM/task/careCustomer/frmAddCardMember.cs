using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinemaCRM.taks.customer;
using PresentationControls;
using CinemaCRM.Core;
using Nop.Services.Security;
using System.Text.RegularExpressions;
using CinemaCRM.Contanst;
namespace CinemaCRM.taks.careCustomer
{
    public partial class frmAddCardMember : Form
    {
        private int customerId;
        private DataSet _dataSet;
        public EncryptionService enkey = new EncryptionService();
        public void setCustomerId(int customerId)
        {
            this.customerId = customerId;
        }

        #region Thông tin chi tiết
        private void butCustomerActive_Click(object sender, EventArgs e)
        {
            if (customerId <= 0) return;
            if (
                MessageBox.Show(@"Kích hoạt tài khoản này bằng phần mềm?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmCustomer_Update", "@Id", customerId, "@flag", 1);
            MessageBox.Show(@"Cập nhật  thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var tblCrmAddCardLevel = new CrmDBConnect().myTable("SP_CrmCardLevel_CRUD", "@flag", 1);

            DataRow rowNothing = tblCrmAddCardLevel.NewRow();
            rowNothing["CardLevelName"] = "--Chọn hạng thẻ--";
            rowNothing["Id"] = "0";
            tblCrmAddCardLevel.Rows.InsertAt(rowNothing, 0);

            var binSource = new BindingSource { DataSource = tblCrmAddCardLevel };
            cbAddCardLevel.DataSource = binSource;
            cbAddCardLevel.DisplayMember = "CardLevelName";
            cbAddCardLevel.ValueMember = "Id";
        }

        /// <summary>
        /// Load country for combox
        /// </summary>
        private void LoadCountry()
        {
            DataTable tbl = new CrmDBConnect().myTable("SP_CrmCountry_GetAll");

            //2016/06/21 ThienNQ( Edited) Add thêm Items nothing.
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
        /// <param name="countryId"></param>
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

        public frmAddCardMember()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void frmDetailsMember_Load(object sender, EventArgs e)
        {
            this.LoadJob();
            this.LoadCountry();
            this.LoadCardLevel();
            __loadData(cbcType);
        }
        #endregion

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

        private CheckBoxComboBox __getCbc(string value)
        {
            switch (value)
            {
                case "6":
                    return cbcType;
                default:
                    return null;
            }
        }

        // Cấp thẻ
        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAddCardLevel.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Hãy chọn loại thẻ.", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCardCode.Text))
                {
                    MessageBox.Show("Hãy nhập mã thẻ.", "Thông báo");
                    return;
                }

                string cardCode = txtCardCode.Text;
                cardCode.Replace("%", "").Replace("?", "").TrimStart().TrimEnd();

                if (new CrmDBConnect().isExist("SP_CrmCustomer_CheckCardCode", "@CardCode", cardCode))
                {
                    MessageBox.Show("Mã thẻ đã tồn tại!", "Thông báo");
                    return;
                }

                var fName = cb.Text.Trim();
                var lName = txtLastName.Text.Trim();
                var phone = txtPhone.Text.Trim();
                var email = txtEmail.Text.Trim();
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

                var address = txtAddress.Text;
                var birtday = dtBirthDay.Value;
                var jobId = Convert.ToInt32(cbCustomerJobs.SelectedValue);
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

                if (string.IsNullOrEmpty(lName) || string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(txtCardCode.Text))
                {
                    MessageBox.Show("Nhập thiếu dữ liệu", "Thông báo");
                    return;
                }

                var cityId = Convert.ToInt32(cbCities.SelectedValue);
                var districtId = Convert.ToInt32(cbDistrict.SelectedValue);
                var countryId = Convert.ToInt32(cbCountry.SelectedValue);
                var cardLevelid = Convert.ToInt32(cbAddCardLevel.SelectedValue);
                var position = txtPosition.Text;
                var pointReward = Convert.ToDecimal(string.IsNullOrWhiteSpace(txtPointReword.Text) ? null : txtPointReword.Text.Trim());
                var pointCard = Convert.ToDecimal(string.IsNullOrWhiteSpace(txtPoinCard.Text) ? null : txtPoinCard.Text.Trim());
                var datecreatecard = dtAccpetedCardDate.Value;
                var dateexpirecard = dtExpireCardDate.Value;
                String CustomerGuid = Guid.NewGuid().ToString();
                string saltKey = enkey.CreateSaltKey(5);
                string strPass = passWordRandom(5);
                String newPass = enkey.CreatePasswordHash(strPass, saltKey, Contanst.Contanst.EncryptionKey);

                //var password = enkey.CreatePasswordHash(model.Password, saltKey, CRM_WEB.Common.Contanst.EncryptionKey);
                String InsertQuery = "";

                //Thực hiện kiểm tra và in dữ liệu
                InsertQuery = "SP_CrmCustomer_Insert";
                object[] CustomerParams = {
                    "@Username", email,
                    "@Email", email,
                    "@Password", newPass,
                    "@PasswordFormatId", 1,
                    "@PasswordSalt", saltKey,
                    "@FullName", lName + " " + fName,
                    "@CustomerLastName", lName,
                    "@CustomerFirstName", fName,
                    "@BirthDay", birtday,
                    "@Mobile", phone,
                    "@Sex", sex,
                    "@Marriage", marriage,
                    "@Address", address,
                    "@Postion", position,
                    "@Favour", __getCheckedItems(cbcType),
                    "@PointReward ", pointReward,
                    "@PointCard ", pointCard,
                    "@CardCode", cardCode,
                    "@CardLevelName", cbAddCardLevel.Text,
                    "@CurrentCardId", cardLevelid,
                    "@DateCreateCard", datecreatecard,
                    "@DateExpireCard", dateexpirecard,
                    "@DateLevel", DateTime.Now,
                    "@CardIssued", 1,
                    "@AreaId", 4 ,
                    "@CityId", cityId,
                    "@Job_Id", jobId,
                    "@Country_Id", countryId,
                    "@DistrictId", districtId,
                };

                DataTable tblUpdateCustomer = new CrmDBConnect().myTable(InsertQuery, CustomerParams);

                var dataSource = new CrmDBConnect().myDataset("SP_CrmConfigSmtp");
                if (dataSource.Tables != null && dataSource.Tables.Count > 0)
                {
                    var data = dataSource.Tables[0].Rows[0];

                    var sendMailHost = data["SMTP_Host"].ToString();
                    var sendMailPort = Convert.ToInt32(data["SMTP_Port"].ToString());
                    var sendMailSederEmail = data["Email"].ToString();
                    var sendMailPass = data["PassWord"].ToString();

                    SendEmail sendEmail = new SendEmail();
                    string msg = sendEmail.Send_Email(sendMailSederEmail, email,
                        "Thông tin đăng nhập Thành viên của Trung tâm chiếu phim Quốc Gia",
                        "Xin chào bạn " + email + " ," + " <BR> " +
                        "Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi ! " + " <BR> " +
                        "Thông tin đăng nhập làm Thành viên trên Website của Trung tâm chiếu phim Quốc Gia http://cskh.chieuphimquocgia.com.vn/Home/Login của bạn là : " + " <BR> " +
                        "User : " + email + " <BR> " +
                        "Password : " + strPass + " <BR> " +
                        "Trân trọng !",
                        sendMailHost, sendMailPort, sendMailPass);

                    MessageBox.Show("Cấp thẻ thành công!" + "\r\n" +
                        "User: " + email + "\r\n" +
                        "Password: " + strPass + "\r\n" +
                        msg
                        , @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //MessageBox.Show("Cấp thẻ thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cấp thẻ: /n" + e.ToString(), @"Thông báo");
            }
        }

        // lấy về các giá trị thù combox sở thích
        private string __getCheckedItems(CheckBoxComboBox checkBoxComboBox)
        {
            return String.Join(",", checkBoxComboBox.CheckBoxItems.
                Where(c => c.Checked).
                Select(c => ((ObjectSelectionWrapper<DataRow>)(c.ComboBoxItem)).Item.ItemArray[0]));
        }

        /// <summary>
        /// hainb8886
        /// 24/08/2015
        /// Tạo mật khẩu ngẫu nhiên
        /// </summary>
        public string passWordRandom(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(10);
                if (temp != -1 && temp == t)
                {
                    return passWordRandom(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }


        private void cbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var countryId = Convert.ToInt32(cbCountry.SelectedValue);
                this.LoadCityByCountryId(countryId);
                this.LoadDistrictByCityId(countryId);
            }
            catch { }
        }

        private void cbAddCardLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //2016/06/22 ThienNQ( Edited) Lấy điểm thưởng và điểm tích lũy cho người mới đăng kí từ bảng CRM_Point
                //var cardId = Convert.ToInt32(cbAddCardLevel.SelectedValue);
                //DataTable tbl = new DBConnect().myTable("SP_CrmCardLevel_CRUD", "@Id", cardId, "@flag", 2);
                //if (tbl.Rows.Count > 0)
                //{
                //    //String.Format("{0:0.##}", 123.4567);
                //    txtPointReword.Text = String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["MinPointCard"]));
                //    lbPoint.Text = cbAddCardLevel.Text + " Có điểm từ " + String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["MinPointCard"]).ToString()) + " đến " + String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["NeededPointCard"]).ToString()) + " .";

                //    //String.Format("{0:0.##}", 123.4567);
                //    txtPoinCard.Text = String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["BuyTicketPointReward"]));
                //    lbPointCard.Text = "Điểm tích lũy nhận được " + String.Format("{0:0.###}", Convert.ToInt32(tbl.Rows[0]["BuyTicketPointReward"]).ToString()) + " .";
                //}

                var tbl = new CrmDBConnect().myTable("SP_CrmPoint_CRUD", "@flag", 0);
                if (tbl.Rows.Count > 0)
                {
                    txtPointReword.Text = Convert.ToDecimal(tbl.Rows[0]["PointRegister"]).ToString("0.00");
                    txtPoinCard.Text = Convert.ToDecimal(tbl.Rows[0]["PointCard"]).ToString("0.00");
                }
                else
                {
                    txtPointReword.Text = 0.ToString("0.00");
                    txtPoinCard.Text = 0.ToString("0.00");
                }

            }
            catch { }
        }

        private void cbCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var CityId = Convert.ToInt32(cbCities.SelectedValue);
                this.LoadDistrictByCityId(CityId);
            }
            catch { }
        }

        //2016/06/08 ThienNQ( Added) Only input numeric
        private void TextBoxInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only input numeric
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        //08/06/2016 KienNK check chỉ nhập số vào textbox >>>>>>>>>>>>
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }
        // 08/06/2016 KienNK <<<<<<<<<<<

        private void TextBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))) e.Handled = true;

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
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
