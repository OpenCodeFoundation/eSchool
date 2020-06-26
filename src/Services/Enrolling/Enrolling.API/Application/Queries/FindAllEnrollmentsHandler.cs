using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Queries
{
    public class FindAllEnrollmentsHandler
        : IRequestHandler<FindAllEnrollmentsQuery, IEnumerable<Enrollment>>
    {
        private readonly EnrollingContext _context;

        public FindAllEnrollmentsHandler(EnrollingContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Enrollment>> Handle(FindAllEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Enrollments.ToListAsync();
        }
    }
}
