using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinemaCRM.task.marketing
{
    public partial class frmTemplate : Form
    {
        public bool tabPage=false;//false: email, true: sms
        public bool tabPageInsert = true;//true for insert false:update
        public int _id=0;
        private string key="",value="",keyValue = "";
        private int _selectedRowIndex = 0;
        public frmTemplate()
        {
            InitializeComponent();
        }

        private void frmTemplate_Load(object sender, EventArgs e)
        {    // check sự kiện tạo tabpages
            if (tabPage == false)
            {
                tabTemplate.TabPages.Remove(tabPage2);
                if (!tabPageInsert)
                {
                    var tblCustomer = new CrmDBConnect().myTable("SP_CrmTemplateEmail_CRUD", "@Id", _id, "@flag", 4);
                    foreach (DataRow row in tblCustomer.Rows)
                    {
                        txtEmailName.Text = row["TemplateName"].ToString();
                        txtEmailCode.Text = row["TemplateCode"].ToString();
                        txtEmailTitle.Text = row["TemplateTitle"].ToString();
                        msHtmlContent.BodyText = row["Description"].ToString();
                    }
                }

            }
            else
            {
                tabTemplate.TabPages.Remove(tabPage1);
                // load key and value
                LoadData();
                if (!tabPageInsert)
                {
                    // load khi có dữ liệu
                    var tblCustomer = new CrmDBConnect().myTable("SP_CrmTemplateSMS_CRUD", "@Id", _id, "@flag", 4);
                    foreach (DataRow row in tblCustomer.Rows)
                    {
                        txtTempName.Text = row["TemplateName"].ToString();
                        txtCode.Text = row["TemplateCode"].ToString();
                        chkStatus.Checked = Convert.ToBoolean(row["Status"]);
                        txtDescription.Text = row["Description"].ToString();
                        keyValue = row["KeyValue"].ToString();
                    }
                }
            }
        }

        private void btnEmailAdd_Click(object sender, EventArgs e)
        {
            int flag = tabPageInsert ? 1 : 2;
            var name=txtEmailName.Text.Trim();
            var code=txtEmailCode.Text.Trim();
            var title = txtEmailTitle.Text.Trim();
            var description=msHtmlContent.BodyText;
            _id = tabPageInsert?0:_id;
         
            CrmDBConnect.RunQuery("SP_CrmTemplateEmail_CRUD", "@Id", _id, "@TemplateName", name, "@TemplateCode", code, "@TemplateTitle", title, "@Description",description,"@flag", flag);
           string msg=tabPageInsert?@"Thêm mới thành công":@"Cập nhật thành công";
           MessageBox.Show(msg, @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEmailClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            keyValue += ","+key + "," + value +",";
            txtDescription.Text += "%" + key + "%";
        }

        private void dgvKeySMS_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKeySMS.CurrentRow == null) return;
                _selectedRowIndex = dgvKeySMS.CurrentRow.Index;
                key = dgvKeySMS.CurrentRow.Cells["Key"].Value.ToString();
                value = dgvKeySMS.CurrentRow.Cells["Value"].Value.ToString();
            }
            catch
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int flag = tabPageInsert ? 1 : 2;
            var name = txtTempName.Text.Trim();
            var code = txtCode.Text.Trim();
            var status = chkStatus.Checked;
            var description = txtDescription.Text;
            _id = tabPageInsert ? 0 : _id;

            CrmDBConnect.RunQuery("SP_CrmTemplateSMS_CRUD", "@Id", _id, "@TemplateName", name, "@TemplateCode", code, "@Status", status, "@Description", description, "@KeyValue",keyValue, "@flag", flag);
            string msg = tabPageInsert ? @"Thêm mới thành công" : @"Cập nhật thành công";
            MessageBox.Show(msg, @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadData()
        {
            var tblCrmJob = new CrmDBConnect().myTable("CRM_Care_KeySMS");
            dgvKeySMS.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmJob };
            bindingNavigator.BindingSource = binSource;
            dgvKeySMS.DataSource = binSource;
        }
    }
}
