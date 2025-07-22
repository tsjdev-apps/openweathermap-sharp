using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    public class GeocodeZipInfo
    {
        /// <summary>
        ///     Specified zip/post code in the API request
        /// </summary>
        [JsonPropertyName("zip")]
        public string ZipCode { get; set; }

        /// <summary>
        ///     Name of the found area
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Geographical coordinates of the found location: Latitude
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latiude { get; set; }

        /// <summary>
        ///     Geographical coordinates of the found location: Longitude
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        ///     Country of the found zip/post code
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
