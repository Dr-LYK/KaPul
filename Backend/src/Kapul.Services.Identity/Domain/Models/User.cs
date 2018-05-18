using System;
using Kapul.Services.Identity.Domain.Services;

namespace Kapul.Services.Identity.Domain.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string FirstName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string IdCard { get; protected set; }
        public string DrivingLicence { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        public User(string name, string firstName, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("User name can not be empty.");
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("User firstname can not be empty.");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("User email can not be empty.");
            }

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.FirstName = firstName;
            this.Email = email.ToLowerInvariant();
            this.IdCard = "";
            this.DrivingLicence = "";
            this.CreationDate = DateTime.Now;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password, Salt));
    }
}
