using OpenWeatherMapSharp.Models;
using Xunit;

namespace OpenWeatherMapSharp.UnitTests;

public class OpenWeatherMapServiceTests
{
    private const string OPENWEATHERMAPAPIKEY = "OWMAPIKEY";


    [Fact]
    public async Task BasicInvalidCredentials()
    {
        // arrange
        OpenWeatherMapService service = new("apikey");
        string cityName = "Pforzheim";

        // act
        OpenWeatherMapServiceResponse<WeatherRoot> serviceResponse = await service.GetWeatherAsync(cityName);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.False(serviceResponse.IsSuccess);
        Assert.NotNull(serviceResponse.Error);
    }


    [Fact]
    public async Task GetWeatherLocationTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;

        // act
        OpenWeatherMapServiceResponse<WeatherRoot> serviceResponse = await service.GetWeatherAsync(latitude, longitude);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(serviceResponse.Response.Coordinates.Latitude, latitude);
        Assert.Equal(serviceResponse.Response.Coordinates.Longitude, longitude);
    }

    [Fact]
    public async Task GetWeatherCityNameTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        string cityName = "Pforzheim";

        // act
        OpenWeatherMapServiceResponse<WeatherRoot> serviceResponse = await service.GetWeatherAsync(cityName);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(serviceResponse.Response.Name, cityName);
    }

    [Fact]
    public async Task GetWeatherCityIdTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        int cityId = 2928810;
        string cityName = "Essen";

        // act
        OpenWeatherMapServiceResponse<WeatherRoot> serviceResponse = await service.GetWeatherAsync(cityId);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(serviceResponse.Response.Name, cityName);
    }


    [Fact]
    public async Task GetForecastLocationTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;

        // act
        OpenWeatherMapServiceResponse<ForecastRoot> serviceResponse = await service.GetForecastAsync(latitude, longitude);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(serviceResponse.Response.City.Coordinates.Latitude, latitude);
        Assert.Equal(serviceResponse.Response.City.Coordinates.Longitude, longitude);
    }

    [Fact]
    public async Task GetForecastCityNameTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        string cityName = "Pforzheim";

        // act
        OpenWeatherMapServiceResponse<ForecastRoot> serviceResponse = await service.GetForecastAsync(cityName);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(serviceResponse.Response.City.Name, cityName);
    }

    [Fact]
    public async Task GetForecastCityIdTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        int cityId = 2928810;
        string cityName = "Essen";

        // act
        OpenWeatherMapServiceResponse<ForecastRoot> serviceResponse = await service.GetForecastAsync(cityId);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(serviceResponse.Response.City.Name, cityName);
    }


    [Fact]
    public async Task GetGeolocationFromNameTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        string name = "Pforzheim";
        string country = "DE";

        // act
        OpenWeatherMapServiceResponse<List<GeocodeInfo>> serviceResponse = await service.GetLocationByNameAsync(name);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);

        GeocodeInfo? firstCountry = serviceResponse.Response.FirstOrDefault();
        Assert.NotNull(firstCountry);
        Assert.Equal(name, firstCountry.Name);
        Assert.Equal(country, firstCountry.Country);
    }

    [Fact]
    public async Task GetGeolocationFromZipTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        string zipCode = "75173";
        string cityName = "Pforzheim";
        string country = "DE";

        // act
        OpenWeatherMapServiceResponse<GeocodeZipInfo> serviceResponse = await service.GetLocationByZipAsync($"{zipCode},{country}");

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(zipCode, serviceResponse.Response.ZipCode);
        Assert.Equal(cityName, serviceResponse.Response.Name);
        Assert.Equal(country, serviceResponse.Response.Country);
    }

    [Fact]
    public async Task GetGeolocationFromLatLonTest()
    {
        // arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;
        string cityName = "Pforzheim";
        string country = "DE";

        // act
        OpenWeatherMapServiceResponse<List<GeocodeInfo>> serviceResponse = await service.GetLocationByLatLonAsync(latitude, longitude);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);

        GeocodeInfo? firstCountry = serviceResponse.Response.FirstOrDefault();
        Assert.NotNull(firstCountry);
        Assert.Equal(cityName, firstCountry.Name);
        Assert.Equal(country, firstCountry.Country);
    }
}