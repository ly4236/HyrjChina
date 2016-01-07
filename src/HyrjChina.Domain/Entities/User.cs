using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string IDCard { get; set; }
        public string Nation { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }
        public string NativePlace { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyCall { get; set; }
        public string IsDelete { get; set; }
        public string IsActive { get; set; }

        public string UserRole { get; set; }
    }
}
