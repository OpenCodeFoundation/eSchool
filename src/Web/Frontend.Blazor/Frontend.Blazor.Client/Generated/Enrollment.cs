using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Enrollment
        : IEnrollment
    {
        public Enrollment(
            string name, 
            string emailAddress, 
            string mobileNumber, 
            System.Guid id)
        {
            Name = name;
            EmailAddress = emailAddress;
            MobileNumber = mobileNumber;
            Id = id;
        }

        public string Name { get; }

        public string EmailAddress { get; }

        public string MobileNumber { get; }

        public System.Guid Id { get; }
    }
}
