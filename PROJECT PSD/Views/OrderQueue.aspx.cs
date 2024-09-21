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
    public partial class OrderQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgridview();
            }

        }

        protected void bindgridview()
        {
            List<TransactionHeader> list;
            list = TransactionRepository.GetUnhandledTransaction();

            TransactionQueueGV.DataSource = list;
            TransactionQueueGV.DataBind();
        }

        protected void handle_btn_Click(object sender, EventArgs e)
        {
            int transactionID = Convert.ToInt32((sender as Button).CommandArgument);
            TransactionHeader tobeupdated = TransactionRepository.GetTransactionHeaderById(transactionID);

            tobeupdated.Status = "handled";
            TransactionRepository.UpdateTransactionStatus(tobeupdated);
        }
    }
}