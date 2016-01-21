using HyrjChina.Domain.Entities;
using System.Collections.Generic;

namespace HyrjChina.Domain.Abstarct
{
    public interface IRegionRepository
    {
        IEnumerable<Region> Regions { get; }

        void SaveCategory(Region category);

        Region DeleteRegion(int ID);

        IEnumerable<Region> GetRegions(int ID);
    }
}
