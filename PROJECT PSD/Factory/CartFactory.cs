using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Factory
{
    public class CartFactory
    {
        public static MsCart insertCart(int userID, int supplementID, int quantity)
        {
            MsCart cart = new MsCart()
            {
                UserID = userID,
                SupplementID = supplementID,
                Quantity = quantity
            };
            return cart;
        }
    }
}