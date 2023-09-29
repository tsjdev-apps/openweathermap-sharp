using Newtonsoft.Json;
using System.Collections.Generic;

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
        [JsonProperty("cod")]
        public string Code { get; set; }

        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonProperty("message")]
        public double Message { get; set; }

        /// <summary>
        ///     A number of timestamps returned in the API response
        /// </summary>
        [JsonProperty("cnt")]
        public int Count { get; set; }

        /// <summary>
        ///     List of forecast items
        /// </summary>
        [JsonProperty("list")]
        public List<ForecastItem> Items { get; set; }

        /// <summary>
        ///     City information
        /// </summary>
        [JsonProperty("city")]
        public City City { get; set; }
    }
}
