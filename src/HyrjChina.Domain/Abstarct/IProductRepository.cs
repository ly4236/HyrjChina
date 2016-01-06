using HyrjChina.Domain.Entities;
using System.Collections.Generic;

namespace HyrjChina.Domain.Abstarct
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

}
