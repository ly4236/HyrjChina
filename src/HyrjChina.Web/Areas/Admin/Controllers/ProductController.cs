using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using HyrjChina.Web.Areas.Admin.Models;
using HyrjChina.Web.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HyrjChina.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        private ICategoryRepository categoryRepository;

        public ProductController(IProductRepository repo, ICategoryRepository categoryRepo)
        {
            repository = repo;
            categoryRepository = categoryRepo;
        }


        public ViewResult Index(string name, string categoryID, int page = 1, int pagesize = 10)
        {
            var products = repository.Products;
            if (!String.IsNullOrEmpty(name))
            {
                products = products.Where(s => s.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(categoryID))
            {
                products = products.Where(x => x.CategoryID == Convert.ToInt32(categoryID));
            }

            ProductListViewModel model = new ProductListViewModel()
            {
                Products = products.OrderBy(p => p.ID)
                .Skip((page - 1) * pagesize)
                .Take(pagesize),
                Categorys = new SelectList(categoryRepository.Categorys, "ID", "Name"),
                CategoryID = categoryID,
                Name = name,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pagesize,
                    TotalItems = products.Count()
                },
            };
            return View(model);
        }
        

        public ViewResult Edit(int ID)
        {
            ViewBag.category = new SelectList(categoryRepository.Categorys, "ID", "Name");
            Product product = repository.Products.FirstOrDefault(p => p.ID == ID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0,
                    image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} 保存成功", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }


        public ViewResult Create()
        {
            ViewBag.category = new SelectList(categoryRepository.Categorys, "ID", "Name");
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} 被删除", deletedProduct.Name);
            }
            return RedirectToAction("Index");

        }

        public FileContentResult GetImage(int ID)
        {
            Product prod = repository.Products
            .FirstOrDefault(p => p.ID == ID);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else {
                return null;
            }
        }
    }
}