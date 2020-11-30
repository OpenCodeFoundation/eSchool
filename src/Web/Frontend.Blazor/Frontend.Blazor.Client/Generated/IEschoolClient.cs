using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial interface IEschoolClient
    {
        Task<IOperationResult<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IGetEnrollments>> GetEnrollmentsAsync(
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IGetEnrollments>> GetEnrollmentsAsync(
            GetEnrollmentsOperation operation,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IRegisterStudent>> RegisterStudentAsync(
            Optional<string> fullName = default,
            Optional<string> email = default,
            Optional<string> mobile = default,
            CancellationToken cancellationToken = default);

        Task<IOperationResult<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IRegisterStudent>> RegisterStudentAsync(
            RegisterStudentOperation operation,
            CancellationToken cancellationToken = default);
    }
}
