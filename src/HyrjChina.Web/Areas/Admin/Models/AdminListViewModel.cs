using HyrjChina.Domain.Entities;
using HyrjChina.Web.Models;
using System.Collections.Generic;

namespace HyrjChina.Web.Areas.Admin.Models
{
    public class AdminListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}