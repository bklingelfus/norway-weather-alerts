using WebAPI.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Data.Interfaces
{
    public interface IWeatherAlertRepository
    {
        Task<IEnumerable<WeatherAlert>> GetWeatherAlertsAsync(string eventType, string geographicDomain, string riskMatrixColor, string certainty, string severity);
    
        // Methods for getting distinct values for each column
        Task<IEnumerable<string>> GetDistinctEventTypesAsync();
        Task<IEnumerable<string>> GetDistinctGeographicDomainsAsync();
        Task<IEnumerable<string>> GetDistinctRiskMatrixColorsAsync();
        Task<IEnumerable<string>> GetDistinctCertaintiesAsync();
        Task<IEnumerable<string>> GetDistinctSeveritiesAsync();
    }
}
