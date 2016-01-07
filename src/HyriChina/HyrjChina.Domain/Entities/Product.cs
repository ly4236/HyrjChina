using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int? ProductGroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsPulish { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
