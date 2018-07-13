using System.Windows.Forms;

namespace CinemaCRM.sys
{
 
    public partial class ConfigureSMSForm : Form
    {
        public ConfigureSMSForm()
        {
            InitializeComponent();
        }

        private void ConfigureSMSForm_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var dataSource = new CrmDBConnect().myDataset("CRM_Sys_ConfigSMS");
            if (dataSource.Tables != null && dataSource.Tables.Count > 0)
            {
                var data = dataSource.Tables[0].Rows[0];
                txtMobile.Text = data["Mobile"].ToString();
                txtBrandName.Text = data["BrandName"].ToString();
                txtUsername.Text = data["UserName"].ToString();
                txtPassword.Text = data["PassWord"].ToString();
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            var update = CrmDBConnect.RunQuery("CRM_Sys_ConfigSMS", "@Mobile", txtMobile.Text.Trim(), "@BrandName",
                txtBrandName.Text.Trim(), "@UserName", txtUsername.Text.Trim(), "@PassWord", txtPassword.Text, "@flag", 1);

            if (update) MessageBox.Show(@"Cập nhật thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Dispose();
            Close();
        }
    }
}
