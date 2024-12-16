namespace WebAPI.Data.DTOs
{
    public class FilterOptionsDto
    {
        public IEnumerable<string> EventTypes { get; set; }
        public IEnumerable<string> GeographicDomains { get; set; }
        public IEnumerable<string> RiskMatrixColors { get; set; }
        public IEnumerable<string> Certainties { get; set; }
        public IEnumerable<string> Severities { get; set; }
    }
}