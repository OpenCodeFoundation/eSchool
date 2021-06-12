using System.Threading.Tasks;
using Xunit;

namespace OpenCodeFoundation.ESchool.Services.Attending.FunctionalTests
{
    [Collection("TestServer")]
    public class AttendanceTests
    {
        private readonly TestServerFixture _testServer;

        public AttendanceTests(TestServerFixture testServer)
        {
            _testServer = testServer ?? throw new System.ArgumentNullException(nameof(testServer));
        }

        [Fact]
        public async Task Get_all_attending_ok_status_code()
        {
            var response = await _testServer.Client.GetAsync("/Attendances");

            response.EnsureSuccessStatusCode();
        }
    }
}
