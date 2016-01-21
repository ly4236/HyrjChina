using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Abstarct
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
        void SaveOrder(IEnumerable<Order> orders);
    }
    public interface IOrderItemRepository { }
}
