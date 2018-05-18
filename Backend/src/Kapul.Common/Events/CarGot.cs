using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class CarGot : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Model { get; }
        public string Color { get; }
        public string PlateNumber { get; }

        protected CarGot()
        {
        }

        public CarGot(Guid Id, Guid UserId, string Model, string Color, string PlateNumber)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.Model = Model;
            this.Color = Color;
            this.PlateNumber = PlateNumber;
        }
    }
}
