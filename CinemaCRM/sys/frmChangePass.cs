using Nop.Services.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace CinemaCRM
{
    public partial class frmChangePass : Form
    {
        private String _matkhau;
        private readonly EncryptionService _enkey = new EncryptionService();

        public frmChangePass()
        {
            InitializeComponent();
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {

        }

        private void txtTEN_ND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) txtMK_OLD.Focus();
        }

        private void txtMK_OLD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) txtMK_NEW.Focus();
        }

        private void txtMK_NEW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) txtMK_CONFIRM.Focus();
        }

        private void txtMK_CONFIRM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) btnSave.Focus();
        }

        private void frmChangePass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // xác nhận mât khẩu cũ        
            //_matkhau = _enkey.CreatePasswordHash(txtMK_OLD.Text, Common.PasswordSalt, Contanst.EncryptionKey);
            //if (Common.PassOld != _matkhau)
            //{
            //    txtMK_OLD.Focus();
            //    MessageBox.Show(@"Nhập sai mật khẩu !");
            //    return;
            //}
            if (txtMK_NEW.Text == "")
            {
                MessageBox.Show(@"Chưa nhập mật khẩu mới !");
                txtMK_NEW.Focus();
                return;
            }

            if (txtMK_CONFIRM.Text == "")
            {
                MessageBox.Show(@"Chưa nhập mật khẩu xác nhận !");
                txtMK_CONFIRM.Focus();
                return;
            }
            if (txtMK_NEW.Text != txtMK_CONFIRM.Text)
            {
                MessageBox.Show(@"Mật khẩu mới không giống mật khẩu xác nhận !");
                txtMK_CONFIRM.Focus();
                return;
            }
            var saltKey = _enkey.CreateSaltKey(5);
            var newPass = _enkey.CreatePasswordHash(txtMK_NEW.Text, saltKey,Contanst.Contanst.EncryptionKey);
            CrmDBConnect.RunQuery("SP_Customer_ChangePass", "@CustomerId", Contanst.Contanst.UserId, "@NewsPass", newPass, "@NewSalt", saltKey);
            MessageBox.Show(@"Mật khẩu đã được thay đổi !");
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}