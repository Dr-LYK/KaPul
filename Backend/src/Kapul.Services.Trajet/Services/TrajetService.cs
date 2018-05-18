using Kapul.Common.Commands;
using Kapul.Services.Trajet.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Trajet.Services
{
    public class TrajetService : ITrajetService
    {
        private readonly ITrajetRepository _trajetRepository;

        public TrajetService(ITrajetRepository trajetRepository)
        {
            _trajetRepository = trajetRepository;
        }

        public async Task AddAsync(CreateTrajet command)
        {
            var trajet = new Domain.Models.Trajet(command.Id, command.UserId, command.Departure, command.DepartureTime, command.Arrival, command.ArrivalTime, command.Price, command.SitsAvailable, command.CreatedAt);
            await _trajetRepository.AddTrajet(trajet);
        }
    }
}
