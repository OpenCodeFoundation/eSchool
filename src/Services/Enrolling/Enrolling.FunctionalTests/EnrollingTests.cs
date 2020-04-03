using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using OpenCodeFoundation.ESchool.Services.Enrolling.API;
using Xunit;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.FunctionalTests
{
    public class EnrollingTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public EnrollingTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory ?? throw new System.ArgumentNullException(nameof(factory));
        }

        [Fact]
        public async Task Get_EndpointsReturnSuccess()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }

    }
}
