using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WeatherOrNot;

namespace WeatherOrNot;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    // We now inject HttpClient and IConfiguration via the constructor.
    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["OpenWeather:ApiKey"]
            ?? throw new InvalidOperationException("API Key not found in configuration.");
    }

    public async Task<WeatherResponse?> GetWeatherForCityAsync(string city)
    {
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
            // In a web app, we should log this instead of writing to the console.
            // For now, we'll just return null and let the UI handle it.
            return null;
        }
    }
}

