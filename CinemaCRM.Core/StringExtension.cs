using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaCRM.Core
{
  public   class StringExtension
    {

        /// <summary>
        /// Convert List int to string được ngăn cách bởi dấu phẩy
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ListIntToStringByCommas(List<int> list) {
            //pass category identifiers as comma-delimited string
            string commaSeparatedIds = "";
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    commaSeparatedIds += list[i].ToString();
                    if (i != list.Count - 1)
                    {
                        commaSeparatedIds += ",";
                    }
                }
            }
            return commaSeparatedIds;
        }


        public static string GenerateRandomNumber(int length, string allowedChars = "0123456789")
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

            // Guid.NewGuid and System.Random are not particularly random. By using a
            // cryptographically-secure random number generator, the caller is always
            // protected, regardless of use.
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        // Divide the byte into allowedCharSet-sized groups. If the
                        // random value falls into the last group and the last group is
                        // too small to choose from the entire allowedCharSet, ignore
                        // the value in order to avoid biasing the result.
                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString().ToUpper();
            }
        }
        public static string GenerateRandomCode()
        {
            return String.Format("{0}{1}", GetDayNow(), GenerateRandomNumber(7));
        }
        private static string GetDayNow()
        {
            var dayofweek = DateTime.Now.DayOfWeek;
            switch (dayofweek)
            {
                case DayOfWeek.Monday:
                    return "M";
                case DayOfWeek.Tuesday:
                    return "T";
                case DayOfWeek.Wednesday:
                    return "W";
                case DayOfWeek.Thursday:
                    return "H";
                case DayOfWeek.Friday:
                    return "F";
                case DayOfWeek.Saturday:
                    return "S";
                default:
                    return "U";
            }



        }
      public static string GenerateCustomerCard(){
          return String.Format("{0}{1}", GetDayNow(), GenerateRandomNumber(10));
      }

       
    }
}
