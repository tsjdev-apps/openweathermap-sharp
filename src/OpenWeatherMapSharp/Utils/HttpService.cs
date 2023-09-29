using Newtonsoft.Json;
using OpenWeatherMapSharp.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherMapSharp.Utils
{
    internal static class HttpService
    {
        internal static async Task<OpenWeatherMapServiceResponse<TClass>> GetDataAsync<TClass>(string url) where TClass : class
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var json = await client.GetStringAsync(url);

                    if (string.IsNullOrWhiteSpace(json))
                    {
                        return null;
                    }

                    return new OpenWeatherMapServiceResponse<TClass>
                    {
                        IsSuccess = true,
                        Response = JsonConvert.DeserializeObject<TClass>(json)
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
