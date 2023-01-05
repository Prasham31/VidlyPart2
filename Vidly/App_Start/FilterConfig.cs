using System.Web;
using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Global filters are defined here
            filters.Add(new HandleErrorAttribute());

            //filters.Add(new AuthorizeAttribute());
        }
    }
}
