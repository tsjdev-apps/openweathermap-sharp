using Newtonsoft.Json;

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
        [JsonProperty("lon")]        
        public double Longitude { get; set; }

        /// <summary>
        ///     Latitude of the location
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
