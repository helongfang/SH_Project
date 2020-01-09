using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SFProject.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            #region 启用api跨域访问
            var allowdMethods = ConfigurationManager.AppSettings["cors:allowedMethods"];
            var allowedOrigin = ConfigurationManager.AppSettings["cors:allowedOrigin"];
            var allowedHeaders = ConfigurationManager.AppSettings["cors:allowedHeaders"];
            var geducors = new EnableCorsAttribute(allowedOrigin, allowedHeaders, allowdMethods) { SupportsCredentials = true };
            config.EnableCors(geducors);
            #endregion
            // Web API 路由
            config.MapHttpAttributeRoutes();

           
            config.Routes.MapHttpRoute(
                name: "DefaultApinew",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            
            );



        }
    }
}
