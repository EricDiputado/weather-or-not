using System.Text.Json.Serialization;

namespace WeatherOrNot.Models;

// Represents an item in the "weather" array, containing the description.
public class WeatherInfo
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}
