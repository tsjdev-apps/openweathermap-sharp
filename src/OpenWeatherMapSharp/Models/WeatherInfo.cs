using Newtonsoft.Json;

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
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Group of weather parameters (Rain, Snow, Clouds etc.)
        /// </summary>
        [JsonProperty("main")]
        public string Main { get; set; }

        /// <summary>
        ///     Weather coniditon with the group
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Weather icon id
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
