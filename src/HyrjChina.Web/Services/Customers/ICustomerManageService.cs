using HyrjChina.Web.Entities.Customers;
using HyrjChina.Web.Services.Models;
using HyrjChina.Web.Services.Util.Pagings;

namespace HyrjChina.Web.Services.Customers
{
    public interface ICustomerManageService
    {
        PagedResult<CustomerManagePageItem> GetList(Paging paging);

        Customer Get(string Name = "");

        bool Edit(Customer model);

        bool Create(Customer model);

        bool Delete(string Name);

        bool ExistsCustomer(string Name);
    }
}
