using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Common.Events;
using Kapul.Services.Identity.BusinessManagement.Interfaces;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Kapul.Services.Identity.Handler
{
    public class DeleteUserHandler : ICommandHandler<DeleteUser>
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public DeleteUserHandler(IBusClient busClient, IUserService userService, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }

        public async Task HandleAsync(DeleteUser command)
        {
            _logger.LogInformation($"Deleting Car {command.Id}");
            Console.WriteLine($"Deleting Car {command.Id}");
            try
            {
                await _userService.DeleteAsync(command.Id);
                await _busClient.PublishAsync(new UserDeleted(command.Id));

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }        
        }
    }
}
