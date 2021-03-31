namespace OpenCodeFoundation.OpenTelemetry
{
    public class JaegerOptions
    {
        public bool Enabled { get; set; }

        public string? ServiceName { get; set; }

        public string? Host { get; set; }

        public int? Port { get; set; }
    }
}
