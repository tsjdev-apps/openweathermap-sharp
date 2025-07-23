using OpenWeatherMapSharp.Utils;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents the root object of the 
    /// current weather data response from 
    /// the OpenWeatherMap API.
    /// </summary>
    public class WeatherRoot
    {
        /// <summary>
        /// Geographic coordinates of the location.
        /// </summary>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// List of weather conditions.
        /// </summary>
        [JsonPropertyName("weather")]
        public List<WeatherInfo> WeatherInfos { get; set; }

        /// <summary>
        /// Internal parameter (usually "stations").
        /// </summary>
        [JsonPropertyName("base")]
        public string Base { get; set; } = string.Empty;

        /// <summary>
        /// Main weather parameters such as 
        /// temperature, humidity, and pressure.
        /// </summary>
        [JsonPropertyName("main")]
        public Main MainWeather { get; set; }

        /// <summary>
        /// Visibility in meters.
        /// </summary>
        [JsonPropertyName("visibility")]
        public double Visibility { get; set; } = 0;

        /// <summary>
        /// Wind data including speed and direction.
        /// </summary>
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        /// <summary>
        /// Cloud coverage data.
        /// </summary>
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        /// <summary>
        /// Rain volume data.
        /// </summary>
        [JsonPropertyName("rain")]
        public Volume Rain { get; set; }

        /// <summary>
        /// Snow volume data.
        /// </summary>
        [JsonPropertyName("snow")]
        public Volume Snow { get; set; }

        /// <summary>
        /// Timestamp of the weather data (Unix, UTC).
        /// </summary>
        [JsonPropertyName("dt")]
        public long DateUnix { get; set; }

        /// <summary>
        /// Timestamp of the weather data as a 
        /// UTC <see cref="DateTime"/>.
        /// </summary>
        [JsonIgnore]
        public DateTime Date => DateUnix.ToDateTime();

        /// <summary>
        /// System data such as sunrise, sunset, 
        /// and country code.
        /// </summary>
        [JsonPropertyName("sys")]
        public System System { get; set; }

        /// <summary>
        /// Shift in seconds from UTC.
        /// </summary>
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        /// <summary>
        /// City ID.
        /// </summary>
        [JsonPropertyName("id")]
        public int CityId { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Response status code.
        /// </summary>
        [JsonPropertyName("cod")]
        public int Code { get; set; }

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
