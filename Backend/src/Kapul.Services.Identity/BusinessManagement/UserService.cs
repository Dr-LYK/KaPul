using System;
using System.Threading.Tasks;
using Kapul.Common.Commands;
using Kapul.Services.Identity.DBO;

namespace Kapul.Services.Identity.BusinessManagement
{
    public class UserService : Interfaces.IUserService
    {
        private readonly DataAccess.Interfaces.IUserRepository _userRepository;

        public UserService(DataAccess.Interfaces.IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(CreateUser command)
        {
            User user = new User
            {
                Id = command.Id,
                Name = command.Name,
                FirstName = command.FirstName,
                Email = command.Email,
                Password = command.Password,
                IdCard = command.IdCard,
                DrivingLicence = command.DrivingLicence,
                RegistrationDate = command.RegistrationDate
            };
            return await _userRepository.Create(user);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<bool> UpdateAsync(UpdateUser command)
        {
            User user = new User
            {
                Id = command.Id,
                Name = command.Name,
                FirstName = command.FirstName,
                Email = command.Email,
                Password = command.Password,
                IdCard = command.IdCard,
                DrivingLicence = command.DrivingLicence,
                RegistrationDate = command.RegistrationDate
            };
            return await _userRepository.Update(user);
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            User user = _userRepository.Get(email);
            if (user == null)
            {
                throw new Exception("Invalid credentials.");
            }
            if (!user.Password.Equals(password))
            {
                throw new Exception("Invalid credentials.");
            }

            return await _userRepository.Create(user);
        }
    }
}
