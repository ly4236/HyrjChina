﻿using HyrjChina.Core.Collections;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyrjChina.Web.Models;
using HyrjChina.Web.Areas.Admin.Models;
using HyrjChina.Web.Infrastructure.Abstract;

namespace HyrjChina.Web.Areas.Admin.Controllers
{
    public class NavController : Controller
    {
        IMenuItemRepository _menuItemRepository;
        ISessionContext _sessionContext;
        // GET: Admin/Nav
        public NavController(
            IMenuItemRepository menuitemRepo,
            ISessionContext sessionContext)
        {
            _menuItemRepository = menuitemRepo;
            _sessionContext = sessionContext;
        }
        public PartialViewResult ProductMenu(string id = null)
        {
            ViewBag.Selected = id;
            IEnumerable<string> items = new List<string>()
            {

            };
            return PartialView("ProductsMenu", items);
        }
        public ActionResult Menu()
        {
            IEnumerable<MenuItem> menuData = _menuItemRepository.MenuItems
                .OrderBy(x => x.Level)
                .ThenBy(x => x.ParentMenuID)
                .ThenBy(x => x.Order);
            var menu = GetTreeMenu(menuData);

            return View(menu);
        }

        public TreeNode<MenuItem> GetTreeMenu(IEnumerable<MenuItem> menu)
        {
            var item = new MenuItem();
            var treeNode = new TreeNode<MenuItem>(item);

            foreach (var menuItem in menu)
            {
                if (menuItem.ParentMenuID == null)
                {
                    treeNode.Append(menuItem);
                }
                else
                {
                    treeNode.Find(menuItem.ParentMenu).Append(menuItem);
                }
            }

            return treeNode;
        }

        public ActionResult Top()
        {
            TopNavViewModel model = new TopNavViewModel()
            {
                User = _sessionContext.GetUserData()
            };
            return View(model);
        }
    }
}