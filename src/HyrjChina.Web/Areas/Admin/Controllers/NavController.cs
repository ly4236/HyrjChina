using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Areas.Admin.Controllers
{
    public class NavController : Controller
    {
        // GET: Admin/Nav
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ProductMenu(string id = null)
        {
            ViewBag.Selected = id;
            IEnumerable<string> items = new List<string>()
            {

            };
            return PartialView("ProductsMenu", items);
        }
    }
}