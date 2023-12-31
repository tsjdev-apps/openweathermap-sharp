﻿using OpenWeatherMapSharp;
using OpenWeatherMapSharp.Models;
using OpenWeatherMapSharp.Models.Enums;
using Spectre.Console;

string openWeatherMapApiKey = "OWMAPIKEY";

// HEADER
Grid headerGrid = new();
headerGrid.AddColumn();
headerGrid.AddRow(new FigletText("OpenWeatherMap").Centered().Color(Color.Red));
AnsiConsole.Write(headerGrid);

// ASK FOR CITY NAME
AnsiConsole.WriteLine();
string cityName = AnsiConsole.Ask<string>("[white]Insert the name of the[/] [red]city[/][white]?[/]");
AnsiConsole.WriteLine();

// GET WEATHER
OpenWeatherMapService openWeatherMapService = new(openWeatherMapApiKey);
var geolocationResponse = await openWeatherMapService.GetLocationByNameAsync(cityName);

if (!geolocationResponse.IsSuccess)
{
    AnsiConsole.Write("Unfortunately I can't recognize the city. Please try again.");
    Console.WriteLine();
    return;
}

var geolocations = geolocationResponse.Response;
var geolocation = geolocations.FirstOrDefault();

if (geolocation is null)
{
    AnsiConsole.Write("Unfortunately I can't recognize the city. Please try again.");
    Console.WriteLine();
    return;
}

OpenWeatherMapServiceResponse<WeatherRoot> weatherResponse = await openWeatherMapService.GetWeatherAsync(geolocation.Latitude, geolocation.Longitude, unit: Unit.Metric);

if (weatherResponse.IsSuccess)
{
    WeatherRoot weatherRoot = weatherResponse.Response;
    Main mainWeather = weatherRoot.MainWeather;

    // LOCATION
    List<Markup> locationMarkupList = new()
    {
        new Markup($"[red]City: [/]{weatherRoot.Name}"),
        new Markup($"[red]Latitude: [/]{weatherRoot.Coordinates.Latitude:0.0000}"),
        new Markup($"[red]Longitude: [/]{weatherRoot.Coordinates.Longitude:0.0000}"),
        new Markup($"[red]Country: [/]{geolocation.Country}"),
        new Markup($"[red]State: [/]{geolocation.State}")
    };
    Rows locationRows = new(locationMarkupList);
    Panel locationPanel = new(locationRows)
    {
        Header = new PanelHeader("Location"),
        Width = 120
    };
    AnsiConsole.Write(locationPanel);

    // WEATHER
    List<Markup> weatherMarkupList = new()
    {
        new Markup($"[red]Temperature: [/]{mainWeather.Temperature}° C"),
        new Markup($"[red]Temperature (Feels Like): [/]{mainWeather.FeelsLikeTemperature}° C"),
        new Markup($"[red]Minimal Temperature: [/]{mainWeather.MinTemperature}° C"),
        new Markup($"[red]Maximal Temperature: [/]{mainWeather.MaxTemperature}° C"),
        new Markup("-----"),
        new Markup($"[red]Pressure Sea Level hPa: [/]{mainWeather.Pressure} hPa"),
        new Markup($"[red]Humidity: [/]{mainWeather.Humidity} %"),
        new Markup($"[red]Sunrise: [/]{weatherRoot.System.Sunrise:g}"),
        new Markup($"[red]Sunset: [/]{weatherRoot.System.Sunset:g}")
    };
    foreach (WeatherInfo weatherInfo in weatherRoot.WeatherInfos)
    {
        weatherMarkupList.Add(new Markup($"[red]Current Conditions: [/]{weatherInfo.Description}"));
    }
    Rows currentWeatherRows = new(weatherMarkupList);
    Panel currentWeatherPanel = new(currentWeatherRows)
    {
        Header = new PanelHeader("Current Weather"),
        Width = 120
    };
    AnsiConsole.Write(currentWeatherPanel);
}
else
{
    AnsiConsole.Write("Unfortunately I can't recognize the city. Please try again.");
}

Console.ReadLine();