using System;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.sys
{

    public partial class ConfigureSMTPForm : Form
    {
        public ConfigureSMTPForm()
        {
            InitializeComponent();
        }

        private void ConfigureSMTPForm_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var dataSource = new CrmDBConnect().myDataset("SP_CrmConfigSmtp");
            if (dataSource.Tables != null && dataSource.Tables.Count > 0)
            {
                var data = dataSource.Tables[0].Rows[0];

                txtHost.Text = data["SMTP_Host"].ToString();
                txtPort.Text = data["SMTP_Port"].ToString();
                chkSMTP.Checked = Convert.ToBoolean(data["SMTP"]);
                txtEmail.Text = data["Email"].ToString();
                txtUsername.Text = data["UserName"].ToString();
                txtPassword.Text = data["PassWord"].ToString();
                chkSSL.Checked = Convert.ToBoolean(data["SSL"]);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var update = CrmDBConnect.RunQuery("SP_CrmConfigSmtp", "@Host", txtHost.Text.Trim(), "@Port", txtPort.Text.Trim(),
                "@SMTP", chkSMTP.Checked, "@Email", txtEmail.Text.Trim(), "@Username", txtUsername.Text.Trim(),
                "@PassWord", txtPassword.Text, "@SSL", chkSSL.Checked, "@flag", 1);

            Contanst.Contanst.Host = txtHost.Text;
            Contanst.Contanst.Port = Convert.ToInt32(txtPort.Text);
            Contanst.Contanst.SederEmail = txtEmail.Text;
            Contanst.Contanst.PassEmail = txtPassword.Text;

            if (update) MessageBox.Show(@"Cập nhật thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            SendEmail email = new SendEmail();
            MessageBox.Show(email.Send_Email(Contanst.Contanst.SederEmail, txtEmailTest.Text.Trim(), "hello", "Test email", Contanst.Contanst.Host, Contanst.Contanst.Port, Contanst.Contanst.PassEmail), @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 2016/06/06 NguyenNT Fix lỗi nhập được chữ >>>
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
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
