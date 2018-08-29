using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class ValuesController : ApiController
    {

        public Weather GetWeatherByTown(string town)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + town + "&mode=html&units=metric&appid=8b28ce9d173f965381c342d72edb7e84";
            var client = new WebClient();
            var content = client.DownloadString(url);
            var weather = new Weather()
            {
                html = content,
                Town = town
            };
            return weather;
        }

        public Weather GetWeatherByPostalCode(int postalcode)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?zip=" + postalcode.ToString() + ",sv&mode=html&units=metric&appid=8b28ce9d173f965381c342d72edb7e84";
            var client = new WebClient();
            var content = client.DownloadString(url);
            var weather = new Weather()
            {
                html = content,
                PostalCode = postalcode
            };
            return weather;
        }
        // GET api/values
        public Weather Get()
        {
            return GetWeatherByTown("stockholm");
        }

        // GET api/values/5
        public Weather Get(string town)
        {
            if(town != null)
                return GetWeatherByTown(town);
            else
                return GetWeatherByTown("stockholm");
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
