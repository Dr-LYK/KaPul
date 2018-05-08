using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class UserAuthenticated: IEvent
    {
        public string Email { get; }

        protected UserAuthenticated()
        {
        }

        public UserAuthenticated(string email)
        {
            this.Email = email;
        }
    }
}
