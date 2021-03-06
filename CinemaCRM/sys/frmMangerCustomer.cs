using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Nop.Services.Security;
using CinemaCRM.Contanst;


namespace CinemaCRM.sys
{
    public partial class frmMangerCustomer : Form
    {
        private CrmDBConnect crmdbconnect = new CrmDBConnect();
        private TicketDBConnect ticketdbconnect = new TicketDBConnect();

        private String mState, Emails, UserName;
        private int CustomerId;
        private int CustomerRoleId, ManufacturerId;
        private int CustomerNewId;
        public EncryptionService enkey = new EncryptionService();

        public frmMangerCustomer()
        {
            InitializeComponent();
        }

        private void LoadCustomerRoleSearch()
        {
            DataTable tab = ticketdbconnect.myTable("SP_CustomerRole_GetRole");
            if (tab.Rows.Count > 0)
            {
                cbCustomerRoleSearch.DisplayMember = "CustomerName";
                cbCustomerRoleSearch.ValueMember = "Id";
                cbCustomerRoleSearch.DataSource = tab;
                cbCustomerRoleSearch.SelectedIndex = 0;
            }

        }

        private void LoadCustomerRole()
        {
            DataTable tab = ticketdbconnect.myTable("SP_CustomerRole_GetRole");
            if (tab.Rows.Count > 0)
            {
                cbCustomerRole.DisplayMember = "CustomerName";
                cbCustomerRole.ValueMember = "Id";
                cbCustomerRole.DataSource = tab;
                cbCustomerRole.SelectedIndex = 0;
            }
        }

        private void txtHOTEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtUsername.Focus();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtMK.Focus();
            }
        }

        private void txtMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnSave.Focus();
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            mState = "Add";
            txtEmail.ReadOnly = false;
            txtUsername.ReadOnly = false;
            txtMK.ReadOnly = false;
            txtMK.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtEmail.Focus();
            btnSave.Enabled = true;
            txtLast.Text = string.Empty;
            txtFirst.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddess.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (CustomerId > 0)
            {
                if (MessageBox.Show("Bạn thực sự muốn xóa người dùng này ?", "Chú ý !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Xóa người dùng
                    try
                    {
                        TicketDBConnect.RunQuery("SP_Customer_CustomerRole_Mapping_Delete", "@Customer_Id", CustomerId);
                        LoadGrdidCustomer(int.Parse(cbCustomerRoleSearch.SelectedValue.ToString()));
                        MessageBox.Show("Xóa người dùng thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Không thể xóa người dùng, kiểm tra mối liên quan tới người dùng này!");
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbMannuafacture.Enabled == true)
            {
                if (cbMannuafacture.SelectedIndex < 0)
                {
                    MessageBox.Show("Nhóm người dùng không được để trống");
                    cbMannuafacture.Focus();
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Tên đăng nhập không để trống");
                txtUsername.Focus();
                return;
            }


            if (string.IsNullOrEmpty(txtFirst.Text))
            {
                MessageBox.Show("Họ không để trống");
                txtFirst.Focus();
                return;
            }


            if (string.IsNullOrEmpty(txtLast.Text))
            {
                MessageBox.Show("Tên không để trống");
                txtLast.Focus();
                return;
            }

            if (mState == "Add")
            {
                if (string.IsNullOrEmpty(txtMK.Text))
                {

                    MessageBox.Show("Mật khẩu để trống");
                }
            }

            if (mState == "Add")
            {
                DataTable tab1 = crmdbconnect.myTable("SP_CheckEmail", "@Email", txtEmail.Text);
                if (tab1.Rows.Count > 0)
                {
                    MessageBox.Show("Địa chỉ email đã tồn tại!");
                    txtEmail.Focus();
                    return;
                }

                DataTable tab2 = crmdbconnect.myTable("SP_CheckUserName", "@Username", txtUsername.Text);
                if (tab2.Rows.Count > 0)
                {
                    MessageBox.Show("Tài khoản đăng nhập đã tồn tại!");
                    txtUsername.Focus();
                    return;
                }

                String CustomerGuid = Guid.NewGuid().ToString();
                string saltKey = enkey.CreateSaltKey(5);
                String newPass = enkey.CreatePasswordHash(txtMK.Text, saltKey,Contanst.Contanst.EncryptionKey);
                try
                {
                    int isManfacture = 0;
                    int manfactureId = 0;

                    if (int.Parse(cbCustomerRole.SelectedValue.ToString()) == 5)
                    {
                        isManfacture = 1;
                        manfactureId = int.Parse(cbMannuafacture.SelectedValue.ToString());
                    }

                    CrmDBConnect.RunQuery("SP_Customer_Create", "@CustomerGuid", CustomerGuid, "@Username", txtUsername.Text.Trim(), "@Email", txtEmail.Text, "@Password", newPass, "@PasswordFormatId", 1, "@PasswordSalt", saltKey, "@IsManufacturer", isManfacture, "@ManufacturerId", manfactureId);
                  
                    DataTable tab3 = crmdbconnect.myTable("SP_SelectMaxCustomerId", "@UserName", txtUsername.Text);
                    if (tab3.Rows.Count > 0)
                    {
                        CustomerNewId = int.Parse(tab3.Rows[0]["Id"].ToString());
                        CrmDBConnect.RunQuery("SP_CinemaStaff_Create_Update", "@Id", CustomerNewId, "@Username", txtUsername.Text.Trim(), "@Fullname", txtFirst.Text + " " + txtLast.Text, "@RoleId", int.Parse(cbCustomerRole.SelectedValue.ToString()), "@Fag", 1);
                        CrmDBConnect.RunQuery("SP_Customer_CustomerRole_Mapping_Create", "@Customer_Id", CustomerNewId, "@CustomerRole_Id", int.Parse(cbCustomerRole.SelectedValue.ToString()));
                        CrmDBConnect.RunQuery("SP_Customer_CustomerRole_Mapping_Create", "@Customer_Id", CustomerNewId, "@CustomerRole_Id", 3);
                        CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerNewId, "@KeyGroup", "Customer", "@Key", "FirstName", "@Value", txtFirst.Text, "@StoreId", 1, "@Fag", 1);
                        CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerNewId, "@KeyGroup", "Customer", "@Key", "LastName", "@Value", txtLast.Text, "@StoreId", 1, "@Fag", 1);
                        CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerNewId, "@KeyGroup", "Customer", "@Key", "StreeAddress", "@Value", txtAddess.Text, "@StoreId", 1, "@Fag", 1);
                        CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerNewId, "@KeyGroup", "Customer", "@Key", "Phone", "@Value", txtPhone.Text, "@StoreId", 1, "@Fag", 1);
                    }

                    txtEmail.Text = "";
                    txtUsername.Text = "";
                    txtMK.Text = "";
                    txtLast.Text = "";
                    txtFirst.Text = "";
                    txtPhone.Text = "";
                    txtAddess.Text = "";

                    MessageBox.Show("Thêm người dùng mới thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadGrdidCustomer(int.Parse(cbCustomerRoleSearch.SelectedValue.ToString()));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Có lỗi, thêm người dùng mới không thành công" + "\n" + ex.Message,"Thông báo lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error );
                }
            }
            else
            {

                //if (txtEmail.Text != Emails)
                //{
                //    DataTable tab1 = dbconnect.myTable("SP_CheckEmail", "@Email", txtEmail.Text);
                //    if (tab1.Rows.Count > 0)
                //    {
                //        MessageBox.Show("Địa chỉ email đã tồn tại!");
                //        txtEmail.Focus();
                //        return;
                //    }
                //}

                //if (txtUsername.Text != UserName)
                //{
                //    DataTable tab2 = dbconnect.myTable("SP_CheckUserName", "@Username", txtUsername.Text);
                //    if (tab2.Rows.Count > 0)
                //    {
                //        MessageBox.Show("Tài khoản đăng nhập đã tồn tại!");
                //        txtUsername.Focus();
                //        return;
                //    }
                //}

                int isManfacture = 0;
                int manfactureId = 0;

                if (int.Parse(cbCustomerRole.SelectedValue.ToString()) == 5)
                {
                    isManfacture = 1;
                    manfactureId = int.Parse(cbMannuafacture.SelectedValue.ToString());
                }
                CrmDBConnect.RunQuery("SP_Customer_Update", "@Username", txtUsername.Text.Trim(), "@Email", txtEmail.Text, "@ManufacturerId", manfactureId, "@Id", CustomerId);
                // xóa
                CrmDBConnect.RunQuery("SP_Customer_CustomerRole_Mapping_Update", "@Customer_Id", CustomerId, "@CustomerRole_Id", int.Parse(cbCustomerRole.SelectedValue.ToString()), "@Fag", 2);
                // them lai
                CrmDBConnect.RunQuery("SP_Customer_CustomerRole_Mapping_Update", "@Customer_Id", CustomerId, "@CustomerRole_Id", int.Parse(cbCustomerRole.SelectedValue.ToString()), "@Fag", 1);

                // 2016/06/07 NguyenNT fix loi khong update duoc thong tin user >>>
                //DBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "FirstName", "@Value", txtFirst.Text, "@StoreId", 1, "@Fag", 2);
                //DBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "LastName", "@Value", txtLast.Text, "@StoreId", 1, "@Fag", 2);
                // 2016/06/07 NguyenNT <<<

                CrmDBConnect.RunQuery("SP_CinemaStaff_Create_Update", "@Fullname", txtFirst.Text + " " + txtLast.Text, "@RoleId", int.Parse(cbCustomerRole.SelectedValue.ToString()), "@Fag", 2, "@Username", txtUsername.Text.Trim());
                DataTable tabGeneric = crmdbconnect.myTable("SP_GetGenericAttribute", "@CusTomerId", CustomerId);

                // 2016/06/07 NguyenNT fix loi khong update duoc thong tin user >>>
                //foreach (DataRow row in tabGeneric.Rows)
                //{
                //    string values = row[3].ToString();
                //    if (values == "StreeAddress")
                //    {
                //        DBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "StreeAddress", "@Value", txtAddess.Text, "@StoreId", 1, "@Fag", 2);
                //    }
                //    else
                //    {
                //        DBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerNewId, "@KeyGroup", "Customer", "@Key", "StreeAddress", "@Value", txtAddess.Text, "@StoreId", 1, "@Fag", 1);
                //    }

                //    if (values == "Phone")
                //    {
                //        DBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "Phone", "@Value", txtPhone.Text, "@StoreId", 1, "@Fag", 2);
                //    }
                //    else
                //    {
                //        DBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerNewId, "@KeyGroup", "Customer", "@Key", "Phone", "@Value", txtPhone.Text, "@StoreId", 1, "@Fag", 1);
                //    }
                //}
                if (tabGeneric.Rows.Count == 0)
                {
                    CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "FirstName", "@Value", txtFirst.Text, "@StoreId", 1, "@Fag", 1);
                    CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "LastName", "@Value", txtLast.Text, "@StoreId", 1, "@Fag", 1);
                    CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "StreeAddress", "@Value", txtAddess.Text, "@StoreId", 1, "@Fag", 1);
                    CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "Phone", "@Value", txtPhone.Text, "@StoreId", 1, "@Fag", 1);
                }
                else
                {
                    CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "FirstName", "@Value", txtFirst.Text, "@StoreId", 1, "@Fag", 2);
                    CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "LastName", "@Value", txtLast.Text, "@StoreId", 1, "@Fag", 2);
                    CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "StreeAddress", "@Value", txtAddess.Text, "@StoreId", 1, "@Fag", 2);
                    CrmDBConnect.RunQuery("SP_GenericAttributeInsertUpdate", "@Id", 0, "@EntityId", CustomerId, "@KeyGroup", "Customer", "@Key", "Phone", "@Value", txtPhone.Text, "@StoreId", 1, "@Fag", 2);
                }
                // 2016/06/07 NguyenNT <<<

                txtEmail.Text = "";
                txtUsername.Text = "";
                txtMK.Text = "";
                txtLast.Text = "";
                txtFirst.Text = "";
                txtPhone.Text = "";
                txtAddess.Text = "";

                LoadGrdidCustomer(int.Parse(cbCustomerRoleSearch.SelectedValue.ToString()));
                MessageBox.Show("Cập nhật thành công!");
            }
            btnSave.Enabled = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != null)
            {
                DataTable tabSeacrh = crmdbconnect.myTable("SP_Customer_Search", "@CustomerRole_Id", int.Parse(cbCustomerRoleSearch.SelectedValue.ToString()), "@Key", txtSearch.Text.ToLower());
                dtCustomer.DataSource = null;
                dtCustomer.AutoGenerateColumns = false;
                dtCustomer.DataSource = tabSeacrh;
            }
        }


        private void cbCustomerRoleSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCustomerRoleSearch.SelectedValue == null) return;
            int customerRolerId = Int16.Parse(cbCustomerRoleSearch.SelectedValue.ToString());
            LoadGrdidCustomer(customerRolerId);
            // 2016/06/06 NguyenNT Xoa gia tri nhap o trong o tim kiem >>>
            txtSearch.Text = "";
            // 2016/06/06 NguyenNT <<<
        }

        private void LoadGrdidCustomer(int CustomerRoleId)
        {
            DataTable tab = crmdbconnect.myTable("SP_Customer_ByRole", "@CustomerRole_Id", CustomerRoleId);
            // 2016/06/06 NguyenNT Fix khong khi chon Nhom nguoi dung khong co ai thi khong reload lai grid du lieu >>>
            //if (tab.Rows.Count > 0)
            //{
                dtCustomer.AutoGenerateColumns = false;
                dtCustomer.DataSource = tab;
            //}
            // 2016/06/06 NguyenNT <<<
        }

        private void dtCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 2016/06/06 NguyenNT Fix lỗi không update được thông tin tài khoản >>>
                mState = "Update";
                // 2016/06/06 NguyenNT <<<
                txtMK.ReadOnly = true;
                txtEmail.ReadOnly = false;
                txtUsername.ReadOnly = false;
                txtEmail.Text = dtCustomer.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                Emails = dtCustomer.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtUsername.Text = dtCustomer.Rows[e.RowIndex].Cells["UserNames"].Value.ToString();
                UserName = dtCustomer.Rows[e.RowIndex].Cells["UserNames"].Value.ToString();
                txtMK.Text = dtCustomer.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                CustomerId = int.Parse(dtCustomer.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                CustomerRoleId = int.Parse(dtCustomer.Rows[e.RowIndex].Cells["CustomerRole"].Value.ToString());
                ManufacturerId = int.Parse(dtCustomer.Rows[e.RowIndex].Cells["Manufacture"].Value.ToString());
                cbCustomerRole.SelectedValue = CustomerRoleId;
                cbMannuafacture.SelectedValue = ManufacturerId;
                if (ManufacturerId == 5)
                {
                    cbMannuafacture.Enabled = true;
                }
                // load danh sách thuoc tính
                DataTable tabGeneric = crmdbconnect.myTable("SP_GetGenericAttribute", "@CusTomerId", CustomerId);
                foreach (DataRow row in tabGeneric.Rows)
                {
                    string values = row[3].ToString();
                    if (values == "FirstName")
                    {
                        txtFirst.Text = row[4].ToString();
                    }

                    if (values == "LastName")
                    {
                        txtLast.Text = row[4].ToString();
                    }

                    if (values == "StreeAddress")
                    {
                        txtAddess.Text = row[4].ToString();
                    }

                    if (values == "Phone")
                    {
                        txtPhone.Text = row[4].ToString();
                    }
                }
                btnSave.Enabled = true;
            }
            catch { }
        }

        private void frmMangerCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomerRoleSearch();
            LoadManufacture();
            LoadCustomerRole();
            btnSave.Enabled = false;
        }


        private void LoadManufacture()
        {
            DataTable tabman = crmdbconnect.myTable("SP_Manufacturer_getall");
            if (tabman.Rows.Count > 0)
            {
                cbMannuafacture.DisplayMember = "Name";
                cbMannuafacture.ValueMember = "Id";
                cbMannuafacture.DataSource = tabman;
                cbMannuafacture.SelectedIndex = 0;
            }
        }

        private void cbCustomerRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int customerRoleId = 0;
            if (cbCustomerRole.SelectedValue != null)
            {
                customerRoleId = int.Parse(cbCustomerRole.SelectedValue.ToString());
                if (customerRoleId == 5)
                {
                    cbMannuafacture.Enabled = true;
                }
                else
                {
                    cbMannuafacture.Enabled = false;
                }
            }
        }
    }
}