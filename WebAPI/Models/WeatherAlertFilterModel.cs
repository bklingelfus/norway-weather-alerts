namespace WebAPI.Models
{
    public class WeatherAlertFilterModel
    {
        public string Event { get; set; }
        public string GeographicDomain { get; set; }
        public string RiskMatrixColor { get; set; }
        public string Certainty { get; set; }
        public string Severity { get; set; }
    }
}
