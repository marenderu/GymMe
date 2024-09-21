using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader newTransactionHeader(int userId, DateTime transactiondate, string status)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                UserID = userId,
                TransactionDate = transactiondate,
                Status = status
            };
            return transactionHeader;
        }

        public static TransactionDetail newTransactionDetail(int transactionID, int supplementId, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = transactionID,
                SupplementID = supplementId,
                Quantity = quantity
            };
            return transactionDetail;
        }
    }
}