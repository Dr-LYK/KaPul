using Kapul.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IBusClient _busClient;

        public UsersController(IBusClient busClient)
        {
            this._busClient = busClient;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Content($"/users/{id}: Not Implemented Yet");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Get([FromBody]AuthenticateUser command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }

        /*[HttpPost("{id}/comment")]
        public async Task<IActionResult> Comment([FromBody]CreateComment command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }*/

        /*[HttpPost("{id}/cars")]
        public async Task<IActionResult> AddCar([FromBody]CreateCar command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }*/

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
