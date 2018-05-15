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

        public async Task AddAsync(Guid userId, string departure, DateTime departureTime, string arrival, double price, long sitsAvailable)
        {
            var trajet = new Domain.Models.Trajet(userId, departure, departureTime, arrival, price, sitsAvailable);
            await _trajetRepository.AddTrajet(trajet);
        }
    }
}
