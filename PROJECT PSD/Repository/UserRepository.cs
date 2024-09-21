using PROJECT_PSD.Factory;
using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Repository
{
    public class UserRepository
    {
        static LocalDatabaseEntities db = Singleton.GetInstance();
        public static List<MsUser> GetAllUsers()
        {
            return db.MsUsers.ToList();
        }

        public static MsUser GetUserById(int id)
        {
            return db.MsUsers.Find(id);
        }

        public static MsUser checkUserLogin(string username, string password)
        {
            return (from user in db.MsUsers where user.UserName == username && user.UserPassword == password select user).FirstOrDefault();
        }

        public static List<MsUser> GetAllCustomers()
        {
            return db.MsUsers.Where(u => u.UserRole.Equals("Customer", StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static string InsertUser(string name, string email, DateTime dob, string gender, string role, string password)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            MsUser newUser = UserFactory.createUser(name, email, dob, gender, role, password);
            db.MsUsers.Add(newUser);
            db.SaveChanges();
            return "Registration Success";
        }
    }
}