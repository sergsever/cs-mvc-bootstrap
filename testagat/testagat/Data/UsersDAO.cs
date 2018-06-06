using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace testagat.Data
{
    public class UsersDAO
    {
        private AgatDbContext DbContext { get; set; }

        public UsersDAO()
        {
            DbContext = new AgatDbContext();
            DbContext.Configuration.ProxyCreationEnabled = false;
        }

        public IEnumerable<Users> GetUsers()
        {
            DbContext.Configuration.ProxyCreationEnabled = false;
            return DbContext.Users.ToList();
        }

        public Users GetUser(int userID)
        {
            return DbContext.Users.Find(userID);
        }

        public void SaveUser(Users user)
        {
            Users curr = DbContext.Users.Find(user.UserID);
            curr.Login = user.Login;
            curr.FirstName = user.FirstName;
            curr.LastName = user.LastName;
            curr.MiddleName = user.MiddleName;
            DbContext.SaveChanges();
        }

        public void DeleteUser(int userID)
        {
            Users user = DbContext.Users.FirstOrDefault(u => u.UserID == userID);
            DbContext.Users.Remove(user);
            DbContext.SaveChanges();


        }

        public int CreateUser(Users user)
        {
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
            int res = user.UserID;
            return res;
        }
        

        }
    }
