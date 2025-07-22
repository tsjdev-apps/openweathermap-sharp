using OpenWeatherMapSharp.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenWeatherMapSharp.Utils
{
    internal static class HttpService
    {
        private static readonly JsonSerializerOptions defaultJsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        internal static async Task<OpenWeatherMapServiceResponse<TClass>> GetDataAsync<TClass>(string url) where TClass : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return null;
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
