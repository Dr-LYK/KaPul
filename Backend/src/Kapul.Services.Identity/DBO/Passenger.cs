using System;
namespace Kapul.Services.Identity.DBO
{
    public class Passenger
    {
        public Guid PassengerId { get; set; }
        public Guid UserId { get; set; }
        public Guid TripId { get; set; }
        public byte NbSeat { get; set; }
    }
}
