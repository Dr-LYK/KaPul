using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Common.Events;
using Kapul.Services.Identity.BusinessManagement.Interfaces;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Kapul.Services.Identity.Handler
{
    public class GetUserHandler : ICommandHandler<GetUser>
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public GetUserHandler(IBusClient busClient, IUserService userService, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }

        public async Task HandleAsync(GetUser command)
        {
            _logger.LogInformation($"Getting User {command.Id}");
            Console.WriteLine($"Getting User {command.Id}");
            try
            {
                DBO.User user = await _userService.GetAsync(command.Id);
                await _busClient.PublishAsync(new UserGot(user.Id, user.Name, user.FirstName, user.Email, user.Password, user.IdCard, user.DrivingLicence, user.RegistrationDate));

                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }        
        }
    }
}
