using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace PROJECT_PSD.Controller
{
    public class CartController
    {
        public static string validateQuantity(int? quantity)
        {
            if (quantity <= 0)
            {
                return "Quantity must be bigger than 0";
            }
            else if(quantity == null)
            {
                return "Quantity cannot be empty";
            }
            return null;
        }
    }
}