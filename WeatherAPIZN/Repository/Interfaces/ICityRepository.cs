using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherAPIZN.Models;

namespace WeatherAPIZN.Repository.Interfaces
{
    /// <summary>
    /// Interface for retrieve cities from API
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// Method to get all available cites from API
        /// </summary>
        /// <returns>city list</returns>
        Task<List<CityProperty>> GetCityAsync(string country);
    }
}