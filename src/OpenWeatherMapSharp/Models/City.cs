using OpenWeatherMapSharp.Utils;
using System;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents basic city information, 
    /// including coordinates, country, 
    /// population, and sunrise/sunset times.
    /// </summary>
    public class City
    {
        /// <summary>
        /// The unique city ID as defined 
        /// by OpenWeatherMap.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the city.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Geographic coordinates 
        /// (latitude and longitude) of the city.
        /// </summary>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// ISO 3166 country code (e.g., "GB", "JP").
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Total population of the city.
        /// </summary>
        [JsonPropertyName("population")]
        public int Population { get; set; }

        /// <summary>
        /// Sunrise time in Unix timestamp format (UTC).
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
        /// Sunset time in Unix timestamp format (UTC).
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
