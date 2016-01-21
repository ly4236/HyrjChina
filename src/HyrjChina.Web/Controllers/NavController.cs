using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using HyrjChina.Web.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Controllers
{
    public class NavController : Controller
    {
        ISessionContext _sessionContext;
        private ICategoryRepository _categoryRepository;
        public NavController(ICategoryRepository repo, ISessionContext sessionContext)
        {
            _categoryRepository = repo;
            _sessionContext = sessionContext;
        }
        public PartialViewResult ProductMenu(string id = null)
        {
            ViewBag.SelectedCategory = id;
            IEnumerable<string> categories = _categoryRepository.Categorys
            .Select(x => x.Name.ToString())
            .Distinct()
            .OrderBy(x => x);
            return PartialView("ProductsMenu", categories);
        }


        public PartialViewResult NavUser()
        {
            User user = _sessionContext.GetUserData();
            return PartialView(user);
        }
    }
}