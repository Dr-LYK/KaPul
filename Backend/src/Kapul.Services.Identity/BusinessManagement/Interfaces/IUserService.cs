using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;

namespace Kapul.Services.Identity.BusinessManagement.Interfaces
{
    public interface IUserService
    {
        Task<DBO.User> CreateAsync(CreateUser command);
        Task<DBO.User> GetAsync(Guid id);
        Task<bool> UpdateAsync(UpdateUser command);
        Task<bool> DeleteAsync(Guid id);
        Task<DBO.User> AuthenticateAsync(string email, string password);
    }
}
