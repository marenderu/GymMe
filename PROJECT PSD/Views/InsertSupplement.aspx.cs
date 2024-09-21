using PROJECT_PSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJECT_PSD.Views
{
    public partial class InsertSupplement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string name = NameTB.Text.Trim();
            string expDateStr = ExpDateTB.Text.Trim();
            string priceStr = PriceTB.Text.Trim();
            string typeIdStr = TypeIDTB.Text.Trim();

            // Validate name
            if (string.IsNullOrEmpty(name))
            {
                ErrorMessageLabel.Text = "Name cannot be empty.";
                return;
            }
            if (!name.Contains("Supplement"))
            {
                ErrorMessageLabel.Text = "Name must contain 'Supplement'.";
                return;
            }

            // Validate expiry date
            if (string.IsNullOrEmpty(expDateStr) || !DateTime.TryParse(expDateStr, out DateTime expDate) || expDate <= DateTime.Today)
            {
                ErrorMessageLabel.Text = "Invalid or past expiry date.";
                return;
            }

            // Validate price
            if (string.IsNullOrEmpty(priceStr) || !int.TryParse(priceStr, out int price) || price < 3000)
            {
                ErrorMessageLabel.Text = "Price cannot be empty and must be a number (at least 3000).";
                return;
            }

            // Validate type ID
            if (string.IsNullOrEmpty(typeIdStr) || !int.TryParse(typeIdStr, out int typeId))
            {
                ErrorMessageLabel.Text = "Type ID must be a valid number.";
                return;
            }

            bool success = SupplementController.InsertSupplement(name, expDate, price, typeId);
            if (success)
            {
                Response.Redirect("~/Views/ManageSupplement.aspx");
            }
            else
            {
                ErrorMessageLabel.Text = "Failed to update supplement.";
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageSupplement.aspx");
        }
    }
}