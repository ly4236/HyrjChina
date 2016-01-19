using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HyrjChina.Domain.Entities
{
    public class Product
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Display(Name = "名称")]
        [Required(ErrorMessage = "请输入产品名称")]
        public string Name { get; set; }
        [Display(Name = "产品类别")]
        public int CategoryID { get; set; }


        [Display(Name = "描述")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "请输入产品说明")]
        public string Description { get; set; }

        [Display(Name = "价格")]
        [Required]
        [Range(-double.MaxValue, double.MaxValue, ErrorMessage = "请输入价格")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        //public bool IsActive { get; set; }

        public virtual Category Category { get; set; }

    }
}
