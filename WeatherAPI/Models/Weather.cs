using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPI.Models
{
    public class Weather
    {
        public string html { get; set; }

        public string Town { get; set; }

        public int PostalCode { get; set; }
    }
}