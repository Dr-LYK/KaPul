using System;
namespace Kapul.Common.Events
{
    public class UserGot
    {
        public Guid Id { get; }
        public string Name { get; }
        public string FirstName { get; }
        public string Email { get; }
        public string Password { get; }
        public string IdCard { get; }
        public string DrivingLicence { get; }
        public DateTime RegistrationDate { get; }

        protected UserGot()
        {
        }

        public UserGot(Guid Id, string Name, string FirstName, string Email, string Password, string IdCard, string DrivingLicence, DateTime RegistrationDate)
        {
            this.Id = Id;
            this.Name = Name;
            this.FirstName = FirstName;
            this.Email = Email;
            this.Password = Password;
            this.IdCard = IdCard;
            this.DrivingLicence = DrivingLicence;
            this.RegistrationDate = RegistrationDate;
        }
    }
}
