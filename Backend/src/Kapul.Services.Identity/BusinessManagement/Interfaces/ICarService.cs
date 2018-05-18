using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;

namespace Kapul.Services.Identity.BusinessManagement.Interfaces
{
    public interface ICarService
    {
        Task<DBO.Car> GetAsync(Guid id);
        Task<DBO.Car> CreateAsync(CreateCar command);
        Task<bool> DeleteAsync(Guid id);
    }
}
