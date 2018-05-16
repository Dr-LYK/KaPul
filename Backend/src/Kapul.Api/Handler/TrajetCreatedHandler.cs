using Kapul.Api.Repositories;
using Kapul.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Handler
{
    public class TrajetCreatedHandler : IEventHandler<TrajetCreated>
    {
        private readonly ITrajetRepository _trajetRepository;

        public TrajetCreatedHandler(ITrajetRepository trajetRepository)
        {
            this._trajetRepository = trajetRepository;
        }

        public async Task HandleAsync(TrajetCreated @event)
        {
            await _trajetRepository.AddAsync(new Models.Trajet
            {
                Id = @event.Id,
                UserId = @event.UserId,
                Departure = @event.Departure,
                DepartureTime = @event.DepartureTime,
                Arrival = @event.Arrival,
                Price = @event.Price,
                SitsAvailable = @event.SitsAvailable,
                CreatedAt = @event.CreatedAt
            });
            Console.WriteLine($"Trajet created: {@event.Departure} -> {@event.Arrival}");
        }
    }
}
