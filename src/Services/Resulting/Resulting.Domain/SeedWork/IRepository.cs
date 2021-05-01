using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resulting.Domain.SeedWork
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Design",
        "CA1040:Avoid empty interfaces",
        Justification = "Marker interface")]
    public interface IRepository<T>
        where T : IAggregateRoot
    {
    }
}
