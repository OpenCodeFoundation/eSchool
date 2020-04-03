using System.Threading.Tasks;
using Xunit;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.FunctionalTests
{
    [Collection("TestServer")]
    public class EnrollingTests
    {
        private readonly TestServerFixture _testServer;

        public EnrollingTests(TestServerFixture testServer)
        {
            _testServer = testServer ?? throw new System.ArgumentNullException(nameof(testServer));
        }

        [Fact]
        public async Task Get_all_enrolling_ok_status_code()
        {
            var response = await _testServer.Client.GetAsync("/");

            response.EnsureSuccessStatusCode();
        }
    }
}
