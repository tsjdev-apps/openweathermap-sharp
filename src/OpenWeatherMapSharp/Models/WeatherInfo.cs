using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Weather information
    /// </summary>
    public class WeatherInfo
    {
        /// <summary>
        ///     Weather condition id
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Group of weather parameters (Rain, Snow, Clouds etc.)
        /// </summary>
        [JsonPropertyName("main")]
        public string Main { get; set; }

        /// <summary>
        ///     Weather coniditon with the group
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Weather icon id
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
