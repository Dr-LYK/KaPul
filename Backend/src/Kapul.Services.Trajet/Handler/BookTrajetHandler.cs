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
    public class BookTrajetHandler : ICommandHandler<BookTrajet>
    {
        private readonly IBusClient _busClient;
        private readonly ITrajetService _trajetService;
        private ILogger _logger;

        public BookTrajetHandler(IBusClient busClient, ITrajetService trajetService, ILogger<BookTrajetHandler> logger)
        {
            _busClient = busClient;
            _trajetService = trajetService;
            _logger = logger;
        }

        public async Task HandleAsync(BookTrajet command)
        {
            _logger.LogInformation($"Booking Trajet {command.TrajetCreated.Departure} -> {command.TrajetCreated.Arrival} with {command.SeatNumber} seats");
            Console.WriteLine($"Booking Trajet {command.TrajetCreated.Departure} -> {command.TrajetCreated.Arrival} with {command.SeatNumber} seats");
            try
            {
                await _trajetService.UpdateAsync(command);
                await _busClient.PublishAsync(new TrajetBooked(command.TrajetCreated.Id, command.TrajetCreated.UserId, command.TrajetCreated.Departure, command.TrajetCreated.DepartureTime, command.TrajetCreated.Arrival, command.TrajetCreated.ArrivalTime, command.TrajetCreated.Price, command.TrajetCreated.SitsAvailable - command.SeatNumber, command.TrajetCreated.CreatedAt, command.SeatNumber));

                return;
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new BookTrajetRejected(command.TrajetCreated.Id, command.SeatNumber, command.TrajetCreated.SitsAvailable, ex.Message, "401"));
                _logger.LogError(ex.Message);
            }
        }
    }
}
