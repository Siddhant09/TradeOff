using TradeOff.ClassLibrary;

namespace TradeOff.Services
{
    internal class RequestServices
    {

        //Author        : Siddhant Chawade
        //Date          : 4th Dec 2022
        //Description   : To get trade requests
        public Response<List<Request>> GetTradeRequests()
        {
            Response<List<Request>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.GetTradeRequestsUrl, null);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Request>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 4th Dec 2022
        //Description   : To accpet trade request
        public Response<List<Request>> AcceptTradeRequest(Request request)
        {
            Response<List<Request>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(request, Urls.AcceptTradeRequestUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Request>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 4th Dec 2022
        //Description   : To reject trade request
        public Response<List<Request>> RejectTradeRequest(Request request)
        {
            Response<List<Request>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(request, Urls.RejectTradeRequestUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Request>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 4th Dec 2022
        //Description   : To cancel trade request
        public Response<List<Request>> CancelTradeRequest(Request request)
        {
            Response<List<Request>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(request, Urls.CancelTradeRequestUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Request>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}
