using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SFProject.Biz.System;
using SFProject.Common.Layui;
using SFProject.Common.Util;
using SFProject.Entity.System;
using SFProject.Logger;
using SFProject.Web.Common;

namespace SFProject.Web.Areas.Amap.Controllers
{
    public class MenuController : BaseController
    {
        MenuService service = new MenuService();
        // GET: System/Menu

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMenuList()
        {
            ResponseData res = new ResponseData();
            IEnumerable<SYSMenu> list = null;
            res.code = 401;
            try
            {
                var response = service.GetMenuByRoleID(base.UserInfo.RoleID);
                if (response.IsSuccess)
                {
                    list = response.Result;
                }
                if (list != null)
                {
                    res.code = 200;
                    res.data = list;
                    res.msg = list != null && list.Any() ? "200" : "无数据";
                }
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                LogUtil.LogException(ex);
            }
            return Json(res);
        }

        /// <summary>
        /// 获取全部菜单
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllMenuList()
        {
            ResponseData res = new ResponseData();
            IEnumerable<SYSMenu> list = null;
            res.code = 401;
            try
            {
                var response = service.GetAllMenuList();
                if (response.IsSuccess)
                {
                    list = response.Result;
                }
                if (list != null)
                {
                    res.code = 200;
                    res.data = list;
                    res.msg = list != null && list.Any() ? "200" : "无数据";
                }
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                LogUtil.LogException(ex);
            }
            return Json(res);
        }

        /// <summary>
        /// 根据角色ID获取菜单列表
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public JsonResult GetMenuListByRoleID(int RoleID)
        {
            ResponseData res = new ResponseData();
            IEnumerable<SYSMenu> list = null;
            res.code = 401;
            try
            {
                var response = service.GetMenuByRoleID(RoleID);
                if (response.IsSuccess)
                {
                    list = response.Result;
                }
                if (list != null)
                {
                    res.code = 200;
                    res.data = list;
                    res.msg = list != null && list.Any() ? "200" : "无数据";
                }
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                LogUtil.LogException(ex);
            }
            return Json(res);
        }
    }
}