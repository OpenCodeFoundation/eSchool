﻿using System;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate
{
    [StronglyTypedId(typeof(Guid))]
    public partial struct EnrollmentId
    {
        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
