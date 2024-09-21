using PROJECT_PSD.Models;
using PROJECT_PSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJECT_PSD.Views
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MsUser currentUser = Session["User"] as MsUser;

                if (currentUser != null)
                {

                    List<TransactionHeader> list;

                    if (currentUser.UserRole == "Admin")
                    {
                        list = TransactionRepository.GetAllTransactionHeader();
                        TransactionHistoryGV.DataSource = list;
                        TransactionHistoryGV.DataBind();
                    }

                    // role = customer
                    else if (currentUser.UserRole == "Customer")
                    {
                        int userID = currentUser.UserID;
                        list = TransactionRepository.GetAllUserTransaction(userID);
                        TransactionHistoryGV.DataSource = list;
                        TransactionHistoryGV.DataBind();
                    }
                }
                else Response.Redirect("~/Views/Login.aspx");
            }

        }

        protected void Detail_btn_Click(object sender, EventArgs e)
        {

            int transactionID = Convert.ToInt32((sender as Button).CommandArgument);
            Response.Redirect("~/Views/TransactionDetailPage.aspx?ID=" + transactionID);
        }
    }
}