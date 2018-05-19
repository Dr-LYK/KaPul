using System;
namespace Kapul.Common.Events
{
    public class UserDeleted
    {
        public Guid Id { get; }

        protected UserDeleted()
        {
        }

        public UserDeleted(Guid id)
        {
            this.Id = id;
        }
    }
}
