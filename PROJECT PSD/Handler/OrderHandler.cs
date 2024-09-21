using PROJECT_PSD.Models;
using PROJECT_PSD.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PROJECT_PSD.Handler
{
    public class OrderHandler
    {
        public static List<MsCart> GetCartByUserID(int userID)
        {
            return CartRepository.GetCartByUserID(userID);
        }

        public static void ClearCart(int userID)
        {
            CartRepository.ClearCart(userID);
        }

        public static bool MakeTransaction(int userID)
        {
            var cartItems = GetCartByUserID(userID);

            if (cartItems == null || !cartItems.Any())
            {
                return false;
            }

            using (var db = new LocalDatabaseEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var newHeader = TransactionRepository.CreateNewTransactionHeader(userID, DateTime.Now, "unhandled");

                        foreach (var cartItem in cartItems)
                        {
                            TransactionRepository.CreateNewTransactionDetail(newHeader.TransactionID, cartItem.SupplementID, cartItem.Quantity);
                            CartRepository.deleteCart(cartItem);
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Checkout failed: " + ex.Message);
                    }
                }
            }
        }
    }
}
