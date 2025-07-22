using OpenWeatherMapSharp.Utils;
using System;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     City information
    /// </summary>
    public class City
    {
        /// <summary>
        ///     City ID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     City name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Coordinates
        /// </summary>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        ///     Country code (GB, JP etc.)
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        ///     City population
        /// </summary>
        [JsonPropertyName("population")]
        public int Population { get; set; }

        /// <summary>
        ///     Sunrise time, unix, UTC
        /// </summary>
        [JsonPropertyName("sunrise")]
        public long SunriseUnix { get; set; }

        /// <summary>
        ///     Sunrise time, DateTime
        /// </summary>
        [JsonIgnore]
        public DateTime Sunrise => SunriseUnix.ToDateTime();

        /// <summary>
        ///     Sunset time, unix, UTC
        /// </summary>
        [JsonPropertyName("sunset")]
        public long SunsetUnix { get; set; }

        /// <summary>
        ///     Sunset time, DateTime
        /// </summary>
        [JsonIgnore]
        public DateTime Sunset => SunsetUnix.ToDateTime();
    }
}
