using System.Windows.Forms;
using System;
using System.Data;

namespace CinemaCRM.task.careCustomer
{
    public partial class frmPointBonus : Form
    {
        public frmPointBonus()
        {
            InitializeComponent();
        }
        /// <summary>
        /// close button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// first load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPointBonus_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// save button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //2016/06/06 ThienNQ( Edited)
            try
            {
                var update = CrmDBConnect.RunQuery("SP_CrmPoint_CRUD",
                    "@PointChange", chkActive.Checked,
                    "@PointMin", decimal.Parse(txtMinPoint.Text.Trim()),
                    "@PointCard", decimal.Parse(txtPointCardRegister.Text.Trim()),
                    "@PointRegister", decimal.Parse(txtPointRewardRegister.Text.Trim()),
                    "@UpdatedUser", Contanst.Contanst.UserName,
                    // 2016/12/05: NguyenNT cập nhật phần tính điểm thưởng và tích lũy dựa trên Mức chi tiêu. >>>
                    // "@flag", 1);
                    "@flag", 1,
                    "@PointLevel", decimal.Parse(txtVndPerPoint.Text.Trim()));
                    // 2016/12/05: NguyenNT cập nhật phần tính điểm thưởng và tích lũy dựa trên Mức chi tiêu. <<<
                if (update) MessageBox.Show(@"Cập nhật thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error when save data");
            }
        }
        /// <summary>
        /// load data
        /// </summary>
        private void LoadData()
        {

            var tblPointConfig = new CrmDBConnect().myTable("SP_CrmPoint_CRUD", "@flag", 0);
            if (tblPointConfig.Rows.Count > 0)
            {
                //2016/06/06 ThienNQ( Edited)
                try
                {
                    txtName.Text = tblPointConfig.Rows[0]["PointName"].ToString();
                    chkActive.Checked = Convert.ToBoolean(tblPointConfig.Rows[0]["PointChange"]);
                    txtMinPoint.Text = String.Format("{0:0.#}", tblPointConfig.Rows[0]["PointMin"]);
                    //2016/06/06 ThienNQ( Deleted) Không có trường tương ứng trong table CRM_Point
                    //txtVndPerPoint.Text = tblPointConfig.Rows[0]["VndPerPoint"].ToString();
                    txtPointCardRegister.Text = tblPointConfig.Rows[0]["PointCard"].ToString();
                    txtPointRewardRegister.Text = tblPointConfig.Rows[0]["PointRegister"].ToString();
                    // 2016/12/05: NguyenNT cập nhật phần tính điểm thưởng và tích lũy dựa trên Mức chi tiêu. >>>
                    txtVndPerPoint.Text = tblPointConfig.Rows[0]["PointLevel"].ToString();
                    // 2016/12/05: NguyenNT cập nhật phần tính điểm thưởng và tích lũy dựa trên Mức chi tiêu. <<<
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error when Load");
                }
            }
        }
        /// <summary>
        /// validate text double
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateTextDouble(object sender, EventArgs e)
        {
            Exception X = new Exception();
            TextBox T = (TextBox)sender;
            try
            {
                double x = double.Parse(T.Text);
                //Customizing Condition (Only numbers larger than or 
                //equal to zero are permitted)
                if (x < 0) // || T.Text.Contains(','))
                    throw X;
            }
            catch (Exception)
            {
                try
                {
                    int CursorIndex = T.SelectionStart - 1;
                    T.Text = T.Text.Remove(CursorIndex, 1);
                    //Align Cursor to same index
                    T.SelectionStart = CursorIndex;
                    T.SelectionLength = 0;
                }
                catch (Exception) { }
            }
        }
        // 2016/12/05: NguyenNT cập nhật phần tính điểm thưởng và tích lũy dựa trên Mức chi tiêu. >>>
        private void txtVndPerPoint_TextChanged(object sender, EventArgs e)
        {
            validateTextDouble(sender, e);
        }

        private void txtPointCardRegister_TextChanged(object sender, EventArgs e)
        {
            validateTextDouble(sender, e);
        }
        // 2016/12/05: NguyenNT cập nhật phần tính điểm thưởng và tích lũy dựa trên Mức chi tiêu. <<<
    }
}
