    using PROJECT_PSD.Controller;
using PROJECT_PSD.Models;
using PROJECT_PSD.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJECT_PSD.Views
{
    public partial class OrderSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<MsSupplement> supplements = SupplementRepository.GetAllSupplements();

                List<MsSupplementType> supplementTypes = SupplementRepository.GetAllSupplementTypes();

                var supplementData = from s in supplements
                                     join st in supplementTypes on s.SupplementTypeID equals st.SupplementTypeID
                                     select new
                                     {
                                         s.SupplementID,
                                         s.SupplementName,
                                         s.SupplementExpiryDate,
                                         s.SupplementPrice,
                                         st.SupplementTypeName
                                     };


                OrderSupplementGV.DataSource = supplementData;
                OrderSupplementGV.DataBind();
            }

        }
        protected void OrderSupplementGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                //lblMessage.Text = "dawkdpwadawd";
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                System.Diagnostics.Debug.WriteLine($"Row Index: {rowIndex}");
                GridViewRow row = OrderSupplementGV.Rows[rowIndex];
                    
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                int quantity = int.Parse(txtQuantity.Text);

                string validationMessage = CartController.validateQuantity(quantity);
                if(validationMessage == null)
                {
                    string supplementName = row.Cells[0].Text;
                    DateTime expiredDate = DateTime.Parse(row.Cells[1].Text);   
                    int price = int.Parse(row.Cells[2].Text);
                    string supplementTypeName = row.Cells[3].Text;

                    HiddenField hfSupplementID = (HiddenField)row.FindControl("hfSupplementID");
                    int supplementID = int.Parse(hfSupplementID.Value);

                    MsUser currentUser = Session["User"] as MsUser;
                    int userID = currentUser.UserID;

                    // Add to cart
                    CartRepository.insertCart(userID, supplementID, quantity);
                    lblMessage.Text = "Success add to cart";
                    refreshCartPage();
                }
                else lblMessage.Text = validationMessage;   
            }
        }

        private void refreshCartPage()
        {
            MsUser currentUser = Session["User"] as MsUser;
            int userID = currentUser.UserID;

            List<MsCart> cartList = CartRepository.GetCartByUserID(userID);
            cartGV.DataSource = cartList;
            cartGV.DataBind();


            // bkin subtotal
            foreach (GridViewRow checkoutRow in cartGV.Rows)
            {
                int rowIndex = checkoutRow.RowIndex;
                int quantity = Convert.ToInt32(checkoutRow.Cells[3].Text);
                int price = Convert.ToInt32(cartList[rowIndex].MsSupplement.SupplementPrice);
                int subTotal = quantity * price;

                Label subTotalLabel = (Label)checkoutRow.FindControl("SubTotal");
                subTotalLabel.Text = subTotal.ToString();
            }

            // bikin total price
            int totalPrice = cartList.Sum(item => item.Quantity * item.MsSupplement.SupplementPrice);
            lblTotalPrice.Text = totalPrice.ToString();

            //OrderSupplementGV.DataSource = SupplementRepository.GetAllSupplements();
            //OrderSupplementGV.DataBind();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            MsUser currentUser = Session["User"] as MsUser;
            int userID = currentUser.UserID;
            lblMessage.Text = OrderController.CheckoutCart(userID);
            refreshCartPage();
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            MsUser currentUser = Session["User"] as MsUser;
            int userID = currentUser.UserID;
            OrderController.ClearCart(userID);
            refreshCartPage();
        }

    }
}