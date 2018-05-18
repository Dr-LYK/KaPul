using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Models
{
    public class Trajet
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Departure { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Arrival { get; set; }

        public DateTime ArrivalTime { get; set; }

        public double Price { get; set; }

        public long SitsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
