using System.Text.Json.Serialization;

namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Main information
    /// </summary>
    public class Main
    {
        /// <summary>
        ///     Temperature.
        ///     Unit Default: Kelvin, Metric: Celcius, Imperial: Fahrenheit
        /// </summary>
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        /// <summary>
        ///     Temperature. This temperature parameter accounts for the human perception of weather.
        ///     Unit Default: Kelvin, Metric: Celcius, Imperial: Fahrenheit
        /// </summary>
        [JsonPropertyName("feels_like")]
        public double FeelsLikeTemperature { get; set; }

        /// <summary>
        ///     Atmospheric pressure of the sea level, hPa
        /// </summary>
        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }

        /// <summary>
        ///     Humidity, %
        /// </summary>
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        /// <summary>
        ///     Minimum temperature at the moment. 
        ///     This is minimal currently observed temperature (within large megalopolises and urban areas).
        ///     Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit
        /// </summary>
        [JsonPropertyName("temp_min")]
        public double MinTemperature { get; set; }

        /// <summary>
        ///     Maximum temperature at the moment. 
        ///     This is maximal currently observed temperature (within large megalopolises and urban areas).
        ///     Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit
        /// </summary>
        [JsonPropertyName("temp_max")]
        public double MaxTemperature { get; set; }

        /// <summary>
        ///     Atmospheric pressure of the sea level, hPa
        /// </summary>
        [JsonPropertyName("sea_level")]
        public double SeaLevelPressure { get; set; }

        /// <summary>
        ///     Atmospheric pressure of the ground level, hPa
        /// </summary>
        [JsonPropertyName("grnd_level")]
        public double GroundLevelPressure { get; set; }
    }
}
