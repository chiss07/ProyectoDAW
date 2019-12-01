using System.Web;
using System.Web.Mvc;

namespace DPADesarrolloWeb2019
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
