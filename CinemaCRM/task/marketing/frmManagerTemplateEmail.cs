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
    public partial class frmManagerTemplateEmail : Form
    {
        private int _id;
        private int _selectedRowIndex = 0;

        public frmManagerTemplateEmail()
        {
            InitializeComponent();
        }


        private void butAdd_Click(object sender, EventArgs e)
        {
            frmTemplate frm = new frmTemplate();
            frm.tabPage = false;
            frm.tabPageInsert = true;
            // 2016/06/03 NguyenNT Load du lieu sau khi show dialog them moi >>>
            // frm.Show();
            frm.ShowDialog();
            // 2016/06/03 NguyenNT <<<
            LoadData("");
        }

        private void btnEmailClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void frmManagerTemplateEmail_Load(object sender, EventArgs e)
        {
            this.LoadData("");
        }

        private void LoadData(string key) {
            var tbl = new CrmDBConnect().myTable("SP_CrmTemplateEmail_CRUD", "@TemplateName",key, "@flag", 0);
            dgEmailTemplateList.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tbl };
            bindingNavigator.BindingSource = binSource;
            dgEmailTemplateList.DataSource = binSource;
        }

        private void btnEmailSearch_Click(object sender, EventArgs e)
        {
            this.LoadData(txtEmailCode.Text.Trim());
        }

        private void btnEmailDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn xóa dữ liệu  này?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmTemplateEmail_CRUD", "@Id", _id, "@flag", 3);
            LoadData("");
        }

        private void dgEmailTemplateList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgEmailTemplateList.CurrentRow == null) return;
            _selectedRowIndex = dgEmailTemplateList.CurrentRow.Index;
            _id = Convert.ToInt32(dgEmailTemplateList.CurrentRow.Cells["Id"].Value);
          
        }

        private void btnEmailEdit_Click(object sender, EventArgs e)
        {
            frmTemplate frm = new frmTemplate();
            frm.tabPage = false;
            frm.tabPageInsert = false;
            frm._id = _id;
            frm.ShowDialog();
            LoadData("");
        }

        private void btnEmailCopy_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn copy dữ liệu tạo dữ liệu mới?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            var name=dgEmailTemplateList.CurrentRow.Cells["TemplateName"].Value.ToString();
            var title = dgEmailTemplateList.CurrentRow.Cells["TemplateTitle"].Value.ToString();
            var code = dgEmailTemplateList.CurrentRow.Cells["TemplateCode"].Value.ToString();
            var description = dgEmailTemplateList.CurrentRow.Cells["Description"].Value.ToString();

            CrmDBConnect.RunQuery("SP_CrmTemplateEmail_CRUD", "@Id", _id, "@TemplateName", name, "@TemplateCode", code, "@TemplateTitle", title, "@Description", description, "@flag", 1);
            string msg = @"Copy dữ liệu thành công";
            MessageBox.Show(msg, @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData("");
        }

        private void dgEmailTemplateList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTemplate frm = new frmTemplate();
            frm.tabPage = false;
            frm.tabPageInsert = false;
            frm._id = _id;
            frm.ShowDialog();
            LoadData("");
        }
    }
}
