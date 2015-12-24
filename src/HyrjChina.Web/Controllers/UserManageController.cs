using HyrjChina.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Controllers
{
    [CustomerAuthorization]
    public class UserManageController : Controller
    {
        //#region 私有字段
        //private readonly IUserManageService _userManageService = new UserManageService();

        //#endregion
        //// GET: UserManage
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}