using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeOff.ClassLibrary
{
    public class Notification
    {
        public string? UserName { get; set; }
        public string? Message { get; set; }
        public string? DateTime { get; set; }
        public bool IsNew { get; set; }

        public List<Notification> GetNotifications()
        {
            List<Notification> notifications = new List<Notification>() {
                new Notification { UserName = "Nithika Sanghi", Message = "Requested for a trade", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = true },
                new Notification { UserName = "Siddhant Chawade", Message = "Accepted your trade request", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = true },
                new Notification { UserName = "Siddhant Chawade", Message = "Rejected your trade request", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = true },
                new Notification { UserName = "Siddhant Chawade", Message = "Liked your item", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = false },
                new Notification { UserName = "Siddhant Chawade", Message = "Disliked your item", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = false },
                new Notification { UserName = "Nithika Sanghi", Message = "Accepted your trade request", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = false },
                new Notification { UserName = "Nithika Sanghi", Message = "Requested for a trade", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = false },
                new Notification { UserName = "Siddhant Chawade", Message = "Liked your item", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = false },
                new Notification { UserName = "Nithika Sanghi", Message = "Requested for a trade", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = false },
                new Notification { UserName = "Nithika Sanghi", Message = "Rejected your trade request", DateTime = System.DateTime.Now.ToShortDateString(), IsNew = false }
            };

            return notifications;
        }
    }
}
