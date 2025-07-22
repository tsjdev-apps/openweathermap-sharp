using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents detailed weather condition information.
    /// </summary>
    public class WeatherInfo
    {
        /// <summary>
        /// Weather condition ID as 
        /// defined by OpenWeatherMap.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Broad category of weather 
        /// conditions (e.g., Rain, Snow, Clouds).
        /// </summary>
        [JsonPropertyName("main")]
        public string Main { get; set; }

        /// <summary>
        /// More detailed description of 
        /// the weather condition.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Weather icon ID that can be used 
        /// to retrieve the corresponding icon.
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
