using Newtonsoft.Json;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Volume information
    /// </summary>
    public class Volume
    {
        /// <summary>
        ///     Volume for the last 1 hour, mm.
        /// </summary>
        [JsonProperty("1h")]
        public double OneHour { get; set; }

        /// <summary>
        ///     Volume for the last 3 hour, mm.
        /// </summary>
        [JsonProperty("3h")]
        public double ThreeHours { get; set; }
    }
}
