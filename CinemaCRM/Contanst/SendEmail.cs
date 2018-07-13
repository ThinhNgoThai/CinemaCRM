using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace CinemaCRM.Contanst
{
    public class SendEmail
    {

        public string Send_Email(string SendFrom, string SendTo, string Subject, string Body, string host, int port, string password)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                bool result = regex.IsMatch(SendTo);
                if (result == false)
                {
                    return "Địa chỉ email không hợp lệ.";
                }
                else
                {

                    MailAddress _SendFrom = new MailAddress(SendFrom);
                    MailAddress _SendTo = new MailAddress(SendTo);

                    MailMessage mail = new MailMessage(_SendFrom, _SendTo);
                    mail.Subject = Subject;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;

                    SmtpClient client = new SmtpClient();
                    client.Host = host;
                    client.Port = port;
                    client.EnableSsl = false;
                    client.Timeout = 10000;
                    client.UseDefaultCredentials = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential(SendFrom, password);
                    client.Send(mail);
                    return "Email đã được gửi đến: " + SendTo + ".";
                }
            }
            catch
            {
                return "Email bị lỗi trong quá trình gửi đến: " + SendTo + ".";
            }
        }

        // gửi theo chiến dịch
        public int Send_Email_campaign(string SendFrom, string SendTo, string Subject, string Body, string host, int port, string password)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                bool result = regex.IsMatch(SendTo);
                if (result == false)
                {
                    return 0;
                }
                else
                {

                    MailAddress _SendFrom = new MailAddress(SendFrom);
                    MailAddress _SendTo = new MailAddress(SendTo);

                    MailMessage mail = new MailMessage(_SendFrom, _SendTo);
                    mail.Subject = Subject;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;

                    SmtpClient client = new SmtpClient();
                    client.Host = host;
                    client.Port = port;
                    client.EnableSsl = false;
                    client.Timeout = 10000;
                    client.UseDefaultCredentials = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential(SendFrom, password);
                    client.Send(mail);
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }

        public string Send_Email_With_Attachment(string SendTo, string SendFrom, string Subject, string Body, string AttachmentPath)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                string from = SendFrom;
                string to = SendTo;
                string subject = Subject;
                string body = Body;
                bool result = regex.IsMatch(to);
                if (result == false)
                {
                    return "Địa chỉ email không hợp lệ.";
                }
                else
                {
                    try
                    {
                        MailMessage em = new MailMessage(from, to, subject, body);
                        Attachment attach = new Attachment(AttachmentPath);
                        em.Attachments.Add(attach);
                        em.Bcc.Add(from);
                        System.Net.Mail.SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";//Ví dụ xử dụng SMTP của gmail                    
                        smtp.Send(em);
                        return "";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string Send_Email_With_BCC_Attachment(string SendTo, string SendBCC, string SendFrom, string Subject, string Body, string AttachmentPath)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                string from = SendFrom;
                string to = SendTo; //Danh sách email được ngăn cách nhau bởi dấu ";"
                string subject = Subject;
                string body = Body;
                string bcc = SendBCC;
                bool result = true;
                String[] ALL_EMAILS = to.Split(';');
                foreach (string emailaddress in ALL_EMAILS)
                {
                    result = regex.IsMatch(emailaddress);
                    if (result == false)
                    {
                        return "Địa chỉ email không hợp lệ.";
                    }
                }
                if (result == true)
                {
                    try
                    {
                        MailMessage em = new MailMessage(from, to, subject, body);
                        Attachment attach = new Attachment(AttachmentPath);
                        em.Attachments.Add(attach);
                        em.Bcc.Add(bcc);

                        System.Net.Mail.SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";//Ví dụ xử dụng SMTP của gmail
                        smtp.Send(em);

                        return "";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
