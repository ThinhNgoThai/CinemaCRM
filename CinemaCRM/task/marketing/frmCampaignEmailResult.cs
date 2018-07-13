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
    public partial class frmCampaignEmailResult : Form
    {
        public frmCampaignEmailResult()
        {
            InitializeComponent();
        }
        private int dateMonthRange = 3;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }







        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCampaignType()
        {
            DataTable dtCampaign = new CrmDBConnect().myTable("SP_CrmCampaignType_CRUD");
            if (dtCampaign.Rows.Count > 0)
            {
                DataRow row = dtCampaign.NewRow();
                row["Id"] = "0";
                row["CampaignName"] = "Chọn loại chiến dịch";
                dtCampaign.Rows.InsertAt(row, 0);

                // Combox form
                cbCampaignType.DisplayMember = "CampaignName";
                cbCampaignType.ValueMember = "Id";
                cbCampaignType.DataSource = dtCampaign;
                cbCampaignType.SelectedIndex = 0;

                // Combox search
                cbCampaignType.DisplayMember = "CampaignName";
                cbCampaignType.ValueMember = "Id";
                cbCampaignType.DataSource = dtCampaign;
                cbCampaignType.SelectedIndex = 0;

            }
        }
        /// <summary>
        /// load data (connect to database ) and search button
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="typeId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void LoadData(DateTime start, DateTime end, string keyword = "", int typeId = 0)
        {
            var tblCrmJob = new CrmDBConnect().myDataset("SP_CrmCampaignEmailResult_Search", "@Keywords", keyword, "@StartDate", start.ToString("yyyy-MM-dd"), "@EndDate", end.ToString("yyyy-MM-dd"));
            dgEmailResult.AutoGenerateColumns = false;
            if (tblCrmJob.Tables.Count > 0)
            {
                var binSource = new BindingSource { DataSource = tblCrmJob.Tables[0] };
                bindingNavigator.BindingSource = binSource;
                dgEmailResult.DataSource = binSource;
                var total = tblCrmJob.Tables[1].Rows[0].Field<int>(0);
                var ok = tblCrmJob.Tables[2].Rows[0].Field<int>(0);
                txtOk.Text = ok.ToString();
                txtTotal.Text = total.ToString();
                txtNotOk.Text = (total - ok).ToString();
            }
        }
        /// <summary>
        /// load data (connect to database ) and search button
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="typeId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void LoadData()
        {
            var tblCrmJob = new CrmDBConnect().myDataset("SP_CrmCampaignEmailResult_Search", "@Keywords", "", "@StartDate", DateTime.Now.ToString("yyyy-MM-dd"), "@EndDate", DateTime.Now.ToString("yyyy-MM-dd"));
            dgEmailResult.AutoGenerateColumns = false;
            if (tblCrmJob.Tables.Count > 0)
            {
                var binSource = new BindingSource { DataSource = tblCrmJob.Tables[0] };
                bindingNavigator.BindingSource = binSource;
                dgEmailResult.DataSource = binSource;
                var total = tblCrmJob.Tables[1].Rows[0].Field<int>(0);
                var ok = tblCrmJob.Tables[2].Rows[0].Field<int>(0);
                txtOk.Text = ok.ToString();
                txtTotal.Text = total.ToString();
                txtNotOk.Text = (total - ok).ToString();
            }
        }
        /// <summary>
        /// form first load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCampaignEmailResult_Load(object sender, EventArgs e)
        {
            LoadCampaignType();
            LoadData();
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }
        /// <summary>
        /// search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var key = txtKeywordCampain.Text.Trim();
            var cTypeId = Convert.ToInt32(cbCampaignType.SelectedValue);
            var start = dtpStart.Value;
            var end = dtpEnd.Value;
            LoadData(start, end, key, cTypeId);
        }
        /// <summary>
        /// cell formating event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgEmailResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgEmailResult.Columns[e.ColumnIndex].Name.Equals("SendOK"))
            {
                // Ensure that the value is a string.
                String stringValue = e.Value.ToString();
                if (stringValue == null) return;

                e.Value = stringValue == "1" ? "Đã gửi" : "Chưa gửi";
            }
        }
    }
}
