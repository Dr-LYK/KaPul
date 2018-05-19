﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Kapul.Services.Identity.DataAccess.Repositories
{
    public class CarRepository : Interfaces.ICarRepository
    {
        private readonly IdentityContext _context;
        private readonly ILogger _logger;
        public CarRepository(IdentityContext context)
        {
            this._context = context;
        }

        public async Task<DBO.Car> Create(DBO.Car car)
        {
            try
            {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
                return car;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on create Car: {ex}");
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
                _logger.LogError(ex, $"Error on delete Car: {ex}");
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
                _logger.LogError(ex, $"Error on get Car with id: {id}: {ex}");
                return null;
            }
        }
    }
}
