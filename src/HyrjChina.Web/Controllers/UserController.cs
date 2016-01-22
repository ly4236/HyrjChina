
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
        IUserAddressRepository _userAddressRepository;
        IAddressRepository _addressRepostory;
        public UserController(
            ISessionContext context,
            IOrderRepository orderRepository,
            IUserAddressRepository userAddressRepository,
            IAddressRepository addressRepostory
            )
        {
            sessionContext = context;
            _orderRepository = orderRepository;
            _userAddressRepository = userAddressRepository;
            _addressRepostory = addressRepostory;
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

        public ActionResult AddressEdit(int addressId)
        {
            var model = _addressRepostory.Addresses.FirstOrDefault(x => x.Id == addressId);
            return View(model);
        }

        public ActionResult AddressCreate()
        {
            return View("AddressEdit", new Address());
        }

        public ActionResult UserOrders()
        {
            return View(_orderRepository.Orders);
        }
    }
}