using System;
using HotChocolate;

namespace OpenCodeFoundation.ESchool.Services.Attending.API.Graphql
{
    public class GraphQlErrorFilter
        : IErrorFilter
    {
        public IError OnError(IError error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            return error.WithMessage(
                error.Exception?.Message ?? string.Empty);
        }
    }
}
