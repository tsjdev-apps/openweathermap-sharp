using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Clouds information
    /// </summary>
    public class Clouds
    {
        /// <summary>
        ///     Cloudiness, %
        /// </summary>
        [JsonPropertyName("all")]
        public int Cloudiness { get; set; }
    }
}
