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
    public partial class frmCampaignPatern : Form
    {
        private string OPERATION_MODE = "UDPATE";
        private bool _IsDataLoaded = false;
        private string _PaternCode = "";
        private CrmDBConnect dbconnect = new CrmDBConnect();

        public frmCampaignPatern()
        {
            InitializeComponent();
        }

        private void frmCampaignPatern_Load(object sender, EventArgs e)
        {
            this.txtPaternNameSr.Text = "";
            this.txtPaternCode.Text = "";
            this.txtPaternString.Text = "";
            this.txtParameterCount.Text = "";

            //Hiển thị danh sách các mẫu chiến dịch khuyến mại
            this.LoadPaternList();

            _IsDataLoaded = true;
            this.dgrCampaignPatern.Focus();
        }

        private void LoadPaternList()
        {
            DataTable tblCampaignPaterns = dbconnect.myTable("SP_CrmCampaignPatern_GetAll");
            this.dgrCampaignPatern.AutoGenerateColumns = false;
            this.dgrCampaignPatern.DataSource = tblCampaignPaterns;

            if (tblCampaignPaterns.Rows.Count > 0)
            {
                _PaternCode = dgrCampaignPatern.CurrentRow.Cells["colPaternCode"].Value.ToString();
            }
        }

        private void SearchPatern(string PaternName)
        {
            DataTable tblCampaignPaterns = dbconnect.myTable("SP_CrmCampaignPatern_SearchName", "@PaternString", PaternName);
            this.dgrCampaignPatern.AutoGenerateColumns = false;
            this.dgrCampaignPatern.DataSource = tblCampaignPaterns;

            if (tblCampaignPaterns.Rows.Count > 0)
            {
                _PaternCode = dgrCampaignPatern.CurrentRow.Cells["colPaternCode"].Value.ToString();
            }
        }

        private void DisplayPaternData(string PaternCode)
        {
            if (PaternCode != "")
            {
                DataTable tblCampaignPatern = dbconnect.myTable("SP_CrmCampaignPatern_GetOne", "@PaternCode", PaternCode);
                if (tblCampaignPatern.Rows.Count > 0)
                {
                    this.txtPaternCode.Enabled = false;
                    this.txtPaternString.Enabled = false;
                    this.txtParameterCount.Enabled = false;
                    this.btnCampaignSave.Enabled = false;
                    this.btnAdd.Enabled = true;
                    this.txtPaternCode.Text = tblCampaignPatern.Rows[0]["PaternCode"].ToString();
                    this.txtPaternString.Text = tblCampaignPatern.Rows[0]["PaternString"].ToString();
                    this.txtParameterCount.Text = tblCampaignPatern.Rows[0]["ParameterCount"].ToString();
                }
            }
        }

        private void btnCampaignSearch_Click(object sender, EventArgs e)
        {
            this.SearchPatern(txtPaternNameSr.Text);
        }

        private void dgrCampaignPatern_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_IsDataLoaded)
            {
                _PaternCode = dgrCampaignPatern.CurrentRow.Cells["colPaternCode"].Value.ToString();
                DisplayPaternData(_PaternCode);
                OPERATION_MODE = "UPDATE";
            }
        }

        private void dgrCampaignPatern_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OPERATION_MODE = "ADD";
            this.txtPaternCode.Text = "";
            this.txtPaternString.Text = "";
            this.txtParameterCount.Text = "";
            this.txtPaternCode.Enabled = true;
            this.txtPaternString.Enabled = true;
            this.txtParameterCount.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnCampaignSave.Enabled = true;
            this.txtPaternCode.Focus();
        }

        private void btnCampaignSave_Click(object sender, EventArgs e)
        {
            //Kiểm tra các giá trị cần nhập và đã hợp lệ chưa
            if (txtPaternCode.Text.Trim().Replace(" ", "") == "")
            {
                MessageBox.Show("Bạn chưa nhập mã quản lý mẫu. Mã này phải là duy nhất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaternCode.Focus();
                return;
            }

            if (txtPaternString.Text.Trim().Replace(" ", "") == "")
            {
                MessageBox.Show("Bạn chưa nhập tên mẫu chiến dịch", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaternString.Focus();
                return;
            }


            if (txtParameterCount.Text.Trim().Replace(" ", "") == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng tham số. Số lượng phải là giá trị số", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaternString.Focus();
                return;
            }

            try 
            {
                //Thực hiện lưu thông tin Patern
                if (OPERATION_MODE == "ADD")
                {
                    //Thực hiện thêm mới mẫu
                    CrmDBConnect.RunQuery("SP_CrmCampaignPatern_Insert", "@PaternCode", txtPaternCode.Text, "@PaternString", txtPaternString.Text, "@ParameterCount", txtParameterCount.Text, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                }
                else
                {
                    //Thực hiện cập nhật mẫu đang có
                    CrmDBConnect.RunQuery("SP_CrmCampaignPatern_Update", "@PaternCode", txtPaternCode.Text, "@PaternString", txtPaternString.Text, "@ParameterCount", txtParameterCount.Text, "@UserName", CinemaCRM.Contanst.Contanst.UserName);
                }

                //Hiển thị lại danh sách Patern và đưa màn hình về chế độ UDPATE
                LoadPaternList();
                OPERATION_MODE = "UPDATE";
                MessageBox.Show("Cập nhật mẫu chiến dịch thành công", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cập nhật mẫu chiến dịch bị lỗi."+ "\n" + ex.Message, "Thông báo lỗi",MessageBoxButtons.OK,  MessageBoxIcon.Error);
            }
        }

        private void butCampainDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format("Bạn có chắc chắn xoá mẫu chiến dịch khuyến mại {0} không?", _PaternCode), "Cảnh báo xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            
            //Kiểm tra xem mẫu chiến dịch có đang được sử dụng hay không. Nếu đang sử dụng thì không cho phép xoá
            DataTable tblCampaignUsing = dbconnect.myTable("SP_CrmCampaignPatern_IsUsing", "@PaternCode", txtPaternCode.Text);

            if(tblCampaignUsing.Rows.Count > 0)
            {
                MessageBox.Show("Mẫu chương trình khuyến mại này dang được sử dụng. Bạn không thể xoá đi được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Thực hiện xoá và thông báo sau khi xoá
            try
            {
                if (_PaternCode != "")
                {
                    CrmDBConnect.RunQuery("SP_CrmCampaignPatern_Delete", "@PaternCode", txtPaternCode.Text);
                }
                MessageBox.Show("Xoá mẫu chiến dịch thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Hiển thị lại danh sách Patern và đưa màn hình về chế độ UDPATE
                LoadPaternList();
                OPERATION_MODE = "UPDATE";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá mẫu chiến dịch bị lỗi." + "\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCampaignClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        // 2016/06/06 NguyenNT Fix lỗi nhập được chữ >>>
        private void txtParameterCount_KeyPress(object sender, KeyPressEventArgs e)
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
