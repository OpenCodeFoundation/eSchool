namespace OpenCodeFoundation.ESchool.Services.Attending.Domain.SeedWork
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1040:Avoid empty interfaces",
        Justification = "Marker interface")]
    public interface IRepository<T>
        where T : IAggregateRoot
    {
    }
}
