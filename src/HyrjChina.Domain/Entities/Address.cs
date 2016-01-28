using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HyrjChina.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "收货人名称")]
        [StringLength(50)]
        public string ConsigneeName { get; set; }

        public int ProvinceId { get; set; }

        public virtual Region Province { get; set; }

        public int CityId { get; set; }

        public virtual Region City { get; set; }

        public int TownId { get; set; }

        public virtual Region Town { get; set; }


        [Display(Name = "详细地址")]
        public string CompleteAddress { get; set; }

        [Display(Name = "手机号")]
        public string Phone { get; set; }

        [Display(Name = "固定电话")]
        public string Tel { get; set; }

        [Display(Name = "地址别名")]
        public string AddressName { get; set; }


        [Display(Name = "公司名称")]
        public string CompanyName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}