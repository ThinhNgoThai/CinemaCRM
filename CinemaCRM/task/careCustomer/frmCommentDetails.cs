using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CinemaCRM.task.careCustomer
{
    public partial class frmCommentDetails : Form
    {
        public int Id;
        public string SelectedStatus;

        public frmCommentDetails()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void frmCommentDetails_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            var listStatus = Status().ToArray();
            cmbStatus.Items.AddRange(listStatus);

            var selected = listStatus.Where(s => s.Text.Equals(SelectedStatus)).ToArray();
            cmbStatus.SelectedItem = selected[0];
        }

        #region Các hàm hỗ trợ
        private static List<StatusItem> Status()
        {
            var status = new List<StatusItem>
            {
                new StatusItem {Value = 1, Text = "Đã duyệt"},
                new StatusItem {Value = 2, Text = "Chờ duyệt"},
                new StatusItem {Value = 3, Text = "Từ chối"}
            };

            return status;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = cmbStatus.SelectedItem.GetType().GetProperty("Value");
            var selectedValue = Convert.ToInt32(item.GetValue(cmbStatus.SelectedItem, null));

            switch (selectedValue)
            {
                case 1:
                    var accept = CrmDBConnect.RunQuery("SP_CrmFilmComment", "@Id", Id, "@operation", 1);
                    if (accept) MessageBox.Show(@"Đã duyệt", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    var pending = CrmDBConnect.RunQuery("SP_CrmFilmComment", "@Id", Id, "@operation", 2);
                    if (pending) MessageBox.Show(@"Đang chờ duyệt", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    var deny = CrmDBConnect.RunQuery("SP_CrmFilmComment", "@Id", Id, "@operation", 3);
                    if (deny) MessageBox.Show(@"Đã từ chối", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }

    public class StatusItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
