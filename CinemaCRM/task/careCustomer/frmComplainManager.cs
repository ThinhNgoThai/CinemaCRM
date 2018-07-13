using System;
using System.Windows.Forms;
using CinemaCRM.task.carecustomer;
using CinemaCRM.Core;
using System.Data;

namespace CinemaCRM.task.careCustomer
{
    public partial class frmComplainManager : Form
    {

        public string SelectedCusEmail;
        public int SelectedCusId;
        private int _id;
        public frmComplainManager()
        {
            InitializeComponent();
        }


        /// <summary>
        /// detail click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            var frm = new frmComplainDetails
            {
                btnSelectUser = { Enabled = false },
                txtComplainCode =
                {
                    Enabled = false,

                },
                cbComplainType = { Enabled = false },
                txtComplainEmail =
                {
                    Enabled = false,

                },
                cbCampaign = { Enabled = false },
                txtComplainDepartment = { Enabled = false },
                txtComplainOrganize = { Enabled = false },
                txtComplainTitle = { Enabled = false },
                txtComplainContentSent = { Enabled = false },

                btnAdd = { Enabled = false }
            };
            frm._inserted = false;
            frm._id = _id;

            frm.ShowDialog();
            this.LoadData("", "", 0, 0);
        }
        /// <summary>
        /// add button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmComplainDetails();

            frm._inserted = true;
            frm.ShowDialog();
            this.LoadData("", "", 0, 0);
        }
        /// <summary>
        /// close button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCamplainClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }
        /// <summary>
        /// first load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmComplainManager_Load(object sender, EventArgs e)
        {
            this.LoadComplainType();

            cbComplainType.Text = "-Chọn loại khiếu nại--";
            this.LoadData("", "", 0, 0);

        }

        /// <summary>
        /// load complain type
        /// </summary>

        private void LoadComplainType()
        {
            var tblCrmType = new CrmDBConnect().myTable("[SP_CrmComplainType_CRUD]");
            if (tblCrmType.Rows.Count > 0)
            {
                DataRow newRow = tblCrmType.NewRow();
                newRow["Id"] = 0;
                newRow["ComplainName"] = "Tất cả";
                tblCrmType.Rows.Add(newRow);

                var binSource = new BindingSource { DataSource = tblCrmType };
                cbComplainType.DataSource = binSource;
                cbComplainType.DisplayMember = "ComplainName";
                cbComplainType.ValueMember = "Id";
                cbComplainType.SelectedValue = 0;
            }
        }


        /// <summary>
        /// load data connect to database
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <param name="flag"></param>
        private void LoadData(string keyword = "", string code = "", int type = 0, int flag = 0)
        {

            var tblCompaint = new CrmDBConnect().myTable("SP_CrmComplain_CRUD", "@Keywords", keyword, "@TypeId", type, "@ComplainCode", code, "@flag", flag);
            dgComplainList.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCompaint };
            bindingNavigator.BindingSource = binSource;
            dgComplainList.DataSource = binSource;
        }

        
        /// <summary>
        /// search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComplainSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtEmail.Text.Trim();
            var type = 0;
            if (cbComplainType.SelectedValue != null)
            {
                type = Convert.ToInt32(cbComplainType.SelectedValue.ToString());

            }
            var code = txtCode.Text.Trim();
            this.LoadData(keyword, code, type, 5);
        }

        /// <summary>
        /// cel enter (selected cell) event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgComplainList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgComplainList.CurrentRow == null) return;

            _id = Convert.ToInt32(dgComplainList.CurrentRow.Cells["Id"].Value);
        }
        /// <summary>
        /// delete button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butComplainDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn xóa dữ liệu này?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmComplain_CRUD", "@Id", _id, "@flag", 4);
            this.LoadData("", "", 0, 0);
        }
        /// <summary>
        /// cell formating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgComplainList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgComplainList.Columns[e.ColumnIndex].Name.Equals("Priority"))
            {
                // Ensure that the value is a string.
                String stringValue = e.Value.ToString();
                if (stringValue == null) return;
                var p = new PriorityEnumExtension();
                e.Value = p.ToPriorityString(Convert.ToInt32(stringValue));
            }
            if (dgComplainList.Columns[e.ColumnIndex].Name.Equals("Status"))
            {
                // Ensure that the value is a string.
                String stringValue = e.Value.ToString();
                if (stringValue == null) return;
                var p = new ComplainActionEnumExtension();
                e.Value = p.ToComplainActionString(Convert.ToInt32(stringValue));
            }


        }

        private void cbComplainType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgComplainList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var frm = new frmComplainDetails
            {
                btnSelectUser = { Enabled = false },
                txtComplainCode =
                {
                    Enabled = false,

                },
                cbComplainType = { Enabled = false },
                txtComplainEmail =
                {
                    Enabled = false,

                },
                cbCampaign = { Enabled = false },
                txtComplainDepartment = { Enabled = false },
                txtComplainOrganize = { Enabled = false },
                txtComplainTitle = { Enabled = false },
                txtComplainContentSent = { Enabled = false },

                btnAdd = { Enabled = false }
            };
            frm._inserted = false;
            frm._id = _id;

            frm.ShowDialog();
            this.LoadData("", "", 0, 0);
        }





    }
}