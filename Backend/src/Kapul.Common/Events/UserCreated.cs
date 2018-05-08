using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class UserCreated
    {
        public string Email { get; }
        public string Name { get; }

        protected UserCreated()
        {
        }

        public UserCreated(string email, string name)
        {
            this.Email = email;
            this.Name = name;
        }
    }
}
