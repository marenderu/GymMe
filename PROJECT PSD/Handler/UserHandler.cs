using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Handler
{
    public class UserHandler
    {
        public static bool UpdateUserProfile(int userID, string newUsername, string email, string gender, DateTime dob)
        {
            using (LocalDatabaseEntities db = new LocalDatabaseEntities())
            {
                var user = db.MsUsers.FirstOrDefault(u => u.UserID == userID);
                if (user != null)
                {
                    user.UserName = newUsername;
                    user.UserEmail = email;
                    user.UserGender = gender;
                    user.UserDOB = dob;

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool UpdateUserPassword(int userID, string oldPassword, string newPassword)
        {
            using (LocalDatabaseEntities db = new LocalDatabaseEntities())
            {
                var user = db.MsUsers.FirstOrDefault(u => u.UserID == userID && u.UserPassword == oldPassword);
                if (user != null)
                {
                    user.UserPassword = newPassword;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}