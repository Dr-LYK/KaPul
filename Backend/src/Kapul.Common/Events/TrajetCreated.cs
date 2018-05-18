using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class TrajetCreated: IAuthenticatedEvent
    {
        public Guid Id { get; }

        public Guid UserId { get; }

        public string Departure { get; }

        public DateTime DepartureTime { get; }

        public string Arrival { get; }

        public DateTime ArrivalTime { get; }

        public double Price { get; }

        public long SitsAvailable { get; }

        public DateTime CreatedAt { get; }

        protected TrajetCreated()
        {
        }

        public TrajetCreated(Guid id, Guid userId,
            string departure, DateTime departureTime, string arrival, DateTime arrivalTime,
            double price, long sitsAvailable, DateTime createdAt)
        {
            this.Id = id;
            this.UserId = userId;
            this.Departure = departure;
            this.DepartureTime = departureTime;
            this.Arrival = arrival;
            this.ArrivalTime = arrivalTime;
            this.Price = price;
            this.SitsAvailable = sitsAvailable;
            this.CreatedAt = createdAt;
        }
    }
}
