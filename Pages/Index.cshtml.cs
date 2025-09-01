using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WeatherOrNot;
using WeatherOrNot.Models;

namespace WeatherOrNot.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherService _weatherService;

        public IndexModel(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        private string? _city;

        [BindProperty(SupportsGet = true)]
        public string? City
        {
            get => _city;
            set
            {
                _city = value;
                if (!string.IsNullOrWhiteSpace(_city))
                {
                    // Reset weather data whenever City is set
                    Weather = _weatherService.GetWeatherForCityAsync(_city).GetAwaiter().GetResult();
                }
                else
                {
                    Weather = null;
                }
            }
        }

        public WeatherResponse? Weather { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrWhiteSpace(City))
            {
                Weather = await _weatherService.GetWeatherForCityAsync(City);
            }
        }
    }
}

