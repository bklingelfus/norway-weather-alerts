using Hangfire;
using WorkerService.Data.Entities;
using WorkerService.Data.Repositories;
using WorkerService.Dtos;

public class Worker : BackgroundService
{
    private readonly IRecurringJobManager _jobManager;
    private readonly IServiceProvider _serviceProvider;

    public Worker(IRecurringJobManager jobManager, IServiceProvider serviceProvider)
    {
        _jobManager = jobManager;
        _serviceProvider = serviceProvider;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Schedule the job
        _jobManager.AddOrUpdate("FetchWeatherAlerts", () => FetchWeatherAlerts(), Cron.Hourly);
        return Task.CompletedTask;
    }

    public async Task FetchWeatherAlerts()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var repository = scope.ServiceProvider.GetRequiredService<IWeatherAlertRepository>();

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.met.no/weatherapi/metalerts/2.0/current.json");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();                
                var alerts = ParseWeatherAlerts(json);
                await repository.UpsertAlertsAsync(alerts);
            }
            else 
            {
                Console.WriteLine("Error fetching");
            }
        }
    }

    private IEnumerable<WeatherAlert> ParseWeatherAlerts(string json)
    {        
        var alerts = new List<WeatherAlert>();

        // Check if the JSON is valid and contains the expected structure
        if (string.IsNullOrEmpty(json))
        {
            throw new ArgumentException("JSON response is empty or null.");
        }

        try
        {
            // Parse the JSON and map to WeatherAlert objects (simplified for brevity)
            var data = System.Text.Json.JsonSerializer.Deserialize<WeatherAlertResponse>(json);
            Console.WriteLine("Total Alerts: " + data.Features.Count);


            // Ensure that data and data.Features are not null
            if (data?.Features == null)
            {
                throw new InvalidOperationException("The features data is missing or null in the JSON response.");
            }

            foreach (var feature in data.Features)
            {
                // Ensure that necessary properties are not null
                if (feature?.Properties == null)
                {
                    continue; // Skip any feature without valid properties
                }

                var properties = feature.Properties;
                var when = feature.When?.Interval;

                // Check if the 'when' and 'interval' are valid before accessing
                if (when == null )
                {
                    continue; // Skip invalid intervals
                }

                // Create the WeatherAlert object
                var weatherAlert = new WeatherAlert
                {
                    Id = properties.Id,
                    Area = properties?.Area,
                    Certainty = properties?.Certainty,
                    Consequences = properties?.Consequences,
                    Event = properties?.Event,
                    GeographicDomain = properties?.GeographicDomain,
                    Instruction = properties?.Instruction,
                    RiskMatrixColor = properties?.RiskMatrixColor,
                    Severity = properties?.Severity,
                    Status = properties?.Status,
                    EventStartingTime = DateTime.Parse(when[0]), // Ensure this is a valid datetime format
                    EventEndingTime = DateTime.Parse(when[1]),   // Ensure this is a valid datetime format
                    Title = properties?.Title,
                    Description = properties?.Description
                };

                alerts.Add(weatherAlert);
            }
        }
        catch (InvalidOperationException ex)
        {
            // Handle other errors, such as missing or malformed data
            Console.WriteLine($"Error processing weather alert: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Catch any other exceptions
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        return alerts;
    }
}

