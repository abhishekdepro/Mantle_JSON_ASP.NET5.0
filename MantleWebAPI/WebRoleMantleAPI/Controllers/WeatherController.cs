using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebRoleMantleAPI.Models;

namespace WebRoleMantleAPI.Controllers
{
    public class WeatherController : ApiController
    {
        Weather[] weather = new Weather[]{
            new Weather{  Id=1, City="Kolkata", Temperature=25, Humidity=88, Condition="Sultry"},
            new Weather{  Id=2, City="Delhi", Temperature=21, Humidity=68, Condition="Cloudy"}
        };

        public IEnumerable<Weather> GetAllForecast()
        {
            return weather;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = weather.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }

    
}
