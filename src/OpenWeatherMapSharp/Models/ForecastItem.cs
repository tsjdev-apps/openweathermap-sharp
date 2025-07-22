using OpenWeatherMapSharp.Utils;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     A Forcast Item
    /// </summary>
    public class ForecastItem
    {
        /// <summary>
        ///     Main weather information
        /// </summary>
        [JsonPropertyName("main")]
        public Main MainWeather { get; set; }

        /// <summary>
        ///     List of weather infos
        /// </summary>
        [JsonPropertyName("weather")]
        public List<WeatherInfo> WeatherInfos { get; set; }

        /// <summary>
        ///     Cloud information
        /// </summary>
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        /// <summary>
        ///     Wind information
        /// </summary>
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        /// <summary>
        ///     Average visibility, metres
        /// </summary>
        [JsonPropertyName("visibility")]
        public double Visibility { get; set; }

        /// <summary>
        ///     Probability of precipitation
        /// </summary>
        [JsonPropertyName("pop")]
        public double Probability { get; set; }

        /// <summary>
        ///     Rain information
        /// </summary>
        [JsonPropertyName("rain")]
        public Volume Rain { get; set; }

        /// <summary>
        ///     Snow information
        /// </summary>
        [JsonPropertyName("snow")]
        public Volume Snow { get; set; }

        /// <summary>
        ///     City information
        /// </summary>
        [JsonPropertyName("city")]
        public City City { get; set; }

        /// <summary>
        ///     Date, Unix, UTC
        /// </summary>
        [JsonPropertyName("dt")]
        public long DateUnix { get; set; }

        /// <summary>
        ///     Date, DateTime
        /// </summary>
        [JsonIgnore]
        public DateTime Date => DateUnix.ToDateTime();
    }
}
