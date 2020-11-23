using HotChocolate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Graphql
{
    public class GraphQlErrorFilter
        : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(
                error.Exception?.Message ?? string.Empty);
        }
    }
}
