using Kapul.Api.ModelBinding;
using Kapul.Api.Repositories;
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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TripsController: Controller
    {
        private readonly IBusClient _busClient;
        private readonly ITrajetRepository _repository;

        public TripsController(IBusClient busClient, ITrajetRepository repository)
        {
            this._busClient = busClient;
            this._repository = repository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var trajets = await _repository.BrowseAsync();
            return Json(trajets.Select(x => new { x.Id, x.Departure, x.DepartureTime, x.Arrival, x.Price, x.SitsAvailable, x.CreatedAt }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var trajet = await _repository.GetAsync(id);
            if (trajet == null)
            {
                return NotFound();
            }
            return Json(new { trajet.Id, trajet.Departure, trajet.DepartureTime, trajet.Arrival, trajet.ArrivalTime, trajet.Price, trajet.SitsAvailable, trajet.CreatedAt });
        }

        [HttpPost("new")]
        public async Task<IActionResult> Post([FromBody]TripsBinding trip)
        {
            CreateTrajet command = trip.ToCreateTrajetCommand();
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            //command.UserId = Guid.Parse(User.Identity.Name);
            await _busClient.PublishAsync(command);
            return Accepted($"trips/{command.Id}");
        }
    }
}
