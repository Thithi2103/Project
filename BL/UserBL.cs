using System;
using System.Collections.Generic;
using DAL;
using Persistence;

namespace BL
{
    public class UserBL
    {
        private UserDAL dal = new UserDAL();
        public User GetUserByUserName(string username)
        {
            return UserDAL.GetUserByUsername(username);
        }
        public User GetUserByID(int ID)
        {
            return UserDAL.GetUserById(ID);
        }
        public bool CheckExistUserAndPass(string user, string pass)
        {
            if(user.Contains(" "))return false;
            if(pass.Contains(" "))return false;

            return UserDAL.CheckUserAndPass(user, pass);
        }
        public List<Application> GetApplicationBoughtByUserID(int UserID)
        {
            return ApplicationDAL.GetApplicationBoughtByUserID(UserID);
        }
    }
}