using System.Web;
using System.Web.Mvc;

namespace BANK_MVC_ONION_DI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
