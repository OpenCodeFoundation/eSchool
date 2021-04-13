using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace CourseRegistration.API.GraphQL
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
