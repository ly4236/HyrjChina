using HyrjChina.Domain.Entities;
using System.Collections.Generic;

namespace HyrjChina.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
