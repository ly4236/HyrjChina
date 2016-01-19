using HyrjChina.Domain.Entities;
using System.Collections.Generic;

namespace HyrjChina.Web.Areas.Admin.Models
{
    public class MenuViewModel
    {
        public IEnumerable<MenuItem> Menu { get; set; }
    }
}