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

        /// <summary>
        /// 获取子region
        /// </summary>
        /// <returns></returns>
        IEnumerable<Region> GetSonRegion(int ID);
        IEnumerable<Region> GetProvinces();
    }
}
