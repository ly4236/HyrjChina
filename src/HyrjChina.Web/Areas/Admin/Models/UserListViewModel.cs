using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyrjChina.Web.Areas.Admin.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}