using OpenWeatherMapSharp;
using OpenWeatherMapSharp.Models;
using OpenWeatherMapSharp.Models.Enums;
using Spectre.Console;

// Your OpenWeatherMap API key (replace with your actual one)
string openWeatherMapApiKey = "OWMAPIKEY";

// == HEADER ==
Grid headerGrid = new();
headerGrid.AddColumn();
headerGrid.AddRow(new FigletText("OpenWeatherMap").Centered().Color(Color.Red));
AnsiConsole.Write(headerGrid);

// == ASK FOR CITY ==
AnsiConsole.WriteLine();
string cityName = AnsiConsole.Ask<string>("[white]Insert the name of the[/] [red]city[/][white]?[/]");
AnsiConsole.WriteLine();

// == INIT SERVICE ==
OpenWeatherMapService openWeatherMapService = new(openWeatherMapApiKey);

// == GEOCODE ==
OpenWeatherMapServiceResponse<List<GeocodeInfo>> geolocationResponse 
    = await openWeatherMapService.GetLocationByNameAsync(cityName);

if (!geolocationResponse.IsSuccess || geolocationResponse.Response?.FirstOrDefault() is not GeocodeInfo geolocation)
{
    AnsiConsole.MarkupLine("[bold red]Unfortunately I can't recognize the city. Please try again.[/]");
    return;
}

// == WEATHER ==
OpenWeatherMapServiceResponse<WeatherRoot> weatherResponse 
    = await openWeatherMapService.GetWeatherAsync(
        geolocation.Latitude,
        geolocation.Longitude,
        unit: Unit.Metric);

if (!weatherResponse.IsSuccess || weatherResponse.Response is not WeatherRoot weatherRoot)
{
    AnsiConsole.MarkupLine("[bold red]Unfortunately I can't retrieve weather data. Please try again.[/]");
    return;
}

Main mainWeather = weatherRoot.MainWeather;

// == LOCATION PANEL ==
Panel locationPanel = new(new Rows(new List<Markup>
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
List<Markup> weatherMarkupList =
[
    new($"[red]Temperature: [/]{mainWeather.Temperature}° C"),
    new($"[red]Feels Like: [/]{mainWeather.FeelsLikeTemperature}° C"),
    new($"[red]Min Temperature: [/]{mainWeather.MinTemperature}° C"),
    new($"[red]Max Temperature: [/]{mainWeather.MaxTemperature}° C"),
    new("-----"),
    new($"[red]Pressure (Sea Level): [/]{mainWeather.Pressure} hPa"),
    new($"[red]Humidity: [/]{mainWeather.Humidity} %"),
    new($"[red]Sunrise: [/]{weatherRoot.System.Sunrise:g}"),
    new($"[red]Sunset: [/]{weatherRoot.System.Sunset:g}")
];

// Add weather descriptions
foreach (WeatherInfo? weatherInfo in weatherRoot.WeatherInfos)
{
    weatherMarkupList.Add(new($"[red]Conditions: [/]{weatherInfo.Description}"));
}

Panel weatherPanel = new(new Rows(weatherMarkupList))
{
    Header = new PanelHeader("Current Weather"),
    Width = 120
};
AnsiConsole.Write(weatherPanel);

// == AIR POLLUTION ==
OpenWeatherMapServiceResponse<AirPollutionRoot> airPollutionResponse
    = await openWeatherMapService.GetAirPollutionAsync(geolocation.Latitude, geolocation.Longitude);

if (!airPollutionResponse.IsSuccess || airPollutionResponse.Response is not AirPollutionRoot airQuality || airQuality.Entries.Count == 0)
{
    AnsiConsole.MarkupLine("[bold red]Unfortunately I can't retrieve air pollution data. Please try again.[/]");
    return;
}

AirPollutionEntry pollution = airQuality.Entries.First();

// Map AQI to meaning
string GetAqiMeaning(int aqi) => aqi switch
{
    1 => "[green]Good[/]",
    2 => "[yellow]Fair[/]",
    3 => "[orange1]Moderate[/]",
    4 => "[red]Poor[/]",
    5 => "[maroon]Very Poor[/]",
    _ => "[grey]Unknown[/]"
};

// == AIR POLLUTION PANEL ==
List<Markup> pollutionMarkupList =
[
    new($"[red]Air Quality Index (AQI): [/]{pollution.AQI.Index} ({GetAqiMeaning(pollution.AQI.Index)})"),
    new("-----"),
    new($"[red]PM2.5: [/]{pollution.Components.FineParticlesMatter:0.00} µg/m³"),
    new($"[red]PM10: [/]{pollution.Components.CoarseParticulateMatter:0.00} µg/m³"),
    new($"[red]O₃ (Ozone): [/]{pollution.Components.Ozone:0.00} µg/m³"),
    new($"[red]NO₂ (Nitrogen Dioxide): [/]{pollution.Components.NitrogenDioxide:0.00} µg/m³"),
    new($"[red]SO₂ (Sulfur Dioxide): [/]{pollution.Components.SulfurDioxide:0.00} µg/m³"),
    new($"[red]CO (Carbon Monoxide): [/]{pollution.Components.CarbonMonoxide:0.00} µg/m³"),
    new($"[red]NH₃ (Ammonia): [/]{pollution.Components.Ammonia:0.00} µg/m³")
];

Panel pollutionPanel = new(new Rows(pollutionMarkupList))
{
    Header = new PanelHeader("Air Pollution"),
    Width = 120
};
AnsiConsole.Write(pollutionPanel);


Console.ReadLine();
