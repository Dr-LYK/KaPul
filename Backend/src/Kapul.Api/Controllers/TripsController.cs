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

        public async Task<IActionResult> GetAll()
        {
            var trajets = await _repository.BrowseAsync();
            return Json(trajets.Select(x => {
                TripsBinding trip = new TripsBinding(x);
                return new { trip.Id, trip.Departure_city, trip.Departure_time, trip.Arriving_city, trip.Arriving_time, trip.Price, trip.Remaining_seats, x.CreatedAt, trip.User_id };
            }));
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery]string from, [FromQuery]string to, [FromQuery]DateTime? date)
        {
            if (from == null && to == null && !date.HasValue)
            {
                return await GetAll();
            }
            else
            {
                if (from == null || to == null || !date.HasValue)
                {
                    return BadRequest();
                }
                var trajets = await _repository.BrowseAsync(from, to, date.Value);
                return Json(trajets.Select(x => {
                    TripsBinding trip = new TripsBinding(x);
                    return new { trip.Id, trip.Departure_city, trip.Departure_time, trip.Arriving_city, trip.Arriving_time, trip.Price, trip.Remaining_seats, x.CreatedAt, trip.User_id };
                }));
            }
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
            return Json(new { trip.Id, trip.Departure_city, trip.Departure_time, trip.Arriving_city, trip.Arriving_time, trip.Price, trip.Remaining_seats, trajet.CreatedAt, trip.User_id });
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
            return Json(new { command.Id });
        }

        [HttpPost("{id}/booking")]
        public async Task<IActionResult> Post([FromBody]SeatNumber seatRequested, Guid id)
        {
            if (seatRequested == null)
            {
                return BadRequest();
            }
            Models.Trajet trajet = await _repository.GetAsync(id);
            if (trajet == null)
            {
                return NotFound();
            }
            if (trajet.SitsAvailable < seatRequested.Nb_seat)
            {
                return BadRequest($"Only {trajet.SitsAvailable} seats available on trip {trajet.Id}");
            }
            BookTrajet command = new BookTrajet
            {
                TrajetCreated = new CreateTrajet { 
                    Id = trajet.Id,
                    UserId = trajet.UserId,
                    Departure = trajet.Departure,
                    DepartureTime = trajet.DepartureTime,
                    Arrival = trajet.Arrival,
                    ArrivalTime = trajet.ArrivalTime,
                    Price = trajet.Price,
                    SitsAvailable = trajet.SitsAvailable,
                    CreatedAt = trajet.CreatedAt
                },
                //UserId = Guid.Parse(User.Identity.Name)
                UserId = Guid.NewGuid(),
                SeatNumber = seatRequested.Nb_seat,
                BookDate = DateTime.UtcNow
            };
            await _busClient.PublishAsync(command);
            return Accepted($"trips/{trajet.Id}");
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
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}
