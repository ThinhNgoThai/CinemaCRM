using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CinemaCRM.dir
{
    public partial class frmTimePrice : Form
    {
        private int _timePricePlusId;
        private bool _isDataLoaded;

        public frmTimePrice()
        {
            InitializeComponent();
        }

        private void frmTimePrice_Load(object sender, EventArgs e)
        {
            LoadTimePricePlus();
            _isDataLoaded = true;
        }

        private void LoadTimePricePlus()
        {
            var tblTimePricePlus = new CrmDBConnect().myTable("SP_TimePricePlus_GetAll");
            grdTimePricePlus.AutoGenerateColumns = false;
            grdTimePricePlus.DataSource = tblTimePricePlus;

            if (tblTimePricePlus.Rows.Count == 0) _timePricePlusId = 0;
        }
    }
}