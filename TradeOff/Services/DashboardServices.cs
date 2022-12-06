using TradeOff.ClassLibrary;

namespace TradeOff.Services
{
    internal class DashboardServices
    {

        //Author        : Siddhant Chawade
        //Date          : 5th Dec 2022
        //Description   : To get dashboard
        public Response<Dashboard> GetDashboard(int filter)
        {
            Response<Dashboard> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.GetDashboardUrl + "?filter=" + filter, null);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<Dashboard>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}
