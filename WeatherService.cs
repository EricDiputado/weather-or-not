using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WeatherApp;

public class WeatherService
{
    // It's best practice to create one static HttpClient and reuse it for the application's lifetime.
    private static readonly HttpClient _httpClient = new();
    private readonly string _apiKey;

    public WeatherService(string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new ArgumentException("API key must be provided.", nameof(apiKey));

        _apiKey = apiKey;
    }

    public async Task<WeatherResponse?> GetWeatherForCityAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            return null;

        try
        {
            // Construct the request URL with the city, API key, and desired units (metric for Celsius).
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";

            // Make the GET request and deserialize the JSON response into our WeatherResponse object.
            // The GetFromJsonAsync extension method handles both steps.
            var weatherResponse = await _httpClient.GetFromJsonAsync<WeatherResponse>(url);
            return weatherResponse;
        }
        catch (HttpRequestException ex)
        {
            // This will catch errors like "404 Not Found" if the city name is invalid.
            Console.WriteLine($"\nError fetching weather data: {ex.StatusCode} - {ex.Message}");
            return null;
        }
    }
}

