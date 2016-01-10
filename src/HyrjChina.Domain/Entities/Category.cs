using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HyrjChina.Domain.Entities
{
    public class Category
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; } //书中没有virtual关键字，这会导致导航属性不能加载，后面的输出就只有根目录！！
        public virtual List<Category> Subcategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            Subcategories = new List<Category>();
        }
    }
}
