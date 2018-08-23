using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WeatherAPIZN.Models;
using WeatherAPIZN.Repository.Interfaces;

namespace WeatherAPIZN.Repository
{
    public class CityRepository: ICityRepository
    {
        private static string cityAPIAddress = APIAddress.cityAPIaddress;
        public async Task<List<CityProperty>> GetCityAsync(string country)
        {
            List<CityProperty> cities = new List<CityProperty>();

            using (var client = new HttpClient())
            {

                string url = cityAPIAddress + country + "&searchby=country";
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "q5rFr7I8D6msheST0ZrwgYSg8nZ5p1PjIKcjsnmoVArc3o87ii");
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(url);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var cityInfo = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    List<CityProperty> result = JsonConvert.DeserializeObject<List<CityProperty>>(cityInfo);
                    if (result.Count > 0)
                    {
                        cities = result.OrderBy(i => i.city).ToList();

                    }
                }
                //returning the employee list to view  
                return cities;
            }
        }
    }
}