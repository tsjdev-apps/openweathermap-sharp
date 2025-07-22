using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents the air quality index (AQI) value.
    /// </summary>
    public class AirPolutionIndex
    {
        /// <summary>
        /// Air Quality Index (1 = Good, 5 = Very Poor).
        /// </summary>
        [JsonPropertyName("aqi")]
        public int Index { get; set; }
    }
}
