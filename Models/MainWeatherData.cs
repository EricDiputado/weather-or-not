using System.Text.Json.Serialization;

namespace WeatherApp.Models;

// Represents the "main" object in the JSON, containing temperature info.
public class MainWeatherData
{
    [JsonPropertyName("temp")]
    public float Temperature { get; set; }
}
