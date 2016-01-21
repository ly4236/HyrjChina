
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyrjChina.Web.Infrastructure.Abstract;
using HyrjChina.Domain.Entities;
using HyrjChina.Domain.Abstarct;
namespace HyrjChina.Web.Controllers
{
    public class UserController : Controller
    {
        ISessionContext sessionContext;
        IOrderRepository _orderRepository;
        public UserController(ISessionContext context, IOrderRepository orderRepository)
        {
            sessionContext = context;
            _orderRepository = orderRepository;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }
        public ActionResult UserAddresses()
        {
            return View();
        }

        public ActionResult UserOrders()
        {
            return View(_orderRepository.Orders);
        }
    }
}