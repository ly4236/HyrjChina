using HyrjChina.Web.Services.Util;
using HyrjChina.Web.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyrjChina.Web.Services.Impl
{
    public sealed class ManageService : ServiceContext, IManageService
    {

        public void LoginOut(string Name, string ipAddress)
        {
        }

        public CustomerSession GetUserSession(string Name, string password, string ipAddress)
        {
            if (DbContext.Customer.Any(p => p.Name == Name && p.Password == password && p.Active && !p.Deleted))
            {
                return new CustomerSession
                {
                    LoginDateTime = DateTime.Now,
                    LoginIpAddress = ipAddress,
                    Name = Name,
                };
            }

            return null;
        }
    }
}