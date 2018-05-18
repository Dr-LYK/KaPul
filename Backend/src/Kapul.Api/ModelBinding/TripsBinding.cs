using Kapul.Api.Models;
using Kapul.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.ModelBinding
{
    public class TripsBinding
    {
        public Guid Id { get; set; }

        public Guid User_id { get; set; }

        public string Departure_city { get; set; }

        public DateTime Departure_time { get; set; }

        public string Arriving_city { get; set; }

        public DateTime Arriving_time { get; set; }

        public double Price { get; set; }

        public ulong Seats_available { get; set; }

        public long Car_id { get; set; }

        public TripsBinding()
        {

        }

        public TripsBinding(Trajet trajet)
        {
            this.Id = trajet.Id;
            this.User_id = trajet.UserId;
            this.Departure_city = trajet.Departure;
            this.Departure_time = trajet.DepartureTime;
            this.Arriving_city = trajet.Arrival;
            this.Arriving_time = trajet.ArrivalTime;
            this.Price = trajet.Price;
            this.Seats_available = trajet.SitsAvailable;
            this.Car_id = 0; // TODO
        }

        public CreateTrajet ToCreateTrajetCommand()
        {
            return new CreateTrajet
            {
                UserId = this.User_id,
                Departure = this.Departure_city,
                DepartureTime = this.Departure_time,
                Arrival = this.Arriving_city,
                ArrivalTime = this.Arriving_time,
                Price = this.Price,
                SitsAvailable = this.Seats_available
            };
        }
    }
}
