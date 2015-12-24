using System.ComponentModel.DataAnnotations;

namespace HyrjChina.Web.Models.Customers
{
    public sealed class ProfileChangePasswordRequest
    {
        public ProfileChangePasswordRequest()
        {
            Name = string.Empty;
            CurrentPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmPassword = string.Empty;
        }

        [Required]
        [Display(Name = "用户账号")]
        public string Name { get; set; }

        [StringLength(32)]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string CurrentPassword { get; set; }

        [StringLength(32)]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "新的密码")]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        [Display(Name = "确认密码")]
        public string ConfirmPassword { get; set; }

        public void Trim()
        {
            if (!string.IsNullOrEmpty(Name)) Name = Name.Trim();

            if (!string.IsNullOrEmpty(CurrentPassword)) CurrentPassword = CurrentPassword.Trim();

            if (!string.IsNullOrEmpty(NewPassword)) NewPassword = NewPassword.Trim();

            if (!string.IsNullOrEmpty(ConfirmPassword)) ConfirmPassword = ConfirmPassword.Trim();
        }
    }
}