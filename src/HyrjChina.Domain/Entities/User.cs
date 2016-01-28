using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HyrjChina.Domain.Entities
{
    public class User
    {

        private ICollection<UserRole> UserRoles { get; set; }
        private ICollection<Order> Orders { get; set; }
        private ICollection<Address> Addresses { get; set; }

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

        //[Display(Name = "身份证号")]
        //[StringLength(200)]
        //public string IDCard { get; set; }

        [Display(Name = "性别")]
        [StringLength(200)]
        public string Gender { get; set; }

        [Display(Name = "生日")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "电子邮件")]
        [StringLength(200)]
        public string Email { get; set; }

        [Display(Name = "手机号码")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public bool Delete { get; set; }
        public bool Active { get; set; }

        public int UserRoleId { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
