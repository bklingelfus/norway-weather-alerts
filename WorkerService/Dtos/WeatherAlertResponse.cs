using System.Text.Json.Serialization;

namespace WorkerService.Dtos
{
        public class WeatherAlertResponse
    {
        [JsonPropertyName("features")]
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        [JsonPropertyName("properties")]
        public FeatureProperties Properties { get; set; }

        [JsonPropertyName("when")]
        public When When { get; set; }
    }

    public class FeatureProperties
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("certainty")]
        public string Certainty { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("area")]
        public string Area { get; set; }

        [JsonPropertyName("consequences")]
        public string Consequences { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("geographicDomain")]
        public string GeographicDomain { get; set; }

        [JsonPropertyName("instruction")]
        public string Instruction { get; set; }

        [JsonPropertyName("riskMatrixColor")]
        public string RiskMatrixColor { get; set; }

        [JsonPropertyName("severity")]
        public string Severity { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class When
    {
        [JsonPropertyName("interval")]
        public string[] Interval { get; set; }
    }
}