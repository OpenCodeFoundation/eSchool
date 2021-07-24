using System;
using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure.Configuration.ValueConverters
{
    public static class ModelConfigurationBuilderExtensions
    {
        public static ModelConfigurationBuilder AddStronglyTypedIds(
            this ModelConfigurationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Properties<EnrollmentId>()
                .HaveConversion(typeof(EnrollmentIdValueConverter), null);
            return builder;
        }
    }
}
