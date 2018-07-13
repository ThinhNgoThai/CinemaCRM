using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nop.Services.Security;
using System.Configuration;
using CinemaCRM.Contanst;
//using SendGridMail;
//using SendGridMail.Transport;
using System.Net.Mail;

namespace CinemaCRM
{
    public partial class frmLogin : Form
    {
        #region Method declare variable to use
        private CrmDBConnect dbconnect = new CrmDBConnect();
        public string UserName, FullName, Password;      
        private string saltKey;
        public Boolean LoginSuccess; 
        public EncryptionService enkey = new EncryptionService();
      
        #endregion

        #region method frmLogin
        public frmLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region method cmdClose_Click
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region method cmdLogin_Click
        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Chưa nhập tên truy nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("Chưa nhập mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassWord.Focus();
                return;
            }

            // string saltKey = enkey.CreateSaltKey(5);          
            DataTable dataSaltKey = dbconnect.myTable("SP_Setting_SaltKey", "Username", txtUserName.Text);
            if (dataSaltKey.Rows.Count > 0)
            {
                saltKey = dataSaltKey.Rows[0]["PasswordSalt"].ToString();
            }
            CinemaCRM.Contanst.Contanst.EncryptionKey = dbconnect.myTable("SP_Setting_Encryptionkey").Rows[0]["Value"].ToString();
            Password = enkey.CreatePasswordHash(txtPassWord.Text, saltKey, CinemaCRM.Contanst.Contanst.EncryptionKey);

            // đăng nhập, lấy thông số kết constan
            DataTable tabNhanvien = dbconnect.myTable("SP_Customer_Login", "Username", txtUserName.Text, "Password", Password, "PasswordSalt", saltKey);

            //LoginSuccess = true;
            //this.Close();


            if (tabNhanvien.Rows.Count > 0)
            {
                Contanst.Contanst.UserId = Int64.Parse(tabNhanvien.Rows[0]["Id"].ToString());
                Contanst.Contanst.UserName = tabNhanvien.Rows[0]["Username"].ToString();
                Contanst.Contanst.PassOld = tabNhanvien.Rows[0]["Password"].ToString();
                //Contanst.Contanst.GroupRole = Int64.Parse(tabNhanvien.Rows[0]["CustomerRole_Id"].ToString());
                //Contanst.Contanst.SystemName = tabNhanvien.Rows[0]["SystemName"].ToString();
                Contanst.Contanst.PasswordSalt = tabNhanvien.Rows[0]["PasswordSalt"].ToString();
                Contanst.Contanst.Email = tabNhanvien.Rows[0]["Email"].ToString();
                LoginSuccess = true;

                DataTable tblEmail = dbconnect.myTable("SP_CrmConfigSmtp");
                Contanst.Contanst.Host =tblEmail.Rows[0]["SMTP_Host"].ToString();
                Contanst.Contanst.Port =Convert.ToInt32(tblEmail.Rows[0]["SMTP_Port"].ToString());
                Contanst.Contanst.SederEmail = tblEmail.Rows[0]["Email"].ToString();
                Contanst.Contanst.PassEmail = tblEmail.Rows[0]["PassWord"].ToString();
                   
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên truy nhập hoặc mật khẩu sai.\n\rVui lòng nhập lại !", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Method txtPassword_KeyPress
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && this.txtPassWord.Text != "")
            {
                if (this.txtUserName.Text != "" && this.txtPassWord.Text != "")
                {
                    this.cmdLogin.PerformClick();
                }
                else if (this.txtUserName.Text == "")
                {
                    this.txtUserName.Focus();
                }
            }
        }
        #endregion

        #region method txtUserName_Enter
        private void txtUserName_Enter(object sender, EventArgs e)
        {
           this.txtUserName.BackColor = Color.Aqua;
        }
        #endregion

        #region method txtUserName_Leave
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            this.txtUserName.BackColor = Color.White;
        }
        #endregion

        #region method txtPassword_Leave
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            this.txtPassWord.BackColor = Color.White;
        }
        #endregion

        #region method txtPassword_Enter
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            this.txtPassWord.BackColor = Color.Aqua;
        }
        #endregion

        #region method frmLogin_Load
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtUserName.Focus();
            
            if(ConfigurationSettings.AppSettings["CrmConnection"].ToString().Contains("3.253") ||
               ConfigurationSettings.AppSettings["CrmConnection"].ToString().Contains("100.55"))
            {
                Contanst.Contanst.CrmConnection = String.Format("{0};User=sa; Pwd=Sa@0912009914", ConfigurationSettings.AppSettings["CrmConnection"].ToString());
                Contanst.Contanst.TicketConnection = String.Format("{0};User=sa; Pwd=Sa@0912009914", ConfigurationSettings.AppSettings["TicketConnection"].ToString());
            }
            else
            {
                Contanst.Contanst.CrmConnection = String.Format("{0};User=sa; Pwd=sa@0912009914", ConfigurationSettings.AppSettings["CrmConnection"].ToString());
                Contanst.Contanst.TicketConnection = String.Format("{0};User=sa; Pwd=sa@0912009914", ConfigurationSettings.AppSettings["TicketConnection"].ToString());
            }

            string ConnectionString = @"Data Source=113.190.242.4;Max Pool Size=8192;Initial Catalog=CinemaTicket2018_test;User ID=sa;pwd=sa@0912009914";
            string CrmConnectionString = @"Data Source=113.190.242.4;Max Pool Size=8192;Initial Catalog=CinemaCrm2018Test;User ID=sa;pwd=sa@0912009914";
            Contanst.Contanst.CrmConnection = CrmConnectionString;
            Contanst.Contanst.TicketConnection = ConnectionString;
        }
        #endregion

        #region method txtUserName_KeyPress
        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.txtPassWord.Focus();
            }
        }
        #endregion
    }
}