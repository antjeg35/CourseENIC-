using System.Web;
using System.Web.Mvc;

namespace TP1Module6EntityFrameworkDojoPart2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
