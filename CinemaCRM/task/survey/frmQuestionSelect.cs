using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CinemaCRM.task.survey
{
    public partial class frmQuestionSelect : Form
    {
        public string IdSurvey { get; set; }
        private int _index;
        private static List<string> _questionIds;
        private static CurrencyManager _currencyManager;
        private static BindingSource _bindingSource;


        public frmQuestionSelect()
        {
            InitializeComponent();
        }

        private void frmQuestionSelect_Load(object sender, EventArgs e)
        {
            __loadData();
            __loadQuestionSelect();
            __loadOldData();
        }

        #region Các method hỗ trợ
        private void __loadData()
        {
            var dataSet = new CrmDBConnect().myDataset("SP_CrmSurvey_QuestionDetail");
            if (dataSet.Tables != null && dataSet.Tables.Count > 0)
            {
                __setComboBox(dataSet.Tables[0], cmbQuestionType);
                __setComboBox(dataSet.Tables[1], cmbQuestionGroup);
                _questionIds = new List<string>();
            }
        }

        private void __loadQuestionSelect()
        {
            var dataSource = new CrmDBConnect().myTable("SP_CrmSurvey_QuestionManager");
            _bindingSource = new BindingSource { DataSource = dataSource };
            dgvAreaSelect.AutoGenerateColumns = false;
            dgvAreaSelect.DataSource = _bindingSource;
            _currencyManager = (CurrencyManager)BindingContext[dgvAreaSelect.DataSource];
        }

        private void __loadOldData()
        {
            var oldDataTable = new CrmDBConnect().myTable("SP_CrmSurvey_SurveyQuestion", "@Id", IdSurvey);
            if (oldDataTable.Rows.Count <= 0) return;

            foreach (DataRow oldData in oldDataTable.Rows)
            {
                var index = dgvSurveyQuestion.Rows.Add();
                dgvSurveyQuestion.Rows[index].Cells["Id_S"].Value = oldData["Id"];
                dgvSurveyQuestion.Rows[index].Cells["QuestionName_S"].Value = oldData["QuestionName"];
            }
            //dgvSurveyQuestion.DataSource = oldDataTable;
            __checkExistQuestion();
        }

        private void __checkExistQuestion()
        {
            _currencyManager.SuspendBinding();
            foreach (DataGridViewRow question in dgvSurveyQuestion.Rows)
            {
                _questionIds.Add(question.Cells["Id_S"].Value.ToString());
            }

            foreach (DataGridViewRow questionSelect in dgvAreaSelect.Rows)
            {
                if (_questionIds.Contains(questionSelect.Cells["Id"].Value.ToString()))
                    questionSelect.Visible = false;
            }
            _currencyManager.ResumeBinding();
        }

        private void __setComboBox(DataTable dataTable, ComboBox comboBox)
        {
            var newRow = dataTable.Rows.Add();
            newRow["Id"] = 0;
            newRow["Name"] = "Tất cả";

            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
        }
        #endregion

        private void btnDetail_Click(object sender, EventArgs e)
        {
            //Check CurentRow = null
            if (dgvAreaSelect.Rows.Count <= 0 || dgvAreaSelect.CurrentRow == null) return;

            var frm = new frmQuestionDetails
            {
                IsAdd = false,
                IsDisabled = true,
                Id = Convert.ToInt32(dgvAreaSelect.CurrentRow.Cells["Id"].Value),
                QuestionName = dgvAreaSelect.CurrentRow.Cells["QuestionName"].Value.ToString(),
                QuestionType = dgvAreaSelect.CurrentRow.Cells["TypeId"].Value.ToString(),
                QuestionGroup = Convert.ToInt32(dgvAreaSelect.CurrentRow.Cells["GroupId"].Value.ToString()),
                QuestionContent = dgvAreaSelect.CurrentRow.Cells["Content"].Value.ToString()
            };
            frm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvAreaSelect.Rows.Count <= 0) return;
            _currencyManager.SuspendBinding();
            foreach (DataGridViewRow question in dgvAreaSelect.Rows)
            {
                var _checked = question.Cells["ChkQuestion"].Value != null && (bool)question.Cells["ChkQuestion"].Value;
                if (_checked)
                {
                    _index = dgvSurveyQuestion.Rows.Add();
                    dgvSurveyQuestion.Rows[_index].Cells["Id_S"].Value = question.Cells["Id"].Value;
                    dgvSurveyQuestion.Rows[_index].Cells["QuestionName_S"].Value = question.Cells["QuestionName"].Value;
                    dgvSurveyQuestion.Rows[_index].Cells["GroupId_S"].Value = question.Cells["GroupId"].Value;
                    dgvSurveyQuestion.Rows[_index].Cells["TypeId_S"].Value = question.Cells["TypeId"].Value;
                    dgvSurveyQuestion.Rows[_index].Cells["Content_S"].Value = question.Cells["Content"].Value;


                    question.Cells["ChkQuestion"].Value = false;
                    question.Visible = false;
                }
            }
            _currencyManager.ResumeBinding();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var listQuestion = new List<DataGridViewRow>();

            foreach (DataGridViewRow question in dgvSurveyQuestion.Rows)
            {
                var _checked = question.Cells["ChkQuestion_S"].Value != null && (bool)question.Cells["ChkQuestion_S"].Value;
                if (_checked) listQuestion.Add(question);
            }

            foreach (var ques in listQuestion)
            {
                foreach (DataGridViewRow row in dgvAreaSelect.Rows)
                {
                    if (row.Cells["Id"].Value.ToString().Equals(ques.Cells["Id_S"].Value.ToString()))
                        row.Visible = true;
                }

                dgvSurveyQuestion.Rows.Remove(ques);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count = 0;
            _questionIds.Clear();
            foreach (DataGridViewRow question in dgvSurveyQuestion.Rows)
            {
                _questionIds.Add(question.Cells["Id_S"].Value.ToString());
                count++;
            }

            try
            {
                CrmDBConnect.RunQuery("SP_CrmSurvey_SurveyQuestion", "@Id", IdSurvey, "@Questions", String.Join(",", _questionIds), "@Count", count, "@flag", 1);
                MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = new List<string>();

            if (!cmbQuestionGroup.SelectedValue.ToString().Equals("0"))
                filter.Add("[GroupId] = '" + cmbQuestionGroup.SelectedValue + "'");

            if (!cmbQuestionType.SelectedValue.ToString().Equals("0"))
                filter.Add("[TypeId] = '" + cmbQuestionType.SelectedValue + "'");

            _bindingSource.Filter = String.Join(" AND ", filter);
            __checkExistQuestion();
        }

        private void frmQuestionSelect_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
