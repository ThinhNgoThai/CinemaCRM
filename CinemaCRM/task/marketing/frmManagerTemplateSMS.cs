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
    public partial class frmManagerTemplateSMS : Form
    {
        private int _id;
        private int _selectedRowIndex = 0;

        public frmManagerTemplateSMS()
        {
            InitializeComponent();
        }
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
     
        private void butAdd_Click(object sender, EventArgs e)
        {
            frmTemplate frm = new frmTemplate();
            frm.tabPage = true;
            // 2016/06/03 NguyenNT Load du lieu sau khi them moi sms >>>
            // frm.Show();
            frm.ShowDialog();
            this.LoadData("", false, 0);
            // 2016/06/03 NguyenNT <<<
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTemplate frm = new frmTemplate();
            frm.tabPage = true;
            frm.tabPageInsert = false;
            if (dgvSMS.CurrentRow == null) return;
            frm._id = Convert.ToInt32(dgvSMS.CurrentRow.Cells["Id"].Value.ToString()); 
            frm.ShowDialog();
            // 2016/06/06 NguyenNT Sua loi search ra gia tri sai >>>
            LoadData("",false, 0);
            // 2016/06/06 NguyenNT <<<
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn xóa dữ liệu  này?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmTemplateSMS_CRUD", "@Id", _id, "@flag", 3);
            // 2016/06/06 NguyenNT Sua loi search ra gia tri sai >>>
            LoadData("",true, 0);
            // 2016/06/06 NguyenNT <<<
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 2016/06/06 NguyenNT Sua loi search ra gia tri sai >>>
            this.LoadData(txtSearch.Text.Trim(),chkStatus.Checked, 0);
            // 2016/06/06 NguyenNT <<<
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn copy dữ liệu tạo dữ liệu mới?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            var name = dgvSMS.CurrentRow.Cells["TemplateName"].Value.ToString();
            var code = dgvSMS.CurrentRow.Cells["TemplateCode"].Value.ToString();
            var status =Convert.ToBoolean(dgvSMS.CurrentRow.Cells["Status"].Value);
            var description = dgvSMS.CurrentRow.Cells["Description"].Value.ToString();
            var KeyValue = dgvSMS.CurrentRow.Cells["KeyValue"].Value.ToString();

            CrmDBConnect.RunQuery("SP_CrmTemplateSMS_CRUD", "@Id", _id, "@TemplateName", name, "@TemplateCode", code, "@Status", status, "@Description", description, "@KeyValue", KeyValue, "@flag", 1);
            string msg = @"Copy dữ liệu thành công";
            MessageBox.Show(msg, @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // 2016/06/06 NguyenNT Sua loi search ra gia tri sai >>>
            LoadData("",true, 0);
            // 2016/06/06 NguyenNT <<<
        }

        // 2016/06/06 NguyenNT Sua loi search ra gia tri sai >>>
        private void LoadData(string key,bool status, int flag)
        // 2016/06/06 NguyenNT <<<
        {
            var tbl = new CrmDBConnect().myTable("SP_CrmTemplateSMS_CRUD", "@TemplateName", key, "@Status", status, "@flag", flag);
            dgvSMS.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tbl };
            bindingNavigator.BindingSource = binSource;
            dgvSMS.DataSource = binSource;


        }

        private void frmManagerTemplateSMS_Load(object sender, EventArgs e)
        {
            // 2016/06/06 NguyenNT Sua loi search ra gia tri sai >>>
            LoadData("",false, 0);
            // 2016/06/06 NguyenNT <<<
        }

        private void dgvSMS_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSMS.CurrentRow == null) return;
            _selectedRowIndex = dgvSMS.CurrentRow.Index;
            _id = 0;
            _id = Convert.ToInt32(dgvSMS.CurrentRow.Cells["Id"].Value.ToString());
        }

        private void dgvSMS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTemplate frm = new frmTemplate();
            frm.tabPage = true;
            frm.tabPageInsert = false;
            if (dgvSMS.CurrentRow == null) return;
            frm._id = Convert.ToInt32(dgvSMS.CurrentRow.Cells["Id"].Value.ToString());
            frm.ShowDialog();
            // 2016/06/06 NguyenNT Sua loi search ra gia tri sai >>>
            LoadData("", false, 0);
            // 2016/06/06 NguyenNT <<<
        }
    }
}
