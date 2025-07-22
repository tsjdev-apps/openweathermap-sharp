using OpenWeatherMapSharp.Models;
using OpenWeatherMapSharp.Models.Enums;
using Xunit;

namespace OpenWeatherMapSharp.UnitTests;

/// <summary>
/// Integration tests for the OpenWeatherMapService using actual API requests.
/// </summary>
public class OpenWeatherMapServiceTests
{
    private const string OPENWEATHERMAPAPIKEY = "OWMAPIKEY";

    [Fact]
    public async Task BasicInvalidCredentials()
    {
        // Arrange
        OpenWeatherMapService service = new("invalid_api_key");
        string cityName = "Pforzheim";

        // Act
        OpenWeatherMapServiceResponse<WeatherRoot> serviceResponse 
            = await service.GetWeatherAsync(cityName);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.False(serviceResponse.IsSuccess);
        Assert.NotNull(serviceResponse.Error);
    }

    [Fact]
    public async Task GetWeatherByCoordinates_ShouldReturnCorrectLocation()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;

        // Act
        OpenWeatherMapServiceResponse<WeatherRoot> serviceResponse 
            = await service.GetWeatherAsync(latitude, longitude);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(latitude, serviceResponse.Response.Coordinates.Latitude);
        Assert.Equal(longitude, serviceResponse.Response.Coordinates.Longitude);
    }

    [Fact]
    public async Task GetWeatherByCityName_ShouldReturnCorrectCity()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        string cityName = "Pforzheim";

        // Act
        OpenWeatherMapServiceResponse<WeatherRoot> serviceResponse 
            = await service.GetWeatherAsync(cityName);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(cityName, serviceResponse.Response.Name);
    }

    [Fact]
    public async Task GetWeatherByCityId_ShouldReturnCorrectCity()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        int cityId = 2928810;
        string cityName = "Essen";

        // Act
        OpenWeatherMapServiceResponse<WeatherRoot> serviceResponse 
            = await service.GetWeatherAsync(cityId);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(cityName, serviceResponse.Response.Name);
    }

    [Fact]
    public async Task GetForecastByCoordinates_ShouldReturnCorrectLocation()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;

        // Act
        OpenWeatherMapServiceResponse<ForecastRoot> serviceResponse 
            = await service.GetForecastAsync(latitude, longitude);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(latitude, serviceResponse.Response.City.Coordinates.Latitude);
        Assert.Equal(longitude, serviceResponse.Response.City.Coordinates.Longitude);
    }

    [Fact]
    public async Task GetForecastByCityName_ShouldReturnCorrectCity()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        string cityName = "Pforzheim";

        // Act
        OpenWeatherMapServiceResponse<ForecastRoot> serviceResponse 
            = await service.GetForecastAsync(cityName);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(cityName, serviceResponse.Response.City.Name);
    }

    [Fact]
    public async Task GetForecastByCityId_ShouldReturnCorrectCity()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        int cityId = 2928810;
        string cityName = "Essen";

        // Act
        OpenWeatherMapServiceResponse<ForecastRoot> serviceResponse 
            = await service.GetForecastAsync(cityId);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);
        Assert.Equal(cityName, serviceResponse.Response.City.Name);
    }

    [Fact]
    public async Task GetGeolocationByName_ShouldReturnCorrectLocation()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        string name = "Pforzheim";
        string country = "DE";

        // Act
        OpenWeatherMapServiceResponse<List<GeocodeInfo>> serviceResponse 
            = await service.GetLocationByNameAsync(name);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);

        GeocodeInfo? firstResult = serviceResponse.Response.FirstOrDefault();
        Assert.NotNull(firstResult);
        Assert.Equal(name, firstResult.Name);
        Assert.Equal(country, firstResult.Country);
    }

    [Fact]
    public async Task GetGeolocationByCoordinates_ShouldReturnCorrectLocation()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;
        string cityName = "Pforzheim";
        string country = "DE";

        // Act
        OpenWeatherMapServiceResponse<List<GeocodeInfo>> serviceResponse 
            = await service.GetLocationByLatLonAsync(latitude, longitude);

        // Assert
        Assert.NotNull(serviceResponse);
        Assert.NotNull(serviceResponse.Response);
        Assert.Null(serviceResponse.Error);
        Assert.True(serviceResponse.IsSuccess);

        GeocodeInfo? firstResult = serviceResponse.Response.FirstOrDefault();
        Assert.NotNull(firstResult);
        Assert.Equal(cityName, firstResult.Name);
        Assert.Equal(country, firstResult.Country);
    }

    [Fact]
    public void Constructor_WithEmptyApiKey_ShouldNotThrowButLikelyFailAtRuntime()
    {
        // Arrange
        OpenWeatherMapService service = new("");

        // Act

        // Assert
        Assert.NotNull(service);
    }

    [Theory]
    [InlineData(LanguageCode.EN, Unit.Standard)]
    [InlineData(LanguageCode.DE, Unit.Metric)]
    [InlineData(LanguageCode.FR, Unit.Imperial)]
    public async Task GetWeather_WithDifferentLanguagesAndUnits_ShouldSucceed(LanguageCode lang, Unit unit)
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);

        // Act
        OpenWeatherMapServiceResponse<WeatherRoot> response 
            = await service.GetWeatherAsync(48.89, 8.69, lang, unit);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Response);
        Assert.Null(response.Error);
    }

    [Fact]
    public async Task GetGeolocation_WithInvalidCity_ShouldReturnEmptyResult()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);

        // Act
        OpenWeatherMapServiceResponse<List<GeocodeInfo>> response 
            = await service.GetLocationByNameAsync("NowherevilleXYZ");

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Response);
        Assert.Empty(response.Response);
    }

    [Theory]
    [InlineData(-999, 10)]
    [InlineData(91, 10)]
    [InlineData(10, -200)]
    public async Task GetWeather_WithInvalidCoordinates_ShouldFail(double lat, double lon)
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);

        // Act
        OpenWeatherMapServiceResponse<WeatherRoot> response 
            = await service.GetWeatherAsync(lat, lon);

        // Assert
        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
        Assert.NotNull(response.Error);
    }

    [Fact]
    public async Task GetAirPollution_ShouldReturnValidResponse()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;

        // Act
        OpenWeatherMapServiceResponse<AirPolutionRoot> response =
            await service.GetAirPolutionAsync(latitude, longitude);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Response);
        Assert.Null(response.Error);

        var entry = response.Response.Entries.FirstOrDefault();
        Assert.NotNull(entry);
        Assert.InRange(entry.Components.CoarseParticulateMatter, 0, 1000); // basic plausibility check
    }

    [Fact]
    public async Task GetAirPollutionForecast_ShouldReturnFutureEntries()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;

        // Act
        OpenWeatherMapServiceResponse<AirPolutionRoot> response =
            await service.GetAirPolutionForecastAsync(latitude, longitude);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Response);
        Assert.Null(response.Error);

        var first = response.Response.Entries.FirstOrDefault();
        Assert.NotNull(first);
        Assert.True(first.Date > DateTime.UtcNow.AddHours(-1));
    }

    [Fact]
    public async Task GetAirPollutionHistory_ShouldReturnEntriesInTimeRange()
    {
        // Arrange
        OpenWeatherMapService service = new(OPENWEATHERMAPAPIKEY);
        double latitude = 48.89;
        double longitude = 8.69;

        // Use a valid past time range (e.g. 3–2 days ago)
        DateTime end = DateTime.UtcNow.AddDays(-2);
        DateTime start = end.AddHours(-24);

        // Act
        OpenWeatherMapServiceResponse<AirPolutionRoot> response =
            await service.GetAirPolutionHistoryAsync(latitude, longitude, start, end);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        Assert.NotNull(response.Response);
        Assert.Null(response.Error);
        Assert.NotEmpty(response.Response.Entries);

        // Ensure all entries are within the time range
        foreach (var entry in response.Response.Entries)
        {
            Assert.InRange(entry.Date, start, end);
        }
    }
}