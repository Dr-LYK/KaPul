using Kapul.Api.Repositories;
using Kapul.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Handler
{
    public class CarCreatedHandler : IEventHandler<CarCreated>
    {
        private readonly ITrajetRepository _trajetRepository;

        public CarCreatedHandler(ITrajetRepository trajetRepository)
        {
            this._trajetRepository = trajetRepository;
        }

        public async Task HandleAsync(CarCreated @event)
        {
            Console.WriteLine($"Car created for user: {@event.UserId} with id: {@event.Id}");
            await Task.CompletedTask;
        }
    }
}
