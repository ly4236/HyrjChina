using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public class UserAddress
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
