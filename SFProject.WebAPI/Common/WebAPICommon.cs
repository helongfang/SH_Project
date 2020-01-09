using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace SFProject.WebAPI.Common
{
    public class WebAPICommon
    {
        /// <summary>
        /// 返回json数据格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static HttpResponseMessage GetJsonData(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ScriptingJsonSerializationSection section = ConfigurationManager.GetSection("system.web.extensions/scripting/webServices/jsonSerialization") as ScriptingJsonSerializationSection;
            if (section != null)
            {
                serializer.MaxJsonLength = section.MaxJsonLength;
                serializer.RecursionLimit = section.RecursionLimit;
            }
            string str = serializer.Serialize(obj);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, System.Text.Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
    }
}