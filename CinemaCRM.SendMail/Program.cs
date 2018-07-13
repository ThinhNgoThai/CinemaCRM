using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Timers;
using System.Threading.Tasks;

namespace CinemaCRM.SendMail
{
    static class Program
    {
        static Timer SendMailTimer = new Timer(30000); 

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int StandbyTime = System.Convert.ToInt32(ConfigurationManager.AppSettings["standbyTime"]);
            Console.WriteLine(String.Format("*******Excute sending e-mail process every {0} minutes********", (Int32)(StandbyTime/60000)));

            SendMailTimer.Enabled = true;
            SendMailTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnElapsedEvent);
            SendMailTimer.Interval = StandbyTime;
            SendMailTimer.Start();
            Console.ReadLine();
        }

        private static void OnElapsedEvent(object source, ElapsedEventArgs e)
        {
            try 
            {
                Console.WriteLine(String.Format("---Start to send e-mail at {0}---", DateTime.Now.ToString("dd-MM-yyyy HH:mm")));
                
                //Tạm dừng bộ đếm Timer để thực hiện việc gửi mail 
                SendMailTimer.Stop();

                //Thực hiện gửi toàn bộ e-mail có trạng thái chưa gửi hoặc gửi chưa thành công
                SendCrmBulkMail objSendBulkMail = new SendCrmBulkMail();
                objSendBulkMail.SendBulkMail();
                Console.WriteLine(String.Format("---Sending all e-mails completed at {0}---", DateTime.Now.ToString("dd-MM-yyyy HH:mm")));
            }
            catch (Exception ex) { }
            finally
            {
                //Khởi động lại bộ đếm Timer để tiến hành các chu trình gửi SMS kế tiếp
                SendMailTimer.Start();
            }
        }
    }
}
