using System.Threading.Tasks;

namespace Attendance.SharedKernel.Interfaces
{
    public interface ICommandHandler<TCommand, TResponse>
    {
        TResponse Handle(TCommand command);
        Task<TResponse> HandleAsync(TCommand command);
    }
}
