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
            return Json(trajets.Select(x => {
                TripsBinding trip = new TripsBinding(x);
                return new { trip.Id, trip.Departure_city, trip.Departure_time, trip.Arriving_city, trip.Arriving_time, trip.Price, trip.SitsAvailable, x.CreatedAt, trip.User_id };
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Models.Trajet trajet = await _repository.GetAsync(id);
            if (trajet == null)
            {
                return NotFound();
            }
            TripsBinding trip = new TripsBinding(trajet);
            return Json(new { trip.Id, trip.Departure_city, trip.Departure_time, trip.Arriving_city, trip.Arriving_time, trip.Price, trip.SitsAvailable, trajet.CreatedAt, trip.User_id });
        }

        [HttpPost("new")]
        public async Task<IActionResult> Post([FromBody]TripsBinding trip)
        {
            if (trip == null)
            {
                return BadRequest();
            }
            CreateTrajet command = trip.ToCreateTrajetCommand();
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            await _busClient.PublishAsync(command);
            return Accepted($"trips/{command.Id}");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Models.Trajet trajet = await _repository.GetAsync(id);
            if (trajet == null)
            {
                return NotFound();
            }
            DeleteTrajet command = new DeleteTrajet
            {
                Id = trajet.Id,
                UserId = trajet.UserId,
                Departure = trajet.Departure,
                Arrival = trajet.Arrival
            };
            Console.WriteLine("Publishing delete command");
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}
