using HyrjChina.Web.Session;

namespace HyrjChina.Web.Services
{
    public interface IManageService
    {
        void LoginOut(string Name, string ipAddress);

        CustomerSession GetUserSession(string Name, string password, string ipAddress);
    }
}
