using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents the geographic coordinates 
    /// of a location.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Longitude of the location, 
        /// in decimal degrees.
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Latitude of the location, 
        /// in decimal degrees.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }
}
