using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testing_JSON
{
    public class Location
    {
        private static string city;
        public static string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value != city)
                {
                    city = value;

                }
            }
        }
    }
}