using Kapul.Api.ModelBinding;
using Kapul.Api.Repositories;
using Kapul.Common.Auth;
using Kapul.Common.Commands;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Controllers
{
    [Route("[controller]")]
    [EnableCors("AllowAllHeaders")]
    public class UsersController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly ITrajetRepository _repository;

        public UsersController(IBusClient busClient, ITrajetRepository repository)
        {
            this._busClient = busClient;
            this._repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Content($"/users/{id}: Not Implemented Yet");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]AuthenticateUser command)
        {
            var token = Guid.NewGuid();
            LoginUserResponse user = new LoginUserResponse
            {
                Id = Guid.NewGuid(),
                Surname = "Kayak",
                Name = "Martin"
            };
            await _busClient.PublishAsync(command);
            return Json(new { token, user});
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _busClient.PublishAsync(command);
            return Json(new { command.Email });
        }

        /*[HttpPost("{id}/comment")]
        public async Task<IActionResult> Comment([FromBody]CreateComment command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }*/

        [HttpPost("{id}/cars")]
        public async Task<IActionResult> AddCar(Guid id, [FromBody]CreateCar command)
        {
            /*Models.Trajet trajet = await _repository.GetAsync(id);
            if (trajet == null)
            {
                return NotFound();
            }*/
            command.Id = Guid.NewGuid();
            //command.UserId = Guid.Parse(User.Identity.Name);
            //command.UserId = Guid.NewGuid();
            command.UserId = Guid.Parse("58877d79-3cdd-4d36-9f30-a6c6953a4860");
            await _busClient.PublishAsync(command);
            return Json(new { command.Id });
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody]CreateUser command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }*/

        /*[HttpDelete("{id}/cars/{car_id}")]
        public async Task<IActionResult> DeleteCar(Guid id, Guid car_id)
        {
            //Create DeleteCar command
            await _busClient.PublishAsync(command);
            return Accepted();
        }*/

        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            // Create DeleteUser command
            await _busClient.PublishAsync(command);
            return Accepted();
        }*/
    }
}
