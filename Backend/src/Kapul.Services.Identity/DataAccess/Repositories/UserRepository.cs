using System;
using System.Linq;
using System.Threading.Tasks;
using Kapul.Services.Identity.DataAccess.Interfaces;
using Kapul.Services.Identity.DBO;
using Microsoft.Extensions.Logging;

namespace Kapul.Services.Identity.DataAccess.Repositories
{
    public class UserRepository : Interfaces.IUserRepository
    {
        private readonly IdentityContext _context;
        private readonly ILogger _logger;

        public UserRepository(IdentityContext context)
        {
            this._context = context;
        }

        public async Task<User> Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on create User: {ex}");
                return null;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                DBO.User user = await _context.Users.FindAsync(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on delete User: {ex}");
            }
            return false;
        }

        public async Task<User> Get(Guid id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on get User with id: {id}: {ex}");
                return null;
            }        
        }

        public User Get(string email)
        {
            try
            {
                return _context.Users.AsQueryable().FirstOrDefault(x => x.Email == email.ToLowerInvariant());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on get User with id: {email}: {ex}");
                return null;
            }
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on update User");
                return false;
            }        
        }
    }
}
