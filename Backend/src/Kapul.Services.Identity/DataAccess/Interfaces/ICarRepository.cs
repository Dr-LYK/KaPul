using System;
using System.Threading.Tasks;
namespace Kapul.Services.Identity.DataAccess.Interfaces
{
    public interface ICarRepository
    {
        Task<DBO.Car> Get(Guid id);
        Task<DBO.Car> Create(DBO.Car car);
        Task<bool> Delete(Guid id);
    }
}
