using OpenWeatherMapSharp.Utils;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    public class WeatherRoot
    {
        /// <summary>
        ///     Coordinates information
        /// </summary>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        ///     List of weather infos
        /// </summary>
        [JsonPropertyName("weather")]
        public List<WeatherInfo> WeatherInfos { get; set; }

        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonPropertyName("base")]
        public string Base { get; set; } = string.Empty;

        /// <summary>
        ///     Main weather information
        /// </summary>
        [JsonPropertyName("main")]
        public Main MainWeather { get; set; }

        /// <summary>
        ///     Average visibility, metres
        /// </summary>
        [JsonPropertyName("visibility")]
        public double Visibility { get; set; } = 0;

        /// <summary>
        ///     Wind information
        /// </summary>
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        /// <summary>
        ///     Clouds information
        /// </summary>
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

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
        ///     Date, Unix, UTC
        /// </summary>
        [JsonPropertyName("dt")]
        public long DateUnix { get; set; }

        /// <summary>
        ///     Date, DateTime
        /// </summary>
        [JsonIgnore]
        public DateTime Date => DateUnix.ToDateTime();

        /// <summary>
        ///     System information
        /// </summary>
        [JsonPropertyName("sys")]
        public System System { get; set; }

        /// <summary>
        ///     City ID
        /// </summary>
        [JsonPropertyName("id")]
        public int CityId { get; set; }

        /// <summary>
        ///     City name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonPropertyName("cod")]
        public int Code { get; set; }

        /// <summary>
        ///     Icon url
        /// </summary>
        [JsonIgnore]
        public string Icon => $"https://openweathermap.org/img/w/{WeatherInfos?[0]?.Icon}.png";

        /// <summary>
        ///     Icon url (2x)
        /// </summary>
        [JsonIgnore]
        public string Icon2x => $"https://openweathermap.org/img/w/{WeatherInfos?[0]?.Icon}@2x.png";

        /// <summary>
        ///     Icon url (4x)
        /// </summary>
        [JsonIgnore]
        public string Icon4x => $"https://openweathermap.org/img/w/{WeatherInfos?[0]?.Icon}@4x.png";


        /// <summary>
        ///    Icon name
        /// </summary>
        [JsonIgnore]
        public string IconName => $"{WeatherInfos?[0]?.Icon}";
    }
}
