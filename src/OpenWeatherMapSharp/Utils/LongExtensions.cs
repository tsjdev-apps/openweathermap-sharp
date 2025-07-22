using System;

namespace OpenWeatherMapSharp.Utils
{
    /// <summary>
    /// Provides extension methods for 
    /// converting Unix timestamps to <see cref="DateTime"/>.
    /// </summary>
    internal static class LongExtensions
    {
        /// <summary>
        /// Converts a Unix timestamp 
        /// (seconds since 1970-01-01 UTC) 
        /// to a local <see cref="DateTime"/>.
        /// </summary>
        /// <param name="unixTimeStamp">
        /// The Unix timestamp to convert.</param>
        /// <returns>
        /// A <see cref="DateTime"/> object representing 
        /// the universal time.
        /// </returns>
        internal static DateTime ToDateTime(this long unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
        }
    }
}
