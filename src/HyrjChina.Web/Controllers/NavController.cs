using HyrjChina.Domain.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Controllers
{
    public class NavController : Controller
    {
        private ICategoryRepository repository;
        public NavController(ICategoryRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult ProductMenu(string id = null)
        {
            ViewBag.SelectedCategory = id;
            IEnumerable<string> categories = repository.Categorys
            .Select(x => x.Name.ToString())
            .Distinct()
            .OrderBy(x => x);
            return PartialView("ProductsMenu", categories);
        }
    }
}