using System;
namespace Kapul.Common.Events
{
    public class UserUpdated
    {
        public Guid Id { get; }

        protected UserUpdated()
        {
        }

        public UserUpdated(Guid id)
        {
            this.Id = id;
        }
    }
}
