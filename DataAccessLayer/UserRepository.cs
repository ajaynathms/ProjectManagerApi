using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data.Entity;

namespace DataAccessLayer
{
   public class UserRepository
    {
        public List<User> GetAllUsers()
        {
            using (var context = new ProjectManagerContext())
            {
               return context.Users.ToList();
            }
        }
        public User AddUser(User oUser)
        {
            using (var context = new ProjectManagerContext())
            {
                context.Users.Add(oUser);
                context.SaveChanges();
                return oUser;
            }
        }
        public User UpdateUser(User oUser)
        {
            using (var context = new ProjectManagerContext())
            {
                context.Users.Attach(oUser);
                context.Entry(oUser).State = EntityState.Modified;
                context.SaveChanges();
                return oUser;
            }
        }
        public bool DeleteUser(User oUser)
        {
            using (var context = new ProjectManagerContext())
            {
                oUser = context.Users.FirstOrDefault(x => x.User_ID == oUser.User_ID);
                context.Users.Remove(oUser);
                context.SaveChanges();
                return true;
            }
        }
    }
}
