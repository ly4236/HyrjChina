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

        public void ChangePassword(int id, string newPassword)
        {
            try
            {
                User dbEntry = context.Users.Find(id);
                if (dbEntry != null)
                {
                    dbEntry.Password = newPassword;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public User GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return context.Users.Where(u => u.Username == username & u.Password == password).FirstOrDefault();
        }

        public bool IsPassRight(int id, string oldPassword)
        {
            User dbEntry = context.Users.Find(id);
            if (dbEntry == null)
            {
                throw new ArgumentNullException("未找到用户");
            }
            return oldPassword == dbEntry.Password;
        }

        public void SaveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
