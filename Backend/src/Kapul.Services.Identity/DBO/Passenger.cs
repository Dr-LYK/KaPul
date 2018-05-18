using System;
namespace Kapul.Services.Identity.DBO
{
    public class Passenger
    {
        public long PassengerId { get; set; }
        public long UserId { get; set; }
        public Guid ProjectId { get; set; }
        public byte NbSeat { get; set; }
    }
}
