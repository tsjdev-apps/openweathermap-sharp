namespace OpenWeatherMapSharp.UnitTests;

public class OpenWeatherMapServiceTests
{
    private const string OPENWEATHERMAPAPIKEY = "OWMAPIKEY";

    [Fact]
    public async Task BasicInvalidCredentials()
    {
        // arrange
        var service = new OpenWeatherMapService("apikey");
        var cityName = "Pforzheim";

        // act
        var serviceResponse = await service.GetWeatherAsync(cityName);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.False(serviceResponse.IsSuccess);
        Assert.NotNull(serviceResponse.Error);
    }

    [Fact]
    public async Task GetWeatherLocationTest()
    {
        // arrange
        var service = new OpenWeatherMapService(OPENWEATHERMAPAPIKEY);
        var latitude = 48.89;
        var longitude = 8.69;

        // act
        var serviceResponse = await service.GetWeatherAsync(latitude, longitude);

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
        var service = new OpenWeatherMapService(OPENWEATHERMAPAPIKEY);
        var cityName = "Pforzheim";

        // act
        var serviceResponse = await service.GetWeatherAsync(cityName);

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
        var service = new OpenWeatherMapService(OPENWEATHERMAPAPIKEY);
        var cityId = 2928810;
        var cityName = "Essen";

        // act
        var serviceResponse = await service.GetWeatherAsync(cityId);

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
        var service = new OpenWeatherMapService(OPENWEATHERMAPAPIKEY);
        var latitude = 48.89;
        var longitude = 8.69;

        // act
        var serviceResponse = await service.GetForecastAsync(latitude, longitude);

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
        var service = new OpenWeatherMapService(OPENWEATHERMAPAPIKEY);
        var cityName = "Pforzheim";

        // act
        var serviceResponse = await service.GetForecastAsync(cityName);

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
        var service = new OpenWeatherMapService(OPENWEATHERMAPAPIKEY);
        var cityId = 2928810;
        var cityName = "Essen";

        // act
        var serviceResponse = await service.GetForecastAsync(cityId);

        // assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(serviceResponse.Response.City.Name, cityName);
    }
}