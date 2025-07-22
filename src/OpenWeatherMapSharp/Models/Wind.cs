using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Wind information
    /// </summary>
    public class Wind
    {
        /// <summary>
        ///     Wind speed
        ///     Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour
        /// </summary>
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        /// <summary>
        ///     Wind direction, degrees (meteorological)
        /// </summary>
        [JsonPropertyName("deg")]
        public double Degrees { get; set; }

        /// <summary>
        ///     Wind gust
        ///     Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour
        /// </summary>
        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }
}
