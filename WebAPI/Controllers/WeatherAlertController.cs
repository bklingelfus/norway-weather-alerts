using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherAlertController : ControllerBase
    {
        private readonly WeatherAlertService _service;

        public WeatherAlertController(WeatherAlertService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherAlerts(
            [FromQuery] string? eventType = null,
            [FromQuery] string? geographicDomain = null,
            [FromQuery] string? riskMatrixColor = null,
            [FromQuery] string? certainty = null,
            [FromQuery] string? severity = null)
        {
            // Call the service to get the weather alerts based on the optional query parameters
            var alerts = await _service.GetWeatherAlertsAsync(eventType, geographicDomain, riskMatrixColor, certainty, severity);

            return Ok(alerts);
        }

        // New route to get available filter options (unique values for each filter column)
        [HttpGet("filters")]
        public async Task<IActionResult> GetFilterOptions()
        {
            var filterOptions = await _service.GetFilterOptionsAsync();
            return Ok(filterOptions);
        }
    }
}
