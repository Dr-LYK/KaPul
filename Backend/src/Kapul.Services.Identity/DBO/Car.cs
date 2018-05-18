using System;
namespace Kapul.Services.Identity.DBO
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
    }
}
