namespace WorkerService.Data.Entities
{
    public class WeatherAlert
    {
        public string Id { get; set; }
        public string Area { get; set; } = string.Empty;  // Default value to avoid null
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Event { get; set; } = string.Empty;
        public string GeographicDomain { get; set; } = string.Empty;
        public string RiskMatrixColor { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string Certainty { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;
        public string Consequences { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? EventStartingTime { get; set; }
        public DateTime? EventEndingTime { get; set; }
    }
}

