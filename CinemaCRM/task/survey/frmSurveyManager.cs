using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CinemaCRM.task.survey
{
    public partial class frmSurveyManager : Form
    {
        private static DataTable _dataSource;
        private static BindingSource _bindingSource;

        public frmSurveyManager()
        {
            InitializeComponent();
        }

        private void frmSurveyManager_Load(object sender, EventArgs e)
        {
            __loadData();
            __loadDataSearch();
        }

        public void __loadData()
        {
            _dataSource = new CrmDBConnect().myTable("SP_CrmSurvey_CRUD");
            dgvSurveyManager.AutoGenerateColumns = false;
            dgvSurveyManager.DataSource = _dataSource;
        }

        private void __loadDataSearch()
        {
            var dataSource = new CrmDBConnect().myTable("SP_CrmSurvey_CRUD");
            if (dataSource.Rows.Count > 0)
            {
                __setComboBox(dataSource, cmbSurveryType);
            }
        }

        private void dgvSurveyManager_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void __setComboBox(DataTable dataTable, ComboBox comboBox)
        {
            var newRow = dataTable.Rows.Add();
            newRow["Id"] = 0;
            newRow["SurveyName"] = "Tất cả";

            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "SurveyName";
            comboBox.ValueMember = "Id";
            comboBox.SelectedValue = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmSurveyDetails { IsAdd = true };
            frm.ShowDialog();
            __loadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //06/07/2016 fix chưa check null trong dgv
            if (dgvSurveyManager.Rows.Count > 0)
            {
                //06/07/2016  KienNK fix lỗi click sửa khảo sát hiển thị object , time lên textbox >>>>>>>
                var frm = new frmSurveyDetails
                {
                    Id = dgvSurveyManager.CurrentRow.Cells["colId"].Value.ToString(),
                    Name = dgvSurveyManager.CurrentRow.Cells["colSurveyName"].Value.ToString(),
                    Type = Convert.ToInt32(dgvSurveyManager.CurrentRow.Cells["TypeId"].Value.ToString()),
                    PointReward = dgvSurveyManager.CurrentRow.Cells["colSurveyPointReward"].Value.ToString(),
                    PointCard = dgvSurveyManager.CurrentRow.Cells["colSurveyPointCard"].Value.ToString(),
                    Time = dgvSurveyManager.CurrentRow.Cells["SurveyTime"].Value.ToString(),
                    Object = dgvSurveyManager.CurrentRow.Cells["SurveyObject"].Value.ToString(),
                    dateStart = Convert.ToDateTime(dgvSurveyManager.CurrentRow.Cells["colSurveyStart"].Value),
                    dateEnd = Convert.ToDateTime(dgvSurveyManager.CurrentRow.Cells["colSurveyEnd"].Value),
                    Active = Convert.ToBoolean(dgvSurveyManager.CurrentRow.Cells["colActiveId"].Value),
                    IsAdd = false
                };
                // 06/07/2016 KienNK <<<<<<<<<
                frm.ShowDialog();
                __loadData();
            }
            else
            {
                MessageBox.Show("Hãy chọn đối tượng trong lưới dữ liệu", "Cảnh báo");
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(@"Bạn có muốn xóa khảo sát này không?", @"Cảnh báo!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    //06/07/2016 KienNK fix không xóa được khảo sát >>>
                    CrmDBConnect.RunQuery("SP_CrmSurvey_CRUD", "@Id", dgvSurveyManager.CurrentRow.Cells["colId"].Value,
                    "@flag", 1);
                    // 06/07/2016 <<<<<<<
                }

                __loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnQuestionUpdate_Click(object sender, EventArgs e)
        {
            //06/07/2016 Lucnv fix lỗi chưa check null dữ liệu trong dgv
            if (dgvSurveyManager.Rows.Count > 0)
            {
                var frm = new frmQuestionSelect
                {
                    IdSurvey = dgvSurveyManager.CurrentRow.Cells["colId"].Value.ToString()
                };

                frm.ShowDialog();
                __loadData();
            }
            else
            {
                MessageBox.Show("Hãy chọn đối tượng trong lưới dữ liệu", "Cảnh báo");
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        { 
            //06/07/2016 Lucnv fix lỗi chưa check null dữ liệu trong dgv
            if (dgvSurveyManager.Rows.Count > 0)
            {
                var frm = new frmSurveyResult();
                frm.SurveyId = dgvSurveyManager.CurrentRow.Cells["colId"].Value.ToString();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy chọn đối tượng trong lưới dữ liệu", "Cảnh báo");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = new List<string>();
            filter.Add("[SurveyName] LIKE '%" + txtSurveyName.Text.Trim() + "%'");

            if (!cmbSurveryType.SelectedValue.ToString().Equals("0"))
                filter.Add("[TypeId] = '" + cmbSurveryType.SelectedValue + "'");

            //EDIT HUNGNT 2016/03/31 >>>	
            //_bindingSource.Filter = String.Join(" AND ", filter);
            //dgvSurveyManager.DataSource = _bindingSource;
            _bindingSource = new BindingSource
            {
                DataSource = dgvSurveyManager.DataSource,
                Filter = String.Join(" AND ", filter)
            };
            dgvSurveyManager.DataSource = _bindingSource;
            //<<< EDIT HUNGNT 2016/03/31
        }

        private void dgvSurveyManager_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //06/09/2016 Lucnv fix lỗi chưa check null dữ liệu trong dgv
            if (dgvSurveyManager.Rows.Count > 0)
            {
                //06/07/2016  KienNK fix lỗi click sửa khảo sát hiển thị object , time lên textbox >>>>>>>
                var frm = new frmSurveyDetails
                {
                    Id = dgvSurveyManager.CurrentRow.Cells["colId"].Value.ToString(),
                    Name = dgvSurveyManager.CurrentRow.Cells["colSurveyName"].Value.ToString(),
                    Type = Convert.ToInt32(dgvSurveyManager.CurrentRow.Cells["TypeId"].Value.ToString()),
                    PointReward = dgvSurveyManager.CurrentRow.Cells["colSurveyPointReward"].Value.ToString(),
                    PointCard = dgvSurveyManager.CurrentRow.Cells["colSurveyPointCard"].Value.ToString(),
                    Time = dgvSurveyManager.CurrentRow.Cells["SurveyTime"].Value.ToString(),
                    Object = dgvSurveyManager.CurrentRow.Cells["SurveyObject"].Value.ToString(),
                    dateStart = Convert.ToDateTime(dgvSurveyManager.CurrentRow.Cells["colSurveyStart"].Value),
                    dateEnd = Convert.ToDateTime(dgvSurveyManager.CurrentRow.Cells["colSurveyEnd"].Value),
                    Active = Convert.ToBoolean(dgvSurveyManager.CurrentRow.Cells["colActiveId"].Value),
                    IsAdd = false
                };
                // 06/07/2016 KienNK <<<<<<<<<
                frm.ShowDialog();
                __loadData();
            }
            else
            {
                MessageBox.Show("Hãy chọn đối tượng trong lưới dữ liệu", "Cảnh báo");
            }
            //06/09/2016 Lucnv
        }
    }
}
