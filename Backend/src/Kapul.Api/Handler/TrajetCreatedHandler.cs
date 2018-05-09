using Kapul.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Handler
{
    public class TrajetCreatedHandler : IEventHandler<TrajetCreated>
    {
        public async Task HandleAsync(TrajetCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Trajet created: {@event.Departure} -> {@event.Arrival}");
        }
    }
}
