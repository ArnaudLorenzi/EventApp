using PortableRest;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using EventApp.DTO;

namespace EventApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        public Page1()
        {
            this.InitializeComponent();
        }
        
        private async void TestWS_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            int i = 0;
            String sessionId = "zM4DQxmA7ad3OsLUFYdBTHmC69m96ilFTGazusy5";
            RestClient rc = new RestClient()
            {
                BaseUrl = "http://10.37.129.2:8080"
            };
            RestRequest req = null;
            RestResponse<String> ret = null;

            req = new RestRequest()
            {
                ContentType= ContentTypes.FormUrlEncoded,
                Method = HttpMethod.Post,
                Resource = "api/authentication"
            };
            req.AddParameter("j_username", "admin");
            req.AddParameter("j_password", "admin");
            //req.AddParameter("submit", "Login");
            ret = await rc.SendAsync<string>(req);
            i++;

            //req = new RestRequest() {
            //    //ContentType= ContentTypes.FormUrlEncoded,
            //    Method = HttpMethod.Get,
            //    Resource = "authenticate"
            //};

            //req.AddParameter("j_username", "admin");
            //req.AddParameter("j_password", "admin");
            ////req.AddParameter("remember-me", "true");
            ////req.AddParameter("submit", "Login");

            //req.AddParameter("Authorization", "Basic YWRtaW46YWRtaW4=");

            ////req.AddQueryString("j_username", "admin");
            ////req.AddQueryString("j_password", "admin");
            ////req.AddQueryString("remember-me", "true");
            ////req.AddQueryString("submit", "Login");

            //ret = await rc.SendAsync<string>(req);

            //foreach (String cookie in ret.HttpResponseMessage.Headers.GetValues("Set-Cookie"))
            //{
            //    if (cookie.StartsWith("JSESSIONID="))
            //    {
            //        sessionId = cookie.Split(';')[0].Split('=')[1];
            //    }
            //}



            req = new RestRequest()
            {
                //ContentType = ContentTypes.FormUrlEncoded,
                Method = HttpMethod.Get,
                //Resource = "authenticate"
                Resource = "/api/events/owned"
            };
            //req.AddHeader("Cookie", "JSESSIONID="+sessionId);
            //req.AddHeader("Accept", "application/json");
            //req.AddParameter("JSESSIONID", sessionId);
            //req.AddQueryString("JSESSIONID", sessionId);

            RestResponse<List<EventDTO>> ret2 = await rc.SendAsync<List<EventDTO>>(req);
            
            i++;
            /*
            var client = new RestClient("http://example.com");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("resource/{id}", Method.POST);
            request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("header", "value");
            */
        }
    }
}
