using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HyrjChina.Web.Areas.Admin.Models
{
    public class ChangePasswordViewModel
    {
        public int UserId { get; set; }

        [Display(Name ="旧的密码")]
        public string OldPassword { get; set; }

        [Display(Name = "新的密码")]
        public string NewPassword { get; set; }

        [Display(Name = "请在输入一次")]
        [Required(ErrorMessage ="请再输入一次密码")]
        [RegularExpression(@"\d",ErrorMessage ="密码格式不正确")]
        public string NewAgainPassword { get; set; }
    }
}