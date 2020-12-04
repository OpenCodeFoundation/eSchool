using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class RegisterStudentResultParser
        : JsonResultParserBase<IRegisterStudent>
    {
        private readonly IValueSerializer _uuidSerializer;

        public RegisterStudentResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _uuidSerializer = serializerResolver.Get("Uuid");
        }

        protected override IRegisterStudent ParserData(JsonElement data)
        {
            return new RegisterStudent
            (
                ParseRegisterStudentAddEnrollment(data, "addEnrollment")
            );

        }

        private global::OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client.IEnrollmentId ParseRegisterStudentAddEnrollment(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new EnrollmentId
            (
                DeserializeUuid(obj, "id")
            );
        }

        private System.Guid DeserializeUuid(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.Guid)_uuidSerializer.Deserialize(value.GetString());
        }
    }
}
