using HyrjChina.Domain.Abstarct;
using System.Web.Mvc;

namespace HyrjChina.Web.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Products);
        }
    }
}