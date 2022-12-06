using TradeOff.ClassLibrary;

namespace TradeOff.Services
{
    internal class InventoryServices
    {

        //Author        : Siddhant Chawade
        //Date          : 2nd Dec 2022
        //Description   : To get options
        public Response<InventoryOptions> GetInventoryOptions()
        {
            Response<InventoryOptions> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.GetInventoryOptionsUrl, null);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<InventoryOptions>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 2nd Dec 2022
        //Description   : To get inventory
        public Response<List<Product>> GetInventory()
        {
            Response<List<Product>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.GetInventoryUrl, null);
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
        //Date          : 2nd Dec 2022
        //Description   : To upsert product
        public Response<Inventory> UpsertProduct(Product product, byte[] bytes, string fileName)
        {
            Response<Inventory> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostFormDateRequest(product, Urls.UpsertProductUrl, bytes, fileName);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<Inventory>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 2nd Dec 2022
        //Description   : To delete product
        public Response<List<Product>> DeleteProduct(Product product)
        {
            Response<List<Product>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(product, Urls.DeleteProductUrl);
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
