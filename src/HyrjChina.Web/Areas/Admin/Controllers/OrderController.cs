using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Web.Areas.Admin.Models;

namespace HyrjChina.Web.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository _orderRepository;
        IOrderItemRepository _orderItemRepository;
        public OrderController(
               IOrderRepository orderRepository,
               IOrderItemRepository orderItemRepository
            )
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        // GET: Admin/Order
        public ActionResult List(int page = 1, int pagesize = 10)
        {
            var orders = _orderRepository.Orders;
            OrderListViewModel model = new OrderListViewModel
            {
                Orders = orders.OrderBy(p => p.ID)
                .Skip((page - 1) * pagesize)
                .Take(pagesize),
                PagingInfo = new Web.Models.PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pagesize,
                    TotalItems = orders.Count()
                },
            };
            return View(model);
        }
    }
}