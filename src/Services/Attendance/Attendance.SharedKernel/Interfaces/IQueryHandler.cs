using System.Threading.Tasks;

namespace Attendance.SharedKernel.Interfaces
{
    public interface IQueryHandler<TQuery, TQueryResponse>
    {
        TQueryResponse Handle(TQuery query);
        Task<TQueryResponse> HandleAsync(TQuery query);
    }
}
