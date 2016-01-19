using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using HyrjChina.Web.Areas.Admin.Models;
using HyrjChina.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;
        private IProductRepository productrepository;

        public CategoryController(
             IProductRepository product, ICategoryRepository category
         )
        {
            productrepository = product;
            categoryRepository = category;
        }

        // GET: Admin/Category
        public ActionResult Index(string name, int page = 1, int pagesize = 10)
        {
            var categorys = categoryRepository.Categorys;
            if (!String.IsNullOrEmpty(name))
            {
                categorys = categorys.Where(s => s.Name.Contains(name));
            }

            CategoryListViewModel model = new CategoryListViewModel()
            {
                Categorys = categorys.OrderBy(p => p.ID)
                .Skip((page - 1) * pagesize)
                .Take(pagesize),
                Name = name,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pagesize,
                    TotalItems = categorys.Count()
                },
            };
            return View(model);
        }

        public ViewResult Edit(int ID)
        {
            Category category = categoryRepository.Categorys.FirstOrDefault(p => p.ID == ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.SaveCategory(category);
                TempData["message"] = string.Format("{0} 保存成功", category.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(category);
            }
        }

        public ViewResult Create()
        {
               return View("Edit", new Category());
        }

        [HttpPost]
        public ActionResult Delete(int categoryID)
        {
            Category deletedCategory = categoryRepository.DeleteCategory(categoryID);
            if (deletedCategory != null)
            {
                TempData["message"] = string.Format("{0} 被删除", deletedCategory.Name);
            }
            return RedirectToAction("Index");

        }
    }
}