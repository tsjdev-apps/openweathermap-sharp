using Newtonsoft.Json;
using OpenWeatherMapSharp.Utils;
using System;
using System.Collections.Generic;

namespace OpenWeatherMapSharp.Models
{
    public class WeatherRoot
    {
        /// <summary>
        ///     Coordinates information
        /// </summary>
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        ///     List of weather infos
        /// </summary>
        [JsonProperty("weather")]
        public List<WeatherInfo> WeatherInfos { get; set; }

        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; } = string.Empty;

        /// <summary>
        ///     Main weather information
        /// </summary>
        [JsonProperty("main")]
        public Main MainWeather { get; set; }

        /// <summary>
        ///     Average visibility, metres
        /// </summary>
        [JsonProperty("visibility")]
        public double Visibility { get; set; } = 0;

        /// <summary>
        ///     Wind information
        /// </summary>
        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        /// <summary>
        ///     Clouds information
        /// </summary>
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        /// <summary>
        ///     Rain information
        /// </summary>
        [JsonProperty("rain")]
        public Volume Rain { get; set; }

        /// <summary>
        ///     Snow information
        /// </summary>
        [JsonProperty("snow")]
        public Volume Snow { get; set; }

        /// <summary>
        ///     Date, Unix, UTC
        /// </summary>
        [JsonProperty("dt")]
        public long DateUnix { get; set; }

        /// <summary>
        ///     Date, DateTime
        /// </summary>
        [JsonIgnore]
        public DateTime Date => DateUnix.ToDateTime();

        /// <summary>
        ///     System information
        /// </summary>
        [JsonProperty("sys")]
        public System System { get; set; }

        /// <summary>
        ///     City ID
        /// </summary>
        [JsonProperty("id")]
        public int CityId { get; set; }

        /// <summary>
        ///     City name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonProperty("cod")]
        public int Code { get; set; }

        /// <summary>
        ///     Icon url
        /// </summary>
        [JsonIgnore]
        public string Icon => $"https://openweathermap.org/img/w/{WeatherInfos?[0]?.Icon}.png";
    }
}
