using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public class ShippingDetails
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "请输入姓名")]
        public string Name { get; set; }
        [Display(Name = "地址")]
        [Required(ErrorMessage = "请输入地址")]
        public string Address { get; set; }

    }

}
