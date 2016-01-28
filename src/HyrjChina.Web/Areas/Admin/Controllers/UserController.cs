using System.Web.Mvc;
using HyrjChina.Domain.Abstarct;
namespace HyrjChina.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserRepository _userRepository;


        public UserController(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        // GET: Admin/User
        public ActionResult Index()
        {

            return View();
        }
    }
}