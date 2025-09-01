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

        [BindProperty(SupportsGet = true)]
        public string? City { get; set; }

        public WeatherResponse? Weather { get; set; }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrWhiteSpace("Auckland"))
            {
                Weather = await _weatherService.GetWeatherForCityAsync("Auckland");
            }
        }
    }
}

