using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resulting.Domain.SeedWork;

namespace Resulting.Domain.AggregateModel.ResultingAggregate
{
    public class Results : Entity, IAggregateRoot
    {
        public Results(
            string Result,
            string GradeScale,
            string Grade)
        {
            Result = !string.IsNullOrWhiteSpace(Result) ? Result
                : throw new ArgumentNullException(nameof(Result));
            GradeScale = !string.IsNullOrWhiteSpace(GradeScale) ? GradeScale
                : throw new ArgumentNullException(nameof(GradeScale));
            Grade = !string.IsNullOrWhiteSpace(Grade) ? Grade
                : throw new ArgumentNullException(nameof(Grade));
        }

        public string Result { get; private set; }

        public string GradeScale { get; private set; }

        public string Grade { get; private set; }

        public int Number { get; private set; }
    }
}
