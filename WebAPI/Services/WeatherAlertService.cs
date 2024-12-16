using WebAPI.Data.Interfaces;
using WebAPI.Data.Entities;
using WebAPI.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public class WeatherAlertService
    {
        private readonly IWeatherAlertRepository _repository;

        public WeatherAlertService(IWeatherAlertRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WeatherAlert>> GetWeatherAlertsAsync(string eventType, string geographicDomain, string riskMatrixColor, string certainty, string severity)
        {
            return await _repository.GetWeatherAlertsAsync(eventType, geographicDomain, riskMatrixColor, certainty, severity);
        }


        // New method to get unique filter options
        public async Task<FilterOptionsDto> GetFilterOptionsAsync()
        {
            var eventTypes = await _repository.GetDistinctEventTypesAsync();
            var geographicDomains = await _repository.GetDistinctGeographicDomainsAsync();
            var riskMatrixColors = await _repository.GetDistinctRiskMatrixColorsAsync();
            var certainties = await _repository.GetDistinctCertaintiesAsync();
            var severities = await _repository.GetDistinctSeveritiesAsync();

            return new FilterOptionsDto
            {
                EventTypes = eventTypes,
                GeographicDomains = geographicDomains,
                RiskMatrixColors = riskMatrixColors,
                Certainties = certainties,
                Severities = severities
            };
        }
    }
}
