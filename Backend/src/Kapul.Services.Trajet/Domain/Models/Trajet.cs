using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Trajet.Domain.Models
{
    public class Trajet
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Departure { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Arrival { get; set; }

        public double Price { get; set; }

        public long SitsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }

        protected Trajet()
        {
        }

        public Trajet(string departure)
        {
            Departure = departure;
        }

        public Trajet(Guid userId, string departure, DateTime departureTime, string arrival, double price, long sitsAvailable)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UserId = userId;
            Departure = departure.ToLowerInvariant();
            DepartureTime = departureTime;
            Arrival = arrival.ToLowerInvariant();
            Price = price;
            SitsAvailable = sitsAvailable;
        }
    }
}
