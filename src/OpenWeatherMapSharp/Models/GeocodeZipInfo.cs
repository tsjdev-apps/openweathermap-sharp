using Newtonsoft.Json;

namespace OpenWeatherMapSharp.Models
{
    public class GeocodeZipInfo
    {
        /// <summary>
        ///     Specified zip/post code in the API request
        /// </summary>
        [JsonProperty("zip")]
        public string ZipCode { get; set; }

        /// <summary>
        ///     Name of the found area
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Geographical coordinates of the found location: Latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latiude { get; set; }

        /// <summary>
        ///     Geographical coordinates of the found location: Longitude
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        /// <summary>
        ///     Country of the found zip/post code
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
