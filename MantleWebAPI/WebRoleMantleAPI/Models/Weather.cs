using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRoleMantleAPI.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public string Condition { get; set; }
    }
}