using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using HyrjChina.Web.Areas.Admin.Models;
using HyrjChina.Web.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HyrjChina.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IUserRepository userRepository;
        private ISessionContext sessionContext;
        public AdminController(IUserRepository repo, ISessionContext session)
        {
            userRepository = repo;
            sessionContext = session;
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.UserId = sessionContext.GetUserData().ID;
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (model.NewAgainPassword != model.NewPassword)
            {
                ModelState.AddModelError("NewAgainPassword", "两次输入密码不一致");
            }
            if (!userRepository.IsPassRight(model.UserId, model.OldPassword))
            {
                ModelState.AddModelError("NewPassword", "原密码验证不正确");
            }
            if (ModelState.IsValid)
            {
                userRepository.ChangePassword(model.UserId, model.NewPassword);
                TempData["message"] = "密码修改成功";
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}