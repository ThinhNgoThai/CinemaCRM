using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.task.survey
{
    public partial class frmQuestionDetails : Form
    {
        public bool IsAdd = true;
        public bool IsDisabled = false;
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string QuestionType { get; set; }
        public int QuestionGroup { get; set; }
        public string QuestionContent { get; set; }

        public frmQuestionDetails()
        {
            InitializeComponent();
        }

        private void frmQuestionDetails_Load(object sender, EventArgs e)
        {
            if (IsAdd) __loadData();
            else __loadDataEdit();
        }

        #region Các method hỗ trợ
        private void __loadDataEdit()
        {
            __loadData();
            rtxtQuestionName.Text = QuestionName;
            cmbQuestionType.SelectedValue = QuestionType;
            cmbQuestionGroup.SelectedValue = QuestionGroup;

            var arrayAnswers = QuestionContent.Split(Convert.ToChar("|"));
            lbAnswers.Items.AddRange(arrayAnswers);

            if (IsDisabled) __disableAll();
        }

        private void __loadData()
        {
            var dataSet = new CrmDBConnect().myDataset("SP_CrmSurvey_QuestionDetail");
            if (dataSet.Tables != null && dataSet.Tables.Count > 0)
            {
                __setComboBox(dataSet.Tables[0], cmbQuestionType);
                __setComboBox(dataSet.Tables[1], cmbQuestionGroup);
                lbAnswers.Items.Clear();
            }
        }

        private void __setComboBox(DataTable dataTable, ComboBox comboBox)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "Id";
        }

        private void __disableAll()
        {
            rtxtQuestionName.ReadOnly = true;
            cmbQuestionGroup.Enabled = false;
            cmbQuestionType.Enabled = false;
            nudAnswers.Enabled = false;
            lbAnswers.Enabled = false;
            __disableBtn(btnAdd, btnSave, butDelete);
        }

        private void __disableBtn(params Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.Enabled = false;
            }
        }

        private void __disableWhenSelected(params string[] strings)
        {
            if (strings.Contains(cmbQuestionType.SelectedValue.ToString()))
            {
                nudAnswers.Enabled = false;
                btnAdd.Enabled = false;
                lbAnswers.Enabled = false;
            }
            else
            {
                nudAnswers.Enabled = true;
                btnAdd.Enabled = true;
                lbAnswers.Enabled = true;
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmAnswerAdd();

            for (var i = 1; i <= nudAnswers.Value; i++)
            {
                frm.Text = @"Thêm câu trả lời " + i;
                frm.Content = "";
                frm.ShowDialog();
                lbAnswers.Items.Add(frm.Content);
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            var selectedItems = lbAnswers.SelectedItems;

            if (lbAnswers.SelectedIndex == -1) return;
            for (var i = selectedItems.Count - 1; i >= 0; i--)
                lbAnswers.Items.Remove(selectedItems[i]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Public.IsNullTextBox(rtxtQuestionName)) return;

            var listAnswers = lbAnswers.Items.Cast<string>().ToList();
            var answers = String.Join("|", listAnswers);
            var flag = IsAdd ? 1 : 2;
            var message = IsAdd ? Messages.Create : Messages.Update;

            try
            {
                CrmDBConnect.RunQuery("SP_CrmSurvey_QuestionDetail", "@Name", rtxtQuestionName.Text,
                    "@Group", cmbQuestionGroup.SelectedValue.ToString(), "@Type", cmbQuestionType.SelectedValue.ToString(),
                    "@Count", lbAnswers.Items.Count, "@Content", answers, "@Id", Id, "@flag", flag);

                MessageBox.Show(message, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dispose();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Messages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblComment.Text = ((DataRowView) (cmbQuestionType.SelectedItem)).Row.ItemArray[2].ToString();
            lbAnswers.Items.Clear();
            __disableWhenSelected("Textbox", "Date");
        }
    }
}
