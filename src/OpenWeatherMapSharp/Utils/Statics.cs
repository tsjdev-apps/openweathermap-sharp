namespace OpenWeatherMapSharp.Utils
{
    /// <summary>
    /// Contains static URI templates for accessing various OpenWeatherMap API endpoints.
    /// </summary>
    internal static class Statics
    {
        private static readonly string BaseUri 
            = "https://api.openweathermap.org";

        private static readonly string WeatherBaseUri 
            = $"{BaseUri}/data/2.5/weather";

        private static readonly string ForecastBaseUri 
            = $"{BaseUri}/data/2.5/forecast";

        private static readonly string GeocodeBaseUri 
            = $"{BaseUri}/geo/1.0";

        private static readonly string AirPollutionBaseUri 
            = $"{BaseUri}/data/2.5/air_pollution";


        /// <summary>
        /// Weather by geographic coordinates (latitude, longitude).
        /// Format: lat={0}&lon={1}&units={2}&lang={3}&appid={4}
        /// </summary>
        public static readonly string WeatherCoordinatesUri 
            = WeatherBaseUri + "?lat={0}&lon={1}&units={2}&lang={3}&appid={4}";

        /// <summary>
        /// Weather by city name.
        /// Format: q={0}&units={1}&lang={2}&appid={3}
        /// </summary>
        public static readonly string WeatherCityUri 
            = WeatherBaseUri + "?q={0}&units={1}&lang={2}&appid={3}";

        /// <summary>
        /// Weather by city ID.
        /// Format: id={0}&units={1}&lang={2}&appid={3}
        /// </summary>
        public static readonly string WeatherIdUri 
            = WeatherBaseUri + "?id={0}&units={1}&lang={2}&appid={3}";

        /// <summary>
        /// Forecast by geographic coordinates.
        /// Format: lat={0}&lon={1}&units={2}&lang={3}&appid={4}
        /// </summary>
        public static readonly string ForecastCoordinatesUri 
            = ForecastBaseUri + "?lat={0}&lon={1}&units={2}&lang={3}&appid={4}";

        /// <summary>
        /// Forecast by city name.
        /// Format: q={0}&units={1}&lang={2}&appid={3}
        /// </summary>
        public static readonly string ForecastCityUri 
            = ForecastBaseUri + "?q={0}&units={1}&lang={2}&appid={3}";

        /// <summary>
        /// Forecast by city ID.
        /// Format: id={0}&units={1}&lang={2}&appid={3}
        /// </summary>
        public static readonly string ForecastIdUri 
            = ForecastBaseUri + "?id={0}&units={1}&lang={2}&appid={3}";

        /// <summary>
        /// Geocoding by location name.
        /// Format: q={0}&limit={1}&appid={2}
        /// </summary>
        public static readonly string GeocodeLocationUri 
            = GeocodeBaseUri + "/direct?q={0}&limit={1}&appid={2}";

        /// <summary>
        /// Geocoding by ZIP/postal code.
        /// Format: zip={0}&appid={1}
        /// </summary>
        public static readonly string GeocodeZipUri 
            = GeocodeBaseUri + "/zip?zip={0}&appid={1}";

        /// <summary>
        /// Reverse geocoding by geographic coordinates.
        /// Format: lat={0}&lon={1}&limit={2}&appid={3}
        /// </summary>
        public static readonly string GeocodeReverseUri 
            = GeocodeBaseUri + "/reverse?lat={0}&lon={1}&limit={2}&appid={3}";

        /// <summary>
        /// Air pollution data by geographic coordinates.
        /// Format: lat={0}&lon={1}&appid={2}
        /// </summary>
        public static readonly string AirPollutionCoordinatesUri 
            = AirPollutionBaseUri + "?lat={0}&lon={1}&appid={2}";

        /// <summary>
        /// Air pollution forecast by geographic coordinates.
        /// Format: lat={0}&lon={1}&start={2}&end={3}&appid={4}
        /// </summary>
        public static readonly string AirPollutionCoordinatesForecastUri 
            = AirPollutionBaseUri + "/forecast?lat={0}&lon={1}&appid={2}";

        /// <summary>
        /// Air pollution history by geographic coordinates.
        /// Format: lat={0}&lon={1}&start={2}&end={3}&appid={4}
        /// </summary>
        public static readonly string AirPollutionCoordinatesHistoryUri 
            = AirPollutionBaseUri + "/history?lat={0}&lon={1}&start={2}&end={3}&appid={4}";
    }
}
