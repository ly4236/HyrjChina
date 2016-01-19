using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HyrjChina.Domain.Entities
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(maximumLength: 50)]
        public string ActionName { get; set; }

        [StringLength(maximumLength: 50)]
        public string ControllerName { get; set; }

        [StringLength(maximumLength: 50)]
        public string Url { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public bool Disable { get; set; }

        [Required]
        public bool HasAccess { get; set; }


        public int? ParentMenuID { get; set; }

        [Required]
        public int Level { get; set; }

        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }
        public virtual MenuItem ParentMenu { get; set; }
        public virtual ICollection<MenuItem> ChildrenMenuItems { get; set; }
    }
}
