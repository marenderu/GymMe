using PROJECT_PSD.Factory;
using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Repository
{
    public class CartRepository
    {
        static LocalDatabaseEntities db = Singleton.GetInstance();
        public static MsCart insertCart(int userID, int supplementID, int quantity)
        {
            MsCart newCart = CartFactory.insertCart(userID, supplementID, quantity);
            db.MsCarts.Add(newCart);
            db.SaveChanges();
            return newCart;
        }

        public static List<MsCart> GetCartByUserID(int userID)
        {
            return (from cart in db.MsCarts where cart.UserID == userID select cart).ToList();
        }
        public static void ClearCart(int userID)
        {
            var cartItems = db.MsCarts.Where(c => c.UserID == userID).ToList();
            db.MsCarts.RemoveRange(cartItems);
            db.SaveChanges();
        }

        public static void deleteCart(MsCart cart)
        {
            db.MsCarts.Remove(cart);
            db.SaveChanges();
        }
    }
}