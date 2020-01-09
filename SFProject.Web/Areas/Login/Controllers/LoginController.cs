using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SFProject.Biz.Account;
using SFProject.Common.Layui;
using SFProject.Common.Util;
using SFProject.Logger;
using SFProject.MessageContracts.Account;
using SFProject.Web.Common;

namespace SFProject.Web.Areas.Login.Controllers
{
    public class LoginController : Controller
    {
        AccountService service = new AccountService();
        // GET: Login/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Main()
        {
            return View();
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult UserLogin(CommonRequest request)
        {
            string msg = string.Empty;
            ResponseData res = new ResponseData();
            SYSUserInfoRequest condition = new SYSUserInfoRequest();
            SYSUserInfoResponse info = new SYSUserInfoResponse();
            List<SYSUserInfoResponse> list = new List<SYSUserInfoResponse>();
            res.code = 401;
            TokenInfo token = new TokenInfo();
            try
            {
                if (request.requestData != null)
                    condition = JsonHelper.DeserializeJsonToObject<SYSUserInfoRequest>(request.requestData);
            }
            catch (Exception ex)
            {
                res.code = 0;
                res.msg = "JSON字符串转数组对象错误" + ex.Message;
                return Json(res);
            }
            try
            {
                info = service.VerificationLogin(condition.UserName, condition.Password);
                if (info != null)
                {
                    //默认session会在20分钟内过期，设置一天过期
                    Session.Timeout = 1440;
                    Session["UserInfo"] = info;//保存用户信息对象

                    //保存签证信息
                    token.iss = "SFProject";
                    token.aud = "chaoran.fang@hi-genious.com";
                    token.sub = "Genious.com";
                    token.jti = DateTime.Now.ToString("yyyyMMddhhmmss");
                    token.OpUserID = info.ID.ToString();
                    token.UserId = info.ID;
                    token.UserName = info.UserName;
                    token.UserPwd = info.Password;
                    token.Status = info.State;
                    //生成令牌
                    msg = CommonToken.GetToken(token);
                    list.Add(info);
                    res.code = 200;
                    res.data = list;
                    res.msg = info.State == 1 ? msg : "false";
                }
            }
            catch (Exception ex)
            {
                LogUtil.LogException(ex);
                res.msg = ex.Message;
            }
            return Json(res);
        }
    }
}