using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Root object representing the air quality response from the API.
    /// </summary>
    public class AirPolutionRoot
    {
        /// <summary>
        /// Geographic coordinates of the measurement location.
        /// </summary>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// List of air polution measurements.
        /// </summary>
        [JsonPropertyName("list")]
        public List<AirPolutionEntry> Entries { get; set; }
    }
}
