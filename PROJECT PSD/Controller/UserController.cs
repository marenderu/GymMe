using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace PROJECT_PSD.Controller
{
    public class UserController
    {
        public static string ValidateLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Username cannot be empty";
            }

            if (string.IsNullOrEmpty(password))
            {
                return "Password cannot be empty";
            }
            return null;
        }

        public static string ValidateRegistration(string username, string email, string gender, string password, string confirmPassword, string dob)
        {
            if (username.Length < 5 || username.Length > 15)
            {
                return "Username must be between 5 and 15 characters.";
            }

            if (!email.EndsWith(".com"))
            {
                return "Email must end with '.com'.";
            }

            if (string.IsNullOrEmpty(gender))
            {
                return "Gender must be chosen.";
            }

            if (string.IsNullOrEmpty(password) || !IsAlphanumeric(password))
            {
                return "Password must be alphanumeric and cannot be empty";
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                return "Confirm Password cannot be empty";
            }

            if (password != confirmPassword)
            {
                return "Passwords do not match.";
            }

            if (!DateTime.TryParse(dob, out DateTime dateOfBirth))
            {
                return "Invalid date of birth.";
            }

            return null;
        }

        private static bool IsAlphanumeric(string password)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(password);
        }

        public static string ValidateProfileUpdate(string username, string email, string gender, string dob)
        {
            if (username.Length < 5 || username.Length > 15 || !System.Text.RegularExpressions.Regex.IsMatch(username, "^[a-zA-Z0-9]+$"))
            {
                return "Username must be between 5 and 15 characters and can only contain alphabets and spaces.";
            }

            if (!email.EndsWith(".com"))
            {
                return "Email must end with '.com'.";
            }

            if (string.IsNullOrEmpty(gender))
            {
                return "Gender must be chosen.";
            }

            if (string.IsNullOrEmpty(dob))
            {
                return "Date of Birth cannot be empty.";
            }

            if (!DateTime.TryParse(dob, out _))
            {
                return "Invalid date of birth.";
            }

            return null;
        }

        public static string ValidatePasswordUpdate(string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword))
            {
                return "Old password must be same as the current password and cannot be empty.";
            }

            if (!IsAlphanumeric(newPassword))
            {
                return "New password must be alphanumeric and cannot be empty.";
            }


            return null;
        }
    }
}