using System;

namespace OpenWeatherMapSharp.Utils
{
    /// <summary>
    /// Provides extension methods for converting 
    /// a <see cref="DateTime"/> to a Unix timestamps.
    /// </summary>
    internal static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a DateTime object to a Unix timestamp (seconds since 1970-01-01T00:00:00Z).
        /// </summary>
        /// <param name="dateTime">The DateTime to convert. 
        /// Should be in UTC or convertible to UTC.</param>
        /// <returns>The Unix timestamp in seconds.</returns>
        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            // Ensure the DateTime is in UTC
            var utcDateTime = dateTime.Kind == DateTimeKind.Utc
                ? dateTime
                : dateTime.ToUniversalTime();

            return new DateTimeOffset(utcDateTime).ToUnixTimeSeconds();
        }
    }
}
