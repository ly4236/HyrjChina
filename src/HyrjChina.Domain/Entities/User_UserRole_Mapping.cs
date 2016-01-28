using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public class User_UserRole_Mapping
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual UserRole UserRole { get; set; }
        public int UserRoleId { get; set; }
    }
}
