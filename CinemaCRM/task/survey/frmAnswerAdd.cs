using System;
using System.Windows.Forms;

namespace CinemaCRM.task.survey
{
    public partial class frmAnswerAdd : Form
    {
        public string Content;

        public frmAnswerAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(txtContent.Text.Trim()))
            {
                MessageBox.Show(@"Không được bỏ trống", @"Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Content = txtContent.Text;
            Close();
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd_Click(sender, e);
        }

        private void frmAnswerAdd_Load(object sender, System.EventArgs e)
        {
            txtContent.Text = "";
        }
    }
}
