using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public bool Disable { get; set; }
        public bool HasAccess { get; set; }
        public int? ParentMenuID { get; set; }
        public virtual MenuItem ParentMenu { get; set; }
        public virtual ICollection<MenuItem> ChildrenMenuItems { get; set; }
    }
}
