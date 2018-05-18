using System;
using System.Threading.Tasks;

namespace Kapul.Services.Identity.BusinessManagement
{
    public class CarService : Interfaces.ICarService
    {
        private readonly DataAccess.Interfaces.ICarRepository _carRepository;

        public CarService(DataAccess.Interfaces.ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<DBO.Car> CreateAsync(CreateCar command)
        {
            return await _carRepository.Create(command);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _carRepository.Delete(id);
        }

        public async Task<DBO.Car> Get(long id)
        {
            return await _carRepository.Get(id);
        }
    }
}
