using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Core.Models;
using Weather.Service.Implementations;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}&{scale}", Name = "GetWeatherInformation")]
        public async Task<ActionResult<WeatherInformation>> Get(string city, string scale, int daysToShow = 15)
        {
            var weatherInformation = await _weatherService.GetWeatherInformation(city, scale, daysToShow);

            if (weatherInformation == null)
            {
                return NotFound();
            }

            return Ok(weatherInformation);
        }
    }
}