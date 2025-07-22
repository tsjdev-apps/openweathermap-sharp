using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents cloud coverage information.
    /// </summary>
    public class Clouds
    {
        /// <summary>
        /// Cloudiness percentage (0–100).
        /// </summary>
        [JsonPropertyName("all")]
        public int Cloudiness { get; set; }
    }
}
