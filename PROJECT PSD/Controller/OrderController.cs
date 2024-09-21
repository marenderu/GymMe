using PROJECT_PSD.Handler;
using PROJECT_PSD.Models;
using System.Collections.Generic;

namespace PROJECT_PSD.Controller
{
    public class OrderController
    {
        public static List<MsCart> GetCartItemsByUserId(int userId)
        {
            return OrderHandler.GetCartByUserID(userId);
        }

        public static void ClearCart(int userId)
        {
            OrderHandler.ClearCart(userId);
        }

        public static string CheckoutCart(int userId)
        {
            if (OrderHandler.MakeTransaction(userId))
            {
                return "Checkout successful";
            }
            else
            {
                return "Checkout failed: Your cart is empty.";
            }
        }
    }
}
    