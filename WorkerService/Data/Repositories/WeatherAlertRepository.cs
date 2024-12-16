using Microsoft.EntityFrameworkCore;
using WorkerService.Data.Entities;

namespace WorkerService.Data.Repositories
{
    public class WeatherAlertRepository : IWeatherAlertRepository
    {
        private readonly AppDbContext _context;

        public WeatherAlertRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task UpsertAlertsAsync(IEnumerable<WeatherAlert> alerts)
        {
            foreach (var alert in alerts)
            {
                var existing = await _context.WeatherAlerts
                    .FirstOrDefaultAsync(x => x.Id == alert.Id);

                if (existing != null)
                {
                    // Update existing alert
                    existing.Certainty = alert.Certainty;
                    existing.Consequences = alert.Consequences;
                    existing.Event = alert.Event;
                    existing.GeographicDomain = alert.GeographicDomain;
                    existing.Instruction = alert.Instruction;
                    existing.RiskMatrixColor = alert.RiskMatrixColor;
                    existing.Severity = alert.Severity;
                    existing.Status = alert.Status;
                    existing.EventStartingTime = alert.EventStartingTime;
                    existing.EventEndingTime = alert.EventEndingTime;
                    existing.Title = alert.Title;
                    existing.Description = alert.Description;
                }
                else
                {
                    // Insert new
                    await _context.WeatherAlerts.AddAsync(alert);
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
