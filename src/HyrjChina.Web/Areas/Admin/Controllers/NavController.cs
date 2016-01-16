using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Areas.Admin.Controllers
{
    public class NavController : Controller
    {
        IMenuItemRepository menuitemRepository;
        // GET: Admin/Nav
        public NavController(IMenuItemRepository menuitemRepo)
        {
            menuitemRepository = menuitemRepo;
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
            IEnumerable<MenuItem> menu = menuitemRepository.MenuItems;


            return View(menu);
        }
    }
}