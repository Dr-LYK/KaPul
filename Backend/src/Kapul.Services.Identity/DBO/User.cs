using System;
namespace Kapul.Services.Identity.DBO
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdCard { get; set; }
        public string DrivingLicence { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
