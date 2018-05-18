using Kapul.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Trajet.Services
{
    public interface ITrajetService
    {
        Task AddAsync(CreateTrajet command);
    }
}
