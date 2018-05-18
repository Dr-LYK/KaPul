using System;
using System.Threading.Tasks;
using Kapul.Services.Identity.Domain.Models;

namespace Kapul.Services.Identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
    }
}
