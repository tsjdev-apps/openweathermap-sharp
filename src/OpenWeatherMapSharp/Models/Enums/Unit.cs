namespace OpenWeatherMapSharp.Models.Enums
{
    /// <summary>
    /// Represents the unit system to be used 
    /// for temperature, wind speed, and other 
    /// measurements. These options correspond 
    /// to the units supported by the 
    /// OpenWeatherMap API.
    /// </summary>
    public enum Unit
    {
        /// <summary>
        /// Standard units: temperature in Kelvin, 
        /// wind speed in meter/sec.
        /// This is the default if no unit is specified.
        /// </summary>
        Standard,

        /// <summary>
        /// Imperial units: temperature in Fahrenheit, 
        /// wind speed in miles/hour.
        /// </summary>
        Imperial,

        /// <summary>
        /// Metric units: temperature in Celsius, 
        /// wind speed in meter/sec.
        /// </summary>
        Metric
    }
}
