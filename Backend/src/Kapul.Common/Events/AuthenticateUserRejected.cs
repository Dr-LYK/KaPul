using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        protected AuthenticateUserRejected()
        {
        }

        public AuthenticateUserRejected(string email, string reason, string code)
        {
            this.Email = email;
            this.Reason = reason;
            this.Code = code;
        }
    }
}
