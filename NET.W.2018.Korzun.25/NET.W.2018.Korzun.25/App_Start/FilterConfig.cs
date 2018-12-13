using System.Web;
using System.Web.Mvc;

namespace NET.W._2018.Korzun._25
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
