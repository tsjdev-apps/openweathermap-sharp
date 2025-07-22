using OpenWeatherMapSharp.Models;
using OpenWeatherMapSharp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWeatherMapSharp
{
    /// <summary>
    /// Defines the contract for communicating with the OpenWeatherMap API.
    /// </summary>
    public interface IOpenWeatherMapService
    {
        /// <summary>
        /// Gets forecast data for a location based 
        /// on its geographic coordinates.
        /// </summary>
        /// <param name="latitude">Latitude of the location.</param>
        /// <param name="longitude">Longitude of the location.</param>
        /// <param name="language">Language of the response (default: English).</param>
        /// <param name="unit">Unit of measurement (default: Standard).</param>
        /// <returns>A forecast response wrapped in <see cref="OpenWeatherMapServiceResponse{T}"/>.</returns>
        Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            double latitude,
            double longitude,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        /// Gets forecast data based on a city ID.
        /// </summary>
        /// <param name="cityId">The city ID.</param>
        /// <param name="language">Language of the response.</param>
        /// <param name="unit">Unit of measurement.</param>
        /// <returns>A forecast response wrapped in <see cref="OpenWeatherMapServiceResponse{T}"/>.</returns>
        [Obsolete("API requests by city name, zip-code, and city ID are deprecated and no longer maintained.")]
        Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            int cityId,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        /// Gets forecast data based on a city name.
        /// </summary>
        /// <param name="city">The city name.</param>
        /// <param name="language">Language of the response.</param>
        /// <param name="unit">Unit of measurement.</param>
        /// <returns>A forecast response wrapped in <see cref="OpenWeatherMapServiceResponse{T}"/>.</returns>
        [Obsolete("API requests by city name, zip-code, and city ID are deprecated and no longer maintained.")]
        Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            string city,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        /// Gets current weather data for a location based on its geographic coordinates.
        /// </summary>
        /// <param name="latitude">Latitude of the location.</param>
        /// <param name="longitude">Longitude of the location.</param>
        /// <param name="language">Language of the response (default: English).</param>
        /// <param name="unit">Unit of measurement (default: Standard).</param>
        /// <returns>A weather response wrapped in <see cref="OpenWeatherMapServiceResponse{T}"/>.</returns>
        Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            double latitude,
            double longitude,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        /// Gets current weather data based on a city ID.
        /// </summary>
        /// <param name="cityId">The city ID.</param>
        /// <param name="language">Language of the response.</param>
        /// <param name="unit">Unit of measurement.</param>
        /// <returns>A weather response wrapped in <see cref="OpenWeatherMapServiceResponse{T}"/>.</returns>
        [Obsolete("API requests by city name, zip-code, and city ID are deprecated and no longer maintained.")]
        Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            int cityId,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        /// Gets current weather data based on a city name.
        /// </summary>
        /// <param name="city">The city name.</param>
        /// <param name="language">Language of the response.</param>
        /// <param name="unit">Unit of measurement.</param>
        /// <returns>A weather response wrapped in <see cref="OpenWeatherMapServiceResponse{T}"/>.</returns>
        [Obsolete("API requests by city name, zip-code, and city ID are deprecated and no longer maintained.")]
        Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            string city,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard);

        /// <summary>
        /// Gets a list of matching locations for a given query string.
        /// </summary>
        /// <param name="query">The location name or part of it to search for.</param>
        /// <param name="limit">The maximum number of results to return (default: 5).</param>
        /// <returns>A response with a list of matching <see cref="GeocodeInfo"/> objects.</returns>
        Task<OpenWeatherMapServiceResponse<List<GeocodeInfo>>> GetLocationByNameAsync(
            string query,
            int limit = 5);

        /// <summary>
        /// Gets geolocation information based on a ZIP or postal code.
        /// </summary>
        /// <param name="zipCode">The ZIP/postal code to search for.</param>
        /// <returns>A response containing a <see cref="GeocodeZipInfo"/> object.</returns>
        Task<OpenWeatherMapServiceResponse<GeocodeZipInfo>> GetLocationByZipAsync(
            string zipCode);

        /// <summary>
        /// Gets a list of matching locations for a given pair of coordinates.
        /// </summary>
        /// <param name="latitude">Latitude of the location.</param>
        /// <param name="longitude">Longitude of the location.</param>
        /// <param name="limit">The maximum number of results to return (default: 5).</param>
        /// <returns>A response with a list of <see cref="GeocodeInfo"/> objects.</returns>
        Task<OpenWeatherMapServiceResponse<List<GeocodeInfo>>> GetLocationByLatLonAsync(
            double latitude,
            double longitude,
            int limit = 5);
    }
}
