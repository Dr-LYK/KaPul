using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Api.Models
{
    public class Car
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }

    }
}
