using HyrjChina.Web.Extendsions;
using HyrjChina.Web.Filters;
using HyrjChina.Web.Models.Customers;
using HyrjChina.Web.Services;
using HyrjChina.Web.Services.Impl;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Controllers
{
    public class HomeController : Controller
    {
        #region 私有字段

        private readonly IManageService _manageService = new ManageService();

        #endregion

        #region index method

        [CustomerAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region 登录操作

        public ActionResult Login()
        {
            return View(new HomeLoginRequest());
        }

        [HttpPost]
        [ValidateModelState]
        public ActionResult Login(HomeLoginRequest model)
        {
            model.Trim();

            var loginUserSession = _manageService.GetUserSession(model.Name, model.Password.ToMd5(), Request.UserHostAddress);

            if (loginUserSession != null)
            {
                Session[Session.SessionID] = loginUserSession;

                var UserCookie = new HttpCookie(CustomerAuthorizationAttribute.CookieUserName, model.Name);

                Response.Cookies.Add(UserCookie);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("_error", "登录密码错误或用户不存在或用户被禁用。");

            return View();
        }

        #endregion

        #region 注销操作

        [CustomerAuthorization]
        public ActionResult LoginOut()
        {
            if (Request.Cookies[CustomerAuthorizationAttribute.CookieUserName] != null &&
                !string.IsNullOrWhiteSpace(Request.Cookies[CustomerAuthorizationAttribute.CookieUserName].Value))
            {
                //退出登录日志记录操作
                _manageService.LoginOut(Request.Cookies[CustomerAuthorizationAttribute.CookieUserName].Value, Request.UserHostAddress);

                Session[Session.SessionID] = null;

                Response.Cookies.Add(new HttpCookie(CustomerAuthorizationAttribute.CookieUserName, string.Empty));
            }

            return RedirectToAction("Login");
        }

        #endregion
    }
}