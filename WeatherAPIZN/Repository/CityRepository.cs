using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using WeatherAPIZN.Repository.Interfaces;

namespace WeatherAPIZN.Repository
{
    public class CityRepository: ICityRepository
    {
        private static string cityAPIAddress = APIAddress.cityAPIaddress;
        public async Task<List<String>> GetCityAsync(string country)
        {
            List<String> cities = new List<String>();

            using (var client = new HttpClient())
            {

                //client.BaseAddress = new Uri(weatherAPIAddress);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(cityAPIAddress + country);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var cityInfo = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    cities = JsonConvert.DeserializeObject<List<String>>(cityInfo);

                }
                //returning the employee list to view  
                return cities;
            }
        }
    }
}