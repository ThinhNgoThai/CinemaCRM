using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CinemaCRM.Core;
using CinemaCRM.dir;

namespace CinemaCRM.task.carecustomer
{
    public partial class frmAddCard : Form
    {
        private List<int> _ids;

        public frmAddCard()
        {
            InitializeComponent();
        }

        private void frmAddCard_Load(object sender, EventArgs e)
        {
            var col = new CalendarColumn
            {
                HeaderText = @"Ngày hết hạn",
                Name = "DateExpired",
                DataPropertyName = "DateExpired"
            };
            dgrUser.Columns.Add(col);
            btnCreate.Enabled = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var frm = new frmSelectUsers();
            frm.ShowDialog();
                _ids = frm.Ids;
               var existIds = new List<int>();
               try
               {
                   foreach (var id in _ids)
                   {
                       foreach (DataGridViewRow currentUser in dgrUser.Rows)
                       {
                           if (currentUser.Cells["Id"].Value.ToString().Equals(id.ToString()))
                           {
                               existIds.Add(Convert.ToInt32(currentUser.Cells["Id"].Value.ToString()));
                           }
                       }
                   }

                   foreach (var id in _ids)
                   {
                       if (!existIds.Contains(id))
                       {
                           var getUser = new CrmDBConnect().myTable("CRM_CareCustomer_CardManager", "@UserId", id, "@flag", 1);

                           foreach (DataRow user in getUser.Rows)
                           {
                               dgrUser.Rows.Add(user.ItemArray);
                           }
                       }
                   }
               }
               catch { }
                btnCreate.Enabled = true;
          
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow user in dgrUser.Rows)
                {
                    CrmDBConnect.RunQuery("CRM_CareCustomer_CardManager", "@UserId", user.Cells["Id"].Value.ToString(),
                        "@PointBonus", user.Cells["PointBonus"].Value, "@Reasons", user.Cells["Reason"].Value,
                        "@CardCode", StringExtension.GenerateCustomerCard(), "@DateExpired", user.Cells["DateExpired"].Value,
                        "@flag", 2);
                }

                MessageBox.Show(@"Cấp/đổi thẻ thành công", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dispose();
                Close();
            }
            catch
            {
                MessageBox.Show(@"Cập nhật ngày hết hạn thẻ", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgrUser.CurrentRow != null)
                dgrUser.Rows.RemoveAt(dgrUser.CurrentRow.Index);

            if (dgrUser.Rows.Count == 0)
                btnCreate.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }
    }

    #region Class hỗ trợ
    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn()
            : base(new CalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell. 
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell()
            : base()
        {
            // Use the short date format. 
            this.Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value. 
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
            // Use the default row value when Value property is null. 
            if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
            else
            {
                //ctl.Value = (DateTime)this.Value;
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses. 
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains. 

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value. 
                return DateTime.Now;
            }
        }
    }

    class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Short;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue  
        // property. 
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToShortDateString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        // This will throw an exception of the string is  
                        // null, empty, or not in the format of a date. 
                        this.Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        // In the case of an exception, just use the  
                        // default value so we're not left with a null 
                        // value. 
                        this.Value = DateTime.Now;
                    }
                }
            }
        }

        // Implements the  
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method. 
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the  
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method. 
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex  
        // property. 
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey  
        // method. 
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed. 
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit  
        // method. 
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl 
        // .RepositionEditingControlOnValueChange property. 
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingControlDataGridView property. 
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingControlValueChanged property. 
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl 
        // .EditingPanelCursor property. 
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell 
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
    #endregion
}
