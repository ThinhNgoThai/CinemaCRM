using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Configuration;

namespace CinemaCRM.Contanst
{
    public class Contanst
    {
        public static string CrmConnection;
        public static string TicketConnection;
        public static string EncryptionKey; // key
        public static Int64 UserId; // Id người dùng
        public static string PassOld; // mật khẩu      
        public static string UserName; // Tên đăng nhập
        public static string FullName; // Tên đăng nhập
        public static Int64 GroupRole; //ID Nhóm quyền 
        public static string SystemName; // Key Nhóm
        public static string PasswordSalt;  // Chuối key
        public static string Email;
        public static string gCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string Host;// phương thức SMTP
        public static string SederEmail;// email người gửi
        public static int Port;// email người gửi     
        public static string PassEmail;// Mật khẩu email

        // Thông số SMS
        public static string Alias = "TTCPQG"; // tên mật danh
        public static string ContentType="0"; // loại  gửi chăm sóc khách hàng
        public static string AuthenticateUser = "bentic1";// Tên đăng nhập
        public static string AuthenticatePass = "vmg123456";// Mật khẩu 
    }
}
