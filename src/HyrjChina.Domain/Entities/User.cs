using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HyrjChina.Domain.Entities
{
    public class User
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = "用户名")]
        [StringLength(50)]
        public string Username { get; set; }

        [Display(Name = "密码")]
        [StringLength(200)]
        public string Password { get; set; }

        [Display(Name = "姓名")]
        [StringLength(200)]
        public string Name { get; set; }


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
