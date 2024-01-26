using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mvc_5TicariOtamasyon
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //controller bazýnda authorize
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); //giriþ yapma alanýný hariç tutmamýz gerekecek onun için login controllerin içine git
            //
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
