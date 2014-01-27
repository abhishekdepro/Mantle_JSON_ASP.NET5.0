using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing_JSON
{
    public partial class Callback : System.Web.UI.Page
    {
        public string json,url;

        public Stream response;
        protected void Page_Load(object sender, EventArgs e)
        {
            url = "";
            oAuthFacebook oAuth = new oAuthFacebook();

            if (Request["code"] == null)
            {
                //Redirect the user back to Facebook for authorization.
                Response.Redirect(oAuth.AuthorizationLinkGet());
            }
            else
            {
                //Get the access token and secret.
                oAuth.AccessTokenGet(Request["code"]);

                if (oAuth.Token.Length > 0)
                {
                    //We now have the credentials, so we can start making API calls
                    ServiceAPI api = new ServiceAPI("f42895e1dbf7b92624e65c952537e07c3d973cb3888a16b21372835d5feac400", "a0a31095a5b969a4b35b3092cfb3344f73161299277cb2881d5c957e27df0969");
                    StorageService storageService = api.BuildStorageService();
                    //{\"name\":\"Nick\",\"age\":30,
                    String dbName = "user";
                    String collectionName = "facebook";
                    //String json = "{\"name\":\"" + city + "\",\"age\":\"" + conditionText.Value + "\",\"phone\":\"" + urlinputbox.Value + "\"}";




                    url = "https://graph.facebook.com/me?fields=location&access_token=" + oAuth.Token;
                    json = oAuth.WebRequest(oAuthFacebook.Method.GET, url, String.Empty);

                    var jObj = JsonConvert.DeserializeObject(json) as JObject;
                    
                    var temperature = jObj["location"].Children()
                                    .Cast<JProperty>()


                                    .Select(x => new
                                    {
                                        resultquery = (string)x.Value,

                                    }).ToList();
                    
                   
                    Storage storage = storageService.InsertJSONDocument(dbName, collectionName, json);
                    IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();


                    Session["location"] = temperature[1].resultquery;
                    Weather.Flag = 1;
                    //int age = user.Age;
                    Response.Redirect("Default.aspx");
                    
                }

            }
        }

        
        
    }
}