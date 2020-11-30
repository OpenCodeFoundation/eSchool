using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class RegisterStudentOperation
        : IOperation<IRegisterStudent>
    {
        public string Name => "registerStudent";

        public IDocument Document => EnrollmentQuery.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(IRegisterStudent);

        public Optional<string> FullName { get; set; }

        public Optional<string> Email { get; set; }

        public Optional<string> Mobile { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (FullName.HasValue)
            {
                variables.Add(new VariableValue("fullName", "String", FullName.Value));
            }

            if (Email.HasValue)
            {
                variables.Add(new VariableValue("email", "String", Email.Value));
            }

            if (Mobile.HasValue)
            {
                variables.Add(new VariableValue("mobile", "String", Mobile.Value));
            }

            return variables;
        }
    }
}
