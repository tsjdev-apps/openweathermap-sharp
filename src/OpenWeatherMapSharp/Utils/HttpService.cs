using OpenWeatherMapSharp.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenWeatherMapSharp.Utils
{
    /// <summary>
    /// Provides internal HTTP functionality 
    /// for retrieving and deserializing 
    /// OpenWeatherMap API responses.
    /// </summary>
    internal static class HttpService
    {
        private static readonly JsonSerializerOptions defaultJsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Sends an HTTP GET request to the 
        /// specified URL and deserializes the 
        /// JSON response into the specified class.
        /// </summary>
        /// <typeparam name="TClass">
        /// The type to deserialize the response into.
        /// </typeparam>
        /// <param name="url">
        /// The URL to send the request to.</param>
        /// <returns>
        /// A task representing the asynchronous operation. 
        /// The result contains a wrapped response with 
        /// either data or an error message.
        /// </returns>
        internal static async Task<OpenWeatherMapServiceResponse<TClass>> GetDataAsync<TClass>(string url) where TClass : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return new OpenWeatherMapServiceResponse<TClass>
                        {
                            IsSuccess = false,
                            Error = "Empty response received from server."
                        };
                    }

                    return new OpenWeatherMapServiceResponse<TClass>
                    {
                        IsSuccess = true,
                        Response = JsonSerializer.Deserialize<TClass>(json, defaultJsonSerializerOptions)
                    };
                }
                catch (Exception ex)
                {
                    return new OpenWeatherMapServiceResponse<TClass>
                    {
                        IsSuccess = false,
                        Error = ex.Message
                    };
                }
            }
        }
    }
}
