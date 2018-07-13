using System;
using System.Linq;
using System.Windows.Forms;
using CinemaCRM.Contanst;
using System.Data;
namespace CinemaCRM.task.survey
{
    public partial class frmSurveyDetails : Form
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string PointReward { get; set; }
        public string PointCard { get; set; }
        public string Time { get; set; }
        public string Object { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public bool Active { get; set; }
        public bool IsSurvey { get; set; }
        public bool IsAdd { get; set; }
        private CrmDBConnect dbconnect = new CrmDBConnect();
        public frmSurveyDetails()
        {
            InitializeComponent();
        }

        private void frmSurveyDetails_Load(object sender, EventArgs e)
        {
            __loadDataEdit();
        }
    
        private void __loadData()
        {
            dtpEnd.MinDate = dtpStart.Value;

            var dataSource = new CrmDBConnect().myTable("SP_CrmSurvey_CRUD");
            cmbType.DataSource = dataSource;
            cmbType.DisplayMember = "SurveyName";
            cmbType.ValueMember = "Id";

            //07/06/2016 KienNk fix khi double click vào row khảo sát sẽ load được tên khảo sát vào combobox >>
            DataTable selectedvalue = dbconnect.myTable("sp_crmSurveyType", "@Id", Type);
            if (selectedvalue.Rows.Count > 0)
            {
                cmbType.SelectedValue = selectedvalue.Rows[0]["Id"].ToString();
            }
            //07/06/2016 KienNK <<
        }

        private void __loadDataEdit()
        {
            __loadData();

            if (!IsAdd)
            {
                txtName.Text = Name;
                txtPointReward.Text = PointReward;
                txtPointCard.Text = PointCard;
                txtMinutes.Text = Time;
                txtObject.Text = Object;
                dtpStart.Value = dateStart;
                dtpEnd.Value = dateEnd;
              //  cmbType.SelectedValue = Type;
                chkActive.Checked = Active;
                chkIsSurvey.Checked = IsSurvey;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.MinDate = dtpStart.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(txtName, txtPointReward, txtMinutes)) return;

            var flag = IsAdd ? 0 : 1;
            var message = IsAdd ? Messages.Create : Messages.Update;

            try
            {
                CrmDBConnect.RunQuery("SP_CrmSurvey_Update", "@SurveyName", txtName.Text.Trim(), "@SurveyPointReward", txtPointReward.Text.Trim(), "@SurveyPointCard", txtPointCard.Text.Trim(),
                    "@SurveyTime", txtMinutes.Text.Trim(), "@SurveyStart", dtpStart.Value, "@SurveyEnd", dtpEnd.Value,
                    "@SurveyObject", txtObject.Text.Trim(), "@Active", chkActive.Checked, "@IsSurvey", chkIsSurvey.Checked, "@SurveyType", Convert.ToString(cmbType.SelectedValue),
                    "@Id", Id, "@flag", flag);

                MessageBox.Show(message, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                    CrmDBConnect.RunQuery("SP_CrmSurvey_CRUD", "@Id", Id, "@flag", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 2016/06/06 NguyenNT Fix lỗi nhập được chữ >>>
        private void txtPointReward_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPointCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        // 2016/06/06 NguyenNT <<<
    }
}
