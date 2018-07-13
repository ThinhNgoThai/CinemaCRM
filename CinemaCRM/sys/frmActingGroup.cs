using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CinemaCRM.sys
{
    public partial class frmActingGroup : Form
    {
        private CrmDBConnect dbconnect = new CrmDBConnect();
        private DataTable tabGroup, tabMenu;    
        private int fag = 0;
        private  int _IdCustomerSelect = 0;

        public frmActingGroup()
        {
            InitializeComponent();
        }

        private void frmActingGroup_Load(object sender, EventArgs e)
        {
            // load nhom quyền      
            LoadActingGroup(_IdCustomerSelect);
            // load tree
            populateTreeview();
        }
             
        public void LoadActingGroup(int CustomerId)
        {
            tabGroup = dbconnect.myTable("SP_CustomerRole_Menu", "@CustomerId", CustomerId);
            if (tabGroup.Rows.Count > 0)
            {
                fag = 1;
                dtActityGroup.AutoGenerateColumns = false;
                dtActityGroup.DataSource = tabGroup;

            }
            else
            {
                fag = 0;
                tabMenu = dbconnect.myTable("SP_LoadMenuOffLine");
                dtActityGroup.AutoGenerateColumns = false;
                dtActityGroup.DataSource = tabMenu;
            }
        }
         

        // load cac tree view
        // Danh sách kế hoạch chờ duyệt theo rạp
        private void populateTreeview()
        {

            // 1. nhóm adminstrator
            DataTable ListAdmin = dbconnect.myTable("SP_GetCustormerByGroup", "@fag",1);

            TreeNode rn1 = tvGroup.Nodes[0];
            rn1.Nodes.Clear();
            if (ListAdmin != null && ListAdmin.Rows.Count > 0)
            {
                TreeNode nodeFP;

                for (int i = 0; i < ListAdmin.Rows.Count; i++)
                {
                    nodeFP = new TreeNode();
                    DataRow dtPC = ListAdmin.Rows[i];
                    nodeFP.Text = dtPC["Username"].ToString();
                    nodeFP.Name = dtPC["Id"].ToString();
                    nodeFP.Tag = dtPC;
                    nodeFP.ImageIndex = 2;
                    nodeFP.SelectedImageIndex = 2;
                    rn1.Nodes.Add(nodeFP);
                }

            }


            // 2. nhóm ban giam doc
            DataTable ListLead = dbconnect.myTable("SP_GetCustormerByGroup", "@fag", 2);

            TreeNode rn2 = tvGroup.Nodes[1];
            rn2.Nodes.Clear();
            if (ListLead != null && ListLead.Rows.Count > 0)
            {
                TreeNode nodeFP;

                for (int i = 0; i < ListLead.Rows.Count; i++)
                {
                    nodeFP = new TreeNode();
                    DataRow dtPC = ListLead.Rows[i];
                    nodeFP.Text = dtPC["Username"].ToString();
                    nodeFP.Name = dtPC["Id"].ToString();
                    nodeFP.Tag = dtPC;
                    nodeFP.ImageIndex = 2;
                    nodeFP.SelectedImageIndex = 2;
                    rn2.Nodes.Add(nodeFP);
                }

            }


            // 3. các truong phó phong
            DataTable ListLeadRoom = dbconnect.myTable("SP_GetCustormerByGroup", "@fag",3);

            TreeNode rn3 = tvGroup.Nodes[2];
            rn3.Nodes.Clear();
            if (ListLeadRoom != null && ListLeadRoom.Rows.Count > 0)
            {
                TreeNode nodeFP;

                for (int i = 0; i < ListLeadRoom.Rows.Count; i++)
                {
                    nodeFP = new TreeNode();
                    DataRow dtPC = ListLeadRoom.Rows[i];
                    nodeFP.Text = dtPC["Username"].ToString();
                    nodeFP.Name = dtPC["Id"].ToString();
                    nodeFP.Tag = dtPC;
                    nodeFP.ImageIndex = 2;
                    nodeFP.SelectedImageIndex = 2;
                    rn3.Nodes.Add(nodeFP);
                }

            }

            // 4. Bộ phân kế hoạch
            DataTable Listplan = dbconnect.myTable("SP_GetCustormerByGroup", "@fag", 4);

            TreeNode rn4= tvGroup.Nodes[3];
            rn4.Nodes.Clear();
            if (Listplan != null && Listplan.Rows.Count > 0)
            {
                TreeNode nodeFP;

                for (int i = 0; i < Listplan.Rows.Count; i++)
                {
                    nodeFP = new TreeNode();
                    DataRow dtPC = Listplan.Rows[i];
                    nodeFP.Text = dtPC["Username"].ToString();
                    nodeFP.Name = dtPC["Id"].ToString();
                    nodeFP.Tag = dtPC;
                    nodeFP.ImageIndex = 2;
                    nodeFP.SelectedImageIndex = 2;
                    rn4.Nodes.Add(nodeFP);
                }
            }

            // 5. Bộ phân kế toán
            DataTable ListReport = dbconnect.myTable("SP_GetCustormerByGroup", "@fag", 5);

            TreeNode rn5 = tvGroup.Nodes[4];
            rn5.Nodes.Clear();
            if (ListReport != null && ListReport.Rows.Count > 0)
            {
                TreeNode nodeFP;

                for (int i = 0; i < ListReport.Rows.Count; i++)
                {
                    nodeFP = new TreeNode();
                    DataRow dtPC = ListReport.Rows[i];
                    nodeFP.Text = dtPC["Username"].ToString();
                    nodeFP.Name = dtPC["Id"].ToString();
                    nodeFP.Tag = dtPC;
                    nodeFP.ImageIndex = 2;
                    nodeFP.SelectedImageIndex = 2;
                    rn5.Nodes.Add(nodeFP);
                }
            }

            // 6. Bộ phân bán vé
            DataTable ListTicket = dbconnect.myTable("SP_GetCustormerByGroup", "@fag", 6);

            TreeNode rn6 = tvGroup.Nodes[5];
            rn6.Nodes.Clear();
            if (ListTicket != null && ListTicket.Rows.Count > 0)
            {
                TreeNode nodeFP;

                for (int i = 0; i < ListTicket.Rows.Count; i++)
                {
                    nodeFP = new TreeNode();
                    DataRow dtPC = ListTicket.Rows[i];
                    nodeFP.Text = dtPC["Username"].ToString();
                    nodeFP.Name = dtPC["Id"].ToString();
                    nodeFP.Tag = dtPC;
                    nodeFP.ImageIndex = 2;
                    nodeFP.SelectedImageIndex = 2;
                    rn6.Nodes.Add(nodeFP);
                }
            }

            // 7. Bộ phân marketting
            DataTable ListMarketting = dbconnect.myTable("SP_GetCustormerByGroup", "@fag",7);

            TreeNode rn7 = tvGroup.Nodes[6];
            rn7.Nodes.Clear();
            if (ListMarketting != null && ListMarketting.Rows.Count > 0)
            {
                TreeNode nodeFP;

                for (int i = 0; i < ListMarketting.Rows.Count; i++)
                {
                    nodeFP = new TreeNode();
                    DataRow dtPC = ListMarketting.Rows[i];
                    nodeFP.Text = dtPC["Username"].ToString();
                    nodeFP.Name = dtPC["Id"].ToString();
                    nodeFP.Tag = dtPC;
                    nodeFP.ImageIndex = 2;
                    nodeFP.SelectedImageIndex = 2;
                    rn7.Nodes.Add(nodeFP);
                }
            }


            // 8. chủ phim
            DataTable ListVerdor = dbconnect.myTable("SP_GetCustormerByGroup", "@fag",8);

            TreeNode rn8 = tvGroup.Nodes[7];
            rn8.Nodes.Clear();
            if (ListVerdor != null && ListVerdor.Rows.Count > 0)
            {
                TreeNode nodeFP;

                for (int i = 0; i < ListVerdor.Rows.Count; i++)
                {
                    nodeFP = new TreeNode();
                    DataRow dtPC = ListVerdor.Rows[i];
                    nodeFP.Text = dtPC["Username"].ToString();
                    nodeFP.Name = dtPC["Id"].ToString();
                    nodeFP.Tag = dtPC;
                    nodeFP.ImageIndex = 2;
                    nodeFP.SelectedImageIndex = 2;
                    rn8.Nodes.Add(nodeFP);
                }
            }
        }
            
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string menu;
            bool edit, read;
            for (int i = 0; i < dtActityGroup.RowCount; i++)
            {
                menu = dtActityGroup.Rows[i].Cells[2].Value.ToString();
                // 2016/06/06 NguyenNT Fix phần chọn phân quyền cho user có thể chọn cả 2 là Có thể sửa và Chỉ đọc >>>
                //edit = (bool)dtActityGroup.Rows[i].Cells[4].Value;
                //read = (bool)dtActityGroup.Rows[i].Cells[5].Value;
                if ((bool)dtActityGroup.Rows[i].Cells[4].Value == true)
                {
                    edit = true;
                    read = false;
                }
                else
                {
                    edit = false;
                    read = true;
                }
                // 2016/06/06 NguyenNT <<<
                CrmDBConnect.RunQuery("SP_CustomerRole_UpdateRole", "@CustomerId", _IdCustomerSelect, "@Menu", menu, "@edit", edit, "@read", read, "@fag", fag);
            }
            MessageBox.Show("Cập nhật thành công!");     
        }

        private void tvGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;

            _IdCustomerSelect = int.Parse(e.Node.Name);
            LoadActingGroup(_IdCustomerSelect);
        }

    }
}
