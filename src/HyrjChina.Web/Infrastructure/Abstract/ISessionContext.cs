using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Web.Infrastructure.Abstract
{
    public interface ISessionContext
    {
        User GetUserData();
        void SetAuthenticationToken(string name, bool isPersistant, User userData);
     }
}
