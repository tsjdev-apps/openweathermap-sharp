using Newtonsoft.Json;
using OpenWeatherMapSharp.Utils;
using System;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     System information
    /// </summary>
    public class System
    {
        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }

        /// <summary>
        ///     Internal parameter
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Country code (GB, JP etc.)
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        ///     Sunrise time, unix, UTC
        /// </summary>
        [JsonProperty("sunrise")]
        public long SunriseUnix { get; set; }

        /// <summary>
        ///     Sunrise time, DateTime
        /// </summary>
        [JsonIgnore]
        public DateTime Sunrise => SunriseUnix.ToDateTime();

        /// <summary>
        ///     Sunset time, unix, UTC
        /// </summary>
        [JsonProperty("sunset")]
        public long SunsetUnix { get; set; }

        /// <summary>
        ///     Sunset time, DateTime
        /// </summary>
        [JsonIgnore]
        public DateTime Sunset => SunsetUnix.ToDateTime();
    }
}
