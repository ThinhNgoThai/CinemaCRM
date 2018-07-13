using System;
using System.Windows.Forms;
using CinemaCRM.dir;
using CinemaCRM.task.customer;
using CinemaCRM.task.careCustomer;
using CinemaCRM.task.marketing;
using CinemaCRM.sys;
using CinemaCRM.task.survey;
using System.Data;



namespace CinemaCRM
{
    public partial class frmManager : Form
    {
        #region method Declare ...
        // private Regis objRegis = new Regis();
        //  private Func objFun = new Func();
        private CrmDBConnect dbconnect = new CrmDBConnect();
        public string UserName = "", Permission = "", Password = "", FullName = "";

        #endregion

        #region method frmManager
        public frmManager()
        {
            InitializeComponent();
        }
        #endregion

        #region method frmManager_Load
        private void frmManager_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            //frm.LoginSuccess = true;
            if (frm.LoginSuccess == true)
            {

                //XAC DINH PHAM VI LAM VIEC CUA NHAN VIEN     
                DataTable tabRole = dbconnect.myTable("SP_CustomerRole_Menu", "@CustomerId", Contanst.Contanst.UserId);
                object[] items;
                for (int i = 0; i < tabRole.Rows.Count; i++)
                {
                    items = tabRole.Rows[i].ItemArray;
                    Role(items[0].ToString().Trim().ToUpper(), items[1].ToString().Trim().ToUpper(),
                        items[2].ToString().Trim().ToUpper());
                }

                // labTEN_ND.Text = "CÁN BỘ TÁC NGHIỆP: " + CODE.Common.UserName;

                // load quyen
                // EnableAllMenu(tabRole);
            }
            else
            {
                this.Close();
                return;
            }
        }
        #endregion

        private void Role(string mnuName, string Edit, string Readonly)
        {
        }

        #region Dropdown when mouse hover
        private void toolStrip_MouseHover(object sender, EventArgs e)
        {
            if (sender is ToolStripDropDownItem)
            {
                var item = sender as ToolStripDropDownItem;
                if (item.HasDropDownItems && !item.DropDown.Visible)
                {
                    item.ShowDropDown();
                }
            }
        }
        #endregion

        #region method checkControl
        private void clearControl(System.Windows.Forms.SplitContainer ctl, string objName)
        {
            for (int i = 0; i < ctl.Panel2.Controls.Count; i++)
            {
                if (ctl.Panel2.Controls[i].Name.ToString().ToUpper() != objName.ToUpper())
                {
                    ctl.Panel2.Controls.RemoveAt(i);
                }
            }
        }
        #endregion

        #region method checkControl
        private bool activeControl(System.Windows.Forms.SplitContainer ctl, string objName)
        {
            for (int i = 0; i < ctl.Panel2.Controls.Count; i++)
            {
                if (ctl.Panel2.Controls[i].Name.ToString().ToUpper() == objName.ToUpper())
                {
                    ctl.Panel2.Controls[i].Show();
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Method SetPermission
        private void SetPermission()
        {
            //v  this.Permission = objFun.GetSysPer(this.UserName, this.Password);
            if (this.Permission.Contains("16"))
            {
                this.tsBCar.Enabled = true;
            }
            else
            {
                this.tsBCar.Enabled = false;
            }
            if (this.Permission.Contains("54"))
            {
                this.tsBProducts.Enabled = true;
            }
            else
            {
                this.tsBProducts.Enabled = false;
            }
            if (this.Permission.Contains("55"))
            {
                this.tsBtnDailyReport.Enabled = true;
            }
            else
            {
                this.tsBtnDailyReport.Enabled = false;
            }

        }
        #endregion

        #region CheckAttachDatabase
        public bool CheckAttachDatabase()
        {
            bool check = true;
            string Serial = "";
            //  Serial = System.Configuration.ConfigurationManager.AppSettings["Attach"].ToString();
            if (Serial == "1")
            {
                check = false;
            }
            return check;
        }
        #endregion

        #region method tsMChangePass_Click
        private void tsMChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass frm = new frmChangePass();
            frm.ShowDialog();
        }
        #endregion

        #region method tsBAccount_Click
        private void tsBAccount_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            CinemaCRM.sys.frmActingGroup frm = new CinemaCRM.sys.frmActingGroup();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region method tsBGroup_Click
        private void tsBGroup_Click(object sender, EventArgs e)
        {
            // SM.sys.frmGroup objSysGroup = new SM.sys.frmGroup();
            // objSysGroup.ShowDialog();
        }
        #endregion

        #region method tsBOnwer_Click
        private void tsBOnwer_Click(object sender, EventArgs e)
        {
            //   SM.sys.frmAboutUs objSysAboutUs = new SM.sys.frmAboutUs();
            //  objSysAboutUs.ShowDialog();
        }
        #endregion

        #region method tsBHelp1_Click
        private void tsBHelp1_Click(object sender, EventArgs e)
        {
            // SM.sys.frmIntro objAbout = new SM.sys.frmIntro();
            //objAbout.ShowDialog();
        }
        #endregion

        #region method tsBHelp3_Click
        private void tsBHelp3_Click(object sender, EventArgs e)
        {
            try
            {
                // SM.sys.FrmRegister objRes = new SM.sys.FrmRegister();
                //  objRes.ShowDialog();
            }
            catch
            {
            }
        }
        #endregion

        #region method tsBMainTask_Click
        private void tsBMainTask_Click(object sender, EventArgs e)
        {
            this.lblS1.Visible = true;
            this.lblS2.Visible = false;
            this.lblS3.Visible = false;
            this.lblS4.Visible = false;
            this.lblS5.Visible = false;
            this.clearControl(this.splitContainer1, "objF1");
            if (this.activeControl(this.splitContainer1, "objF1"))
            {
                return;
            }
            else
            {
                splitContainer1.Panel2.Controls.Clear();
                var frm = new frmManagerCustomer
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                splitContainer1.Panel2.Controls.Add(frm);
                frm.Show();
            }
        }
        #endregion

        #region method tsBBill_Click
        private void tsBBill_Click(object sender, EventArgs e)
        {
            this.lblS2.Visible = true;
            this.lblS1.Visible = false;
            this.lblS3.Visible = false;
            this.lblS4.Visible = false;
            this.lblS5.Visible = false;
            this.splitContainer1.Panel2.Controls.Clear();
            this.clearControl(this.splitContainer1, "objF1");
            if (this.activeControl(this.splitContainer1, "objF1"))
            {
                return;
            }
            else
            {
                splitContainer1.Panel2.Controls.Clear();
                var frm = new frmComplainManager
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                splitContainer1.Panel2.Controls.Add(frm);
                frm.Show();
            }
        }
        #endregion

        #region method tsBtnMainDir_Click
        private void tsBtnMainDir_Click(object sender, EventArgs e)
        {
            this.lblS3.Visible = true;
            this.lblS2.Visible = false;
            this.lblS1.Visible = false;
            this.lblS4.Visible = false;
            this.lblS5.Visible = false;
            this.splitContainer1.Panel2.Controls.Clear();
            this.clearControl(this.splitContainer1, "objF1");
            if (this.activeControl(this.splitContainer1, "objF1"))
            {
                return;
            }
            else
            {
                splitContainer1.Panel2.Controls.Clear();
                var frm = new frmAnalyzeSimple
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                splitContainer1.Panel2.Controls.Add(frm);
                frm.Show();
            }
        }
        #endregion


        #region method tsBExit_Click
        private void tsBExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình này không?\r\n\r\nBấm YES để thoát, bấm NO để tiếp tục sủ dụng chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion

        #region method tsBConfig_Click
        private void tsBConfig_Click(object sender, EventArgs e)
        {
            //SM.sys.frmConfig objSysConfig = new SM.sys.frmConfig();
            // objSysConfig.ShowDialog();
        }
        #endregion

        #region method mnuCustomer_Click
        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            CinemaCRM.dir.frmDemo frm = new CinemaCRM.dir.frmDemo();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region Method tsBLogin_Click
        private void tsBLogin_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        #endregion

        #region Method tsManagerCustomer_Click
        private void tsManagerCustomer_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            CinemaCRM.sys.frmMangerCustomer frm = new CinemaCRM.sys.frmMangerCustomer();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region Method tsJob_Click
        private void tsJob_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            CinemaCRM.dir.frmJob frm = new CinemaCRM.dir.frmJob();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region Method mnuConfigAges_Click
        private void mnuConfigAges_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var frm = new frmConfigAges();
            var title = (Label)frm.Controls["lbTitle"];
            var mi = sender as ToolStripMenuItem;
            title.Text = mi.Text;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region Method mnuArea_Click
        private void mnuArea_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmConfigArea
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region Method  mnuHoliday_Click
        // Hainb 21/11/2014
        private void mnuHoliday_Click(object sender, EventArgs e)
        {
            CinemaCRM.dir.frmHoliday frm = new CinemaCRM.dir.frmHoliday();
            frm.ShowDialog();
        }
        #endregion

        #region Method mnuTimePrice_Click
        private void mnuTimePrice_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var frm = new frmTimeSellTicket();
            HelepLableText(frm, sender);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        private void mnuConfigAge_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var frm = new frmConfigAges();
            HelepLableText(frm, sender);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var frm = new frmCategoryFilm();

            HelepLableText(frm, sender);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void HelepLableText(Form frm, object sender)
        {
            var title = (Label)frm.Controls["lbTitle"];
            var mi = (ToolStripMenuItem)sender;
            title.Text = mi.Text;
        }

        #region Method mnuTicketsPerBuy_Click
        private void mnuTicketsPerBuy_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var frm = new frmConfigTicketsPerBuy();
            HelepLableText(frm, sender);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        private void btnCustomerType_Click(object sender, EventArgs e)
        {

            this.splitContainer1.Panel2.Controls.Clear();
            var frm = new frmCustomerType();
            HelepLableText(frm, sender);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();

        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();

        }

        private void mnuManagerUser_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var frm = new CinemaCRM.sys.frmMangerCustomer();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuRoleUser_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            var frm = new CinemaCRM.sys.frmActingGroup();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Methods to config points
        private void mnuPointReward_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmConfigPointReward
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuPointCard_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmConfigPointCard
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        #endregion

        #region Method mnuConfigRevenue_Click
        private void mnuConfigRevenue_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmConfigRevenue
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region Method mnuManufacturerList_Click
        private void mnuManufacturerList_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmManufacturerList
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region Method mnuFrequencyReview_Click
        private void mnuFrequencyReview_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmFrequencyReview
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        private void mnuListCustomer_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmManagerCustomer
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuAnalyze_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmAnalyzeAdvance
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void tsExcel_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmSearchCustomer
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuRatingComment_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmComments
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuManagerCard_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmManagerMember
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        #region Method mnuAnalyzeSelect_Click
        private void mnuAnalyzeSelect_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmAnalyzeSimple
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        #region Method mnuCardClass_Click
        private void mnuCardClass_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmManagerCardClass
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        #endregion

        private void mnuCardLevel_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmManagerCardClass
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuMkt_CampaignPatern_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmCampaignPatern
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }
        private void mnuMkt_CampaignList_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmCampaignList
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuStatistical_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmCampaignEmailResult
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuTemplateEmail_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmManagerTemplateEmail
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuTempSMS_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmManagerTemplateSMS
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuConfigureSMTP_Click(object sender, EventArgs e)
        {
            ConfigureSMTPForm frm = new ConfigureSMTPForm();
            frm.ShowDialog();
        }

        private void mnuStaticsSMS_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmCampaignSMSResult
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuConfigureSMS_Click(object sender, EventArgs e)
        {
            ConfigureSMSForm frm = new ConfigureSMSForm();
            frm.ShowDialog();
        }


        private void mnuTicket_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmListGift
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuComplaint_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmComplainManager
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuPointBonus_Click(object sender, EventArgs e)
        {
            var frm = new frmPointBonus();
            frm.ShowDialog();
        }

        private void mnuSurveyType_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmSurveyType
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuQuestionType_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmQuestionType
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuQuestionManager_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmQuestionManager
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuSurveyManager_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmSurveyManager
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void mnuComplainType_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmComplainType
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void menuQuestionGroup_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            var frm = new frmQuestionGroup
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            splitContainer1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void tsBProducts_Click(object sender, EventArgs e)
        {

            this.clearControl(this.splitContainer1, "objF1");
            if (this.activeControl(this.splitContainer1, "objF1"))
            {
                return;
            }
            else
            {
                splitContainer1.Panel2.Controls.Clear();
                var frm = new frmAnalyzeAdvance
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                splitContainer1.Panel2.Controls.Add(frm);
                frm.Show();
            }
        }

        // cấp thẻ thành viên cho khách hàng
        private void tsBMember_ButtonClick(object sender, EventArgs e)
        {
            this.lblS1.Visible = true;
            this.lblS2.Visible = false;
            this.lblS3.Visible = false;
            this.lblS4.Visible = false;
            this.lblS5.Visible = false;
            this.clearControl(this.splitContainer1, "objF1");
            if (this.activeControl(this.splitContainer1, "objF1"))
            {
                return;
            }
            else
            {
                splitContainer1.Panel2.Controls.Clear();
                var frm = new frmManagerMember
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                splitContainer1.Panel2.Controls.Add(frm);
                frm.Show();
            }
        }

        private void báoCaoTheoMẫuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CinemaCRM.Reports.frmReports frmRp = new Reports.frmReports();
            frmRp.ShowDialog();
        }
    }
}