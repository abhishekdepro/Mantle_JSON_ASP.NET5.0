using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Testing_JSON
{
    public partial class _Default : Page
    {
        private string city;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void show()
        {

        }

        protected void submiturlbtn_clicked(object sender, EventArgs e)
        {
            // Stream response;
            if(urlinputbox.Value!="")
                 city = urlinputbox.Value.ToString();
            else if(conditionText.Value!="")
                city = conditionText.Value.ToString();
            try
            {
                WebClient wc = new WebClient();
                string download="http://api.openweathermap.org/data/2.5/weather?q="+city+"&units=metric";
                string json = wc.DownloadString(download);
                


                var jObj = JsonConvert.DeserializeObject(json) as JObject;
                List<JObject> result = jObj["weather"].Children()
                                .Cast<JObject>()
                                
                                .ToList();
                var temperature = jObj["main"].Children()
                                .Cast<JProperty>()


                                .Select(x => new
                                {
                                    resultquery = (string)x.Value,

                                }).ToList();
                
                var final = result[0].Children()
                                .Cast<JProperty>()
                                
                                
                                .Select(x => new
                                {
                                    temp = (string)x.Value,

                                }).ToList();
                
                urlinputbox.Value = temperature[0].resultquery;
                weathercondition.Text = "Weather Condition: ";
                weathercondition.Text += final[2].temp.ToUpper();
                conditionText.Value = final[2].temp;
            }
            catch (Exception ex) {
                
                error.Text=ex.Message;
                error.Visible = true;
            }
        }

    }
}