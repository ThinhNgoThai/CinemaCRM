using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CinemaCRM.task.survey
{
    public partial class frmQuestionManager : Form
    {
        private static DataTable _dataSource;
        private static BindingSource _bindingSource;

        public frmQuestionManager()
        {
            InitializeComponent();
        }

        private void frmQuestionManager_Load(object sender, EventArgs e)
        {
            __loadData();
            __loadDataSearch();
        }

        #region Các method hỗ trợ
        private void __loadData()
        {
            _dataSource = new CrmDBConnect().myTable("SP_CrmSurvey_QuestionManager");

            _bindingSource = new BindingSource { DataSource = _dataSource };
            bindingNavigator.BindingSource = _bindingSource;
            dgbQuestionManager.DataSource = _bindingSource;
        }

        private void __loadDataSearch()
        {
            var dataSet = new CrmDBConnect().myDataset("SP_CrmSurvey_QuestionDetail");
            try
            {
                __setComboBox(dataSet.Tables[0], cmbQuestionType);
                __setComboBox(dataSet.Tables[1], cmbQuestionGroup);
            }
            catch { }
            
            
        }

        private void __setComboBox(DataTable dataTable, ComboBox comboBox)
        {
            var newRow = dataTable.Rows.Add();
            newRow["Id"] = 0;
            newRow["Name"] = "Tất cả";

            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
            comboBox.SelectedValue = 0;
        }  
        #endregion

        private void butAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmQuestionDetails { IsAdd = true };
            frm.ShowDialog();
            __loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var frm = new frmQuestionDetails
            {
                IsAdd = false,
                Id = Convert.ToInt32(dgbQuestionManager.CurrentRow.Cells["Id"].Value.ToString()),
                QuestionName = dgbQuestionManager.CurrentRow.Cells["QuestionName"].Value.ToString(),
                QuestionType = dgbQuestionManager.CurrentRow.Cells["TypeId"].Value.ToString(),
                QuestionGroup = Convert.ToInt32(dgbQuestionManager.CurrentRow.Cells["GroupId"].Value.ToString()),
                QuestionContent = dgbQuestionManager.CurrentRow.Cells["Content"].Value.ToString()
            };
            frm.ShowDialog();
            __loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;

                var id = Convert.ToInt32(dgbQuestionManager.CurrentRow.Cells["Id"].Value.ToString());
                CrmDBConnect.RunQuery("SP_CrmSurvey_QuestionManager", "@Id", id, "@flag", 1);

                __loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = new List<string>();

            if (!cmbQuestionGroup.SelectedValue.ToString().Equals("0"))
                filter.Add("[GroupId] = '" + cmbQuestionGroup.SelectedValue + "'");

            if (!cmbQuestionType.SelectedValue.ToString().Equals("0"))
                filter.Add("[TypeId] = '" + cmbQuestionType.SelectedValue + "'");

            _bindingSource.Filter = String.Join(" AND ", filter);
            bindingNavigator.BindingSource = _bindingSource;
            dgbQuestionManager.DataSource = _bindingSource;
        }

        private void dgbQuestionManager_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var frm = new frmQuestionDetails
            {
                IsAdd = false,
                Id = Convert.ToInt32(dgbQuestionManager.CurrentRow.Cells["Id"].Value.ToString()),
                QuestionName = dgbQuestionManager.CurrentRow.Cells["QuestionName"].Value.ToString(),
                QuestionType = dgbQuestionManager.CurrentRow.Cells["TypeId"].Value.ToString(),
                QuestionGroup = Convert.ToInt32(dgbQuestionManager.CurrentRow.Cells["GroupId"].Value.ToString()),
                QuestionContent = dgbQuestionManager.CurrentRow.Cells["Content"].Value.ToString()
            };
            frm.ShowDialog();
            __loadData();
        }
    }
}
