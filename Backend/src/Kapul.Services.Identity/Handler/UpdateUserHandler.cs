using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Common.Events;
using Kapul.Services.Identity.BusinessManagement.Interfaces;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Kapul.Services.Identity.Handler
{
    public class UpdateUserHandler : ICommandHandler<UpdateUser>
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UpdateUserHandler(IBusClient busClient, IUserService userService, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }

        public async Task HandleAsync(UpdateUser command)
        {
            _logger.LogInformation($"Updating Car {command.Id}");
            Console.WriteLine($"Updating Car {command.Id}");
            try
            {
                await _userService.UpdateAsync(command);
                await _busClient.PublishAsync(new UserUpdated(command.Id));

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }        
        }
    }
}
