using System;

namespace OpenCodeFoundation.OpenTelemetry
{
    public class OpenTelemetryOptions
        : IConfigurationOptions
    {
        public bool Enabled { get; set; }

        public bool AlwaysOnSampler { get; set; } = true;

        public bool Istio { get; set; }

        public JaegerOptions Jaeger { get; set; } = new ();

        public void Validate()
        {
            if (Jaeger.Enabled)
            {
                ValidateJaeger();
            }
        }

        private void ValidateJaeger()
        {
            if (string.IsNullOrWhiteSpace(Jaeger.ServiceName))
            {
                throw new ArgumentException("Jaeger service name can not be null if Jaeger is enabled");
            }

            if (string.IsNullOrWhiteSpace(Jaeger.Host))
            {
                throw new ArgumentException("Jaeger Host can not be null if Jaeger is enabled");
            }
        }
    }
}
