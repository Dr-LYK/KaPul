using System;
namespace Kapul.Services.Identity.DBO
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid User_Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Registration { get; set; }
    }
}
