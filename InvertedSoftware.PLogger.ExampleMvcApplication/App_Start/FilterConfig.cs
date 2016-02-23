using System.Web;
using System.Web.Mvc;

namespace InvertedSoftware.PLogger.ExampleMvcApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}