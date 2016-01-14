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
        private IMenuItemRepository menuItemRepository;

        public AdminController(IUserRepository repo, ISessionContext session, IMenuItemRepository menuItemRepo)
        {
            userRepository = repo;
            sessionContext = session;
            menuItemRepository = menuItemRepo;
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

        #region Menu
        public ActionResult MenuList()
        {
            MenuViewModel model = new MenuViewModel();
            model.Menu = menuItemRepository.MenuItems;
            
            return View(model);
        }

        public ActionResult MenuItemEdit(int ID)
        {
            MenuItem menuItem = menuItemRepository.MenuItems.FirstOrDefault(p => p.ID == ID);
            return View(menuItem);
        }

        [HttpPost]
        public ActionResult MenuItemEdit(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                menuItemRepository.SaveMenuItem(menuItem);
                TempData["message"] = string.Format("{0} 保存成功", menuItem.Name);
                return RedirectToAction("MenuList");
            }
            else
            {
                // there is something wrong with the data values
                return View(menuItem);
            }
        }

        public ViewResult MenuItemCreate()
        {
             return View("MenuItemEdit", new MenuItem());
        }

        [HttpPost]
        public ActionResult DeleteMenuItem(int ID)
        {
            MenuItem deletedMenuItem = menuItemRepository.DeleteMenuItem(ID);
            if (deletedMenuItem != null)
            {
                TempData["message"] = string.Format("{0} 被删除", deletedMenuItem.Name);
            }
            return RedirectToAction("MenuList");

        }
        #endregion

    }
}