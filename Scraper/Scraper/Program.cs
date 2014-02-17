using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string data = wc.DownloadString(new Uri("http://www.wunderground.com/cgi-bin/findweather/hdfForecast?query=kolkata", UriKind.Absolute));

            MatchCollection m1=Regex.Matches(data,"<span id="+"yfs_l10_gcj14.cmx"+">.*?</span>");

            
            Console.WriteLine(m1[0].ToString());
            
        }
    }
}
