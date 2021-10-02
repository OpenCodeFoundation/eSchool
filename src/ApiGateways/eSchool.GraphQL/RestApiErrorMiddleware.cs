using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Resolvers;
using OpenCodeFoundation.ESchool.ApiGateways.ESchool.GraphQL.Enrolling;

namespace OpenCodeFoundation.ESchool.ApiGateways.ESchool.GraphQL
{
    public class RestApiErrorMiddleware
    {
        private readonly FieldDelegate _next;

        public RestApiErrorMiddleware(FieldDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(IMiddlewareContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (ApiException<ValidationProblemDetails> exception)
            {
                var errors = exception.Result.Errors;
                foreach (var validationErrors in errors)
                {
                    foreach (var validationError in validationErrors.Value)
                    {
                        context.ReportError(ErrorBuilder
                            .New()
                            .SetMessage(validationError)
                            .SetPath(context.Path)
                            .SetExtension("field", validationErrors.Key)
                            .SetExtension("extra", exception.Result.AdditionalProperties)
                            .Build());
                    }
                }
            }
            catch (ApiException<ProblemDetails> exception)
            {
                context.ReportError(ErrorBuilder
                    .New()
                    .SetMessage(exception.Result.Title ?? string.Empty)
                    .SetPath(context.Path)
                    .SetExtension("extra", exception.Result.AdditionalProperties)
                    .Build());
            }
        }
    }
}
