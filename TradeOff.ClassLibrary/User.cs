using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeOff.ClassLibrary
{
    public class User
    {
        public long? UserId { get; set; }
        public string? strUserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? AuthToken { get; set; }
        public string? Password { get; set; }
        public bool? IsVerified { get; set; }
        public string? ProfilePicUrl { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }
        public long? StateId { get; set; }
        public bool? PushNotification { get; set; }
        public bool? EmailNotification { get; set; }
        public bool? IsDarkTheme { get; set; }
        public string? Date { get; set; }
        public List<LookupOption>? StatesList { get; set; }
    }
    public class Notification
    {
        public long? FromUserId { get; set; }
        public long? ToUserId { get; set; }
        public string? UserName { get; set; }
        public string? UserProfilePicUrl { get; set; }
        public string? ToUserName { get; set; }
        public string? ToUserProfilePicUrl { get; set; }
        public string? Message { get; set; }
        public string? DateTime { get; set; }
        public bool IsNew { get; set; }
        public long? ProductId { get; set; }
    }
    public class Availability
    {
        public long? AvailabilityId { get; set; }
        public long? UserId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public TimeSpan? FromTime { get; set; }
        public TimeSpan? ToTime { get; set; }
        public string? strFrom { get; set; }
        public string? strTo { get; set; }
        public string? Days { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public bool? Sunday { get; set; }
    }
}
