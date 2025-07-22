using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents a geocoded location with name, 
    /// coordinates, and optional metadata such 
    /// as country and state.
    /// </summary>
    public class GeocodeInfo
    {
        /// <summary>
        /// Name of the found location.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Localized names of the location in 
        /// different languages, keyed by 
        /// language code (e.g., "en", "de").
        /// </summary>
        [JsonPropertyName("local_names")]
        public Dictionary<string, string> LocalNames { get; set; }

        /// <summary>
        /// Latitude of the location 
        /// in decimal degrees.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the location 
        /// in decimal degrees.
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Country code of the location 
        /// (ISO 3166 format, e.g., "US", "DE").
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Optional state or administrative 
        /// region of the location, if available.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
