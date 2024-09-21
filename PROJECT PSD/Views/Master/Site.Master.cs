using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJECT_PSD.Views.Master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MsUser user = Session["User"] as MsUser;
                if (user != null)
                {

                    string role = user.UserRole;
                    if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        adminNav.Visible = true;
                    }
                    else
                    {
                        customerNav.Visible = true;
                    }
                }
                else Response.Redirect("~/Views/Home.aspx");
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            string[] cookies = Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {
                if (Request.Cookies[cookie] != null)
                {
                    HttpCookie expiredCookie = new HttpCookie(cookie)
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };
                    Response.Cookies.Add(expiredCookie);
                }

            }
            Session.Remove("User");
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}