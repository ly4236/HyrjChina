using HyrjChina.Domain.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyrjChina.Domain.Entities;

namespace HyrjChina.Domain.Concrete
{
  public  class EFCategoryRepository : ICategoryRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Category> Categorys
        {
            get { return context.Categorys; }
        }

        public Category DeleteCategory(int ID)
        {
            Category dbEntry = context.Categorys.Find(ID);
            if (dbEntry != null)
            {
                context.Categorys.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public IEnumerable<Product> GetProducts(int ID)
        {
            return context.Products.Where(x => x.CategoryID == ID);
        }

        public void SaveCategory(Category category)
        {
            if (category.ID == 0)
            {
                context.Categorys.Add(category);
            }
            else {
                Category dbEntry = context.Categorys.Find(category.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                    dbEntry.ParentCategoryId = category.ParentCategoryId;
                }
            }
            context.SaveChanges();
        }
    }
}
