using OpenWeatherMapSharp.Utils;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents a single forecast entry 
    /// containing weather data for a 
    /// specific point in time.
    /// </summary>
    public class ForecastItem
    {
        /// <summary>
        /// Main weather parameters such as 
        /// temperature, pressure, and humidity.
        /// </summary>
        [JsonPropertyName("main")]
        public Main MainWeather { get; set; }

        /// <summary>
        /// A list of weather conditions 
        /// (e.g., rain, clouds, clear sky).
        /// </summary>
        [JsonPropertyName("weather")]
        public List<WeatherInfo> WeatherInfos { get; set; }

        /// <summary>
        /// Cloud coverage information.
        /// </summary>
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        /// <summary>
        /// Wind speed and direction information.
        /// </summary>
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        /// <summary>
        /// Average visibility in meters.
        /// </summary>
        [JsonPropertyName("visibility")]
        public double Visibility { get; set; }

        /// <summary>
        /// Probability of precipitation (0.0–1.0).
        /// </summary>
        [JsonPropertyName("pop")]
        public double Probability { get; set; }

        /// <summary>
        /// Rain volume information.
        /// </summary>
        [JsonPropertyName("rain")]
        public Volume Rain { get; set; }

        /// <summary>
        /// Snow volume information.
        /// </summary>
        [JsonPropertyName("snow")]
        public Volume Snow { get; set; }

        /// <summary>
        /// City details associated with the forecast 
        /// (if applicable).
        /// </summary>
        [JsonPropertyName("city")]
        public City City { get; set; }

        /// <summary>
        /// Forecast time as Unix timestamp (UTC).
        /// </summary>
        [JsonPropertyName("dt")]
        public long DateUnix { get; set; }

        /// <summary>
        /// Forecast time as a 
        /// UTC <see cref="DateTime"/>.
        /// </summary>
        [JsonIgnore]
        public DateTime Date 
            => DateUnix.ToDateTime();

        /// <summary>
        /// Weather icon URL (default size).
        /// </summary>
        [JsonIgnore]
        public string Icon
            => $"https://openweathermap.org/img/wn/{WeatherInfos?[0]?.Icon}.png";

        /// <summary>
        /// Weather icon URL (2x resolution).
        /// </summary>
        [JsonIgnore]
        public string Icon2x
            => $"https://openweathermap.org/img/wn/{WeatherInfos?[0]?.Icon}@2x.png";

        /// <summary>
        /// Weather icon URL (4x resolution).
        /// </summary>
        [JsonIgnore]
        public string Icon4x
            => $"https://openweathermap.org/img/wn/{WeatherInfos?[0]?.Icon}@4x.png";

        /// <summary>
        /// Weather icon name.
        /// </summary>
        [JsonIgnore]
        public string IconName
            => WeatherInfos?[0]?.Icon;
    }
}
