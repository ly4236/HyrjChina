using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HyrjChina.Web.Entities.Customers
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [DisplayName("用户名")]
        public string Name { get; set; }
        
        [MaxLength(32)]
        [DisplayName("登录密码")]
        public string Password { get; set; }
        
        [MaxLength(50)]
        [DisplayName("昵称")]
        public string Nick { get; set; }

        [MaxLength(50)]
        [DisplayName("邮箱")]
        public string Email { get; set; }

        [MaxLength(20)]
        [DisplayName("手机号")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("激活")]
        public bool Active { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        [DisplayName("删除")]
        public bool Deleted { get; set; }

        [DisplayName("上次登录时间")]
        public DateTime LastLoginTime { get; set; }

        [DisplayName("管理员评价")]
        public string AdminComment { get; set; }

    }
}