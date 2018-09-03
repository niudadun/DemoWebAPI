using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPIZN.Models;
using WeatherAPIZN.Repository;

namespace WeatherAPIZN.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCityAsync()
        {
            CityRepository cityrepo = new CityRepository();

            Task<List<CityProperty>> result = cityrepo.GetCityAsync("Australia");

            Assert.IsTrue(result.IsCompleted);
        }

        [TestMethod]
        public void GetWeatherAsync()
        {
            WeatherRepository weatherrepo = new WeatherRepository();

            Task<String> result = weatherrepo.GetWeatherAsync("Sydney");

            Assert.IsNotNull(result); 
        }
    }
}
