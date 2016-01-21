using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Abstarct
{
    public interface IAddressRepository
    {
        IEnumerable<Address> Addresses { get; }

        void SaveCategory(Address address);

        Address DeleteAddress(int ID);

        IEnumerable<Product> GetAddresses(int ID);
    }

}
