using FluentAssertions;
using Kapul.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Kapul.Api.Tests.Unit.Controller
{
    public class HomeControllerTests
    {
        [Fact]
        public void Home_controller_get_should_return_string_content()
        {
            HomeController controller = new HomeController();
            IActionResult result = controller.Get();
            ContentResult contentResult = result as ContentResult;
            contentResult.Should().NotBeNull();
            contentResult.Content.ShouldAllBeEquivalentTo("Kapul API");
        }
    }
}
