using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Common.Events;
using Kapul.Services.Identity.BusinessManagement.Interfaces;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Kapul.Services.Identity.Handler
{
    public class GetCarHandler : ICommandHandler<GetCar>
    {
        private readonly IBusClient _busClient;
        private readonly ICarService _carService;
        private readonly ILogger _logger;

        public GetCarHandler(IBusClient busClient, ICarService carService, ILogger<GetCarHandler> logger)
        {
            _busClient = busClient;
            _carService = carService;
            _logger = logger;
        }

        public async Task HandleAsync(GetCar command)
        {
            _logger.LogInformation($"Getting Car {command.Id}");
            Console.WriteLine($"Getting Car {command.Id}");
            try
            {
                DBO.Car car = await _carService.GetAsync(command.Id);
                await _busClient.PublishAsync(new CarGot(car.Id, car.UserId, car.Model, car.Color, car.PlateNumber));

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
