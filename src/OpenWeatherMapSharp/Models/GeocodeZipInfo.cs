using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents geolocation data 
    /// returned from a ZIP/postal code 
    /// geocoding request.
    /// </summary>
    public class GeocodeZipInfo
    {
        /// <summary>
        /// The ZIP or postal code specified 
        /// in the API request.
        /// </summary>
        [JsonPropertyName("zip")]
        public string ZipCode { get; set; }

        /// <summary>
        /// The name of the found area or locality.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Latitude of the found location in 
        /// decimal degrees.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the found location 
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
    }
}
