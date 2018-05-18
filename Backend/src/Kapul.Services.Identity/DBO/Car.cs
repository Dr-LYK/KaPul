using System;
namespace Kapul.Services.Identity.DBO
{
    public class Car
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
    }
}
