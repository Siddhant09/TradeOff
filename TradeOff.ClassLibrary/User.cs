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
    }
}
