using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Lifetime;
using WeatherAPIZN.Repository;
using WeatherAPIZN.Repository.Interfaces;

namespace WeatherAPIZN
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            container.RegisterType<IWeatherRepository, WeatherRepository>(new HierarchicalLifetimeManager());
            
            //UnityResolver = new UnityResolver(container);
            //var container = new Container();
            //container.Register<IWeatherRepository, WeatherRepository>();
            //container.Register<ICityRepository, CityRepository>();

            //container.Verify();

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);

        }
    }
}
