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
    public partial class frmCampaignList : Form
    {
        private bool _IsDataLoaded = false;
        private int _CampaignId = 0;
        private string _CampaignName = "";
        private CrmDBConnect dbconnect = new CrmDBConnect();

        public frmCampaignList()
        {
            InitializeComponent();
        }

        private void frmCampaignList_Load(object sender, EventArgs e)
        {
            //Hiển thị danh sách mẫu chiến dịch khuyến mại
            BindControls();

            //Thiết lập các giá trị mặc định
            this.txtCampaignName.Text = "";
            // 2016/06/06 NguyenNT Sửa lỗi phần tìm kiếm >>>
            //this.cboCampaignPatern.SelectedIndex = 0;
            //this.chkIsContinuous.Checked = true;
            //this.chkIsPeriodical.Checked = true;
            //dtpStartDateFrom.Value = DateTime.Now.AddMonths(-3);
            //dtpStartDateTo.Value = DateTime.Now;
            //dtpEndDateFrom.Value = DateTime.Now;
            //dtpEndDateTo.Value = DateTime.Now.AddMonths(3);
            // 2016/06/06 NguyenNT <<<

            //Hiển thị danh sách chương trình khuyến mại
            LoadCampaigns();
            _IsDataLoaded = true;
            this.grdCampaign.Focus();
        }

        private void BindControls()
        {
            //Binding campaign paterns
            DataTable tblPaterns = dbconnect.myTable("SP_CrmCampaignPatern_GetAll");
            if (tblPaterns.Rows.Count > 0)
            {
                DataRow rowPatern = tblPaterns.NewRow();
                rowPatern["PaternCode"] = "";
                rowPatern["PaternString"] = "Tất cả";
                tblPaterns.Rows.InsertAt(rowPatern, 0);
                // 2016/06/06 NguyenNT Sửa lỗi phần tìm kiếm >>>
                //this.cboCampaignPatern.DataSource = tblPaterns;
                //this.cboCampaignPatern.ValueMember = "PaternCode";
                //this.cboCampaignPatern.DisplayMember = "PaternString";
                // 2016/06/06 NguyenNT <<<
            }
        }

        private void LoadCampaigns()
        {
            DataTable tblCampaigns = dbconnect.myTable("SP_CrmCampaign_GetAll");
            this.grdCampaign.AutoGenerateColumns = false;
            this.grdCampaign.DataSource = tblCampaigns;

            if (tblCampaigns.Rows.Count > 0)
            {
                _CampaignId = System.Convert.ToInt32(grdCampaign.CurrentRow.Cells["colId"].Value);
                _CampaignName = grdCampaign.CurrentRow.Cells["colCampaignName"].Value.ToString();
            }
        }

        private void grdCampaign_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_IsDataLoaded)
            {
                _CampaignId = System.Convert.ToInt32(grdCampaign.CurrentRow.Cells["colId"].Value);
                // 2016/06/03 NguyenNT Lỗi hiển thị sai tên chương trình khuyến mại khi click vào button Kết thúc >>>
                _CampaignName = grdCampaign.CurrentRow.Cells["colCampaignName"].Value.ToString();
                // 2016/06/03 NguyenNT <<<
            }
        }

        private void grdCampaign_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void grdCampaign_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 2016/06/06 NguyenNT Sửa lỗi phần tìm kiếm >>>
            if (txtCampaignName.Text.Trim() == "")
            {
                DataTable tblCampaigns = dbconnect.myTable("SP_CrmCampaign_GetAll");
                this.grdCampaign.AutoGenerateColumns = false;
                this.grdCampaign.DataSource = tblCampaigns;
            }
            else
            {
                DataTable tblCampaigns = dbconnect.myTable("SP_CrmCampaign_Search", "@CampaignName", txtCampaignName.Text.Trim());
                this.grdCampaign.AutoGenerateColumns = false;
                this.grdCampaign.DataSource = tblCampaigns;
            }
            // 2016/06/06 NguyenNT <<<
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            frmCampaignDetail frmCampaignDetail = new frmCampaignDetail();
            frmCampaignDetail.OperationMode = "ADD";
            frmCampaignDetail.ShowDialog();
            this.LoadCampaigns();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_CampaignId > 0)
            {
                frmCampaignDetail frmCampaignDetail = new frmCampaignDetail();
                frmCampaignDetail.CampaignId = _CampaignId;
                frmCampaignDetail.OperationMode = "UPDATE";
                frmCampaignDetail.ShowDialog();
                this.LoadCampaigns();
            }
            else
                MessageBox.Show("Bạn chưa chọn chương trình khuyến mại để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CampaignId > 0)
                {
                    if (MessageBox.Show(String.Format("Bạn có chắc chắn muốn kết thúc chương trình khuyến mại [{0}] không?", _CampaignName), "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;

                    //Thực hiện chuyển trạng thái chương trình khuyến mại sang kết thúc
                    CrmDBConnect.RunQuery("SP_CrmCampaign_Close", "@Id", _CampaignId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                    MessageBox.Show("Đã kết thúc chương trình khuyến mại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadCampaigns();
                }
                else
                    MessageBox.Show("Bạn phải chọn một chương trình khuyến mại để kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Kết thúc chương trình khuyến mại bị lỗi. Hãy liên hệ với quản trị hệ thống để xử lý" + "\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_CampaignId <= 0)
            {
                MessageBox.Show("Bạn phải chọn một chương trình khuyến mại để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc chắn muốn xoá chương trình khuyến mại [{0}] không?", _CampaignName), "Cảnh báo xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) 
                return;

            //Thực hiện xoá và thông báo sau khi xoá, hiển thị lại danh sách chương trình
            try
            {
                CrmDBConnect.RunQuery("SP_CrmCampaign_Delete", "@Id", _CampaignId, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                MessageBox.Show("Xoá mẫu chương trình khuyến mại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCampaigns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá chương trình khuyến mại  bị lỗi. Hãy liên hệ với quản trị hệ thống để xử lý" + "\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
