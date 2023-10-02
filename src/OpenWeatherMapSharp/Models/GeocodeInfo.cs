using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenWeatherMapSharp.Models
{
    public class GeocodeInfo
    {
        /// <summary>
        ///     Name of the found location
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Name of the found location in dufferent languages
        /// </summary>
        [JsonProperty("local_names")]
        public Dictionary<string, string> LocalNames { get; set; }

        /// <summary>
        ///     Geographical coordinates of the found location: Latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        ///     Geographical coordinates of the found location: Longitude
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        ///     Country of the found location        
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        ///     State of the found location, where available
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
