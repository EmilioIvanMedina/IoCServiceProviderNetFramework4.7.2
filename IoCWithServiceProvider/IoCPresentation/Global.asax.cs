using IoCPresentation.App_Start;
using Microsoft.Extensions.DependencyInjection;
using SampleServices.Interfaces;
using SampleServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IoCPresentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            
            DependencyResolver.SetResolver(new ServiceProviderDependencyResolver(ServiceProvider));
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISampleService, SampleService>();
        }
    }
}
