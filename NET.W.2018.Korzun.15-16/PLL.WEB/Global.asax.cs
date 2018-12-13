using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using PLL.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PLL.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Ninject

            NinjectModule serviceModule = new NinjectConfig();

            var kernel = new StandardKernel(serviceModule);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
