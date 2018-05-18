using Kapul.Api.Repositories;
using Kapul.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Handler
{
    public class TrajetDeletedHandler: IEventHandler<TrajetDeleted>
    {
        private readonly ITrajetRepository _trajetRepository;

        public TrajetDeletedHandler(ITrajetRepository trajetRepository)
        {
            this._trajetRepository = trajetRepository;
        }

        public async Task HandleAsync(TrajetDeleted @event)
        {
            await _trajetRepository.DeleteAsync(@event.Id);
            Console.WriteLine($"Trajet deleted: {@event.Departure} -> {@event.Arrival}");
        }
    }
}
