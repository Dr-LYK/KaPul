using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class TrajetDeleted : IAuthenticatedEvent
    {
        public Guid Id { get; }

        public Guid UserId { get; }

        public string Departure { get; }

        public string Arrival { get; }

        protected TrajetDeleted()
        {
        }

        public TrajetDeleted(Guid id, Guid userId, string departure, string arrival)
        {
            this.Id = id;
            this.UserId = userId;
            this.Departure = departure;
            this.Arrival = arrival;
        }
    }
}
