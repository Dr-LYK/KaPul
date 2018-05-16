using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kapul.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Kapul.Api.Repositories
{
    public class TrajetRepository : ITrajetRepository
    {
        private readonly IMongoDatabase _database;

        public TrajetRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Trajet trajet)
            => await Collection.InsertOneAsync(trajet);

        public async Task<IEnumerable<Trajet>> BrowseAsync(Guid userId)
            => await Collection.AsQueryable().Where(x => x.UserId == userId).ToListAsync();

        public async Task<Trajet> GetAsync(Guid id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(i => i.Id == id);


        private IMongoCollection<Trajet> Collection
            => _database.GetCollection<Trajet>("Course");
    }
}
