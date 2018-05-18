using Kapul.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Repositories
{
    public interface ITrajetRepository
    {
        Task<Trajet> GetAsync(Guid id);
        Task AddAsync(Trajet trajet);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Trajet trajet);
        Task<IEnumerable<Trajet>> BrowseAsync();
        Task<IEnumerable<Trajet>> BrowseAsync(string from, string to, DateTime date);
    }
}
