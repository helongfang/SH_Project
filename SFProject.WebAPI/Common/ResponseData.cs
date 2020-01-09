using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFProject.WebAPI.Common
{
    public class ResponseData
    {
        public int code { get; set; }

        public string msg { get; set; }

        public int count { get; set; }

        public IEnumerable<object> data { get; set; }
    }
}