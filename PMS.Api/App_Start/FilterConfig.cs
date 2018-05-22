using PMS.Api.Filters;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace PMS.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogErrorAttribute()); 
        }
    }
}
