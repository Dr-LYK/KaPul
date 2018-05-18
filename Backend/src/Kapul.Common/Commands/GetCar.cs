using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Commands
{
    class GetCar : IAuthenticatedCommand
    {
        public Guid Id { get; }
        public Guid UserId { get; set; }
    }
}
