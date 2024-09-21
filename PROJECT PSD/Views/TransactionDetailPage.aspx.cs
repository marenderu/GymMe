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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        static LocalDatabaseEntities db = Singleton.GetInstance();
        private void BindGridView()
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);


            TransactionHeader transactionHeader = TransactionRepository.GetTransactionHeaderById(id);
            List<TransactionDetail> transactionDetails = TransactionRepository.GetAllTransactionDetail();
            List<MsSupplement> msSupplements = SupplementRepository.GetAllSupplements();
            List<MsSupplementType> msSupplementTypes = SupplementRepository.GetAllSupplementTypes();


            var jointTables = from td in transactionDetails
                              join th in transactionDetails on td.TransactionID equals th.TransactionID
                              join s in msSupplements on td.SupplementID equals s.SupplementID
                              join st in msSupplementTypes on s.SupplementTypeID equals st.SupplementTypeID
                              where th.TransactionID == id
                              select new
                              {
                                  TransactionID = transactionHeader.TransactionID,
                                  TransactionDate = transactionHeader.TransactionDate,
                                  Status = transactionHeader.Status,
                                  SupplementName = s.SupplementName,
                                  SupplementExpiryDate = s.SupplementExpiryDate,
                                  SupplementPrice = s.SupplementPrice,
                                  SupplementTypeName = st.SupplementTypeName,
                                  Quantity = td.Quantity,
                              };

            TransactionDetailGV.DataSource = jointTables.ToList();
            TransactionDetailGV.DataBind();
        }
    }
}