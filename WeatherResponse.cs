using System.Text.Json.Serialization;
using System.Collections.Generic;
using WeatherOrNot.Models;

namespace WeatherOrNot;

/// <summary>
/// Represents the overall JSON response from the OpenWeatherMap API.
/// We use JsonPropertyName to map the JSON field (e.g., "name") to our C# property (e.g., "CityName").
/// </summary>
public class WeatherResponse
{
    [JsonPropertyName("name")]
    public string CityName { get; set; } = string.Empty;

    [JsonPropertyName("main")]
    public WeatherOrNot.Models.MainWeatherData Main { get; set; } = new();

    [JsonPropertyName("weather")]
    public List<WeatherOrNot.Models.WeatherInfo> Weather { get; set; } = new();
}
