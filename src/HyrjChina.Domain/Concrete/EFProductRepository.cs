using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using System.Collections.Generic;

namespace HyrjChina.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }

        }
    }
}
