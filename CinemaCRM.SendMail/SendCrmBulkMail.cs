using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CinemaCRM.SendMail;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace CinemaCRM.SendMail
{
    public class SendCrmBulkMail
    {
        private string _fromMailAddress = "";
        private string _displayName = "";
        private string _toEmail = "";
        private string _smtpServer = "";
        private string _smtpAccount = "";
        private string _smtpPwd = "";
        private int _smtpPort = 25;
        private bool _smtpSsl = false;
        private int _timeOut = 20000;
        private int _sendInternal = 10000;
        private string _mailSubject = "";
        private string _mailBody = "";
        private DBConnect dbconnect = new DBConnect();

        /// <summary>
        /// Function to send e-mail
        /// Author: haudv
        /// Update: 9/30/2015
        /// </summary>
        /// <param name="failReason">The fail reason.</param>
        /// <returns>
        /// true: send mail successfully ; false: send mail fail
        /// </returns>
        private bool SendMail(out string failReason)
        {
            try
            {
                //Initial a SmtpClient to send email
                SmtpClient smtpClt = new SmtpClient(_smtpServer, _smtpPort);
                smtpClt.Credentials = new NetworkCredential(_smtpAccount, _smtpPwd);
                smtpClt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClt.EnableSsl = _smtpSsl;
                smtpClt.Timeout = _timeOut;

                //Create MailMessage which will be sent
                MailMessage mailMsg = new MailMessage();
                mailMsg.From = new MailAddress(_fromMailAddress, _displayName);
                mailMsg.To.Add(_toEmail);
                mailMsg.Subject = _mailSubject;
                mailMsg.Body = _mailBody;

                //Send mail
                smtpClt.Send(mailMsg);
                failReason = "";
                return true;
            }
            catch (Exception ex)
            {
                failReason = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Function to send an exist mail message
        /// Author: haudv
        /// Update: 9/30/2015
        /// </summary>
        /// <param name="mailMsg">Mail Message</param>
        /// <param name="failReason">Sending fail reason</param>
        /// <returns>
        /// true: send mail successfully ; false: send mail fail
        /// </returns>
        private bool SendMail(MailMessage mailMsg, out string failReason)
        {
            try
            {
                //Initial a SmtpClient to send email
                SmtpClient smtpClt = new SmtpClient(_smtpServer, _smtpPort);
                smtpClt.Credentials = new NetworkCredential(_smtpAccount, _smtpPwd);
                smtpClt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClt.EnableSsl = _smtpSsl;
                smtpClt.Timeout = _timeOut;

                //Send mail
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtpClt.Send(mailMsg);
                failReason = "";
                return true;
            }
            catch (Exception ex)
            {
                failReason = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Function to send Cinema Crm e-mail
        /// Author: haudv
        /// Update: 9/30/2015
        /// </summary>
        public void SendBulkMail()
        {
            try
            {

                //Setting smtp client parameters (see web.confif file)
                _smtpServer = ConfigurationManager.AppSettings["smtpserver"] + "";
                _smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["smtpport"]);
                _smtpAccount = ConfigurationManager.AppSettings["smtpaccount"] + "";
                _smtpPwd = ConfigurationManager.AppSettings["smtppassword"] + "";
                _smtpSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["smtpssl"]);
                _timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["smtptimeout"]);
                _sendInternal = Convert.ToInt32(ConfigurationManager.AppSettings["mailSendInterval"]);
                _fromMailAddress = ConfigurationManager.AppSettings["fromMailAddress"] + "";
                _displayName = ConfigurationManager.AppSettings["smtpDisplayName"] + "";

                //Cập nhật thông tin cần gửi mail từ bảng định nghĩa gửi mail cho chương trình quảng cáo
                //20160401 - NguyenNT update >>>
                //DBConnect.RunQuery("SP_CrmCampaignEmailSend_Insert");
                DBConnect.RunQuery("SP_CrmCampaignEmailSend_Insert");
                //20160401 End update<<<

                //Lấy danh sách thông tin đang chờ gửi email trong bảng hàng đợi
                DataTable sendList = dbconnect.myTable("SP_CrmCampaignEmailSend_GetAll");
                if (sendList.Rows.Count > 0)
                {
                    for (int i = 0; i < sendList.Rows.Count; i++)
                    {
                        try
                        {
                            string failReason = "";
                            string sBody = sendList.Rows[i]["Body"].ToString();
                            MailMessage mailMsg = new MailMessage();
                            mailMsg.From = new MailAddress(_fromMailAddress, _displayName);
                            mailMsg.To.Add(sendList.Rows[i]["ToEmail"].ToString());
                            mailMsg.Subject = sendList.Rows[i]["Subject"].ToString();
                            mailMsg.Body = "<img height=1 src='http://cskh.chieuphimquocgia.com.vn/CampaignEmailResult/MailOpened?id=" + sendList.Rows[i]["Id"] + "' width=1>" + MakeLink(sBody, sendList.Rows[i]["Id"].ToString());
                            mailMsg.IsBodyHtml = true;

                            //Send mail
                            bool sendStatus = this.SendMail(mailMsg, out failReason);
                            if (sendStatus == true)
                            {
                                //Cập nhật trạng thái đã gửi mail thành công và ngày gửi
                                DBConnect.RunQuery("SP_CrmCampaignEmailSend_UpdateSuccess", "@Id", System.Convert.ToInt32(sendList.Rows[i]["Id"]), "@FromEmail", _fromMailAddress);
                                DBConnect.RunQuery("SP_CrmCampaignEmailResult_Insert", "@Id", System.Convert.ToInt32(sendList.Rows[i]["Id"]), "@Status", 1);
                            }
                            else
                            {
                                //Cập nhật số lần đã cố gắng gửi, và cập nhật lí do gửi e-mail bị lỗi
                                DBConnect.RunQuery("SP_CrmCampaignEmailSend_UpdateFail", "@Id", System.Convert.ToInt32(sendList.Rows[i]["Id"]), "@FromEmail", _fromMailAddress, "@FailReason", failReason);
                                DBConnect.RunQuery("SP_CrmCampaignEmailResult_Insert", "@Id", System.Convert.ToInt32(sendList.Rows[i]["Id"]), "@Status", 0);
                            }

                            //Sleep a while for my health
                            System.Threading.Thread.Sleep(_sendInternal);
                        }
                        catch (Exception ex) { }
                    }
                }
            }
            catch (Exception ex) { }
        }

        protected string MakeLink(string txt, string id)
        {
            Regex regx = new Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);
            MatchCollection mactches = regx.Matches(txt);
            foreach (Match match in mactches)
            {
                txt = txt.Replace(match.Value, "http://cskh.chieuphimquocgia.com.vn/CampaignEmailResult/MailClicked?id=" + id + "&sUrl=" + match.Value);
            }
            return txt;
        }
    }
}
