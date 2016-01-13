using HyrjChina.Domain.Entities;
using HyrjChina.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HyrjChina.Web.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public IEnumerable<SelectListItem> Categorys { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "类别")]
        public string CategoryID { get; set; }
    }
}