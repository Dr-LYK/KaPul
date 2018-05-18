using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Trajet.Domain.Repositories
{
    public interface ITrajetRepository
    {
        Task<Models.Trajet> GetAsync(Guid id);
        Task AddTrajet(Models.Trajet trajet);
        Task DeleteTrajet(Guid id);
    }
}
