using Newtonsoft.Json;
using OpenWeatherMapSharp.Utils;
using System;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     City information
    /// </summary>
    public class City
    {
        /// <summary>
        ///     City ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///     City name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Coordinates
        /// </summary>
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        ///     Country code (GB, JP etc.)
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        ///     City population
        /// </summary>
        [JsonProperty("population")]
        public int Population { get; set; }

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
