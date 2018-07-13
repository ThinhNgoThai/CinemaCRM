using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Windows.Forms;
using CinemaCRM.Contanst;

namespace CinemaCRM.dir
{
    public partial class frmConfigArea : Form
    {
        private List<District> _selected;
        private string _operationMode;
        private int _selectedRowIndex = 0;
        private int _id;

        public frmConfigArea()
        {
            InitializeComponent();
        }

        private void frmConfigArea_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            txtAreaName.Enabled = false;
            txtAreaChosen.ReadOnly = true;

            LoadToTreeView();
            LoadToDataGridView();
            treeCity.Enabled = true;

            EnableBtn(true, false, false, false);
        }

        private void LoadToTreeView()
        {
            treeCity.Nodes.Clear();
            var dataSource = new CrmDBConnect().myTable("SP_CrmArea_CRUD");

            foreach (DataRow city in dataSource.Rows)
            {
                var cityNode = new HiddenCheckBoxTreeNode(city["Name"].ToString());

                var getDistrict = new CrmDBConnect().myTable("SP_CrmArea_CRUD", "@City_Id", city["Id"].ToString(),
                    "@flag", 1);

                foreach (DataRow district in getDistrict.Rows)
                {
                    cityNode.Nodes.Add(district["ID"].ToString(), district["Name"].ToString(), district["ID"].ToString());
                }

                treeCity.Nodes.Add(cityNode);
            }
        }

        private void LoadToDataGridView()
        {
            var dataSource = new CrmDBConnect().myTable("SP_CrmArea_CRUD", "@flag", 3);
            dgvArea.DataSource = dataSource;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operationMode = "ADD";
            treeCity.Enabled = true;
            UncheckAllNodes(treeCity.Nodes);

            txtAreaName.Text = "";
            txtAreaName.Enabled = true;
            txtAreaChosen.Text = @"Chọn địa điểm ở bảng bên trái";

            _selected = new List<District>();

            EnableBtn(false, false, true, false);
        }

        private void treeCity_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Checked)
            {
                var selectedDistrict = new District(e.Node.ImageKey, e.Node.Text);
                var index = _selected.Find(s => s.Id.Equals(selectedDistrict.Id));
                _selected.Remove(index);
            }
        }

        private void treeCity_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                txtAreaChosen.Text = "";

                if (e.Node.Checked)
                {
                    var selectedDistrict = new District(e.Node.ImageKey, e.Node.Text);
                    var index = _selected.Find(s => s.Id.Equals(selectedDistrict.Id));

                    if (null == index)
                        _selected.Add(selectedDistrict);
                    else
                        _selected.Remove(index);

                    var text = _selected.Select(s => s.Name).ToArray();
                    txtAreaChosen.Text = string.Join(", ", text);
                }
                else
                {
                    var indexRemove = _selected.Find(s => s.Id.Equals(e.Node.ImageKey));
                    if (indexRemove != null)
                    {
                        _selected.Remove(indexRemove);
                    }
                    var text = _selected.Select(s => s.Name).ToArray();
                    txtAreaChosen.Text = string.Join(", ", text);
                }

            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var listId = string.Join(",", _selected.Select(s => s.Id).ToArray());
            if (Public.IsNullTextBox(txtAreaName)) return;

            if (_operationMode == "ADD")
            {
                CrmDBConnect.RunQuery("SP_CrmArea_CRUD", "@AreaName", txtAreaName.Text.Trim(), "@ListDistrict", listId,
                    "@flag", 2);
                MessageBox.Show(Messages.Create, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

                EnableBtn(true, true, false, true);
            }

            if (_operationMode == "UPDATE")
            {
                CrmDBConnect.RunQuery("SP_CrmArea_CRUD", "@AreaName", txtAreaName.Text.Trim(), "@ListDistrict", listId,
                    "@Id", _id, "@flag", 5);
                MessageBox.Show(Messages.Update, Messages.Notice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

                EnableBtn(true, true, false, true);
            }
        }

        private void dgvArea_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvArea.CurrentRow == null) return;
                _selectedRowIndex = dgvArea.CurrentRow.Index;
                _id = Convert.ToInt32(dgvArea.CurrentRow.Cells["Id"].Value);
                txtAreaName.Text = dgvArea.CurrentRow.Cells["AreaName"].Value.ToString();
                txtAreaName.Enabled = false;

                var areaChosen = dgvArea.CurrentRow.Cells["ListDistrict"].Value.ToString().Trim();
                var currentDistrict = areaChosen.Split(Convert.ToChar(","));
                _selected = new List<District>();

                foreach (TreeNode node in treeCity.Nodes)
                {
                    UncheckAllNodes(node.Nodes);
                    foreach (TreeNode child in node.Nodes)
                    {
                        foreach (var district in currentDistrict)
                        {
                            if (child.ImageKey == district)
                            {
                                child.Checked = true;
                            }
                        }
                    }
                }
            }
            catch { }

            EnableBtn(true, true, false, true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id <= 0) return;
            if (
                MessageBox.Show(Messages.Delete, Messages.Warning, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            CrmDBConnect.RunQuery("SP_CrmArea_CRUD", "@Id", _id, "@flag", 4);
            LoadToDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _operationMode = "UPDATE";
            treeCity.Enabled = true;
            txtAreaName.Enabled = true;

            EnableBtn(true, false, true, false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var bs = new BindingSource
            {
                DataSource = dgvArea.DataSource,
                Filter = "AreaName" + " like '%" + txtSearchArea.Text + "%'"
            };
            dgvArea.DataSource = bs;
        }

        #region Các funtion Hỗ trợ
        //Bật tắt các nút
        private void EnableBtn(bool btnAdd, bool btnEdit, bool btnSave, bool btnDelete)
        {
            this.btnAdd.Enabled = btnAdd;
            this.btnEdit.Enabled = btnEdit;
            this.btnSave.Enabled = btnSave;
            this.btnDelete.Enabled = btnDelete;
        }

        private void UncheckAllNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = false;
                CheckChildren(node, false);
            }
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }
        #endregion
    }

    #region Các Class hỗ trợ
    public class HiddenCheckBoxTreeNode : TreeNode
    {
        public HiddenCheckBoxTreeNode() { }
        public HiddenCheckBoxTreeNode(string text) : base(text) { }
        public HiddenCheckBoxTreeNode(string text, TreeNode[] children) : base(text, children) { }
        public HiddenCheckBoxTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex) { }
        public HiddenCheckBoxTreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children) : base(text, imageIndex, selectedImageIndex, children) { }
        protected HiddenCheckBoxTreeNode(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context) { }
    }

    public class MixedCheckBoxesTreeView : TreeView
    {
        /// <summary>
        /// Specifies the attributes of a node
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TV_ITEM
        {
            public int Mask;
            public IntPtr ItemHandle;
            public int State;
            public int StateMask;
            public IntPtr TextPtr;
            public int TextMax;
            public int Image;
            public int SelectedImage;
            public int Children;
            public IntPtr LParam;
        }

        public const int TVIF_STATE = 0x8;
        public const int TVIS_STATEIMAGEMASK = 0xF000;

        public const int TVM_SETITEMA = 0x110d;
        public const int TVM_SETITEM = 0x110d;
        public const int TVM_SETITEMW = 0x113f;

        public const int TVM_GETITEM = 0x110C;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref TV_ITEM lParam);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // trap TVM_SETITEM message
            if (m.Msg == TVM_SETITEM || m.Msg == TVM_SETITEMA || m.Msg == TVM_SETITEMW)
                // check if CheckBoxes are turned on
                if (CheckBoxes)
                {
                    // get information about the node
                    TV_ITEM tv_item = (TV_ITEM)m.GetLParam(typeof(TV_ITEM));
                    HideCheckBox(tv_item);
                }
        }

        protected void HideCheckBox(TV_ITEM tv_item)
        {
            if (tv_item.ItemHandle != IntPtr.Zero)
            {
                // get TreeNode-object, that corresponds to TV_ITEM-object
                TreeNode currentTN = TreeNode.FromHandle(this, tv_item.ItemHandle);

                HiddenCheckBoxTreeNode hiddenCheckBoxTreeNode = currentTN as HiddenCheckBoxTreeNode;
                // check if it's HiddenCheckBoxTreeNode and
                // if its checkbox already has been hidden

                if (hiddenCheckBoxTreeNode != null)
                {
                    HandleRef treeHandleRef = new HandleRef(this, Handle);

                    // check if checkbox already has been hidden
                    TV_ITEM currentTvItem = new TV_ITEM();
                    currentTvItem.ItemHandle = tv_item.ItemHandle;
                    currentTvItem.StateMask = TVIS_STATEIMAGEMASK;
                    currentTvItem.State = 0;

                    IntPtr res = SendMessage(treeHandleRef, TVM_GETITEM, 0, ref currentTvItem);
                    bool needToHide = res.ToInt32() > 0 && currentTvItem.State != 0;

                    if (needToHide)
                    {
                        // specify attributes to update
                        TV_ITEM updatedTvItem = new TV_ITEM();
                        updatedTvItem.ItemHandle = tv_item.ItemHandle;
                        updatedTvItem.Mask = TVIF_STATE;
                        updatedTvItem.StateMask = TVIS_STATEIMAGEMASK;
                        updatedTvItem.State = 0;

                        // send TVM_SETITEM message
                        SendMessage(treeHandleRef, TVM_SETITEM, 0, ref updatedTvItem);
                    }
                }
            }
        }

        protected override void OnBeforeCheck(TreeViewCancelEventArgs e)
        {
            base.OnBeforeCheck(e);

            // prevent checking/unchecking of HiddenCheckBoxTreeNode,
            // otherwise, we will have to repeat checkbox hiding
            if (e.Node is HiddenCheckBoxTreeNode)
                e.Cancel = true;
        }
    }

    public class District
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public District(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
    #endregion
}
