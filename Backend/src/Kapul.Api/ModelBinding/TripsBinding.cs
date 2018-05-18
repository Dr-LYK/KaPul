using Kapul.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.ModelBinding
{
    public class TripsBinding
    {
        public Guid UserId { get; set; }

        public string Departure_city { get; set; }

        public DateTime Departure_time { get; set; }

        public string Arriving_city { get; set; }

        public DateTime Arriving_time { get; set; }

        public double Price { get; set; }

        public long SitsAvailable { get; set; }

        public long Car_id { get; set; }

        public CreateTrajet ToCreateTrajetCommand()
        {
            return new CreateTrajet
            {
                UserId = this.UserId,
                Departure = this.Departure_city,
                DepartureTime = this.Departure_time,
                Arrival = this.Arriving_city,
                ArrivalTime = this.Arriving_time,
                Price = this.Price,
                SitsAvailable = this.SitsAvailable
            };
        }
    }
}
