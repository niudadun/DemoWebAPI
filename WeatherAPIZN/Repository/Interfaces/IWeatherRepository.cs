using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using WeatherAPIZN.Models;

namespace WeatherAPIZN.Repository.Interfaces
{
    /// <summary>
    /// Interface for retrieve weather related data from API
    /// </summary>
    public interface IWeatherRepository
    {
        /// <summary>
        /// Method to get all available cites from API
        /// </summary>
        /// <returns>city list</returns>
        Task<String> GetWeatherAsync(string city);
    }
}