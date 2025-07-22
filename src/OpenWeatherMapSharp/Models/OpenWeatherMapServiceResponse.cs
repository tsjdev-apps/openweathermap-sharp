namespace OpenWeatherMapSharp.Models
{
    /// <summary>
    /// Generic wrapper for responses returned 
    /// by the OpenWeatherMapService.
    /// Encapsulates success status, 
    /// response data, and potential error messages.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the response object.
    /// </typeparam>
    public class OpenWeatherMapServiceResponse<T>
        where T : class
    {
        /// <summary>
        /// Indicates whether the request 
        /// was successful.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// The response object returned by 
        /// the service if the request was successful.
        /// </summary>
        public T Response { get; set; }

        /// <summary>
        /// Error message or details 
        /// if the request failed.
        /// </summary>
        public string Error { get; set; }
    }
}
