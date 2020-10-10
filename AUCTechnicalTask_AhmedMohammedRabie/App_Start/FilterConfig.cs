using System.Web;
using System.Web.Mvc;

namespace AUCTechnicalTask_AhmedMohammedRabie
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
