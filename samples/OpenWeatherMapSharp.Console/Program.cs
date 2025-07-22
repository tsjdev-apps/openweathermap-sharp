using OpenWeatherMapSharp;
using OpenWeatherMapSharp.Models;
using OpenWeatherMapSharp.Models.Enums;
using Spectre.Console;

// Your OpenWeatherMap API key (replace with your actual one)
string openWeatherMapApiKey = "OWMAPIKEY";

// == HEADER ==
var headerGrid = new Grid();
headerGrid.AddColumn();
headerGrid.AddRow(new FigletText("OpenWeatherMap").Centered().Color(Color.Red));
AnsiConsole.Write(headerGrid);

// == ASK FOR CITY ==
AnsiConsole.WriteLine();
string cityName = AnsiConsole.Ask<string>("[white]Insert the name of the[/] [red]city[/][white]?[/]");
AnsiConsole.WriteLine();

// == INIT SERVICE ==
var openWeatherMapService = new OpenWeatherMapService(openWeatherMapApiKey);

// == GEOCODE ==
var geolocationResponse = await openWeatherMapService.GetLocationByNameAsync(cityName);

if (!geolocationResponse.IsSuccess || geolocationResponse.Response?.FirstOrDefault() is not GeocodeInfo geolocation)
{
    AnsiConsole.MarkupLine("[bold red]Unfortunately I can't recognize the city. Please try again.[/]");
    return;
}

// == WEATHER ==
var weatherResponse = await openWeatherMapService.GetWeatherAsync(
    geolocation.Latitude,
    geolocation.Longitude,
    unit: Unit.Metric
);

if (!weatherResponse.IsSuccess || weatherResponse.Response is not WeatherRoot weatherRoot)
{
    AnsiConsole.MarkupLine("[bold red]Unfortunately I can't retrieve weather data. Please try again.[/]");
    return;
}

var mainWeather = weatherRoot.MainWeather;

// == LOCATION PANEL ==
var locationPanel = new Panel(new Rows(new List<Markup>
{
    new($"[red]City: [/]{weatherRoot.Name}"),
    new($"[red]Latitude: [/]{weatherRoot.Coordinates.Latitude:0.0000}"),
    new($"[red]Longitude: [/]{weatherRoot.Coordinates.Longitude:0.0000}"),
    new($"[red]Country: [/]{geolocation.Country}"),
    new($"[red]State: [/]{geolocation.State ?? "[not available]"}")
}))
{
    Header = new PanelHeader("Location"),
    Width = 120
};
AnsiConsole.Write(locationPanel);

// == WEATHER PANEL ==
var weatherMarkupList = new List<Markup>
{
    new($"[red]Temperature: [/]{mainWeather.Temperature}° C"),
    new($"[red]Feels Like: [/]{mainWeather.FeelsLikeTemperature}° C"),
    new($"[red]Min Temperature: [/]{mainWeather.MinTemperature}° C"),
    new($"[red]Max Temperature: [/]{mainWeather.MaxTemperature}° C"),
    new("-----"),
    new($"[red]Pressure (Sea Level): [/]{mainWeather.Pressure} hPa"),
    new($"[red]Humidity: [/]{mainWeather.Humidity} %"),
    new($"[red]Sunrise: [/]{weatherRoot.System.Sunrise:g}"),
    new($"[red]Sunset: [/]{weatherRoot.System.Sunset:g}")
};

// Add weather descriptions
foreach (var weatherInfo in weatherRoot.WeatherInfos)
{
    weatherMarkupList.Add(new($"[red]Conditions: [/]{weatherInfo.Description}"));
}

var weatherPanel = new Panel(new Rows(weatherMarkupList))
{
    Header = new PanelHeader("Current Weather"),
    Width = 120
};
AnsiConsole.Write(weatherPanel);

Console.ReadLine();
