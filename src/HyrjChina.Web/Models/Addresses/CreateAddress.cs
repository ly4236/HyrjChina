using System.ComponentModel.DataAnnotations;

namespace HyrjChina.Web.Models.Addresses
{
    public class CreateAddress
    {
        [StringLength(16)]
        [Required]
        [Display(Name = "收货人姓名")]
        [DataType(DataType.Text)]
        public string Name;

        [Required]
        public int ProvinceId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public string DetailedAddress { get; set; }

        [Required]
        [RegularExpression("",ErrorMessage ="手机号格式不正确")]
        public string Phone { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public string AddressName { get; set; }
    }
}