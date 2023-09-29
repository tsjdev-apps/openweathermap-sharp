using OpenWeatherMapSharp.Models;
using OpenWeatherMapSharp.Models.Enums;
using OpenWeatherMapSharp.Utils;
using System;
using System.Threading.Tasks;

namespace OpenWeatherMapSharp
{
    /// <summary>
    ///     This class is used to communicate with the Open Weather Map API
    /// </summary>
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly string _apiKey;

        /// <summary>
        ///     Create an instance of the OpenWeatherMapService.
        /// </summary>
        /// <param name="apiKey"></param>
        public OpenWeatherMapService(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            double latitude,
            double longitude,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            var url = string.Format(Statics.WeatherCoordinatesUri, latitude, longitude, unit.ToString().ToLower(), language.ToString().ToLower(), _apiKey);
            return await HttpService.GetDataAsync<WeatherRoot>(url);
        }

        /// <inheritdoc/>
        [Obsolete("Please note that API requests by city name, zip-codes and city id have been deprecated. Although they are still available for use, bug fixing and updates are no longer available for this functionality.")]
        public async Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            string city,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            var url = string.Format(Statics.WeatherCityUri, city, unit.ToString().ToLower(), language.ToString().ToLower(), _apiKey);
            return await HttpService.GetDataAsync<WeatherRoot>(url);
        }

        /// <inheritdoc/>
        [Obsolete("Please note that API requests by city name, zip-codes and city id have been deprecated. Although they are still available for use, bug fixing and updates are no longer available for this functionality.")]
        public async Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            int cityId,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            var url = string.Format(Statics.WeatherIdUri, cityId, unit.ToString().ToLower(), language.ToString().ToLower(), _apiKey);
            return await HttpService.GetDataAsync<WeatherRoot>(url);
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            double latitude,
            double longitude,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            var url = string.Format(Statics.ForecastCoordinatesUri, latitude, longitude, unit.ToString().ToLower(), language.ToString().ToLower(), _apiKey);
            return await HttpService.GetDataAsync<ForecastRoot>(url);
        }

        /// <inheritdoc/>
        [Obsolete("Please note that API requests by city name, zip-codes and city id have been deprecated. Although they are still available for use, bug fixing and updates are no longer available for this functionality.")]
        public async Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            string city,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            var url = string.Format(Statics.ForecastCityUri, city, unit.ToString().ToLower(), language.ToString().ToLower(), _apiKey);
            return await HttpService.GetDataAsync<ForecastRoot>(url);
        }

        /// <inheritdoc/>
        [Obsolete("Please note that API requests by city name, zip-codes and city id have been deprecated. Although they are still available for use, bug fixing and updates are no longer available for this functionality.")]
        public async Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            int id,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            var url = string.Format(Statics.ForecastIdUri, id, unit.ToString().ToLower(), language.ToString().ToLower(), _apiKey);
            return await HttpService.GetDataAsync<ForecastRoot>(url);
        }
    }
}
