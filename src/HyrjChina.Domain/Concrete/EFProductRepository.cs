using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;
using System.Collections.Generic;
using System;

namespace HyrjChina.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveProduct(Product product)
        {
            if (product.ID == 0)
            {
                context.Products.Add(product);
            }
            else {
                Product dbEntry = context.Products.Find(product.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.CategoryID = product.CategoryID;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;

                }
            }
            context.SaveChanges();
        }

    }
}
