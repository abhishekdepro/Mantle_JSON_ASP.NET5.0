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
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;  

namespace Testing_JSON
{
    public partial class _Default : Page
    {
          
        private string city;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Weather.Flag != 0)
            {
                urlinputbox.Value = Session["location"].ToString();
               
            }
            if (urlinputbox.Value != "")
            {
                Page.Title = urlinputbox.Value.ToUpper()+" weather";
            }
        }

        public void show()
        {
            ServiceAPI api = new ServiceAPI("f42895e1dbf7b92624e65c952537e07c3d973cb3888a16b21372835d5feac400", "a0a31095a5b969a4b35b3092cfb3344f73161299277cb2881d5c957e27df0969");
            StorageService storageService = api.BuildStorageService();
            //{\"name\":\"Nick\",\"age\":30,
            String dbName = "user";
            String collectionName = "data";
            String json = "{\"name\":\""+city+"\",\"age\":\""+conditionText.Value+"\",\"phone\":\""+urlinputbox.Value+"\"}"; 
            Storage storage = storageService.InsertJSONDocument(dbName, collectionName, json);
            
            IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();
              
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
                var weather = jObj["main"].Children()
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
                
                urlinputbox.Value = weather[0].resultquery;
                weathercondition.Text = "Weather Condition: ";
                weathercondition.Text += final[2].temp.ToUpper();
                conditionText.Value = final[2].temp;
                humidityText.Value = weather[4].resultquery;
               /// submiturlbtn.Visible = false;
                show();
            }
            catch (Exception ex) {
                
                error.Text=ex.Message;
                error.Visible = true;
            }
        }

        protected void ButtonFb_Click(object sender, EventArgs e)
        {
            oAuthFacebook oFB = new oAuthFacebook();
            Response.Redirect(oFB.AuthorizationLinkGet());
        }

    }
}
