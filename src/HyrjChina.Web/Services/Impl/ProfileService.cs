using HyrjChina.Web.Entities.Customers;
using HyrjChina.Web.Services.Customers;
using HyrjChina.Web.Services.Util;
using System.Data.Entity;
using System.Linq;

namespace HyrjChina.Web.Services.Impl
{
    public sealed class ProfileService : ServiceContext, IProfileService
    {
        public Customer GetUserInfo(string Name = "")
        {
            return DbContext.Customer.FirstOrDefault(p => p.Name == Name);
        }

        public bool ChangePassword(string Name = "", string newPassword = "")
        {
            var userInfo = GetUserInfo(Name);

            if (userInfo == null) return false;

            userInfo.Password = newPassword;
            DbContext.Entry(userInfo).State = EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }
    }
}