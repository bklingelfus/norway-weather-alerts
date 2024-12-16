using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using WorkerService.Data;
using WorkerService.Data.Repositories;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Add EF Core
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

        // Add Repository
        services.AddScoped<IWeatherAlertRepository, WeatherAlertRepository>();

        // Add Hangfire
        services.AddHangfire(config =>
            config.UseSqlServerStorage(context.Configuration.GetConnectionString("DefaultConnection")));
        services.AddHangfireServer();

        // Add WorkerService
        services.AddHostedService<Worker>();
    })
    .Build();

builder.Run();
