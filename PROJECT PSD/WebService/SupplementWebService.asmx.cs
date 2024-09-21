using PROJECT_PSD.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PROJECT_PSD.WebService
{
    /// <summary>
    /// Summary description for SupplementWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SupplementWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string InsertSupplement(string name, DateTime expdate, int price, int typeid)
        {
            return JsonHandler.Encode(SupplementHandler.InsertSupplement(name, expdate, price, typeid));
        }

        [WebMethod]
        public string UpdateSupplement(int id, string name, DateTime expdate, int price, int typeid)
        {
            return JsonHandler.Encode(SupplementHandler.UpdateSupplement(id, name, expdate, price, typeid));
        }

        [WebMethod]
        public string GetAllSupplements()
        {
            return JsonHandler.Encode(SupplementHandler.GetAllSupplements());
        }
    }
}
