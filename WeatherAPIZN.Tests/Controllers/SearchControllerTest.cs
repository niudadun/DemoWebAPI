using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAPIZN;
using WeatherAPIZN.Controllers;
using WeatherAPIZN.Repository.Interfaces;

namespace WeatherAPIZN.Tests.Controllers
{
    [TestClass]
    class SearchControllerTest
    {

        readonly IWeatherRepository _weatherRepository;
        readonly ICityRepository _cityRepository;

        [TestMethod]
        public void GetWeatherAsync()
        {
            SearchController controller = new SearchController(_weatherRepository, _cityRepository);

            Task<ActionResult> result = controller.GetWeatherAsync("Australia");

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
