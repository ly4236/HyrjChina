using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyrjChina.Domain.Abstarct;
using HyrjChina.Domain.Entities;

namespace HyrjChina.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public User Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public User GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public User GetByUsernameAndPassword(string username,string password)
        {
            return context.Users.Where(u => u.Username == username & u.Password == password).FirstOrDefault();
        }

        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
