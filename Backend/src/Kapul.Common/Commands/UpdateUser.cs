using System;
namespace Kapul.Common.Commands
{
    public class UpdateUser : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdCard { get; set; }
        public string DrivingLicence { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
