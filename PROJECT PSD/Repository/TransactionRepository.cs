using PROJECT_PSD.Factory;
using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJECT_PSD.Repository
{
    public class TransactionRepository
    {
        static LocalDatabaseEntities db = Singleton.GetInstance();

        public static List<TransactionDetail> GetAllTransactionDetail()
        {
            return db.TransactionDetails.ToList();
        }

        public static List<TransactionHeader> GetAllTransactionHeader()
        {
            return db.TransactionHeaders.ToList();
        }

        public static List<TransactionHeader> GetAllUserTransaction(int id)
        {
            return db.TransactionHeaders.Where(t => t.UserID == id).ToList();
        }

        public static TransactionHeader GetTransactionHeaderById(int id)
        {
            return db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == id);
        }

        public static List<TransactionHeader> GetUnhandledTransaction()
        {
            return db.TransactionHeaders.Where(t => t.Status == "Unhandled").ToList();
        }

        public static void UpdateTransactionStatus(TransactionHeader transactionHeader)
        {
            var existingTransaction = db.TransactionHeaders.Find(transactionHeader.TransactionID);
            if (existingTransaction != null)
            {
                existingTransaction.Status = transactionHeader.Status;
                db.SaveChanges();
            }
        }

        public static TransactionHeader CreateNewTransactionHeader(int userId, DateTime transactionDate, string status)
        {
            var transactionHeader = TransactionFactory.newTransactionHeader(userId, transactionDate, status);
            db.TransactionHeaders.Add(transactionHeader);
            db.SaveChanges();
            return transactionHeader;
        }

        public static void CreateNewTransactionDetail(int transactionId, int supplementId, int quantity)
        {
            var transactionDetail = TransactionFactory.newTransactionDetail(transactionId, supplementId, quantity);
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }
    }
}
