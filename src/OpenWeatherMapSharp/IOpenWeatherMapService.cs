using OpenWeatherMapSharp.Models;
using OpenWeatherMapSharp.Models.Enums;
using System;
using System.Threading.Tasks;

namespace OpenWeatherMapSharp
{
    /// <summary>
    ///     This interface defines the methods to communicate with the Open Weather Map API
    /// </summary>
    public interface IOpenWeatherMapService
    {
        /// <summary>
        ///     Gets forecast for a location given its longitude and latitude
        /// </summary>
        /// <param name="latitude">The latitude of the location</param>
        /// <param name="longitude">The longitude of the location</param>
        /// <param name="language">The language used for the response</param>
        /// <param name="unit">The unit of measurement for the response</param>
        /// <returns>The OpenWeatherMapServiceResponse containing the forecast information</returns>
        Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            double latitude,
            double longitude,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        ///     Gets forecast for a location given its city ID
        /// </summary>
        /// <param name="cityId">The ID of the location's city</param>
        /// <param name="language">The language used for the response</param>
        /// <param name="unit">The unit of measurement for the response</param>
        /// <returns>The OpenWeatherMapServiceResponse containing the forecast information</returns>
        [Obsolete("Please note that API requests by city name, zip-codes and city id have been deprecated. Although they are still available for use, bug fixing and updates are no longer available for this functionality.")]
        Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            int cityId,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        ///     Gets forecast for a location given its city name
        /// </summary>
        /// <param name="city">The name of the location's city</param>
        /// <param name="language">The language used for the response</param>
        /// <param name="unit">The unit of measurement for the response</param>
        /// <returns>The OpenWeatherMapServiceResponse containing the forecast information</returns>
        [Obsolete("Please note that API requests by city name, zip-codes and city id have been deprecated. Although they are still available for use, bug fixing and updates are no longer available for this functionality.")]
        Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            string city,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        ///     Gets weather information for a location given its longitude and latitude
        /// </summary>
        /// <param name="latitude">The latitude of the location</param>
        /// <param name="longitude">The longitude of the location</param>
        /// <param name="language">The language used for the response</param>
        /// <param name="unit">The unit of measurement for the response</param>
        /// <returns>The OpenWeatherMapServiceResponse containing the weather information</returns>
        Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            double latitude,
            double longitude,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        /// Gets weather information for a location given its city ID
        /// </summary>
        /// <param name="cityId">The ID of the location's city</param>
        /// <param name="language">The language used for the response</param>
        /// <param name="unit">The unit of measurement for the response</param>
        /// <returns>The OpenWeatherMapServiceResponse containing the weather information</returns>
        [Obsolete("Please note that API requests by city name, zip-codes and city id have been deprecated. Although they are still available for use, bug fixing and updates are no longer available for this functionality.")]
        Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            int cityId,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        /// Gets weather information for a location given its city name
        /// </summary>
        /// <param name="city">The name of the location's city</param>
        /// <param name="language">The language used for the response</param>
        /// <param name="unit">The unit of measurement for the response</param>
        /// <returns>The OpenWeatherMapServiceResponse containing the weather information</returns>
        [Obsolete("Please note that API requests by city name, zip-codes and city id have been deprecated. Although they are still available for use, bug fixing and updates are no longer available for this functionality.")]
        Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            string city,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);
    }
}