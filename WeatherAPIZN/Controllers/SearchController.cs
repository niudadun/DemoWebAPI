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
    public class SearchController : Controller
    {
        readonly IWeatherRepository _weatherRepository;
        readonly ICityRepository _cityRepository;
        public SearchController(IWeatherRepository weatherRepository, ICityRepository cityRepository)
        {
            _weatherRepository = weatherRepository;
            _cityRepository = cityRepository;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        // GET: Weather info
        public async Task<ActionResult> GetWeatherAsync(string city)
        {

            var weatherInfo = await _weatherRepository.GetWeatherAsync(city);
            return Content(weatherInfo, "application/json");
        }

        // GET: A list of City
        public async Task<ActionResult> GetComboBoxDropDownList(string countryName)
        {
            var cityList = await _cityRepository.GetCityAsync(countryName);
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }
    }
}