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
        Task<IEnumerable<Trajet>> BrowseAsync();
    }
}
