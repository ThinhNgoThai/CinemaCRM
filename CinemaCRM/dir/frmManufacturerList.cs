using System;
using System.Data;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmManufacturerList : Form
    {
        private String _operationMode = "UPDATE";
        private int _selectedRowIndex;

        int _manufacturerId;
        private readonly CrmDBConnect crmdbconnect = new CrmDBConnect();
        private readonly TicketDBConnect ticketdbconnect = new TicketDBConnect();

        public frmManufacturerList()
        {
            InitializeComponent();
        }

        private void frmManufacturerList_Load(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            LoadManufacturers();
        }

        private void LoadManufacturers()
        {
            DataTable tblManufacturers = ticketdbconnect.myTable("SP_Manufacturer_GetAll");
            grdManufacturers.AutoGenerateColumns = false;
            grdManufacturers.DataSource = tblManufacturers;

            if (grdManufacturers.RowCount > 0)
            {
                if (_operationMode == "ADD")
                {
                    _selectedRowIndex = 0;
                    _manufacturerId = Convert.ToInt32(grdManufacturers.Rows[0].Cells["ManufacturerId"].Value);
                    txtManufacturerName.Text = grdManufacturers.Rows[0].Cells["ManufacturerName"].Value.ToString();
                }
            }
            else
            {
                _manufacturerId = 0;
                txtManufacturerName.Text = "";
            }
        }

        private void grdManufacturers_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _selectedRowIndex = grdManufacturers.CurrentRow.Index;
            _manufacturerId = Convert.ToInt32(grdManufacturers.CurrentRow.Cells["ManufacturerId"].Value);
            txtManufacturerName.Text = grdManufacturers.CurrentRow.Cells["ManufacturerName"].Value.ToString();
            txtFullName.Text = grdManufacturers.CurrentRow.Cells["FullName"].Value.ToString();
            txtAddress.Text = grdManufacturers.CurrentRow.Cells["Address"].Value.ToString();
            txtAcountBank.Text = grdManufacturers.CurrentRow.Cells["AcountBank"].Value.ToString();
            txtBank.Text = grdManufacturers.CurrentRow.Cells["BankName"].Value.ToString();
            txtAddessBank.Text = grdManufacturers.CurrentRow.Cells["AddressBank"].Value.ToString();
            txtPhonNumber.Text = grdManufacturers.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            txtFax.Text = grdManufacturers.CurrentRow.Cells["Fax"].Value.ToString();
            txtUrl.Text = grdManufacturers.CurrentRow.Cells["Url"].Value.ToString();
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void grdManufacturers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void grdManufacturers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}