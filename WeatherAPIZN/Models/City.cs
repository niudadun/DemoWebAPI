using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPIZN.Models
{
    public class City
    {

        public string name { get; set; }

        public string temp { get; set; }

        public string visibility { get; set; }

        public string humidity { get; set; }

        public string wind { get; set; }

        public string pressure { get; set; }

        public string main { get; set; }

        public string desciption { get; set; }

    }

    public class CityProperty
    {

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }

    }

}