using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Commands
{
    public class BookTrajet: IAuthenticatedCommand
    {
        public CreateTrajet TrajetCreated { get; set; }
        public Guid UserId { get; set; }
        public ulong SeatNumber { get; set; }
        public DateTime BookDate { get; set; }
    }
}
