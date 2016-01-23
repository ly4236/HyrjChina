using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;

namespace HyrjChina.Domain.Concrete
{
    public class EFRegionRepository : IRegionRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Region> Regions
        {
            get
            {
                return context.Regions;
            }
        }

        public Region DeleteRegion(int ID)
        {

            throw new NotImplementedException();
        }

        public IEnumerable<Region> GetSonRegion(int ID)
        {
            return context.Regions.Where(x => x.ParentRegionId == ID).OrderBy(x => x.Code);
        }


        public IEnumerable<Region> GetProvinces()
        {
            return context.Regions
                .Where(x => x.Level == 1)
                .OrderBy(x => x.Code);
        }

        public IEnumerable<Region> GetRegions(int ID)
        {
            return context.Regions.Where(x => x.Id == ID);
        }


        public void SaveCategory(Region category)
        {
            throw new NotImplementedException();
        }

    }
}
