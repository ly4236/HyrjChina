using System.ComponentModel.DataAnnotations;

namespace HyrjChina.Web.Models.Customers
{
    public class HomeLoginRequest
    {
        public HomeLoginRequest()
        {
            Name = string.Empty;
            Password = string.Empty;
        }

        [StringLength(16)]
        [Required]
        [Display(Name = "用户名")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [StringLength(32)]
        [Required]
        [Display(Name = "登录密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public void Trim()
        {
            if (!string.IsNullOrEmpty(Name)) Name = Name.Trim();

            if (!string.IsNullOrEmpty(Password)) Password = Password.Trim();

        }
    }
}