using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        [Display(Name = "权限名称")]
        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }

        public bool Active { get; set; }
    }
}
