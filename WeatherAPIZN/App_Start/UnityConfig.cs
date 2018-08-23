using System;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WeatherAPIZN.Repository;
using WeatherAPIZN.Repository.Interfaces;

namespace WeatherAPIZN
{
    public static class UnityConfig
    {
        public static Type IWeatherRepository { get; private set; }
        public static Type ICityRepository { get; private set; }
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            
            container.RegisterType<IWeatherRepository, WeatherRepository>();
            container.RegisterType<ICityRepository, CityRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}