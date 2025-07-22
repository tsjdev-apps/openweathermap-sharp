using OpenWeatherMapSharp.Utils;
using System;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Contains system-related metadata 
    /// from the OpenWeatherMap API response.
    /// </summary>
    public class System
    {
        /// <summary>
        /// Internal parameter used by the API.
        /// </summary>
        [JsonPropertyName("type")]
        public int Type { get; set; }

        /// <summary>
        /// Internal system identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Country code (ISO 3166 format), 
        /// e.g., "GB", "JP".
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Sunrise time as a Unix timestamp (UTC).
        /// </summary>
        [JsonPropertyName("sunrise")]
        public long SunriseUnix { get; set; }

        /// <summary>
        /// Sunrise time converted to a 
        /// UTC <see cref="DateTime"/>.
        /// </summary>
        [JsonIgnore]
        public DateTime Sunrise
            => SunriseUnix.ToDateTime();

        /// <summary>
        /// Sunset time as a Unix timestamp (UTC).
        /// </summary>
        [JsonPropertyName("sunset")]
        public long SunsetUnix { get; set; }

        /// <summary>
        /// Sunset time converted to a 
        /// UTC <see cref="DateTime"/>.
        /// </summary>
        [JsonIgnore]
        public DateTime Sunset
            => SunsetUnix.ToDateTime();
    }
}
