using WorkerService.Data.Entities;

namespace WorkerService.Data.Repositories
{
    public interface IWeatherAlertRepository
    {
        Task UpsertAlertsAsync(IEnumerable<WeatherAlert> alerts);
    }
}
