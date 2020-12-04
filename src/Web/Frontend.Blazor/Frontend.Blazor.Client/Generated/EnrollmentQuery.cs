﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class EnrollmentQuery
        : global::StrawberryShake.IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            48,
            55,
            48,
            100,
            55,
            50,
            49,
            52,
            49,
            102,
            49,
            52,
            101,
            97,
            102,
            98,
            100,
            56,
            49,
            57,
            54,
            57,
            52,
            100,
            55,
            57,
            50,
            97,
            52,
            102,
            55,
            101
        };
        private readonly byte[] _content = new byte[]
        {
            113,
            117,
            101,
            114,
            121,
            32,
            103,
            101,
            116,
            69,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            115,
            32,
            123,
            32,
            101,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            46,
            46,
            46,
            32,
            101,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            32,
            125,
            32,
            125,
            32,
            109,
            117,
            116,
            97,
            116,
            105,
            111,
            110,
            32,
            114,
            101,
            103,
            105,
            115,
            116,
            101,
            114,
            83,
            116,
            117,
            100,
            101,
            110,
            116,
            40,
            36,
            102,
            117,
            108,
            108,
            78,
            97,
            109,
            101,
            58,
            32,
            83,
            116,
            114,
            105,
            110,
            103,
            33,
            44,
            32,
            36,
            101,
            109,
            97,
            105,
            108,
            58,
            32,
            83,
            116,
            114,
            105,
            110,
            103,
            33,
            44,
            32,
            36,
            109,
            111,
            98,
            105,
            108,
            101,
            58,
            32,
            83,
            116,
            114,
            105,
            110,
            103,
            33,
            41,
            32,
            123,
            32,
            97,
            100,
            100,
            69,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            40,
            105,
            110,
            112,
            117,
            116,
            58,
            32,
            123,
            32,
            110,
            97,
            109,
            101,
            58,
            32,
            36,
            102,
            117,
            108,
            108,
            78,
            97,
            109,
            101,
            44,
            32,
            101,
            109,
            97,
            105,
            108,
            58,
            32,
            36,
            101,
            109,
            97,
            105,
            108,
            44,
            32,
            109,
            111,
            98,
            105,
            108,
            101,
            58,
            32,
            36,
            109,
            111,
            98,
            105,
            108,
            101,
            32,
            125,
            41,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            46,
            46,
            46,
            32,
            101,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            73,
            100,
            32,
            125,
            32,
            125,
            32,
            102,
            114,
            97,
            103,
            109,
            101,
            110,
            116,
            32,
            101,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            32,
            111,
            110,
            32,
            69,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            46,
            46,
            46,
            32,
            101,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            73,
            100,
            32,
            110,
            97,
            109,
            101,
            32,
            101,
            109,
            97,
            105,
            108,
            65,
            100,
            100,
            114,
            101,
            115,
            115,
            32,
            109,
            111,
            98,
            105,
            108,
            101,
            78,
            117,
            109,
            98,
            101,
            114,
            32,
            125,
            32,
            102,
            114,
            97,
            103,
            109,
            101,
            110,
            116,
            32,
            101,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            73,
            100,
            32,
            111,
            110,
            32,
            69,
            110,
            114,
            111,
            108,
            108,
            109,
            101,
            110,
            116,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            105,
            100,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static EnrollmentQuery Default { get; } = new EnrollmentQuery();

        public override string ToString() => 
            @"query getEnrollments {
              enrollments {
                ... enrollment
              }
            }
            
            mutation registerStudent($fullName: String!, $email: String!, $mobile: String!) {
              addEnrollment(input: { name: $fullName, email: $email, mobile: $mobile }) {
                ... enrollmentId
              }
            }
            
            fragment enrollment on Enrollment {
              ... enrollmentId
              name
              emailAddress
              mobileNumber
            }
            
            fragment enrollmentId on Enrollment {
              id
            }";
    }
}
