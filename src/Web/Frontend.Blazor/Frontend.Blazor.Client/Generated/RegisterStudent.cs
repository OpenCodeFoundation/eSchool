using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class RegisterStudent
        : IRegisterStudent
    {
        public RegisterStudent(
            global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IEnrollmentId addEnrollment)
        {
            AddEnrollment = addEnrollment;
        }

        public global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IEnrollmentId AddEnrollment { get; }
    }
}
