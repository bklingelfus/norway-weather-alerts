using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Interfaces;
using WebAPI.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data.Repositories
{
    public class WeatherAlertRepository : IWeatherAlertRepository
    {
        private readonly ApplicationDbContext _context;

        public WeatherAlertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherAlert>> GetWeatherAlertsAsync(string eventType, string geographicDomain, string riskMatrixColor, string certainty, string severity)
        {
            IQueryable<WeatherAlert> query = _context.WeatherAlerts;

            // Normalize inputs to handle case-insensitivity and extra spaces
            eventType = string.IsNullOrWhiteSpace(eventType) ? string.Empty : string.Join(" ", eventType.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToLower();
            geographicDomain = string.IsNullOrWhiteSpace(geographicDomain) ? string.Empty : string.Join(" ", geographicDomain.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToLower();
            riskMatrixColor = string.IsNullOrWhiteSpace(riskMatrixColor) ? string.Empty : string.Join(" ", riskMatrixColor.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToLower();
            certainty = string.IsNullOrWhiteSpace(certainty) ? string.Empty : string.Join(" ", certainty.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToLower();
            severity = string.IsNullOrWhiteSpace(severity) ? string.Empty : string.Join(" ", severity.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToLower();

            if (!string.IsNullOrEmpty(eventType))
                query = query.Where(x => x.Event.ToLower().Contains(eventType));
            if (!string.IsNullOrEmpty(geographicDomain))
                query = query.Where(x => x.GeographicDomain.ToLower().Contains(geographicDomain));
            if (!string.IsNullOrEmpty(riskMatrixColor))
                query = query.Where(x => x.RiskMatrixColor.ToLower().Contains(riskMatrixColor));
            if (!string.IsNullOrEmpty(certainty))
                query = query.Where(x => x.Certainty.ToLower().Contains(certainty));
            if (!string.IsNullOrEmpty(severity))
                query = query.Where(x => x.Severity.ToLower().Contains(severity));

            return await query.ToListAsync();
        }

        // Methods to get distinct values for each filter column
        public async Task<IEnumerable<string>> GetDistinctEventTypesAsync()
        {
            return await _context.WeatherAlerts
                .Select(w => w.Event)
                .Distinct()
                .OrderBy(e => e)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctGeographicDomainsAsync()
        {
            return await _context.WeatherAlerts
                .Select(w => w.GeographicDomain)
                .Distinct()
                .OrderBy(g => g)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctRiskMatrixColorsAsync()
        {
            return await _context.WeatherAlerts
                .Select(w => w.RiskMatrixColor)
                .Distinct()
                .OrderBy(r => r)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctCertaintiesAsync()
        {
            return await _context.WeatherAlerts
                .Select(w => w.Certainty)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetDistinctSeveritiesAsync()
        {
            return await _context.WeatherAlerts
                .Select(w => w.Severity)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();
        }
    }
}
