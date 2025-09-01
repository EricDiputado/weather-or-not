using System.Text.Json.Serialization;

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
    public MainWeatherData Main { get; set; } = new();

    [JsonPropertyName("weather")]
    public List<WeatherInfo> Weather { get; set; } = new();
}

// Represents the "main" object in the JSON, containing temperature info.
public class MainWeatherData
{
    [JsonPropertyName("temp")]
    public float Temperature { get; set; }
}

// Represents an item in the "weather" array, containing the description.
public class WeatherInfo
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

