using HyrjChina.Domain.Entities;

namespace HyrjChina.Domain.Abstarct
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
