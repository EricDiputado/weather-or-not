using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        // --- IMPORTANT ---
        // Replace "YOUR_API_KEY" with your actual OpenWeatherMap API key.
        // For real applications, use a secure way to store secrets, like .NET User Secrets or Azure Key Vault.
        const string apiKey = "697b8a7eef92517f83e2ad80560f07b8";

        if (apiKey == "YOUR_API_KEY")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please replace 'YOUR_API_KEY' with your actual API key in Program.cs.");
            Console.ResetColor();
            return;
        }

        var weatherService = new WeatherService(apiKey);

        Console.Write("Enter a city name: ");
        string? city = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine("City name cannot be empty.");
            return;
        }

        try
        {
            WeatherResponse? weatherData = await weatherService.GetWeatherForCityAsync(city);

            if (weatherData != null && weatherData.Weather.Any())
            {
                Console.WriteLine("\n--- Current Weather ---");
                Console.WriteLine($"City: {weatherData.CityName}");
                Console.WriteLine($"Temperature: {weatherData.Main.Temperature}°C");
                Console.WriteLine($"Description: {weatherData.Weather.First().Description}");
                Console.WriteLine("-----------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}

