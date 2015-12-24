using System.ComponentModel.DataAnnotations;
namespace HyrjChina.Web.Models.Customers
{
    public class CustomerCreateRequest
    {
        public CustomerCreateRequest()
        {
            Name = string.Empty;
            Password = string.Empty;
        }

        [MaxLength(16)]
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "用户名")]
        public string Name { get; set; }

        [MinLength(6)]
        [MaxLength(12)]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "登录密码")]
        public string Password { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "真实姓名")]
        public string Nick { get; set; }

        [Required]
        [Display(Name = "账号状态")]
        public bool IsEnable { get; set; }
    }
}