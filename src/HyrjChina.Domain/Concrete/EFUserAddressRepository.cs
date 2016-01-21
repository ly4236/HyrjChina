using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;

namespace HyrjChina.Domain.Concrete
{
    public class EFUserAddressRepository : IUserAddressRepository
    {
        private EFDbContext context = new EFDbContext();
        public IOrderedQueryable<UserAddress> GetAddressesByUserId(int userid)
        {
            return context.UserAddresses.Where(x => x.UserId == userid).OrderBy(x => x.UserId);
        }
    }
}
