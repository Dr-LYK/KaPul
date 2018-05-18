using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class BookTrajetRejected: IRejectedEvent
    {
        public Guid TrajetId { get; set; }
        public ulong SeatRequested { get; set; }
        public ulong SeatAvailable { get; set; }
        public string Reason { get; }
        public string Code { get; }

        protected BookTrajetRejected()
        {
        }

        public BookTrajetRejected(Guid id, ulong seatRequested, ulong seatAvailable, string reason, string code)
        {
            this.TrajetId = id;
            this.SeatRequested = seatRequested;
            this.SeatAvailable = SeatAvailable;
            this.Reason = reason;
            this.Code = code;
        }
    }
}
