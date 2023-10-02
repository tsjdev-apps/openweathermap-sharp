namespace OpenWeatherMapSharp.Utils
{
    internal static class Statics
    {
        private static readonly string BaseUri = "https://api.openweathermap.org";
        private static readonly string WeatherBaseUri = $"{BaseUri}/data/2.5/weather";
        private static readonly string ForecastBaseUri = $"{BaseUri}/data/2.5/forecast";
        private static readonly string GeocodeBaseUri = $"{BaseUri}/geo/1.0";

        public static readonly string WeatherCoordinatesUri
            = WeatherBaseUri + "?lat={0}&lon={1}&units={2}&lang={3}&appid={4}";

        public static readonly string WeatherCityUri
            = WeatherBaseUri + "?q={0}&units={1}&lang={2}&appid={3}";

        public static readonly string WeatherIdUri
            = WeatherBaseUri + "?id={0}&units={1}&lang={2}&appid={3}";

        public static readonly string ForecastCoordinatesUri
            = ForecastBaseUri + "?lat={0}&lon={1}&units={2}&lang={3}&appid={4}";
        
        public static readonly string ForecastCityUri
            = ForecastBaseUri + "?q={0}&units={1}&lang={2}&appid={3}";

        public static readonly string ForecastIdUri
            = ForecastBaseUri + "?id={0}&units={1}&lang={2}&appid={3}";

        public static readonly string GeocodeLocationUri
            = GeocodeBaseUri + "/direct?q={0}&limit={1}&appid={2}";

        public static readonly string GeocodeZipUri
            = GeocodeBaseUri + "/zip?zip={0}&appid={1}";

        public static readonly string GeocodeReverseUri
            = GeocodeBaseUri + "/reverse?lat={0}&lon={1}&limit={2}&appid={3}";
    }
}
