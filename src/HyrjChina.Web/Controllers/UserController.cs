
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
        IRegionRepository _regionReposiory;

        public UserController(
            ISessionContext context,
            IOrderRepository orderRepository,
            IUserAddressRepository userAddressRepository,
            IAddressRepository addressRepostory,
            IRegionRepository regionReposiory
            )
        {
            sessionContext = context;
            _orderRepository = orderRepository;
            _userAddressRepository = userAddressRepository;
            _addressRepostory = addressRepostory;
            _regionReposiory = regionReposiory;
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
            User user = sessionContext.GetUserData();
            var model = _userAddressRepository.GetAddressesByUserId(user.ID).ToList();
            return View(model);
        }


        public ActionResult AddressEdit(int addressId)
        {
            var model = _addressRepostory.Addresses.FirstOrDefault(x => x.Id == addressId);
            ViewData["Provinces"] = new SelectList(
              _regionReposiory.GetProvinces()
              , "ID", "Name");
            ViewData["Citys"] = new SelectList(
             _regionReposiory.GetSonRegion(model.ProvinceId)
             , "ID", "Name");
            ViewData["Towns"] = new SelectList(
             _regionReposiory.GetSonRegion(model.CityId)
             , "ID", "Name");
            return View(model);
        }


        [HttpPost]
        public ActionResult AddressEdit(Address addresss)
        {
            User user = sessionContext.GetUserData();
            UserAddress userAddress = new UserAddress()
            {
                Address = addresss,
                UserId = user.ID,
            };
            if (addresss.Id!=0)
            {
                userAddress.AddressId = addresss.Id;
            }
            if (ModelState.IsValid)
            {
                _userAddressRepository.SaveUserAddress(userAddress);
                TempData["message"] = string.Format("地址保存成功", addresss.AddressName);
                return RedirectToAction("UserAddresses");
            }
            else
            {
                // there is something wrong with the data values
                return View(addresss);
            }
        }

        public ActionResult AddressCreate()
        {
            ViewData["Provinces"] = new SelectList(
                _regionReposiory.GetProvinces()
                , "ID", "Name");
            return View("AddressEdit", new Address());
        }

        public JsonResult GetSonRegions(int Id)
        {
            return Json(
                new SelectList(
                _regionReposiory.GetSonRegion(Id)
                , "ID", "Name"));

        }

        public JsonResult GetProvinces()
        {
            return Json(
                new SelectList(
                _regionReposiory.GetProvinces()
                , "ID", "Name"));

        }

        public ActionResult UserOrders()
        {
            return View(_orderRepository.Orders);
        }
    }

    public class RegionViewModel
    {
        public SelectList Provinces { get; set; }
        public SelectList Citys { get; set; }
        public SelectList Towns { get; set; }
        public SelectList Countrys { get; set; }

        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? TownId { get; set; }
        public int? CountryId { get; set; }
    }
}