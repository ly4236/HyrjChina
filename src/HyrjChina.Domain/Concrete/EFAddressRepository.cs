using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;

namespace HyrjChina.Domain.Concrete
{
    public class EFAddressRepository : IAddressRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Address> Addresses
        {
            get
            {
                return context.Addresses;
            }
        }

        public Address DeleteAddress(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAddresses(int ID)
        {
            throw new NotImplementedException();
        }

        public void SaveAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
