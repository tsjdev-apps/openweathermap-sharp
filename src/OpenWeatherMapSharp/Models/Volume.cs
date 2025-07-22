using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents precipitation volume over 
    /// a specific time period.
    /// </summary>
    public class Volume
    {
        /// <summary>
        /// Precipitation volume for the last 
        /// 1 hour, in millimeters.
        /// </summary>
        [JsonPropertyName("1h")]
        public double OneHour { get; set; }
    }
}
