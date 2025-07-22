using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents the root object of a 
    /// weather forecast API response.
    /// </summary>
    public class ForecastRoot
    {
        /// <summary>
        /// Response status code 
        /// (e.g., "200" for success).
        /// </summary>
        [JsonPropertyName("cod")]
        public string Code { get; set; }

        /// <summary>
        /// Internal message or status value 
        /// (usage may vary by API version).
        /// </summary>
        [JsonPropertyName("message")]
        public double Message { get; set; }

        /// <summary>
        /// Number of forecast entries returned 
        /// in the response.
        /// </summary>
        [JsonPropertyName("cnt")]
        public int Count { get; set; }

        /// <summary>
        /// List of forecast items for 
        /// different timestamps.
        /// </summary>
        [JsonPropertyName("list")]
        public List<ForecastItem> Items { get; set; }

        /// <summary>
        /// Information about the city to which 
        /// the forecast applies.
        /// </summary>
        [JsonPropertyName("city")]
        public City City { get; set; }
    }
}
