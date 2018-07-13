using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using CinemaCRM.SendSMS.vn.brandsms;

namespace CinemaCRM.SendSMS
{
    public class SendCrmSms
    {
        private DBConnect dbconnect = new DBConnect();
        private int _sendInternal = Convert.ToInt32(ConfigurationManager.AppSettings["smsSendInterval"]);
        private VMGAPI vmgapi = new VMGAPI();

        public void SendSms()
        {
            try
            {
                //Cập nhật thông tin cần gửi SMS từ bảng định nghĩa gửi SMS cho chương trình quảng cáo
                DBConnect.RunQuery("SP_CrmCampaignSmsSend_Insert");

                //Lấy danh sách thông tin đang chờ gửi email trong bảng hàng đợi
                DataTable sendList = dbconnect.myTable("SP_CrmCampaignSmsSend_GetAll");

                if (sendList.Rows.Count > 0)
                {
                    for (int i = 0; i < sendList.Rows.Count; i++)
                    {
                        try
                        {
                            string failReason = "";
                            string ToPhone = "84" + sendList.Rows[i]["CustomerPhone"].ToString().Substring(1);
                            string Message = sendList.Rows[i]["MessageContent"].ToString();

                            //Send Sms
                            ApiBulkReturn bulkReturn = vmgapi.BulkSendSms(ToPhone, "TTCPQG", Message, "0", "ttcpquocgia", "ttcpquocgia");
                            if (bulkReturn.error_code == 0)
                            {
                                //Cập nhật trạng thái đã gửi mail thành công và ngày gửi
                                DBConnect.RunQuery("SP_CrmCampaignSmsSend_UpdateSuccess", "@Id", System.Convert.ToInt32(sendList.Rows[i]["Id"]));
                            }
                            else
                            {
                                switch (bulkReturn.error_code)
                                {
                                    case -1:
                                        failReason = "Message content unicode character";
                                        break;
                                    case 100:
                                    case 101:
                                    case 102:
                                    case 103:
                                        failReason = "Authentication failure";
                                        break;
                                    case 104:
                                    case 105:
                                        failReason = "Template not invalid";
                                        break;
                                    case 900:
                                        failReason = "System is error";
                                        break;
                                    case 901:
                                    case 902:
                                    case 903:
                                        failReason = "Invalid message length or msisdn number";
                                        break;
                                    case 904:
                                        failReason = "Brandname is inactive";
                                        break;
                                }

                                //Cập nhật số lần đã cố gắng gửi, và cập nhật lí do gửi SMS bị lỗi
                                DBConnect.RunQuery("SP_CrmCampaignSmsSend_UpdateFail", "@Id", System.Convert.ToInt32(sendList.Rows[i]["Id"]), "@FailReason", failReason);
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
    }
}
