using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class TrajetBooked: IAuthenticatedEvent
    {
        public TrajetCreated TrajetUpdated { get; set; }
        public Guid UserId { get; set; }
        public ulong SeatNumber { get; set; }

        protected TrajetBooked()
        {
        }

        public TrajetBooked(Guid id, Guid userId, string departure, DateTime departureTime, string arrival, DateTime arrivalTime, double price, ulong sitsAvailable, DateTime createdAt, ulong seatNumber)
        {
            this.TrajetUpdated = new TrajetCreated(id, userId, departure, departureTime, arrival, arrivalTime, price, sitsAvailable, createdAt);
            this.UserId = userId;
            this.SeatNumber = seatNumber;
        }
    }
}
