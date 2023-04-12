using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeOff.ClassLibrary
{
    public class Urls
    {
        public const string BaseUrl = "https://tradeoffapi.siddhantchawade.com/";

        //Profile
        public const string SignUpUrl = "api/sign-up";
        public const string VerifyEmailUrl = "api/verify-email";
        public const string SignInUrl = "api/sign-in";
        public const string GetProfileUrl = "api/get-profile";
        public const string UpdateProfileUrl = "api/update-profile";
        public const string GetTradeRequestHistoryUrl = "api/get-trade-request-history";
        public const string GetNotificationsUrl = "api/get-notifications";
        public const string DeleteNotificationsUrl = "api/delete-notifications";
        public const string UpdateNotificationStatusUrl = "api/update-notification-status";
        public const string GetInboxUrl = "api/get-inbox";
        public const string GetMessagesUrl = "api/get-messages?userId1=";
        public const string SendMessageUrl = "api/send-messages";
        public const string GetAvailabilityUrl = "api/get-availability";
        public const string UpsertAvailabilityUrl = "api/upsert-availability";
        public const string DeleteAvailabilityUrl = "api/delete-availability";
        public const string GetSettingsUrl = "api/get-settings";
        public const string UpdateSettingsUrl = "api/update-settings";

        //Inventory
        public const string GetInventoryOptionsUrl = "api/get-inventory-options";
        public const string GetInventoryUrl = "api/get-inventory";
        public const string UpsertProductUrl = "api/upsert-product";
        public const string DeleteProductUrl = "api/delete-product";

        //Browse
        public const string GetBrowseUrl = "api/get-browse?keyword=";
        public const string LikeProductUrl = "api/like-product";
        public const string DislikeProductUrl = "api/dislike-product";
        public const string RequestTradeUrl = "api/request-trade";
        public const string GetCommentsUrl = "api/get-comments";
        public const string InsertCommentUrl = "api/insert-comment";

        //Dashboard
        public const string GetDashboardUrl = "api/get-dashboard?filter=";

        //Request
        public const string GetTradeRequestsUrl = "api/get-trade-requests";
        public const string AcceptTradeRequestUrl = "api/accept-trade-request";
        public const string RejectTradeRequestUrl = "api/reject-trade-request";
        public const string CancelTradeRequestUrl = "api/cancel-trade-request";
    }
}
