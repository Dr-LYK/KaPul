﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kapul.Services.Trajet.Domain.Models
{
    public class Trajet
    {
        public Guid Id { get; protected set; }

        public Guid UserId { get; protected set; }

        public string Departure { get; protected set; }

        public DateTime DepartureTime { get; protected set; }

        public string Arrival { get; protected set; }

        public double Price { get; protected set; }

        public long SitsAvailable { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected Trajet()
        {
        }

        public Trajet(string departure)
        {
            Departure = departure;
        }

        public Trajet(Guid userId, string departure, DateTime departureTime, string arrival, double price, long sitsAvailable)
        {
            /*if (string.IsNullOrWhiteSpace(departure) || string.IsNullOrWhiteSpace(arrival))
            {
                throw new Exception("wrong trajet");
            }*/

            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UserId = userId;
            Departure = departure.ToLowerInvariant();
            DepartureTime = departureTime;
            Arrival = arrival.ToLowerInvariant();
            Price = price;
            SitsAvailable = sitsAvailable;
        }
    }
}
