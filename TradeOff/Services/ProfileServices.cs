using TradeOff.ClassLibrary;

namespace TradeOff.Services
{
    internal class ProfileServices
    {
        //Author        : Siddhant Chawade
        //Date          : 1st Dec 2022
        //Description   : To register new user
        public Response<User> SignUp(User user)
        {
            Response<User> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(user, Urls.SignUpUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<User>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 1st Dec 2022
        //Description   : To verify email
        public Response<User> VerifyEmail(User user)
        {
            Response<User> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(user, Urls.VerifyEmailUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<User>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 1st Dec 2022
        //Description   : To authenticate user and login
        public Response<User> SignIn(User user)
        {
            Response<User> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(user, Urls.SignInUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<User>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 1st Dec 2022
        //Description   : To get profile
        public Response<User> GetProfile()
        {
            Response<User> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.GetProfileUrl, null);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<User>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 1st Dec 2022
        //Description   : To update profile
        public Response<User> UpdateProfile(User user)
        {
            Response<User> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpPostRequest(user, Urls.UpdateProfileUrl);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<User>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 4th Dec 2022
        //Description   : To trade requests history
        public Response<List<Request>> GetTradeRequestHistory()
        {
            Response<List<Request>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.GetTradeRequestHistoryUrl, null);
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
        //Date          : 6th Dec 2022
        //Description   : To get notifications
        public Response<List<Notification>> GetNotifications()
        {
            Response<List<Notification>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.GetNotificationsUrl, null);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Notification>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 6th Dec 2022
        //Description   : To delete notifications
        public Response<List<Notification>> DeleteNotifications()
        {
            Response<List<Notification>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.DeleteNotificationsUrl, null);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Notification>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

        //Author        : Siddhant Chawade
        //Date          : 6th Dec 2022
        //Description   : To get notifications
        public Response<List<Notification>> UpdateNotificationStatus()
        {
            Response<List<Notification>> response = null;
            try
            {
                //posting request through http method
                var httpResponse = HTTPServices.HttpGetRequest(Urls.UpdateNotificationStatusUrl, null);
                //converting http response into model class
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<List<Notification>>>(httpResponse.Content);
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}
