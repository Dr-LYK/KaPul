using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;

namespace Kapul.Services.Identity.BusinessManagement.Interfaces
{
    public interface ICarService
    {
        Task<DBO.Car> GetAsync(long id);
        Task<DBO.Car> CreateAsync(CreateCar command);
        Task<bool> DeleteAsync(long id);
    }
}
