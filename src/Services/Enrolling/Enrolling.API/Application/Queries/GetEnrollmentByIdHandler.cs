using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Queries
{
    public class GetEnrollmentByIdHandler
        : IRequestHandler<GetEnrollmentByIdQuery, Enrollment?>
    {
        private readonly IEnrollmentRepository _repository;

        public GetEnrollmentByIdHandler(IEnrollmentRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Enrollment?> Handle(
            GetEnrollmentByIdQuery query,
            CancellationToken cancellationToken)
        {
            return await _repository.FindByIdAsync(query.Id);
        }
    }
}
