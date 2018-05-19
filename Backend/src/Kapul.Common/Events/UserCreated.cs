using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class UserCreated
    {
        public Guid Id { get; }
        public string Name { get; }
        public string FirstName { get; }
        public string Email { get; }

        protected UserCreated()
        {
        }

        public UserCreated(Guid id, string name, string firstname, string email)
        {
            this.Id = id;
            this.Name = name;
            this.FirstName = firstname;
            this.Email = email;
        }
    }
}
