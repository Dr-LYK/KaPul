using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    class CarGot : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Model { get; }
        public string Color { get; }
        public string PlateNumber { get; }
        public DateTime CreatedAt { get; }

        protected CarGot()
        {
        }

        public CarGot(long Id, Guid UserId, string Model, string Color, string PlateNumber,DateTime CreatedAt)
        {
            this.Id = new Guid(Id.ToString());
            this.UserId = UserId;
            this.Model = Model;
            this.Color = Color;
            this.PlateNumber = PlateNumber;
        }
    }
}
