using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;

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
            DBO.Car car = new DBO.Car
            {
                Id = command.Id,
                UserId = command.UserId,
                Model = command.Model,
                Color = command.Color,
                PlateNumber = command.PlateNumber
            };

            return await _carRepository.Create(car);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _carRepository.Delete(id);
        }

        public async Task<DBO.Car> Get(Guid id)
        {
            return await _carRepository.Get(id);
        }
    }
}
