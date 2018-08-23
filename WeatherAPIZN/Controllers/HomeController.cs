using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherAPIZN.Repository;
using WeatherAPIZN.Repository.Interfaces;

namespace WeatherAPIZN.Controllers
{
    public class HomeController : Controller
    {
        private WeatherRepository _weatherRepository = new WeatherRepository();
        //public HomeController(IWeatherRepository weatherRepository)
        //{
        //    _weatherRepository = weatherRepository;
        //}
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetWeatherAsync(string city)
        {
            
            var weatherInfo = await _weatherRepository.GetWeatherAsync(city);
            return Content(weatherInfo, "application/json");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}