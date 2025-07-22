using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Coordinates information
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        ///     Longitude of the location
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        ///     Latitude of the location
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }
}
