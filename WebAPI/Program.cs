using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Interfaces;
using WebAPI.Data.Repositories;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure the DbContext with SQL Server connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add repository and service to DI container
builder.Services.AddScoped<IWeatherAlertRepository, WeatherAlertRepository>();
builder.Services.AddScoped<WeatherAlertService>();

var app = builder.Build();

app.Urls.Add("http://localhost:5000");

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
