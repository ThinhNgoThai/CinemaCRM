using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaCRM.Core
{
  public  class ComplainActionEnumExtension
    {
        private StatusFeature News = new StatusFeature(30, "Mới");
        private StatusFeature Process = new StatusFeature(20, "Đang xử lý");
        private StatusFeature Close = new StatusFeature(10, "Đóng");
        public string ToComplainActionString(int code)
        {
            var arrayCode = new List<int>() { 10, 20, 30 };
            if (arrayCode.Contains(code))
            {
                switch (code)
                {
                    case 30:
                        return News.Des;
                    case 20:
                        return Process.Des;

                    default:

                        return Close.Des;
                }

            }
            else
            {
                return "Undefine Priority status";
            }

        }

        public List<StatusFeature> ToComplainActionList()
        {

            var list = new List<StatusFeature>();
            list.Add(News);
            list.Add(Process);
            list.Add(Close);


            return list;
        }
    }
}
