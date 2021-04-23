using System.Threading.Tasks;
using Xunit;

namespace OpenCodeFoundation.ESchool.Services.Attendance.FunctionalTests
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
        public async Task Get_all_enrolling_ok_status_code()
        {
            var response = await _testServer.Client.GetAsync("/Enrollments");

            response.EnsureSuccessStatusCode();
        }
    }
}
