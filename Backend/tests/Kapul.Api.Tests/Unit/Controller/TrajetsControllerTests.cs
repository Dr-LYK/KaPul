using FluentAssertions;
using Kapul.Api.Controllers;
using Kapul.Api.ModelBinding;
using Kapul.Api.Repositories;
using Kapul.Common.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kapul.Api.Tests.Unit.Controller
{
    public class TrajetsControllerTests
    {
        [Fact]
        public async Task trajet_controller_post_should_result_accepted()
        {
            var busClientMock = new Mock<IBusClient>();
            var trajetRespositoryMock = new Mock<ITrajetRepository>();
            TripsController controller = new TripsController(busClientMock.Object, trajetRespositoryMock.Object);
            Guid userId = Guid.NewGuid();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userId.ToString()) }, "test"))
                }
            };
            TripsBinding command = new TripsBinding
            {
                Id = Guid.NewGuid(),
                User_id = userId
            };
            var result = await controller.Post(command);
            var contentResult = result as AcceptedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo($"trips/{command.Id}");
        }
    }
}
