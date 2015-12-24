﻿using HyrjChina.Web.Session;
using System;
using System.Web.Mvc;


namespace HyrjChina.Web.Filters
{
    public class CustomerAuthorizationAttribute : ActionFilterAttribute
    {
        public static readonly string CookieUserName = "Name";
        public static readonly string ManageLoginUrl = "/home/login";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //用户授权验证
            if (filterContext.HttpContext.Request.Cookies[CookieUserName] == null ||
                filterContext.HttpContext.Session == null ||
                filterContext.HttpContext.Session[filterContext.HttpContext.Session.SessionID] == null)
            {
                //跳转到登录界面
                filterContext.Result = new RedirectResult(ManageLoginUrl);
            }
            else
            {
                var cookieUserName = filterContext.HttpContext.Request.Cookies[CookieUserName].Value;
                var currentUserSession = filterContext.HttpContext.Session[filterContext.HttpContext.Session.SessionID] as CustomerSession;
                if (string.IsNullOrEmpty(cookieUserName) || currentUserSession == null)
                {
                    filterContext.Result = new RedirectResult(ManageLoginUrl);
                }
                else
                {
                    if (string.Compare(cookieUserName, currentUserSession.Name, StringComparison.CurrentCultureIgnoreCase) != 0 ||
                        String.Compare(currentUserSession.LoginIpAddress, filterContext.HttpContext.Request.UserHostAddress, StringComparison.CurrentCultureIgnoreCase) != 0)
                    {
                        filterContext.Result = new RedirectResult(ManageLoginUrl);
                    }
                    else
                    {
                        //用户权限菜单
                        //filterContext.Controller.TempData["UserPermissions"] = null;
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}