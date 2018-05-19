using System;
using System.Threading.Tasks;

namespace Kapul.Services.Identity.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<DBO.User> Create(DBO.User user);
        Task<DBO.User> Get(Guid id);
        DBO.User Get(string email);
        Task<bool> Update(DBO.User user);
        Task<bool> Delete(Guid id);
    }
}
