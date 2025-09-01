using System.Text.Json.Serialization;

namespace WeatherApp;

// Represents the overall JSON response from the OpenWeatherMap API.
// We use JsonPropertyName to map the JSON field (e.g., "name") to our C# property (e.g., "CityName").
// Moved to Models/WeatherResponse.cs
public class WeatherResponse
{
    [JsonPropertyName("name")]
    public string CityName { get; set; } = string.Empty;

    [JsonPropertyName("main")]
    public MainWeatherData Main { get; set; } = new();

    [JsonPropertyName("weather")]
    public List<WeatherInfo> Weather { get; set; } = new();
}
