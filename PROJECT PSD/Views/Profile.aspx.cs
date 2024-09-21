using PROJECT_PSD.Controller;
using PROJECT_PSD.Handler;
using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJECT_PSD.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
        {
            MsUser user = Session["User"] as MsUser;

            if (user != null)
            {
                //lblProfileMessage.Text = "xadaxaw";
                txtUsername.Text = user.UserName;
                txtEmail.Text = user.UserEmail;
                ddlGender.SelectedValue = user.UserGender;
                txtDOB.Text = user.UserDOB.ToString("dd MMMM yyyy");

                txtOldPassword.Text = user.UserPassword;
            }

            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            MsUser user = Session["User"] as MsUser;

            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string gender = ddlGender.SelectedValue;
            string dob = txtDOB.Text;

            string validationMessage = UserController.ValidateProfileUpdate(username, email, gender, dob);
            if (validationMessage == null)
            {
                int userID = user.UserID;
                DateTime dt = Convert.ToDateTime(dob);

                bool success = UserHandler.UpdateUserProfile(userID, username, email, gender, dt);

                lblProfileMessage.Text = success ? "Profile updated successfully." : "Failed to update profile.";
            }
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;

            MsUser user = Session["User"] as MsUser;
            string validationMessage = UserController.ValidatePasswordUpdate(oldPassword, newPassword);
            if (validationMessage == null)
            {
                //string currentUsername = User.Identity.Name;
                int currentUserID = user.UserID;
                bool success = UserHandler.UpdateUserPassword(currentUserID, oldPassword, newPassword);

                lblPasswordMessage.Text = success ? "Password updated successfully." : "Failed to update password.";
            }
            else lblProfileMessage.Text = validationMessage;
        }
    }
}