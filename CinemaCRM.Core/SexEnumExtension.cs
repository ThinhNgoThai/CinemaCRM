using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaCRM.Core
{
    public class SexEnumExtension
    {
        private StatusFeature Male = new StatusFeature(1, "Nam");
        private StatusFeature Female = new StatusFeature(0, "Nữ");
      
        public string ToSexString(int code)
        {
            var arrayCode = new List<int>() { 1, 0 };
            if (arrayCode.Contains(code))
            {
                switch (code)
                {
                    case 30:
                        return Male.Des;
                   

                    default:

                        return Female.Des;
                }

            }
            else
            {
                return "Undefine Sex";
            }

        }

        public List<StatusFeature> ToSexList()
        {

            var list = new List<StatusFeature>();
            list.Add(Male);
            list.Add(Female);
           


            return list;
        }
    }
}
