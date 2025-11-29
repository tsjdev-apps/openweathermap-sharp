using OpenWeatherMapSharp.Models;
using OpenWeatherMapSharp.Models.Enums;
using OpenWeatherMapSharp.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenWeatherMapSharp
{
    /// <summary>
    /// Provides access to the OpenWeatherMap API 
    /// for retrieving weather and geolocation data.
    /// </summary>
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly string _apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenWeatherMapService"/> class with the specified API key.
        /// </summary>
        /// <param name="apiKey">Your OpenWeatherMap API key.</param>
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
            string url = string.Format(
                Statics.WeatherCoordinatesUri,
                latitude,
                longitude,
                unit.ToString("G").ToLowerInvariant(),
                language.ToString("G").ToLowerInvariant(),
                _apiKey);

            return await HttpService.GetDataAsync<WeatherRoot>(url);
        }

        /// <inheritdoc/>
        [Obsolete("API requests by city name, ZIP code, and city ID are deprecated. They are still supported, but no longer maintained or updated.")]
        public async Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            string city,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            string url = string.Format(
                Statics.WeatherCityUri,
                city,
                unit.ToString("G").ToLowerInvariant(),
                language.ToString("G").ToLowerInvariant(),
                _apiKey);

            return await HttpService.GetDataAsync<WeatherRoot>(url);
        }

        /// <inheritdoc/>
        [Obsolete("API requests by city name, ZIP code, and city ID are deprecated. They are still supported, but no longer maintained or updated.")]
        public async Task<OpenWeatherMapServiceResponse<WeatherRoot>> GetWeatherAsync(
            int cityId,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            string url = string.Format(
                Statics.WeatherIdUri,
                cityId,
                unit.ToString("G").ToLowerInvariant(),
                language.ToString("G").ToLowerInvariant(),
                _apiKey);

            return await HttpService.GetDataAsync<WeatherRoot>(url);
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            double latitude,
            double longitude,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            string url = string.Format(
                Statics.ForecastCoordinatesUri,
                latitude,
                longitude,
                unit.ToString("G").ToLowerInvariant(),
                language.ToString("G").ToLowerInvariant(),
                _apiKey);

            return await HttpService.GetDataAsync<ForecastRoot>(url);
        }

        /// <inheritdoc/>
        [Obsolete("API requests by city name, ZIP code, and city ID are deprecated. They are still supported, but no longer maintained or updated.")]
        public async Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            string city,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            string url = string.Format(
                Statics.ForecastCityUri,
                city,
                unit.ToString("G").ToLowerInvariant(),
                language.ToString("G").ToLowerInvariant(),
                _apiKey);

            return await HttpService.GetDataAsync<ForecastRoot>(url);
        }

        /// <inheritdoc/>
        [Obsolete("API requests by city name, ZIP code, and city ID are deprecated. They are still supported, but no longer maintained or updated.")]
        public async Task<OpenWeatherMapServiceResponse<ForecastRoot>> GetForecastAsync(
            int id,
            LanguageCode language = LanguageCode.EN,
            Unit unit = Unit.Standard)
        {
            string url = string.Format(
                Statics.ForecastIdUri,
                id,
                unit.ToString("G").ToLowerInvariant(),
                language.ToString("G").ToLowerInvariant(),
                _apiKey);

            return await HttpService.GetDataAsync<ForecastRoot>(url);
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<List<GeocodeInfo>>> GetLocationByNameAsync(string query, int limit = 5)
        {
            string url = string.Format(Statics.GeocodeLocationUri, query, limit, _apiKey);
            return await HttpService.GetDataAsync<List<GeocodeInfo>>(url);
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<GeocodeZipInfo>> GetLocationByZipAsync(string zipCode)
        {
            string url = string.Format(Statics.GeocodeZipUri, zipCode, _apiKey);
            return await HttpService.GetDataAsync<GeocodeZipInfo>(url);
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<List<GeocodeInfo>>> GetLocationByLatLonAsync(double latitude, double longitude, int limit = 5)
        {
            string url = string.Format(Statics.GeocodeReverseUri, latitude, longitude, limit, _apiKey);
            return await HttpService.GetDataAsync<List<GeocodeInfo>>(url);
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<AirPollutionRoot>> GetAirPollutionAsync(double latitude, double longitude)
        {
            string url = string.Format(Statics.AirPollutionCoordinatesUri, latitude, longitude, _apiKey);
            return await HttpService.GetDataAsync<AirPollutionRoot>(url);
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<AirPollutionRoot>> GetAirPollutionForecastAsync(double latitude, double longitude)
        {
            string url = string.Format(Statics.AirPollutionCoordinatesForecastUri, latitude, longitude, _apiKey);
            return await HttpService.GetDataAsync<AirPollutionRoot>(url);
        }

        /// <inheritdoc/>
        public async Task<OpenWeatherMapServiceResponse<AirPollutionRoot>> GetAirPollutionHistoryAsync(double latitude, double longitude, DateTime start, DateTime end)
        {
            string url = string.Format(Statics.AirPollutionCoordinatesHistoryUri, latitude, longitude, start.ToUnixTimestamp(), end.ToUnixTimestamp(), _apiKey);
            return await HttpService.GetDataAsync<AirPollutionRoot>(url);
        }
    }
}
