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
    public partial class frmSelectCampaign : Form
    {
        //public bool tabPage=false;//false: email, true: sms
        #region field
        private int dateRange = 3;
        public  int _selectedCampain = 0;
        public string _selectedCampaingName = "";
        public int start_age;
        public int end_age;
        public int job_id;
        public int area_id;
        public int templateId;
        public int tempateSmsId;
        #endregion
        /// <summary>
        /// ctor
        /// </summary>
        public frmSelectCampaign()
        {
            InitializeComponent();
        }
        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        /// <summary>
        /// load campain type
        /// </summary>
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
        /// load data and search data
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="campainTypeId"></param>
        /// <param name="review"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void LoadData(string keyword="",int campainTypeId=0,bool review=false,DateTime? start =null,DateTime? end=null) {

            var dataSource = new CrmDBConnect().myTable("CRM_Campaign_CRUD", "@CampaignName", keyword, "@CampaignType_Id", campainTypeId, "@Review", review, "@DateFrom", start, "@DateTo", end);
            dgvCampaign.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvCampaign.DataSource = binSource;
        }
        /// <summary>
        /// form load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSelectCampaign_Load(object sender, EventArgs e)
        {
            LoadCampaignType();
            LoadData();
            var now = DateTime.Now;
            dtpStart.Value = now.AddMonths((-1) * dateRange);
            dtpStart.Value = now.AddMonths((1) * dateRange);
            
        }
        /// <summary>
        /// search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var key = txtCampaignSearch.Text.Trim();
            var cbType=Convert.ToInt32(cbCampaignType.SelectedValue);
            var start = dtpStart.Value;
            var end = dtpEnd.Value;
            LoadData(key,cbType,false,start,end);
        }
        /// <summary>
        /// copy button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            _selectedCampain = Convert.ToInt32(dgvCampaign.CurrentRow.Cells["Id"].Value);
            _selectedCampaingName = dgvCampaign.CurrentRow.Cells["CampaignName"].Value.ToString();
            start_age = Convert.ToInt32(dgvCampaign.CurrentRow.Cells["AgeFrom"].Value);
            end_age = Convert.ToInt32(dgvCampaign.CurrentRow.Cells["AgeTo"].Value);
            area_id = Convert.ToInt32(dgvCampaign.CurrentRow.Cells["AreaId"].Value);
            job_id = Convert.ToInt32(dgvCampaign.CurrentRow.Cells["JobId"].Value);
            templateId = Convert.ToInt32(dgvCampaign.CurrentRow.Cells["TemplateEmailId"].Value);
            tempateSmsId = Convert.ToInt32(dgvCampaign.CurrentRow.Cells["TemplateSMSId"].Value);
            this.Dispose();
            this.Close();
        }

      

        

      
    }
}
