using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Represents the main weather data, 
    /// including temperature, pressure, and humidity.
    /// </summary>
    public class Main
    {
        /// <summary>
        /// Current temperature.
        /// Units — Default: Kelvin, 
        /// Metric: Celsius, 
        /// Imperial: Fahrenheit.
        /// </summary>
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        /// <summary>
        /// Perceived temperature accounting 
        /// for human perception.
        /// Units — Default: Kelvin, 
        /// Metric: Celsius, 
        /// Imperial: Fahrenheit.
        /// </summary>
        [JsonPropertyName("feels_like")]
        public double FeelsLikeTemperature { get; set; }

        /// <summary>
        /// Atmospheric pressure at sea level, in hPa.
        /// </summary>
        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        /// <summary>
        /// Humidity percentage (0–100).
        /// </summary>
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        /// <summary>
        /// Minimum observed temperature 
        /// at the moment (typically within urban areas).
        /// Units — Default: Kelvin, 
        /// Metric: Celsius, 
        /// Imperial: Fahrenheit.
        /// </summary>
        [JsonPropertyName("temp_min")]
        public double MinTemperature { get; set; }

        /// <summary>
        /// Maximum observed temperature 
        /// at the moment (typically within urban areas).
        /// Units — Default: Kelvin, 
        /// Metric: Celsius, 
        /// Imperial: Fahrenheit.
        /// </summary>
        [JsonPropertyName("temp_max")]
        public double MaxTemperature { get; set; }

        /// <summary>
        /// Atmospheric pressure at sea level, 
        /// in hPa.
        /// </summary>
        [JsonPropertyName("sea_level")]
        public double SeaLevelPressure { get; set; }

        /// <summary>
        /// Atmospheric pressure at ground level, 
        /// in hPa.
        /// </summary>
        [JsonPropertyName("grnd_level")]
        public double GroundLevelPressure { get; set; }
    }
}
