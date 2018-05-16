using Kapul.Common.Mongo;
using Kapul.Services.Trajet.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Trajet.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ITrajetRepository _trajetRepository;

        public CustomMongoSeeder(IMongoDatabase database, ITrajetRepository trajetRepository) : base (database)
        {
            _trajetRepository = trajetRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            /*var trajets = new List<string>
            {
                "Londres",
                "Paris"
            };

            await Task.WhenAll(trajets.Select( x =>
                _trajetRepository.AddTrajet(new Domain.Models.Trajet(x))));*/
            await Task.CompletedTask;
        }
    }
}
