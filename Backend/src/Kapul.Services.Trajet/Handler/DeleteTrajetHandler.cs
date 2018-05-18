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
    public class DeleteTrajetHandler : ICommandHandler<DeleteTrajet>
    {
        private readonly IBusClient _busClient;
        private readonly ITrajetService _trajetService;
        private ILogger _logger;

        public DeleteTrajetHandler(IBusClient busClient, ITrajetService trajetService, ILogger<DeleteTrajetHandler> logger)
        {
            _busClient = busClient;
            _trajetService = trajetService;
            _logger = logger;
        }

        public async Task HandleAsync(DeleteTrajet command)
        {
            _logger.LogInformation($"Deleting Trajet {command.Departure} -> {command.Arrival}");
            Console.WriteLine($"Deleting Trajet {command.Departure} -> {command.Arrival}");
            try
            {
                await _trajetService.DeleteAsync(command.Id);
                await _busClient.PublishAsync(new TrajetDeleted(command.Id, command.UserId, command.Departure, command.Arrival));

                return;
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new DeleteTrajetRejected(command.Id, ex.Message, "401"));
                _logger.LogError(ex.Message);
            }
        }
    }
}
