using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Configuration;

namespace CinemaCRM.Contanst
{
    public class Common
    {
       // public static string Connection;
       // public static string EncryptionKey; // key
        public static string PassOld; // mật khẩu
       // public static Int64 UserId; // Id người dùng
        public static string UserName; // Tên đăng nhập
        public static string FullName; // Tên đăng nhập
        public static Int64 GroupRole; //ID Nhóm quyền 
        public static string SystemName; // Key Nhóm
        public static string PasswordSalt;  // Chuối key
        public static string Email;
        public static int StoreId = 1;
        public static int Duration = 5;
        public static DateTime ServerDate = DateTime.Now;
        public static int RoomTimeOut = int.Parse(ConfigurationSettings.AppSettings["RoomTimeOut"].ToString());
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

    
}
