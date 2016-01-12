using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Web.Models;
using HyrjChina.Domain.Entities;

namespace HyrjChina.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRespository repository;
        public int PageSize = 4;

        public ProductController(IProductRespository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult Index(int ID)
        {
            Product product = repository.Products.First(x => x.ID == ID);
            return View(product);
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.CategoryID.ToString() ==
                    category)
                    .OrderBy(p => p.ID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                            repository.Products.Count() :
                            repository.Products.Where(e => e.CategoryID.ToString() ==
                            category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
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
        public ViewResult ProductSoftwareIndex()
        {
            ProductSoftwareIndexViewMode model = new ProductSoftwareIndexViewMode
            {
                Products = repository.Products
                    .Where(p => p.CategoryID == 1)
                    .OrderBy(p => p.ID).ToList()
            };
            return View(model);
        }


    }
}