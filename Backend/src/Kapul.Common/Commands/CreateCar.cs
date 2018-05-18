using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Commands
{
    public class CreateCar : IAuthenticatedCommand
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }

        public Guid UserId { get; set; }
    }
}
