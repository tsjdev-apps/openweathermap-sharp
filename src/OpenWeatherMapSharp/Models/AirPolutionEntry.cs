using OpenWeatherMapSharp.Utils;
using System;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents a single entry of air quality data, 
    /// including AQI, components, and timestamp.
    /// </summary>
    public class AirPolutionEntry
    {
        /// <summary>
        /// Main air quality index (AQI).
        /// </summary>
        [JsonPropertyName("main")]
        public AirPolutionIndex AQI { get; set; }

        /// <summary>
        /// Concentrations of individual air components.
        /// </summary>
        [JsonPropertyName("components")]
        public AirPolutionComponents Components { get; set; }

        /// <summary>
        /// Timestamp of the measurement (Unix time in seconds).
        /// </summary>
        [JsonPropertyName("dt")]
        public long DateUnix { get; set; }

        /// <summary>
        /// Timestamp of the weather data as a 
        /// UTC <see cref="DateTime"/>.
        /// </summary>
        [JsonIgnore]
        public DateTime Date
            => DateUnix.ToDateTime();
    }
}
