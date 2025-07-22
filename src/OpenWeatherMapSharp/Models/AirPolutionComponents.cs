using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents the concentration values 
    /// of various air pollutants (in μg/m³).
    /// </summary>
    public class AirPolutionComponents
    {
        /// <summary>
        /// Carbon monoxide concentration.
        /// </summary>
        [JsonPropertyName("co")]
        public double CarbonMonoxide { get; set; }

        /// <summary>
        /// Nitric oxide concentration.
        /// </summary>
        [JsonPropertyName("no")]
        public double NitrogenMonoxide { get; set; }

        /// <summary>
        /// Nitrogen dioxide concentration.
        /// </summary>
        [JsonPropertyName("no2")]
        public double NitrogenDioxide { get; set; }

        /// <summary>
        /// Ozone concentration.
        /// </summary>
        [JsonPropertyName("o3")]
        public double Ozone { get; set; }

        /// <summary>
        /// Sulfur dioxide concentration.
        /// </summary>
        [JsonPropertyName("so2")]
        public double SulfurDioxide { get; set; }

        /// <summary>
        /// Fine particulate matter (PM2.5) concentration.
        /// </summary>
        [JsonPropertyName("pm2_5")]
        public double FineParticlesMatter { get; set; }

        /// <summary>
        /// Coarse particulate matter (PM10) concentration.
        /// </summary>
        [JsonPropertyName("pm10")]
        public double CoarseParticulateMatter { get; set; }

        /// <summary>
        /// Ammonia concentration.
        /// </summary>
        [JsonPropertyName("nh3")]
        public double Ammonia { get; set; }
    }
}
