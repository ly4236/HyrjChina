using HyrjChina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Abstarct
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username,string password);

        User GetByID(int ID);

        User Delete(int ID);

        void SaveUser(User user);
    }
}
