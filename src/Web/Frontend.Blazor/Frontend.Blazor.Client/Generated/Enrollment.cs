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
            System.Guid id, 
            string name, 
            string emailAddress, 
            string mobileNumber)
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddress;
            MobileNumber = mobileNumber;
        }

        public System.Guid Id { get; }

        public string Name { get; }

        public string EmailAddress { get; }

        public string MobileNumber { get; }
    }
}
