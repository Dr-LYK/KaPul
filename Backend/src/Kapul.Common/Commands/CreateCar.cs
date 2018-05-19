using System;

namespace Kapul.Common.Commands
{
    public class CreateCar : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Registration { get; set; }

        public Guid UserId { get; set; }
    }
}
