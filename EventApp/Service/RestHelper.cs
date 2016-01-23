using EventApp.DTO;
using EventApp.Model;
using PortableRest;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventApp.Service
{
    public class RestHelper
    {
#if ONLINE
        public const String BASE_URL = "http://195.154.11.196:8080";
#else
        public const String BASE_URL = "http://10.211.55.2:8080";
#endif
        private String sessionId = null;
        public String SessionId
        {
            private get { return sessionId; }
            set { sessionId = value; }
        }

        private RestClient client;

        private static RestHelper instance;

        public static RestHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new RestHelper();
                return instance;
            }
        }

        private RestHelper()
        {
            client = new RestClient()
            {
                BaseUrl = BASE_URL
            };
        }

        public async Task<Boolean> Authenticate(String userName, String password)
        {
            RestRequest req = new RestRequest()
            {
                ContentType = ContentTypes.FormUrlEncoded,
                Method = HttpMethod.Post,
                Resource = "api/authentication"
            };
            req.AddParameter("j_username", "admin");
            req.AddParameter("j_password", "admin");
            RestResponse<String> ret = await client.SendAsync<string>(req);

            if (ret.HttpResponseMessage.IsSuccessStatusCode)
            {
                foreach (String cookie in ret.HttpResponseMessage.Headers.GetValues("Set-Cookie"))
                {
                    if (cookie.StartsWith("JSESSIONID="))
                    {
                        SessionId = cookie.Split(';')[0].Split('=')[1];
                    }
                }
            }

            return ret.HttpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<RestResult<T>> GetData<T>(string service)
            where T : class
        {
            RestRequest req = new RestRequest()
            {
                ContentType = ContentTypes.FormUrlEncoded,
                Method = HttpMethod.Get,
                Resource = service
            };
            RestResponse<T> ret = await client.SendAsync<T>(req);
            if (ret.HttpResponseMessage.IsSuccessStatusCode)
            {
                return new RestSuccessResult<T>(ret.Content);
            }
            else {
                return new RestFailureResult<T>(ret.HttpResponseMessage.ReasonPhrase);
            }
        }

        public async Task<RestResult<OUT>> Post<IN, OUT>(string service, IN data)
            where OUT : class
        {
            RestRequest req = new RestRequest()
            {
                ContentType = ContentTypes.Json,
                Method = HttpMethod.Post,
                Resource = service
            };
            req.AddParameter(data);
            RestResponse<OUT> ret = await client.SendAsync<OUT>(req);
            if (ret.HttpResponseMessage.IsSuccessStatusCode)
            {
                return new RestSuccessResult<OUT>(ret.Content);
            }
            else {
                return new RestFailureResult<OUT>(ret.HttpResponseMessage.ReasonPhrase);
            }
        }

        public async Task<RestResult<OUT>> Put<IN, OUT>(string service, IN data)
            where OUT : class
        {
            RestRequest req = new RestRequest()
            {
                ContentType = ContentTypes.Json,
                Method = HttpMethod.Put,
                Resource = service
            };
            req.AddParameter(data);
            RestResponse<OUT> ret = await client.SendAsync<OUT>(req);
            if (ret.HttpResponseMessage.IsSuccessStatusCode)
            {
                return new RestSuccessResult<OUT>(ret.Content);
            }
            else {
                return new RestFailureResult<OUT>(ret.HttpResponseMessage.ReasonPhrase);
            }
        }

        public async Task<RestResult<Boolean>> Delete(string service, int id)
        {
            RestRequest req = new RestRequest()
            {
                ContentType = ContentTypes.FormUrlEncoded,
                Method = HttpMethod.Delete,
                Resource = service
            };
            req.AddParameter("id", id);
            RestResponse<String> ret = await client.SendAsync<String>(req);
            if (ret.HttpResponseMessage.IsSuccessStatusCode)
            {
                return new RestSuccessResult<Boolean>(true);
            }
            else {
                return new RestFailureResult<Boolean>(ret.HttpResponseMessage.ReasonPhrase);
            }
        }

        public String buildURL(String urlPart)
        {
            //var url = RestHelper.BASE_URL + "/" + urlPart + "?JSESSIONID=" + JSESSEIONID;
            var url = RestHelper.BASE_URL + "/" + urlPart + ";jsessionid=" + SessionId;
            return url;
        }

    }
}
