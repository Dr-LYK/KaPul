using Kapul.Common.Commands;
using Kapul.Common.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Trajet.Handler
{
    public class CreateTrajetHandler : ICommandHandler<CreateTrajet>
    {
        private readonly IBusClient _busClient;

        public CreateTrajetHandler(IBusClient busClient)
        {
            this._busClient = busClient;
        }

        public async Task HandleAsync(CreateTrajet command)
        {
            Console.WriteLine($"Creating Trajet {command.Departure} -> {command.Arrival}");
            await _busClient.PublishAsync(new TrajetCreated(command.Id, command.UserId, command.Departure, command.DepartureTime, command.Arrival, command.Price, command.SitsAvailable, command.CreatedAt));
        }
    }
}
