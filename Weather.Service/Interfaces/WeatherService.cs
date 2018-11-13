using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Models;
using Weather.Service.Implementations;

namespace Weather.Service.Interfaces
{
    public class WeatherService : IWeatherService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string WEATHER_API_KEY;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;

            // getting the api's auth token from the app's configuration
            WEATHER_API_KEY = _configuration.GetSection("WEATHER_API_KEY").Value;

            // getting the api's base url from the app's configuration
            string apiBaseUrl = _configuration.GetSection("WEATHER_API_URL").Value;
            httpClient.BaseAddress = new Uri(apiBaseUrl);
        }

        public async Task<WeatherInformation> GetWeatherInformation(string city, string scale, int daysToShow = 15)
        {
            string requestParameters = $"city={city.ToString()}&country=mexico&units={scale.ToString()}&days={daysToShow.ToString()}&key={WEATHER_API_KEY}";

            // going to the server to get the weather information
            HttpResponseMessage response = await _httpClient.GetAsync($"forecast/daily?{requestParameters}");

            try {
                // making sure everything went OK
                response.EnsureSuccessStatusCode();

                string responseText = await response.Content.ReadAsStringAsync();

                // deserializing JSON into a real world object
                WeatherInformation weather = JsonConvert.DeserializeObject<WeatherInformation>(responseText);

                return weather;
            }
            catch
            {
                return null;
            }
        }

        public async Task<WeatherForecast> GetWeatherForecast(string city, string scale, int daysToShow = 15)
        {
            string requestParameters = $"city={city.ToString()}&country=mexico&units={scale.ToString()}&days={daysToShow.ToString()}&key={WEATHER_API_KEY}";

            // going to the server to get the weather information
            HttpResponseMessage response = await _httpClient.GetAsync($"forecast/daily?{requestParameters}");

            // making sure everything went OK
            response.EnsureSuccessStatusCode();

            string responseText = await response.Content.ReadAsStringAsync();

            // deserializing JSON into a real world object
            WeatherForecast weather = JsonConvert.DeserializeObject<WeatherForecast>(responseText);

            return weather;
        }
    }
}

