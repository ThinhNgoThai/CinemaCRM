using System;
using System.Windows.Forms;
using CinemaCRM.dir;
using CinemaCRM.Core;
using System.Data;
using CinemaCRM.Contanst;

namespace CinemaCRM.task.carecustomer
{
    public partial class frmComplainDetails : Form
    {

        public int _id;
        public bool _inserted;
        private string _randomstring;


        public int _selectedCusId;
        public string _selectedEmail;

        public frmComplainDetails()
        {
            InitializeComponent();
        }

        private void frmComplainDetails_Load(object sender, EventArgs e)
        {
            this.LoadComplainType();
            this.LoadPriorityStatus();
            this.LoadActionEnumStatus();
            this.LoadCampaign();
            this.LoadStaff();
            if (_inserted)
            {
                txtComplainCode.Text = StringExtension.GenerateRandomCode();

                _randomstring = txtComplainCode.Text;
                txtComplainCode.Enabled = false;
                btnReply.Enabled = false;
            }
            else
            {
                var tbl = new CrmDBConnect().myTable("SP_CrmComplain_CRUD", "@Id", _id, "@flag", 2);
                foreach (DataRow row in tbl.Rows)
                {

                    txtComplainTitle.Text = row["Title"].ToString();
                    txtComplainCode.Text = row["ComplainCode"].ToString();
                    txtComplainDepartment.Text = row["Department"].ToString();
                    txtComplainOrganize.Text = row["Organization"].ToString();
                    txtComplainEmail.Text = row["CustomerEmail"].ToString();
                    txtComplainCause.Text = row["Cause"].ToString();
                    txtComplainResolve.Text = row["OverCome"].ToString();
                    txtComplainContentSent.Text = row["Content"].ToString();
                    txtComplainDescription.Text = row["Description"].ToString();
                    var cemail = Convert.ToBoolean(row["SendEmail"]);
                    cbEmailSend.Checked = cemail;
                    var csms = Convert.ToBoolean(row["SendSMS"]);
                    cbPriority.SelectedValue = row["Priority"];  //Allow Null
                    cbComplainType.SelectedValue = row["ComplainTypeId"];  //Allow Null
                    cbComplainStatus.SelectedValue = row["Status"]; //Allow Null
                    cbComplainUserAssign.SelectedValue = row["ProcessCustomerId"]; //Allow Null
                    break;
                }
                btnReply.Enabled = true;
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }


        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            var frm = new frmSelectUsers();
            frm.MultiSelect = false;

            frm.ShowDialog();
            this._selectedCusId = frm._id;
            this._selectedEmail = frm.email;
            txtComplainEmail.Text = frm.email;
            txtPhone.Text = frm.phone;
            txtComplainEmail.Enabled = false;

        }
        /// <summary>
        /// load loại khiếu nại
        /// </summary>
        private void LoadComplainType()
        {
            var tblCrmJob = new CrmDBConnect().myTable("[SP_CrmComplainType_CRUD]");
            var binSource = new BindingSource { DataSource = tblCrmJob };
            cbComplainType.DataSource = binSource;
            cbComplainType.DisplayMember = "ComplainName";
            cbComplainType.ValueMember = "Id";
        }
        /// <summary>
        /// load tình trạng ưu tiên
        /// </summary>
        private void LoadPriorityStatus()
        {

            var status = new PriorityEnumExtension();
            cbPriority.DataSource = status.ToPriorityList();
            cbPriority.DisplayMember = "Des";
            cbPriority.ValueMember = "Code";

        }
        /// <summary>
        /// load hành động duyệt hay không duyệt
        /// </summary>
        private void LoadActionEnumStatus()
        {

            var status = new ComplainActionEnumExtension();
            cbComplainStatus.DataSource = status.ToComplainActionList();
            cbComplainStatus.DisplayMember = "Des";
            cbComplainStatus.ValueMember = "Code";

        }
        /// <summary>
        /// load chiến dịch
        /// </summary>
        private void LoadCampaign()
        {
            var tblCrmJob = new CrmDBConnect().myTable("SP_CrmCampaign_GetAll");


            var binSource = new BindingSource { DataSource = tblCrmJob };
            cbCampaign.DataSource = binSource;
            cbCampaign.DisplayMember = "Name";
            cbCampaign.ValueMember = "Id";
        }
        private void LoadStaff()
        {
            var tblCrmJob = new TicketDBConnect().myTable("SP_CinemaStaff_GetStaffs", "@RoleId", 8);
            var binSource = new BindingSource { DataSource = tblCrmJob };

            cbComplainUserAssign.DataSource = binSource;
            cbComplainUserAssign.DisplayMember = "FullName";
            cbComplainUserAssign.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var cName = txtComplainTitle.Text.Trim();
            var cDate = dtpDateAssigned.Value;
            var cContent = txtComplainContentSent.Text.Trim();
            var depart = txtComplainDepartment.Text.Trim();
            var org = txtComplainOrganize.Text.Trim();
            var processCusId = cbComplainUserAssign.SelectedValue;  //Allow Null
            var status = cbComplainStatus.SelectedValue;  //Allow Null
            var piority = cbPriority.SelectedValue;  //Allow Null
            var sendMail = cbEmailSend.Checked;
            var cause = txtComplainCause.Text.Trim();
            var overcome = txtComplainResolve.Text.Trim();
            var des = txtComplainContentSent.Text.Trim();
            var campainId = (cbCampaign.SelectedValue.ToString().Trim() == "") ? 0 : Convert.ToInt32(cbCampaign.SelectedValue.ToString().Trim());
            var cType = cbComplainType.SelectedValue;
            //var cType = (cbComplainType.SelectedValue.ToString().Trim() == "") ? 0 : Convert.ToInt32(cbComplainType.SelectedValue.ToString().Trim());
            CrmDBConnect.RunQuery("SP_CrmComplain_CRUD", "@ComplainName", cName, "@ComplainCode", _randomstring, "@ComplainDate", DateTime.Now,
                "@Title", cName,
                "@Content", cContent,
                "@Department", depart,
                "@Organization", org,
                "@ProcessCustomerId", processCusId,
                "@ProcessDate", cDate,
                "@Status", status,
                "@Priority", piority,
                "@SendEmail", sendMail,
                "@SendSMS", false,
                "@Cause", cause,
                "@OverCome", overcome,
                "@Description", des,
                "@DescriptionSMS", "",
                "@ComplainCancel", 0,
                "@CampaignId", campainId,
                "@CustomerId", _selectedCusId,
                "@CompainTypeId", cType,
                "@CustomerEmail", _selectedEmail,
                "@flag", 1);

            MessageBox.Show(@"Thêm mới thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnReply_Click(object sender, EventArgs e)
        {

            var cDate = dtpDateAssigned.Value;

            var processCusId = cbComplainUserAssign.SelectedValue;   //Allow Null
            var status = cbComplainStatus.SelectedValue;  //Allow Null
            var piority = cbPriority.SelectedValue;  //Allow Null
            var sendMail = cbEmailSend.Checked;
            var cause = txtComplainCause.Text.Trim();
            var overcome = txtComplainResolve.Text.Trim();
            var des = txtComplainDescription.Text.Trim();

            CrmDBConnect.RunQuery("SP_CrmComplain_CRUD",
                "@Id", _id,
                "@ProcessCustomerId", processCusId,
                "@ProcessDate", cDate,
                "@Status", status,
                "@Priority", piority,
                "@SendEmail", sendMail,
                "@SendSMS", false,
                "@Cause", cause,
                "@OverCome", overcome,
                "@Description", des,
                "@DescriptionSMS", "",
                "@flag", 3);

            // Gửi email
            if (cbEmailSend.Checked == true)
            {
                SendEmail email = new SendEmail();
                email.Send_Email(Contanst.Contanst.SederEmail, txtComplainEmail.Text, txtComplainTitle.Text, txtComplainDescription.Text, Contanst.Contanst.Host, Contanst.Contanst.Port, Contanst.Contanst.PassEmail);
            }

            MessageBox.Show(@"Cập nhật trả lời thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
            Close();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {

            var cDate = dtpDateAssigned.Value;
            var processCusId = cbComplainUserAssign.SelectedValue;   //Allow Null
            CrmDBConnect.RunQuery("SP_CrmComplain_CRUD",
                "@Id", _id,
                "@ProcessCustomerId", processCusId,
                "@ProcessDate", cDate,
                "@Status", cbComplainStatus.SelectedValue,  //Allow Null
                "@flag", 6);
            MessageBox.Show(@"Gán  xử lý thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
            Close();
        }

    }
}
