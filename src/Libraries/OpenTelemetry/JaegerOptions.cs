using System.Diagnostics.CodeAnalysis;

namespace OpenCodeFoundation.OpenTelemetry
{
    public class JaegerOptions
    {
        [MemberNotNullWhen(true, nameof(ServiceName), nameof(Host))]
        public bool Enabled { get; set; }

        public string? ServiceName { get; set; }

        public string? Host { get; set; }

        public int? Port { get; set; }
    }
}
