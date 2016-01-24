using HyrjChina.Domain.Entities;
using HyrjChina.Web.Models;
using System;
using System.Collections.Generic;

namespace HyrjChina.Web.Areas.Admin.Models
{
    public class OrderListViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}