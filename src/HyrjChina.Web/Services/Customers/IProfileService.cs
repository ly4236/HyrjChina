using HyrjChina.Web.Entities.Customers;

namespace HyrjChina.Web.Services.Customers
{
    public interface IProfileService
    {
        Customer GetUserInfo(string Name = "");

        bool ChangePassword(string Name = "", string newPassword = "");
    }
}
