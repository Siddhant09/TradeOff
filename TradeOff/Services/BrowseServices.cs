using TradeOff.ClassLibrary;

namespace TradeOff.Services
{
    internal class BrowseServices
    {

        //Author        : Siddhant Chawade
        //Date          : 3rd Dec 2022
        //Description   : To get browse list
        public Response<List<Product>> GetBrowse(string? keyword)
        {
            Response<List<Product>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.GetBrowseUrl + "?keyword=" + keyword, null);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Product>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 3rd Dec 2022
        //Description   : To like product
        public Response<List<Product>> LikeProduct(Product product)
        {
            Response<List<Product>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(product, Urls.LikeProductUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Product>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 3rd Dec 2022
        //Description   : To dislike product
        public Response<List<Product>> DislikeProduct(Product product)
        {
            Response<List<Product>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(product, Urls.DislikeProductUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Product>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 3rd Dec 2022
        //Description   : To request trade
        public Response<List<Product>> RequestTrade(Request request)
        {
            Response<List<Product>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(request, Urls.RequestTradeUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Product>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}
