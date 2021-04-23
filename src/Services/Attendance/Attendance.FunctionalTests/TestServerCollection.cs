using Xunit;

namespace OpenCodeFoundation.ESchool.Services.Attendance.FunctionalTests
{
    [CollectionDefinition("TestServer")]
    public class TestServerCollection
        : ICollectionFixture<TestServerFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
