using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyrjChina.Domain.Abstarct;
namespace HyrjChina.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Order> Orders
        {
            get { return context.Orders; }
        }

        public void SaveOrder(IEnumerable<Order> orders)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}
