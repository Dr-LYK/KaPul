using Kapul.Common.Commands;
using Kapul.Services.Trajet.Domain.Repositories;
using Kapul.Services.Trajet.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kapul.Services.Trajet.Tests.Unit.Services
{
    public class TrajetsServiceTests
    {
        [Fact]
        public async Task trajets_service_add_async_should_succeed()
        {
            var trajetRespositoryMock = new Mock<ITrajetRepository>();
            var trajetService = new TrajetService(trajetRespositoryMock.Object);

            CreateTrajet command = new CreateTrajet {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Departure = "Paris",
                DepartureTime = DateTime.Today,
                Arrival = "London",
                ArrivalTime = DateTime.Today,
                Price = 12,
                SitsAvailable = 3
            };
            await trajetService.AddAsync(command);
            trajetRespositoryMock.Verify(x => x.AddTrajet(It.IsAny<Domain.Models.Trajet>()));
        }
    }
}
