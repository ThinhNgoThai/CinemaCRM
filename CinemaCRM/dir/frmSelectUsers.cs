using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CinemaCRM.Core;

namespace CinemaCRM.dir
{
    public partial class frmSelectUsers : Form
    {
        public int _id;
        public string email = "";
        public string phone = "";
        public bool MultiSelect = true;

        public List<int> Ids { get; set; }

        public frmSelectUsers()
        {
            InitializeComponent();
        }
        public frmSelectUsers(int id, string email)
        {
            InitializeComponent();
            _id = id;
            this.email = email;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void LoadSelectedCustomer(string name = "", string email = "", string phone = "", bool sex = true, int flag = 0)
        {

            var tblCrm = new CrmDBConnect().myTable("CRM_SelectedCustomer_List", "@Name", name, "@Email", email, "@Phone", phone, "@Sex", sex, "@flag", flag);
            dgCusList.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrm };
            bindingNavigator.BindingSource = binSource;
            dgCusList.DataSource = binSource;

        }

        private void frmSelectUsers_Load(object sender, EventArgs e)
        {
            LoadSelectedCustomer("", "", "", false, 0);
            LoadGender();

            dgCusList.MultiSelect = MultiSelect;
        }

        private void dgCusList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgCusList.CurrentRow == null) return;
            _id = Convert.ToInt32(dgCusList.CurrentRow.Cells["Id"].Value);
            email = dgCusList.CurrentRow.Cells["Email_New"].Value.ToString();
            phone = dgCusList.CurrentRow.Cells["phone_number"].Value.ToString();
            //txtCusName.Text = dgCusList.CurrentRow.Cells["Column4"].Value.ToString();

        }
        private void LoadGender()
        {
            var gen = new SexEnumExtension();
            cbCusGender.DataSource = gen.ToSexList();
            cbCusGender.DisplayMember = "Des";
            cbCusGender.ValueMember = "Code";
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (!MultiSelect)
            {
                _id = Convert.ToInt32(dgCusList.CurrentRow.Cells["Id"].Value);
                email = dgCusList.CurrentRow.Cells["Email_New"].Value.ToString();
                phone = dgCusList.CurrentRow.Cells["phone_number"].Value.ToString();
            }
            else
            {
                Ids = new List<int>();
                foreach (DataGridViewRow data in dgCusList.SelectedRows)
                {
                    Ids.Add(Convert.ToInt32(data.Cells["Id"].Value.ToString()));
                }
            }

            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var name = txtCusName.Text.Trim();
            var email = txtCusEmail.Text.Trim();
            var sex = Convert.ToBoolean(cbCusGender.SelectedValue);
            var phone = txtCusPhone.Text.Trim();
            LoadSelectedCustomer(name, email, phone, sex, 0);
        }
    }
}
