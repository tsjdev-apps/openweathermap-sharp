namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    ///     Wrapper for the OpenWeatherMapService response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OpenWeatherMapServiceResponse<T> where T : class
    {
        /// <summary>
        ///     Indicates if the request was successful
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Contains the provided response object
        /// </summary>
        public T Response { get; set; }

        /// <summary>
        ///     Error information
        /// </summary>
        public string Error { get; set; }
    }
}
