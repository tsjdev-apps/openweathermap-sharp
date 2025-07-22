using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents wind-related weather data, 
    /// including speed, direction, and gusts.
    /// </summary>
    public class Wind
    {
        /// <summary>
        /// Wind speed.
        /// Units — Default & Metric: 
        /// meters/second, Imperial: miles/hour.
        /// </summary>
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        /// <summary>
        /// Wind direction in 
        /// meteorological degrees (0°–360°).
        /// </summary>
        [JsonPropertyName("deg")]
        public double Degrees { get; set; }

        /// <summary>
        /// Wind gust speed.
        /// Units — Default & Metric: 
        /// meters/second, Imperial: miles/hour.
        /// </summary>
        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }
}
