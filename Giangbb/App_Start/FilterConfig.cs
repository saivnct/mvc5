using System.Web;
using System.Web.Mvc;

namespace Giangbb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //appy authorize for whole application
            filters.Add(new AuthorizeAttribute());
        }
    }
}
