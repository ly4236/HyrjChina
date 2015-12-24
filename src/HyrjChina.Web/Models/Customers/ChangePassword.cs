using System.ComponentModel.DataAnnotations;

namespace HyrjChina.Web.Models.Customers
{
    public sealed class ChangePassword
    {
        [StringLength(16)]
        [Required]
        [Display(Name = "用户名")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [StringLength(32)]
        [Required]
        [Display(Name = "当前密码")]
        [DataType(DataType.Password)]

        public string CurrentPassword { get; set; }

        [StringLength(32)]
        [Required]
        [Display(Name = "新密码")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [StringLength(32)]
        [Required]
        [Display(Name = "重复新密码")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}