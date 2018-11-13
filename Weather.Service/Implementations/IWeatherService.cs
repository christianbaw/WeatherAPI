using System;
using System.Collections.Generic;
using Weather.Core.Models;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Service.Implementations
{
   public interface IWeatherService
    {
        Task<WeatherInformation> GetWeatherInformation(string city, string scale, int daysToShow = 15);
        Task<WeatherForecast> GetWeatherForecast(string city, string scale, int daysToShow = 15);
    }
}
