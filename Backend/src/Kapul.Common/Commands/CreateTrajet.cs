using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Commands
{
    public class CreateTrajet : IAuthenticatedCommand
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Departure { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Arrival { get; set; }

        public double Price { get; set; }

        public long SitsAvailable { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
