using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WeatherAPIZN.Repository
{
    public class APIAddress
    {
        public static readonly string weatherAPIaddress = ConfigurationManager.AppSettings["weatherAPI"];

        public static readonly string cityAPIaddress = ConfigurationManager.AppSettings["cityAPI"];

        public static readonly string APIKey = ConfigurationManager.AppSettings["APIKey"];
    }
}