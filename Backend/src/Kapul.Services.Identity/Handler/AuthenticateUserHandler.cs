using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Common.Events;
using Kapul.Services.Identity.BusinessManagement.Interfaces;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Kapul.Services.Identity.Handler
{
    public class AuthenticateUserHandler
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public AuthenticateUserHandler(IBusClient busClient, IUserService userService, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }

        public async Task HandleAsync(AuthenticateUser command)
        {
            _logger.LogInformation($"Authentication of User {command.Email}");
            Console.WriteLine($"Authentication of User {command.Email}");
            try
            {
                DBO.User user = await _userService.AuthenticateAsync(command.Email, command.Password);
                await _busClient.PublishAsync(new UserAuthenticated(user.Email));

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
