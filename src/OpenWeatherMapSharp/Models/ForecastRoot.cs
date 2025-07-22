using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     The Forcast Root object
    /// </summary>
    public class ForecastRoot
    {
        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonPropertyName("cod")]
        public string Code { get; set; }

        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonPropertyName("message")]
        public double Message { get; set; }

        /// <summary>
        ///     A number of timestamps returned in the API response
        /// </summary>
        [JsonPropertyName("cnt")]
        public int Count { get; set; }

        /// <summary>
        ///     List of forecast items
        /// </summary>
        [JsonPropertyName("list")]
        public List<ForecastItem> Items { get; set; }

        /// <summary>
        ///     City information
        /// </summary>
        [JsonPropertyName("city")]
        public City City { get; set; }
    }
}
