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

        public async Task DeleteAsync(Guid id)
        {
            await _trajetRepository.DeleteTrajet(id);
        }

        public async Task UpdateAsync(BookTrajet command)
        {
            var trajet = new Domain.Models.Trajet(command.TrajetCreated.Id, command.TrajetCreated.UserId, command.TrajetCreated.Departure, command.TrajetCreated.DepartureTime, command.TrajetCreated.Arrival, command.TrajetCreated.ArrivalTime, command.TrajetCreated.Price, command.TrajetCreated.SitsAvailable - command.SeatNumber, command.TrajetCreated.CreatedAt);
            await _trajetRepository.UpdateTrajet(trajet);
        }
    }
}
