using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Configuration;

namespace CinemaCRM.Core
{
    public class Common
    {
        public static String Connection;
        public static String EncryptionKey; // key
        public static String PassOld; // mật khẩu
        public static Int64 UserId; // Id người dùng
        public static String UserName; // Tên đăng nhập
        public static String FullName; // Tên đăng nhập
        public static Int64 GroupRole; //ID Nhóm quyền 
        public static String SystemName; // Key Nhóm
        public static String PasswordSalt;  // Chuối key
        public static String Email;
        public static int StoreId = 1;
        public static int Duration = 5;
        public static DateTime ServerDate = DateTime.Now;
        public static int RoomTimeOut = int.Parse(ConfigurationSettings.AppSettings["RoomTimeOut"].ToString());

        public static string RoomName = "PHÒNG";

        public static string POSShortName = ConfigurationSettings.AppSettings["POSShortName"].ToString();
        public static string POSFullName = ConfigurationSettings.AppSettings["POSFullName"].ToString();
        public static string PrinterName = ConfigurationSettings.AppSettings["PrinterName"].ToString();
        public static int TicketTimeOut = Convert.ToInt16(ConfigurationSettings.AppSettings["TicketTimeOut"]);
        public static int ScreensPerRow = Convert.ToInt16(ConfigurationSettings.AppSettings["ScreensPerRow"]);
        public static int TimingCellWidth = Convert.ToInt16(ConfigurationSettings.AppSettings["TimingCellWidth"]);
        public static int LayoutCellHeight = 30;
        public static int LayoutCellWidth = 35;

        public static string OnlineTicket = "Online";
        public static string OfflineTicket = "Offline";
        public static string SellingTicket = "Selling";
        public static string SoldTicket = "Sold";
        public static string InvitationTicket = "Invitation";
        public static string ContractTicket = "Contract";
        public static string ReserveTicket = "Reservation";
        public static string CodeNumber = "M0 00000000";
        public static string ReportPath = System.Windows.Forms.Application.StartupPath + @"\Ticket.rpt";


        public static Color OnlineTicketColor = Color.FromName(ConfigurationSettings.AppSettings["OnlineTicketColor"].ToString());
        public static Color OfflineTicketColor = Color.FromName(ConfigurationSettings.AppSettings["OfflineTicketColor"].ToString());
        public static Color SoldTicketColor = Color.FromName(ConfigurationSettings.AppSettings["SoldTicketColor"].ToString());
        public static Color InviteTicketColor = Color.FromName(ConfigurationSettings.AppSettings["InviteTicketColor"].ToString());
        public static Color MyInviteTicketColor = Color.FromName(ConfigurationSettings.AppSettings["MyInviteTicketColor"].ToString());
        public static Color ContractTicketColor = Color.FromName(ConfigurationSettings.AppSettings["ContractTicketColor"].ToString());
        public static Color ReserveTicketColor = Color.FromName(ConfigurationSettings.AppSettings["ReserveTicketColor"].ToString());

        public static Color OnlineTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["OnlineTicketTextColor"].ToString());
        public static Color OfflineTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["OfflineTicketTextColor"].ToString());
        public static Color SoldTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["SoldTicketTextColor"].ToString());
        public static Color InviteTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["InviteTicketTextColor"].ToString());
        public static Color ContractTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["ContractTicketTextColor"].ToString());
        public static Color ReserveTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["ReserveTicketTextColor"].ToString());

        public static Color MyOnlineTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["MyOnlineTicketTextColor"].ToString());
        public static Color MyOfflineTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["MyOfflineTicketTextColor"].ToString());
        public static Color MySoldTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["MySoldTicketTextColor"].ToString());
        public static Color MyInviteTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["MyInviteTicketTextColor"].ToString());
        public static Color MyContractTicketTextColor = Color.FromName(ConfigurationSettings.AppSettings["MyContractTicketTextColor"].ToString());

        public static string[] ChairMarkF1 = System.Configuration.ConfigurationSettings.AppSettings["ChairMarkF1"].Split(',');
        public static string[] ChairMarkF2 = System.Configuration.ConfigurationSettings.AppSettings["ChairMarkF2"].Split(',');
        public static string[] ChairMarkF3 = System.Configuration.ConfigurationSettings.AppSettings["ChairMarkF3"].Split(',');

        public static string gCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

        //loại bỏ ký co dấu và khoảng chách trống 
        //Nguyễn hải
        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string RemoveSign4VietnameseString(string str)
        {
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        public static string ReplaceUnicode(string strOld)
        {
            string strNew = RemoveSign4VietnameseString(strOld);
            string srtSign = "";
            string[] words;
            words = strNew.Split(' ');
            foreach (string word in words)
            {
                srtSign += word;
            }
            return srtSign;
        }
    }

    public enum OrderStatus
    {
        Pending = 10,
        Processing = 20,
        Complete = 30,
        Cancelled = 40
    }

    public enum ShippingStatus
    {
        ShippingNotRequired = 10,
        NotYetShipped = 20,
        PartiallyShipped = 25,
        Shipped = 30,
        Delivered = 40
    }

    public enum PaymentStatus
    {
        Pending = 10,
        Authorized = 20,
        Paid = 30,
        PartiallyRefunded = 35,
        Refunded = 40,
        Voided = 50   
    }

    public enum PlanStatus
    {
        Nothing = 0,    // ke hoach da duoc tao ra nhung chua gui lanh dao
        Wait = 1,       // da gui lanh dao, dang cho duyet
        Rejected = 2,   // lanh dao tu choi it nhat 1 lan, dang sua lai
        Approved = 3    // da duoc chap nhan boi lanh dao
    }

    public class INFO_CommonData
    {
        public const string DATE_FORM = "MM/dd/yyyy";
        public readonly string INV_DATEFORM = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern;

        public const string STATUS_NEW = "N"; // New not store in db
        public const string STATUS_UPDATE = "1"; // Update before wait
        public const string STATUS_WAIT = "2";  //Wait
        public const string STATUS_REJECTED = "5";  //  
        public const string STATUS_APPROVED = "3"; //"Approved";
        public const string STATUS_ARCHIVE = "4"; //"Archived";

        public const string STATUS_NEW_TEXT = "Tạo Mới";
        public const string STATUS_UPDATE_TEXT = "Cập Nhật";
        public const string STATUS_WAIT_TEXT = "Chờ Duyệt";
        public const string STATUS_REJECTED_TEXT = "Không Duyệt";
        public const string STATUS_APPROVED_TEXT = "Đã Duyệt";
        public const string STATUS_ARCHIVE_TEXT = "Lưu Trữ";

        public const string COST_TYPE = "C";
        public const string EXPENSE_TYPE = "T";
    }
}
