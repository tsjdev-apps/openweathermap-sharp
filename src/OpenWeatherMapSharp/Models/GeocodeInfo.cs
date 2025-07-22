using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    public class GeocodeInfo
    {
        /// <summary>
        ///     Name of the found location
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Name of the found location in dufferent languages
        /// </summary>
        [JsonPropertyName("local_names")]
        public Dictionary<string, string> LocalNames { get; set; }

        /// <summary>
        ///     Geographical coordinates of the found location: Latitude
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        ///     Geographical coordinates of the found location: Longitude
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        ///     Country of the found location        
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        ///     State of the found location, where available
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
