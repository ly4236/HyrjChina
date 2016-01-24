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

        public void SaveUserAddress(UserAddress userAddress)
        {
            if (userAddress.AddressId == 0)
            {
                context.UserAddresses.Add(userAddress);
            }
            else {
                UserAddress dbEntry = context.UserAddresses.Find(userAddress.AddressId, userAddress.UserId);
                if (dbEntry != null)
                {
                    dbEntry.Address.ConsigneeName = userAddress.Address.ConsigneeName;
                    dbEntry.Address.ProvinceId = userAddress.Address.ProvinceId;
                    dbEntry.Address.CityId = userAddress.Address.CityId;
                    dbEntry.Address.TownId = userAddress.Address.TownId;
                    dbEntry.Address.CompleteAddress = userAddress.Address.CompleteAddress;
                    dbEntry.Address.Phone = userAddress.Address.Phone;
                    dbEntry.Address.AddressName = userAddress.Address.AddressName;
                }
            }
            context.SaveChanges();
        }
    }
}
