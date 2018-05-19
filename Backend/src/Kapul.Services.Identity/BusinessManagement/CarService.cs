using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Services.Identity.DBO;

namespace Kapul.Services.Identity.BusinessManagement
{
    public class CarService : Interfaces.ICarService
    {   
        private readonly DataAccess.Interfaces.ICarRepository _carRepository;

        public CarService(DataAccess.Interfaces.ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Car> CreateAsync(CreateCar command)
        {
            Car car = new Car
            {
                Id = command.Id,
                User_Id = command.UserId,
                Model = command.Model,
                Color = command.Color,
                Registration = command.Registration
            };

            return await _carRepository.Create(car);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _carRepository.Delete(id);
        }

        public async Task<Car> GetAsync(Guid id)
        {
            return await _carRepository.Get(id);
        }
    }
}
