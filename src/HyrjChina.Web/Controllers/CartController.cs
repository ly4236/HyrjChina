using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using System.Linq;
using System.Web.Mvc;
using HyrjChina.Web.Models;
using HyrjChina.Web.Infrastructure.Abstract;
using System.Collections.Generic;

namespace HyrjChina.Web.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private ISessionContext _sessionContext;
        //private IAddressRepository _addressRepository;
        private IUserAddressRepository _userAddressRepository;
        private IOrderRepository _orderRepository;
        private IAddressRepository _addressRepository;
        public CartController(
            IProductRepository repo,
            ISessionContext sessionContext,
          IAddressRepository addressRepository,
          IUserAddressRepository userAddressRepository,
          IOrderRepository orderRepository)
        {
            repository = repo;
            _sessionContext = sessionContext;
            _addressRepository = addressRepository;
            _userAddressRepository = userAddressRepository;
            _orderRepository = orderRepository;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int ID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int ID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ID == ID);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);

        }

        [Authorize]
        public ViewResult Checkout()
        {
            User user = _sessionContext.GetUserData();
            IOrderedQueryable<UserAddress> UserAddresses = _userAddressRepository.GetAddressesByUserId(user.ID);

            if (UserAddresses.Count() == 0)
            {
                Order model = new Order()
                {
                    User = _sessionContext.GetUserData()
                };
                return View(model);
            }
            else
            {
                Order model = new Order()
                {
                    User = _sessionContext.GetUserData(),
                    Address = _userAddressRepository.GetAddressesByUserId(user.ID).FirstOrDefault().Address,

                };
                model.AddressId = model.Address.Id;
                return View(model);
            }


        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, Order order, int AddressId)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                //orderProcessor.ProcessOrder(cart, shippingDetails);
                Address address = _addressRepository.Addresses.Where(x => x.Id == AddressId).FirstOrDefault();
                order.Address = new Address()
                {
                    ConsigneeName = address.ConsigneeName,
                    ProvinceId = address.ProvinceId,
                    CityId = address.CityId,
                    TownId = address.TownId,
                    CompleteAddress = address.CompleteAddress,
                    Phone = address.Phone,
                    AddressName = address.AddressName,

                };
                order.UserId = _sessionContext.GetUserData().ID;
                order.OrderStatus = 0;

                order.OrderItems = new List<OrderItem>();
                foreach (var item in cart.Lines)
                {
                    order.OrderItems.Add(new OrderItem()
                    {
                        ProductId = item.Product.ID,
                        Quantity = item.Quantity,
                        Price = item.Product.Price
                    });
                }
                order.OrderTotal = order.OrderItems.Sum(x => x.Price * x.Quantity);
                order.OrderDiscount = 1;
                _orderRepository.SaveOrder(order);
                cart.Clear();
                return View("Completed");
            }
            else {
                return View(order);
                //_orderRepository.Orders.
            }
        }
        public ActionResult Completed()
        {
            return View();
        }

    }

}
