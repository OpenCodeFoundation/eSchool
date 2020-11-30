using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetEnrollmentsOperation
        : IOperation<IGetEnrollments>
    {
        public string Name => "getEnrollments";

        public IDocument Document => EnrollmentQuery.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetEnrollments);

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            return Array.Empty<VariableValue>();
        }
    }
}
