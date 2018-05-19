using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Kapul.Services.Identity.DataAccess.Repositories
{
    public class CarRepository : Interfaces.ICarRepository
    {
        private readonly IdentityContext _context;

        public CarRepository(IdentityContext context)
        {
            this._context = context;
        }

        public async Task<DBO.Car> Create(DBO.Car car)
        {
            try
            {
                _context.Cars.Add(car);
                Console.WriteLine("Before");
                await _context.SaveChangesAsync();
                Console.WriteLine("After");
                return car;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on create Car: {ex}");
                return null;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                DBO.Car car = await _context.Cars.FindAsync(id);
                if (car != null)
                {
                    _context.Cars.Remove(car);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on delete Car: {ex}");
            }
            return false;
        }

        public async Task<DBO.Car> Get(Guid id)
        {
            try
            {
                return await _context.Cars.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on get Car with id: {id}: {ex}");
                return null;
            }
        }
    }
}
