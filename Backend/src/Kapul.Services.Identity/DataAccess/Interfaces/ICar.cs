using System;
using System.Threading.Tasks;
namespace Kapul.Services.Identity.DataAccess.Interfaces
{
    public interface ICar
    {
        Task<DBO.Car> Get(long id);
        Task<DBO.Car> Create(DBO.Car car);
        Task<bool> Delete(long id);
    }
}
