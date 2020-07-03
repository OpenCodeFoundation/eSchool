using System;
using System.Threading.Tasks;
using Attendance.SharedKernel.Interfaces;

namespace Attendance.SharedKernel
{
    public class QueryHandler
    {
        private readonly IServiceProvider _serviceProvider;
        public QueryHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TQueryResponse> SubmitAsync<TQuery, TQueryResponse>(TQuery query)
        {
            var queryHandler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TQueryResponse>)) as IQueryHandler<TQuery, TQueryResponse>;

            return queryHandler.HandleAsync(query);
        }

        public TQueryResponse Submit<TQuery, TQueryResponse>(TQuery query)
        {
            var queryHandler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TQueryResponse>)) as IQueryHandler<TQuery, TQueryResponse>;

            return queryHandler.Handle(query);
        }
    }
}
