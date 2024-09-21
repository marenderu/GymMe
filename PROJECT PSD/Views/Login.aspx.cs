using PROJECT_PSD.Controller;
using PROJECT_PSD.Models;
using PROJECT_PSD.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJECT_PSD.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text; 
            bool rememberMe = chkRememberMe.Checked;

            string validationMessage = UserController.ValidateLogin(username, password);

            if (validationMessage == null)
            {
                MsUser checkUser = UserRepository.checkUserLogin(username, password);
                if (checkUser != null)
                {
                    Session["User"] = checkUser;
                    if(rememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("user_cookie");
                        cookie.Value = checkUser.UserID.ToString();
                        cookie.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(cookie);
                    }
                    Response.Redirect("~/Views/Home.aspx");
                }
                else lblMessage.Text = "User doesn't exist";
            }
            else lblMessage.Text = validationMessage;
        }
    }
}