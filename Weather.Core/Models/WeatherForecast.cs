using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Core.Models
{
    public class WeatherForecast
    {
        [JsonProperty("datetime")]
        public DateTimeOffset Datetime { get; set; }

        [JsonProperty("ts")]
        public Int32 Time { get; set; }

        [JsonProperty("temp")]
        public long Temp { get; set; }

        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }

        [JsonProperty("min_temp")]
        public double MinTemp { get; set; }

        [JsonProperty("app_max_temp")]
        public long AppMaxTemp { get; set; }

        [JsonProperty("app_min_temp")]
        public long AppMinTemp { get; set; }
    }
}
