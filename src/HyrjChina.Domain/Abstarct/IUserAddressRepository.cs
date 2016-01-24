using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Abstarct
{
    public interface IUserAddressRepository
    {
        IOrderedQueryable<UserAddress> GetAddressesByUserId(int userid);

        void SaveUserAddress(UserAddress userAddress);
    }
}
