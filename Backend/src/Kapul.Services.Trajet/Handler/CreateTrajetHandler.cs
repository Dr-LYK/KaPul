using Kapul.Common.Commands;
using Kapul.Common.Events;
using Kapul.Services.Trajet.Services;
using Microsoft.Extensions.Logging;
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
        private readonly ITrajetService _trajetService;
        private ILogger _logger;

        public CreateTrajetHandler(IBusClient busClient, ITrajetService trajetService, ILogger<CreateTrajetHandler> logger)
        {
            _busClient = busClient;
            _trajetService = trajetService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateTrajet command)
        {
            _logger.LogInformation($"Creating Trajet {command.Departure} -> {command.Arrival}");
            Console.WriteLine($"Creating Trajet {command.Departure} -> {command.Arrival}");
            try
            {
                await _trajetService.AddAsync(command);
                await _busClient.PublishAsync(new TrajetCreated(command.Id, command.UserId, command.Departure, command.DepartureTime, command.Arrival, command.ArrivalTime, command.Price, command.SitsAvailable, command.CreatedAt));
                
                return;
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateTrajetRejected(command.DepartureTime, command.ArrivalTime, command.Price, command.SitsAvailable, ex.Message, "401"));
                _logger.LogError(ex.Message);
            }
        }
    }
}
