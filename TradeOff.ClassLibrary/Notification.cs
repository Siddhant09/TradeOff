using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeOff.ClassLibrary
{
    public class Notification1
    {
        public long? FromUserId { get; set; }
        public long? ToUserId { get; set; }
        public string? UserName { get; set; }
        public string? UserProfilePicUrl { get; set; }
        public string? Message { get; set; }
        public string? DateTime { get; set; }
        public bool IsNew { get; set; }
    }
}
