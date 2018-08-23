using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherAPIZN.Models;
using WeatherAPIZN.Repository.Interfaces;

namespace WeatherAPIZN.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private static string weatherAPIAddress = APIAddress.weatherAPIaddress;
        private static string APIKey = APIAddress.APIKey;
        public async Task<String> GetWeatherAsync(string city)
        {
            City CityInfo = new City();
            String propertyInfo = "";
            using (var client = new HttpClient())
            {
                string url = weatherAPIAddress + city + "&APPID=" + APIKey;
                client.BaseAddress = new Uri(url);
                //var addr = new Uri(weatherAPIAddress + city + "&APPID=" + APIKey);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(url);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    propertyInfo = Res.Content.ReadAsStringAsync().Result;

                }
                //returning the employee list to view  
                return propertyInfo;
            }
        }
    }
}