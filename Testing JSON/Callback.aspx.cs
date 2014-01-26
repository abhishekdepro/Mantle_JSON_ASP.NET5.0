using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Testing_JSON
{
    public partial class Callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";
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
                    

                    
                    
                    url = "https://graph.facebook.com/1819858178/?access_token=CAADBZAtilqtYBAIlTDFPZB2ZCesskF2PBYVw2jbPiswOsOvQqjQgnWSydUWs4ghR1vrRThNYHAkRJvvfuQlW0AEINzyXJTFQNTBpZAMJRUJUflVWrEiJHrRkg5dxkm2oTyi3SMi5Ds4wrdOzIHZAcSljD8EDpvS4n0vAhkGqFU4IJ4QMdUamMgLekK7x6GnlT4BMM1WqwcQZDZD";
                    string json = oAuth.WebRequest(oAuthFacebook.Method.GET, url, String.Empty);
                    Storage storage = storageService.InsertJSONDocument(dbName, collectionName, json);
                    IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();
                }
            }
        }
    }
}