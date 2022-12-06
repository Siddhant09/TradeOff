using Newtonsoft.Json.Linq;
using RestSharp;
using TradeOff.ClassLibrary;

namespace TradeOff.Services
{
    public static class HTTPServices
    {
        //Author        : Siddhant Chawade
        //Date          : 1st Dec 2022
        //Description   : To make a HTTP Post request
        public static IRestResponse HttpPostRequest<T>(T model, string uri)
        {
            //creating url
            var client = new RestClient(Urls.BaseUrl);
            var request = new RestRequest(uri, Method.POST);
            if(uri != Urls.SignInUrl && uri != Urls.SignUpUrl && uri != Urls.VerifyEmailUrl)
            {
                //adding parameters to header
                request.AddHeader("UserId", Preferences.Default.Get("userId", string.Empty));
                request.AddHeader("AuthToken", Preferences.Default.Get("authToken", string.Empty));
            }
            //adding parameters to body
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(model);
            //executing the request
            IRestResponse response = client.Execute(request);
            //returning the response
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 1st Dec 2022
        //Description   : To make a HTTP Get request
        public static IRestResponse HttpGetRequest(string uri, Dictionary<string, string> dictionary)
        {
            //creating url
            string url = string.Format("{0}/{1}", Urls.BaseUrl, uri);
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            //adding parameters to header
            request.AddHeader("UserId", Preferences.Default.Get("userId", string.Empty));
            request.AddHeader("AuthToken", Preferences.Default.Get("authToken", string.Empty));
            if (dictionary != null && dictionary.Count > 0)
            {
                foreach (var pair in dictionary)
                {
                    //adding parameters to body
                    request.AddParameter(pair.Key, pair.Value);
                }
            }
            //executing the request
            IRestResponse response = client.Execute(request);
            //returning the response
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 1st Dec 2022
        //Description   : To make a HTTP Post request with files
        public static IRestResponse HttpPostFormDateRequest<T>(T model, string uri, byte[] bytes, string fileName)
        {
            //creating url
            var client = new RestClient(Urls.BaseUrl);
            var request = new RestRequest(uri, Method.POST);
            if (uri != Urls.SignInUrl && uri != Urls.SignUpUrl && uri != Urls.VerifyEmailUrl)
            {
                //adding parameters to header
                request.AddHeader("UserId", Preferences.Default.Get("userId", string.Empty));
                request.AddHeader("AuthToken", Preferences.Default.Get("authToken", string.Empty));
                request.AddParameter("FormData", JObject.FromObject(model));
            }
            //adding parameters to body
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(model);
            if(!string.IsNullOrEmpty(fileName))
                request.AddFile("", bytes, fileName);

            //executing the request
            IRestResponse response = client.Execute(request);
            //returning the response
            return response;
        }
    }
}
