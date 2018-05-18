using Kapul.Api.Repositories;
using Kapul.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Handler
{
    public class TrajetBookedHandler : IEventHandler<TrajetBooked>
    {
        private readonly ITrajetRepository _trajetRepository;

        public TrajetBookedHandler(ITrajetRepository trajetRepository)
        {
            this._trajetRepository = trajetRepository;
        }

        public async Task HandleAsync(TrajetBooked @event)
        {
            await _trajetRepository.UpdateAsync(new Models.Trajet
            {
                Id = @event.TrajetUpdated.Id,
                UserId = @event.TrajetUpdated.UserId,
                Departure = @event.TrajetUpdated.Departure,
                DepartureTime = @event.TrajetUpdated.DepartureTime,
                Arrival = @event.TrajetUpdated.Arrival,
                ArrivalTime = @event.TrajetUpdated.ArrivalTime,
                Price = @event.TrajetUpdated.Price,
                SitsAvailable = @event.TrajetUpdated.SitsAvailable,
                CreatedAt = @event.TrajetUpdated.CreatedAt
            });
            Console.WriteLine($"Trajet booked: {@event.TrajetUpdated.Departure} -> {@event.TrajetUpdated.Arrival} with {@event.SeatNumber}");
        }
    }
}
