namespace OpenWeatherMapSharp.Utils
{
    internal static class Statics
    {
        private static readonly string BaseUri = "https://api.openweathermap.org/data/2.5";
        private static readonly string WeatherBaseUri = $"{BaseUri}/weather";
        private static readonly string ForecastBaseUri = $"{BaseUri}/forecast";

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
    }
}
