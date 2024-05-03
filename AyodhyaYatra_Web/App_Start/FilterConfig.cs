using System.Web;
using System.Web.Mvc;
using AyodhyaYatra_Web.Infrastructure.Authentication;

namespace AyodhyaYatra_Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomAuthorize());
            //filters.Add(new RequreSecureConnectionFilter());
        }
    }
}
