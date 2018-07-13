using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace CinemaCRM.task.marketing
{
    public partial class frmExcelKey : Form
    {
        private string _operationMode = "UPDATE";
        private int _selectedRowIndex = 0;
        private int _id;
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel0710ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1};'";

        public frmExcelKey()
        {
            InitializeComponent();
        }
           /// <summary>
           /// close button click
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
   
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// add button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAdd_Click(object sender, EventArgs e)
        {
            frmTemplate frm = new frmTemplate();
            frm.tabPage = true;
            frm.Show();
        }
           /// <summary>
           /// select button click
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>

        private void btnSelect_Click(object sender, EventArgs e)
        {
            frmSelectCampaign frm = new frmSelectCampaign();
            frm.ShowDialog();
        }
        /// <summary>
        /// add button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            EnabedText(true, true);
            ClearText(string.Empty, string.Empty);
            EnableBtn(false, false, true, false);
        }

        //Bật tắt các nút
        private void EnableBtn(bool btnAdd, bool btnEdit, bool btnSave, bool btnDelete)
        {
            this.btnAdd.Enabled = btnAdd;
            this.btnEdit.Enabled = btnEdit;
            this.btnSave.Enabled = btnSave;
            this.btnDelete.Enabled = btnDelete;
        }
        /// <summary>
        /// enable or disable text box
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void EnabedText(bool key, bool value)
        {
            txtKey.Enabled = key;
            txtValue.Enabled = value;           
        }

        /// <summary>
        /// clear all text box to empty
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void ClearText(string key, string value)
        {
            txtKey.Text = "";
            txtValue.Text = "";            
        }
        /// <summary>
        /// edit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            EnabedText(true, true);          
            EnableBtn(true, true, true, false);
        }

      /// <summary>
      /// import excel click
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            openFileDialog1.ShowDialog();

        }
        /// <summary>
        /// delete button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(@"Bạn thực sự muốn xóa tâp khóa này?", @"Chú ý!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("CRM_Care_KeySMS", "@Id", _id, "@flag", 3);
            LoadData();
        }
        /// <summary>
        /// search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dataSource = new CrmDBConnect().myTable("CRM_Care_KeySMS", "@Key", txtSearch.Text.Trim(), "@Value", txtSearch.Text);
            dgvSMS.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = dataSource };
            bindingNavigator.BindingSource = binSource;
            dgvSMS.DataSource = binSource;
        }
        /// <summary>
        /// save button click 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKey.Text.Trim() == "")
            {
                MessageBox.Show(@"Chưa nhập key", @"Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtValue.Text.Trim() == "")
            {
                MessageBox.Show(@"Chưa nhập giá trị", @"Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("CRM_Care_KeySMS", "@Key", txtKey.Text.Trim(), "@Value", txtValue.Text, "@flag", 1);
                LoadData();
                dgvSMS.Enabled = true;
                MessageBox.Show(@"Thêm mới thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("CRM_Care_KeySMS", "@Id", _id, "@Key", txtKey.Text.Trim(), "@Value", txtValue.Text, "@flag", 2);
                LoadData();
                dgvSMS.Rows[0].Selected = false;
                dgvSMS.Rows[_selectedRowIndex].Selected = true;
                MessageBox.Show(@"Sửa thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableBtn(true, true, false, true);
            }
        }
        /// <summary>
        /// load data connect to database
        /// </summary>
        private void LoadData()
        {
            var tblCrmJob = new CrmDBConnect().myTable("CRM_Care_KeySMS");
            dgvSMS.AutoGenerateColumns = false;

            var binSource = new BindingSource { DataSource = tblCrmJob };
            bindingNavigator.BindingSource = binSource;
            dgvSMS.DataSource = binSource;

            EnabedText(false, false);
        }
        /// <summary>
        /// load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExcelKey_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// cell enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSMS_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSMS.CurrentRow == null) return;
            _selectedRowIndex = dgvSMS.CurrentRow.Index;
            _id = Convert.ToInt32(dgvSMS.CurrentRow.Cells["Id"].Value);
            txtKey.Text = dgvSMS.CurrentRow.Cells["Key"].Value.ToString();
            txtValue.Text = dgvSMS.CurrentRow.Cells["Value"].Value.ToString();         
            EnabedText(true, true);
            EnableBtn(true, true, false, true);
        }
        /// <summary>
        /// dialog open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);       
            string conStr, sheetName;

            conStr = string.Empty;
            // set version office
            switch (extension)
            {

                case ".xls": //Excel 97-03
                    conStr = string.Format(Excel03ConString, filePath, "YES");
                    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel0710ConString, filePath, "YES");
                    break;
            }

            //Get the name of the First Sheet.
            // get value
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    con.Close();
                }
            }

            // check value and insert data 
            //Read Data from the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandText = "SELECT Id,[Key],[Value] From [" + sheetName + "]";
                        cmd.Connection = con;
                        con.Open();
                        oda.SelectCommand = cmd;
                        oda.Fill(dt);
                        con.Close();

                        if (_operationMode == "ADD")
                        {
                            var tblCrmJob = new CrmDBConnect().myTable("CRM_Care_KeySMS");
                            foreach (DataRow row in dt.Rows) // Loop over the rows.
	                        {                            
                                // Presuming the DataTable has a column named Date.
                                DataRow[] foundRows;
                                string str=row.ItemArray[1].ToString();
                                foundRows =  tblCrmJob.Select("Key like '%" + str +"%'");
                                if (foundRows.Length <0)
                                {
                                    CrmDBConnect.RunQuery("CRM_Care_KeySMS", "@Key", row.ItemArray[1].ToString(), "@Value", row.ItemArray[2].ToString(), "@flag", 1);
                                }
	                        }
                        }
                    }
                }
            }

            // message
            LoadData();
            dgvSMS.Enabled = true;
            MessageBox.Show(@"Thêm mới thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            EnableBtn(true, true, false, true);
        }

    }
}
