using System.Text.Json.Serialization;
using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp;

/// <summary>
/// Represents the overall JSON response from the OpenWeatherMap API.
/// We use JsonPropertyName to map the JSON field (e.g., "name") to our C# property (e.g., "CityName").
/// </summary>
public class WeatherResponse
{
    [JsonPropertyName("name")]
    public string CityName { get; set; } = string.Empty;

    [JsonPropertyName("main")]
    public WeatherApp.Models.MainWeatherData Main { get; set; } = new();

    [JsonPropertyName("weather")]
    public List<WeatherApp.Models.WeatherInfo> Weather { get; set; } = new();
}
