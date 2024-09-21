using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Factory
{
    public class UserFactory
    {
        public static MsUser createUser(string name, string email, DateTime dob, string gender, string role, string password)
        {
            MsUser user = new MsUser();
            user.UserName = name;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = dob;
            user.UserRole = role;
            user.UserPassword = password;
            return user;
        }
    }
}