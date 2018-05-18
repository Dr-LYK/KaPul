using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Commands
{
    public class DeleteTrajet: IAuthenticatedCommand
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Departure { get; set; }

        public string Arrival { get; set; }
    }
}
