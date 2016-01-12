using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Abstarct
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categorys { get; }

        void SaveCategory(Category category);

        Category DeleteCategory(int ID);

        IEnumerable<Product> GetProducts(int ID);
    }
}
