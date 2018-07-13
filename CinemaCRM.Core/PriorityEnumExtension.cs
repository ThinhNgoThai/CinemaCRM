using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaCRM.Core
{
   public class PriorityEnumExtension
    {

        private StatusFeature High = new StatusFeature(30, "Cao");
        private StatusFeature Medium = new StatusFeature(20, "Trung bình");
        private StatusFeature Low = new StatusFeature(10, "Thấp");
        public string ToPriorityString(int code)
        {
            var arrayCode = new List<int>() { 10, 20, 30 };
            if (arrayCode.Contains(code))
            {
                switch (code)
                {
                    case 30:
                        return High.Des;
                    case 20:
                        return Medium.Des;

                    default:

                        return Low.Des;
                }

            }
            else
            {
                return "Undefine Priority status";
            }

        }

        public List<StatusFeature> ToPriorityList()
        {

            var list = new List<StatusFeature>();
            list.Add(High);
            list.Add(Medium);
            list.Add(Low);


            return list;
        }
    }
}
