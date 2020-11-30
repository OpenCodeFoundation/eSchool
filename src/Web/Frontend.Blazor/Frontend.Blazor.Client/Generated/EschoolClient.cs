using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawberryShake;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class EschoolClient
        : IEschoolClient
    {
        private const string _clientName = "EschoolClient";

        private readonly global::StrawberryShake.IOperationExecutor _executor;

        public EschoolClient(global::StrawberryShake.IOperationExecutorPool executorPool)
        {
            _executor = executorPool.CreateExecutor(_clientName);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IGetEnrollments>> GetEnrollmentsAsync(
            global::System.Threading.CancellationToken cancellationToken = default)
        {

            return _executor.ExecuteAsync(
                new GetEnrollmentsOperation(),
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IGetEnrollments>> GetEnrollmentsAsync(
            GetEnrollmentsOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IRegisterStudent>> RegisterStudentAsync(
            global::StrawberryShake.Optional<string> fullName = default,
            global::StrawberryShake.Optional<string> email = default,
            global::StrawberryShake.Optional<string> mobile = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (fullName.HasValue && fullName.Value is null)
            {
                throw new ArgumentNullException(nameof(fullName));
            }

            if (email.HasValue && email.Value is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (mobile.HasValue && mobile.Value is null)
            {
                throw new ArgumentNullException(nameof(mobile));
            }

            return _executor.ExecuteAsync(
                new RegisterStudentOperation
                {
                    FullName = fullName, 
                    Email = email, 
                    Mobile = mobile
                },
                cancellationToken);
        }

        public global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IRegisterStudent>> RegisterStudentAsync(
            RegisterStudentOperation operation,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            if (operation is null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return _executor.ExecuteAsync(operation, cancellationToken);
        }
    }
}
