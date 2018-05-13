using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Trajet.Repository
{
    public class TrajetRepository : Domain.Repositories.ITrajetRepository
    {
        private readonly IMongoDatabase _database;

        public TrajetRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddTrajet(Domain.Models.Trajet trajet) 
            => await Collection.InsertOneAsync(trajet);

        public async Task<Domain.Models.Trajet> GetAsync(Guid id) 
            => await Collection.AsQueryable().FirstOrDefaultAsync(i => i.Id == id);

        private IMongoCollection<Domain.Models.Trajet> Collection
            => _database.GetCollection<Domain.Models.Trajet>("Course");
    }
}
