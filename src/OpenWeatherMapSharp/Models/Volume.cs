using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Volume information
    /// </summary>
    public class Volume
    {
        /// <summary>
        ///     Volume for the last 1 hour, mm.
        /// </summary>
        [JsonPropertyName("1h")]
        public double OneHour { get; set; }
    }
}
