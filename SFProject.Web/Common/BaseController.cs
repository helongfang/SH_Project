using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SFProject.Biz.System;
using SFProject.Entity.System;
using SFProject.MessageContracts.Account;
using SFProject.MessageContracts.System;

namespace SFProject.Web.Common
{
    public class BaseController : Controller
    {
        public SYSUserInfoResponse UserInfo
        {
            get
            {
                return Session["UserInfo"] as SYSUserInfoResponse;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserInfo == null)
            {
                filterContext.Result = new RedirectResult("/Login/Login/Index");
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (string.Equals("POST", filterContext.HttpContext.Request.RequestType, StringComparison.OrdinalIgnoreCase))
            {
                new LogService().Log(new LogRequest() { LogHistory = new LogHistory() { Name = UserInfo.UserName, Time = DateTime.Now, Action = filterContext.RouteData.Values["action"].ToString() } });
            }
        }
    }
}