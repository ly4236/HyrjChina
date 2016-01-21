using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HyrjChina.Domain.Entities
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string LevelName { get; set; }

        public int ParentRegionId { get; set; }
        public virtual Region ParentRegion { get; set; }
        public virtual ICollection<Region> ChildrenRegionItems { get; set; }

        public ICollection<Address> ProvinceAddresses { get; set; }
        public ICollection<Address> CityAddresses { get; set; }
        public ICollection<Address> TownAddresses { get; set; }
    }
}