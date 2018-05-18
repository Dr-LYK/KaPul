﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Events
{
    public class CarCreated : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Model { get; }
        public string Color { get; }
        public string PlateNumber { get; }
        public DateTime CreatedAt { get; }

        protected CarCreated()
        {
        }

        public CarCreated(Guid Id, Guid UserId, string Model, string Color, string PlateNumber)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.Model = Model;
            this.Color = Color;
            this.PlateNumber = PlateNumber;
        }
    }
}
