using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyrjChina.Web.Models
{
    public class ProductSoftwareIndexViewMode
    {
        public IList<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}