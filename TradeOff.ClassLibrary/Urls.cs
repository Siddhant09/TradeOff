using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeOff.ClassLibrary
{
    public class Urls
    {
        public const string BaseUrl = "https://tradeoffapi.siddhantchawade.com/"; // "http://10.0.2.2:59485/"; // "http://192.168.0.115:59485";

        //Profile
        public const string SignUpUrl = "api/sign-up";
        public const string VerifyEmailUrl = "api/verify-email";
        public const string SignInUrl = "api/sign-in";
        public const string GetProfileUrl = "api/get-profile";
        public const string UpdateProfileUrl = "api/update-profile";
        public const string GetTradeRequestHistoryUrl = "api/get-trade-request-history";

        //Inventory
        public const string GetInventoryOptionsUrl = "api/get-inventory-options";
        public const string GetInventoryUrl = "api/get-inventory";
        public const string UpsertProductUrl = "api/upsert-product";
        public const string DeleteProductUrl = "api/delete-product";

        //Browse
        public const string GetBrowseUrl = "api/get-browse";
        public const string LikeProductUrl = "api/like-product";
        public const string DislikeProductUrl = "api/dislike-product";
        public const string RequestTradeUrl = "api/request-trade";

        //Dashboard
        public const string GetDashboardUrl = "api/get-dashboard";

        //Request
        public const string GetTradeRequestsUrl = "api/get-trade-requests";
        public const string AcceptTradeRequestUrl = "api/accept-trade-request";
        public const string RejectTradeRequestUrl = "api/reject-trade-request";
        public const string CancelTradeRequestUrl = "api/cancel-trade-request";
    }
}
