using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testagat.Data;

namespace testagat.Models
{
    public class UsersModel
    {
        private UsersDAO UsersDAO;

        public UsersModel()
        {
            UsersDAO = new UsersDAO();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return UsersDAO.GetUsers();
        }

        public Users GetUser(int UserID)
        {
            return UsersDAO.GetUser(UserID);
        }

        public void SaveUser(Users user)
        {
            UsersDAO.SaveUser(user);
        }

        public void DeleteUser(int userID)
        {
            UsersDAO.DeleteUser(userID);
        }

        public int CreateUser(Users user)
        {
            return UsersDAO.CreateUser(user);
        }
    }
}