using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure.Configuration.ValueConverters
{
    public class EnrollmentIdValueConverter
        : ValueConverter<EnrollmentId, Guid>
    {
        public EnrollmentIdValueConverter()
            : base(e => e.Value, value => EnrollmentId.FromGuid(value))
        {
        }
    }
}
