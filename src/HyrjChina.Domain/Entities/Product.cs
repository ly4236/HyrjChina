using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HyrjChina.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "请输入产品名称")]
        public string Name { get; set; }
        public string Category { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "请输入产品说明")]
        public string Description { get; set; }

        [Required]
        [Range(-double.MaxValue, double.MaxValue, ErrorMessage = "请输入价格")]
        public decimal Price { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        //public bool IsActive { get; set; }
        
    }
}
