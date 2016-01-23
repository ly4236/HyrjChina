using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HyrjChina.Domain.Entities
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "名称")]
        [Required]
        [StringLength(maximumLength:100)]
        public string Name { get; set; }

        public int Level { get; set; }

        [StringLength(10)]
        public string LevelName { get; set; }
        
        [StringLength(15)]
        public string Code { get; set; }

        public int? ParentRegionId { get; set; }
        public virtual Region ParentRegion { get; set; }
        public virtual ICollection<Region> ChildrenRegionItems { get; set; }

        public ICollection<Address> ProvinceAddresses { get; set; }
        public ICollection<Address> CityAddresses { get; set; }
        public ICollection<Address> TownAddresses { get; set; }
    }
}