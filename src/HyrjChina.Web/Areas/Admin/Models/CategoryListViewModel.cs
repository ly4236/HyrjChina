using HyrjChina.Domain.Entities;
using HyrjChina.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HyrjChina.Web.Areas.Admin.Models
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categorys { get; set; }

        public PagingInfo PagingInfo { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

    }
}