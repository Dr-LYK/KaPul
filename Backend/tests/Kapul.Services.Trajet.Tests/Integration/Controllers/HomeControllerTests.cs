using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Kapul.Services.Trajet.Tests.Integration.Controllers
{
    class HomeControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HomeControllerTests()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Api.Startup>());
            _client = _server.CreateClient();
        }


        [Fact]
        public async Task home_controller_get_should_result_String_content()
        {
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            content.Should().BeEquivalentTo("Kapul API");
        }
    }
}
