using FluentAssertions;
using Kapul.Api.Controllers;
using Kapul.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RawRabbit;
using Xunit;

namespace Kapul.Api.Tests.Unit.Controller
{
    public class HomeControllerTests
    {
        [Fact]
        public void Home_controller_get_should_return_string_content()
        {
            var clientMock = new Mock<IBusClient>();
            var trajetRespositoryMock = new Mock<ITrajetRepository>();
            HomeController controller = new HomeController(clientMock.Object, trajetRespositoryMock.Object);
            IActionResult result = controller.Get();
            ContentResult contentResult = result as ContentResult;
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().BeEquivalentTo("Kapul API");
        }
    }
}
