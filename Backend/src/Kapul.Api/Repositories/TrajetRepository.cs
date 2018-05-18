﻿using System;
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

        public async Task<IEnumerable<Trajet>> BrowseAsync()
            => await Collection.AsQueryable().ToListAsync();

        public async Task<IEnumerable<Trajet>> BrowseAsync(string from, string to, DateTime date)
            => await Collection.AsQueryable().Where(t => t.Departure == from && t.Arrival == to && t.DepartureTime == date).ToListAsync();

        public async Task<Trajet> GetAsync(Guid id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(i => i.Id == id);

        public async Task DeleteAsync(Guid id)
           => await Collection.DeleteOneAsync(i => i.Id == id);

        public async Task UpdateAsync(Trajet trajet)
             => await Collection.ReplaceOneAsync(t => t.Id == trajet.Id, trajet);

        private IMongoCollection<Trajet> Collection
            => _database.GetCollection<Trajet>("Trips");
    }
}
