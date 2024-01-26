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
            //controller baz�nda authorize
            GlobalFilters.Filters.Add(new AuthorizeAttribute()); //giri� yapma alan�n� hari� tutmam�z gerekecek onun i�in login controllerin i�ine git
            //
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
