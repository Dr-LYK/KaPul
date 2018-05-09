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
    public class TrajetsController: Controller
    {
        private readonly IBusClient _busClient;

        public TrajetsController(IBusClient busClient)
        {
            this._busClient = busClient;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateTrajet command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            await _busClient.PublishAsync(command);
            return Accepted($"trajet/{command.Id}");
        }
    }
}
