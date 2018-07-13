using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Configuration;
using System.Threading.Tasks;

namespace CinemaCRM.SendSMS
{
    class Program
    {
        static Timer SendSmsTimer = new Timer(30000); 

        static void Main(string[] args)
        {
            int StandbyTime = System.Convert.ToInt32(ConfigurationManager.AppSettings["standbyTime"]);
            Console.WriteLine(String.Format("*******Excute sending SMS process every {0} minutes********", (Int32)(StandbyTime / 60000)));

            SendSmsTimer.Enabled = true;
            SendSmsTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedEvent);
            SendSmsTimer.Interval = StandbyTime;
            SendSmsTimer.Start();
            Console.ReadLine();
        }

        private static void OnElapsedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                Console.WriteLine(String.Format("---Start to send SMS at {0}---", DateTime.Now.ToString("dd-MM-yyyy HH:mm")));

                //Tạm dừng bộ đếm Timer để thực hiện việc gửi SMS
                SendSmsTimer.Stop();

                //Thực hiện gửi toàn bộ e-mail có trạng thái chưa gửi hoặc gửi chưa thành công
                SendCrmSms objSendSms = new SendCrmSms();
                objSendSms.SendSms();
                Console.WriteLine(String.Format("---Sending all messages completed at {0}---", DateTime.Now.ToString("dd-MM-yyyy HH:mm")));
            }
            catch (Exception ex) { }
            finally
            {                 
                //Khởi động lại bộ đếm Timer để tiến hành các chu trình gửi SMS kế tiếp
                SendSmsTimer.Start();
            }
        }
    }
}
