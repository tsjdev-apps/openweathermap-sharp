using Newtonsoft.Json;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Clouds information
    /// </summary>
    public class Clouds
    {
        /// <summary>
        ///     Cloudiness, %
        /// </summary>
        [JsonProperty("all")]
        public int Cloudiness { get; set; }
    }
}
