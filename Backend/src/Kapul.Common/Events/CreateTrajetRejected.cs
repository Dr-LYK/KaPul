using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class CreateTrajetRejected: IRejectedEvent
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public ulong SitsAvailable { get; set; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateTrajetRejected()
        {
        }

        public CreateTrajetRejected(DateTime departureTime, DateTime arrivalTime, double price, ulong sitsAvailable, string reason, string code)
        {
            this.DepartureTime = departureTime;
            this.ArrivalTime = arrivalTime;
            this.Price = price;
            this.SitsAvailable = sitsAvailable;
            this.Reason = reason;
            this.Code = code;
        }
    }
}
