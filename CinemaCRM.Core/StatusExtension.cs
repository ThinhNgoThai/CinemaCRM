using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaCRM.Core
{

    public class StatusExtension {
        public StatusExtension() {
            sStatus = new S_ShippingStatus();
            pStatus = new P_PaymentStatus();
            oStatus = new O_OrderStatus();
            onePayStatus = new OnePayStatus();
        }
        public S_ShippingStatus sStatus;
        public P_PaymentStatus pStatus;
        public O_OrderStatus oStatus;
        public OnePayStatus onePayStatus;
    }

    #region shipping stataus
    public class S_ShippingStatus
    {


        private StatusFeature S_ShippingNotRequired = new StatusFeature(10, "Không yêu cầu");
        private StatusFeature S_NotYetShipped = new StatusFeature(20, "Chưa chuyển hàng");
        private StatusFeature S_PartiallyShipped = new StatusFeature(25, "Chưa chuyển một phần");
        private StatusFeature S_Shipped = new StatusFeature(30, "Đã chuyển");
        private StatusFeature S_Delivered = new StatusFeature(40, "Đã Phân phối");

        public string ToShippingString(int code)
        {
            var arrayCode = new List<int>() { 10, 20, 25, 30, 40 };
            if (arrayCode.Contains(code))
            {
                switch (code)
                {
                    case 20:
                        return S_NotYetShipped.Des;
                    case 25:
                        return S_PartiallyShipped.Des;
                    case 30:
                        return S_Shipped.Des;
                    case 40:
                        return S_Delivered.Des;
                    default:
                        return S_ShippingNotRequired.Des;

                }

            }
            else
            {
                return "Undefine Shipping Status";
            }

        }

        public List<StatusFeature> ToShipList()
        {

            var list = new List<StatusFeature>();
            list.Add(S_ShippingNotRequired);
            list.Add(S_NotYetShipped);
            list.Add(S_PartiallyShipped);
            list.Add(S_Shipped);
            list.Add(S_Delivered);

            return list;
        }


    }
    #endregion
    #region payment status
    public class P_PaymentStatus
    {


        private StatusFeature P_Pending = new StatusFeature(10, "Chưa thanh toán");
        private StatusFeature P_Authorized = new StatusFeature(20, "Kiểm duyệt");
        private StatusFeature P_PartiallyRefunded = new StatusFeature(25, "Thanh toán một phần");
        private StatusFeature P_Refunded = new StatusFeature(30, "Thanh toán");
        private StatusFeature P_Voided = new StatusFeature(40, "Phiếu khống");

        public string ToPaymentString(int code)
        {
            var arrayCode = new List<int>() { 10, 20, 30, 40 };
            if (!arrayCode.Contains(code))
            {
                switch (code)
                {
                    case 10:
                        return P_Pending.Des;
                    case 20:
                        return P_Authorized.Des;
                    case 25:
                        return P_PartiallyRefunded.Des;
                    case 30:
                        return P_Refunded.Des;
                    default:
                        return P_Voided.Des;

                }

            }
            else
            {
                return "Undefine Payment Status";
            }

        }

        public List<StatusFeature> ToPaymentList()
        {

            var list = new List<StatusFeature>();
            list.Add(P_Pending);
            list.Add(P_Authorized);
            list.Add(P_PartiallyRefunded);
            list.Add(P_Refunded);
            list.Add(P_Voided);

            return list;
        }


    }
    #endregion

    #region order stataus
    public class O_OrderStatus
    {


        private StatusFeature O_Pending = new StatusFeature(10, "Đang chờ");
        private StatusFeature O_Processing = new StatusFeature(20, "Đang giao dịch");
        private StatusFeature O_Complete = new StatusFeature(30, "Thành công");
        private StatusFeature O_Cancelled = new StatusFeature(40, "Hủy");
        

        public string ToOrderString(int code)
        {
            var arrayCode = new List<int>() { 10, 20, 30, 40 };
            if (arrayCode.Contains(code))
            {
                switch (code)
                {
                    case 20:
                        return O_Processing.Des;
                    case 30:
                        return O_Complete.Des;
                    case 40:
                        return O_Cancelled.Des;
                    default:

                        return O_Pending.Des;
                }

            }
            else
            {
                return "Undefine Oder Status";
            }

        }

        public List<StatusFeature> ToOrderList()
        {

            var list = new List<StatusFeature>();
            list.Add(O_Pending);
            list.Add(O_Processing);
            list.Add(O_Complete);
            list.Add(O_Complete);

            return list;
        }


    }

    #endregion

    #region OnePayStatus
    public class OnePayStatus{

    
        private StatusFeature Success = new StatusFeature(30, "Đang chờ");
        private StatusFeature Fail = new StatusFeature(60, "Đang giao dịch");

        public string ToOnePayString(int code)
        {
            var arrayCode = new List<int>() { 10, 20, 30, 40 };
            if (arrayCode.Contains(code))
            {
                switch (code)
                {
                    case 20:
                        return Success.Des;
            
                     
                    default:

                        return Fail.Des;
                }

            }
            else
            {
                return "Undefine OnePay Status";
            }

        }

        public List<StatusFeature> ToOnePayList()
        {

            var list = new List<StatusFeature>();
            list.Add(Success);
            list.Add(Fail);
        

            return list;
        }



  }

    #endregion

   


}
