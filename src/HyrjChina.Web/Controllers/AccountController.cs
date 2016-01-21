using HyrjChina.Web.Infrastructure.Abstract;
using HyrjChina.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Web.Infrastructure.Concrete;

namespace HyrjChina.Web.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository repository;
        SessionContext sessionContext = new SessionContext();
        public AccountController(IUserRepository repo)
        {
            repository = repo;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var authenticatedUser = repository.GetByUsernameAndPassword(model.UserName, model.Password);
                if (authenticatedUser != null)
                {
                    sessionContext.SetAuthenticationToken(model.UserName, false, authenticatedUser);
                    return Redirect(returnUrl ?? Url.Action("Index","Home"));
                }
                else {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else {
                return View();
            }
        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect("~/");
        }
    }
}