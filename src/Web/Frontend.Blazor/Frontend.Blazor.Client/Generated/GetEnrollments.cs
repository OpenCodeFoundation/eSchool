using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetEnrollments
        : IGetEnrollments
    {
        public GetEnrollments(
            global::System.Collections.Generic.IReadOnlyList<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IEnrollment> enrollments)
        {
            Enrollments = enrollments;
        }

        public global::System.Collections.Generic.IReadOnlyList<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IEnrollment> Enrollments { get; }
    }
}
