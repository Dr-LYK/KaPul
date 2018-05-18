using Kapul.Api.ModelBinding;
using Kapul.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Controllers
{
    [Route("")]
    public class HomeController: Controller
    {
        private readonly IBusClient _busClient;
        private readonly ITrajetRepository _repository;

        public HomeController(IBusClient busClient, ITrajetRepository repository)
        {
            this._busClient = busClient;
            this._repository = repository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Content("Kapul API");
        }

        [HttpGet("bestPrices")]
        public IActionResult GetBestPrices()
        {
            return Content("BestPrices: Not Implemented Yet");
        }

        [HttpGet("nextDepartures")]
        public async Task<IActionResult> GetNextDepartures([FromQuery]uint limit = 3)
        {
            var trajets = await _repository.BrowseAsync();
            List<Models.Trajet> trajetsSorted = trajets.ToList();
            trajetsSorted = trajetsSorted.Where(x => x.DepartureTime >= DateTime.Now).ToList();
            trajetsSorted.Sort((x, y) => x.DepartureTime.CompareTo(y.DepartureTime));
            List<Models.Trajet> nextTrajets = new List<Models.Trajet>();
            foreach (var trajet in trajetsSorted)
            {
                if (limit == 0)
                {
                    break;
                }
                else
                {
                    nextTrajets.Add(trajet);
                    limit--;
                }
            }
            return Json(nextTrajets.Select(x => {
                TripsBinding trip = new TripsBinding(x);
                return new { trip.Id, trip.Departure_city, trip.Departure_time, trip.Arriving_city, trip.Arriving_time, trip.Price, trip.Remaining_seats, x.CreatedAt, trip.User_id };
            }));
        }
    }
}
