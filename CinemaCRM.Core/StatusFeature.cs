using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaCRM.Core
{
    public class StatusFeature
    {
        public StatusFeature(int Code, string Des)
        {
            this.Code = Code;
            this.Des = Des;
        }
        public int Code { get; set; }
        public string Des { get; set; }

    }
}
