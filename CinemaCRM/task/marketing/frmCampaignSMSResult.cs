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
    public partial class frmCampaignSMSResult : Form
    {
        public frmCampaignSMSResult()
        {
            InitializeComponent();
        }

        private int dateMonthRange = 3;
       
    

       
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCampaignSMSResult_Load(object sender, EventArgs e)
        {
            LoadCampaignType();
            LoadData();
            var now = DateTime.Now;
            dtpStart.Value = now.AddMonths((-1) * dateMonthRange);
            dtpEnd.Value = now.AddMonths((1) * dateMonthRange);
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

        private void LoadData(string keyword = "", int typeId = 0, DateTime? start = null, DateTime? end = null)
        {
            //var tblCrmJob = new DBConnect().myDataset("SP_CrmCampaignEmailResult_Search", "@Keywords", keyword, "@CompainType_Id", typeId, "@StartDate", start, "@EndDate", end);
            //dgList.AutoGenerateColumns = false;

            //if (tblCrmJob.Tables.Count > 0)
            //{
            //    var binSource = new BindingSource { DataSource = tblCrmJob.Tables[0] };
            //    bindingNavigator1.BindingSource = binSource;
            //    dgList.DataSource = binSource;
            //    var total = tblCrmJob.Tables[1].Rows[0].Field<int>(0);
            //    var ok = tblCrmJob.Tables[2].Rows[0].Field<int>(0);
            //    txtOk.Text = ok.ToString();
            //    txtTotal.Text = total.ToString();
            //    txtNotOk.Text = (total - ok).ToString();
            //}

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var key = txtKeywordCampain.Text.Trim();
            var cTypeId = Convert.ToInt32(cbCampaignType.SelectedValue);
            var start = dtpStart.Value;
            var end = dtpEnd.Value;
            LoadData(key, cTypeId, start, end);
        }

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgList.Columns[e.ColumnIndex].Name.Equals("SendOK"))
            {
                // Ensure that the value is a string.
                String stringValue = e.Value.ToString();
                if (stringValue == null) return;

                e.Value = stringValue == "1" ? "Đã gửi" : "Chưa gửi";
            }
        }
    }
}
