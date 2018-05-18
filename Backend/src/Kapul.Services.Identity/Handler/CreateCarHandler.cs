using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Common.Events;
using Kapul.Services.Identity.BusinessManagement.Interfaces;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Kapul.Services.Identity.Handler
{
    public class CreateCarHandler : ICommandHandler<CreateCar>
    {
        private readonly IBusClient _busClient;
        private readonly ICarService _carService;
        private readonly ILogger _logger;

        public CreateCarHandler(IBusClient busClient, ICarService carService, ILogger<CreateCarHandler> logger)
        {
            _busClient = busClient;
            _carService = carService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateCar command)
        {
            _logger.LogInformation($"Creating Car {command.Model}");
            Console.WriteLine($"Creating Car {command.Model}");
            try
            {
                await _carService.CreateAsync(command);
                await _busClient.PublishAsync(new CarCreated(command.Id, command.UserId, command.Model, command.Color, command.PlateNumber));

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
