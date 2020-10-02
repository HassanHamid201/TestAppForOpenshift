using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TestAppForOpenshift.Models;

namespace TestAppForOpenshift.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
         
        [BindProperty]
        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }

        public void OnGet()
        {
            var rng = new Random();
            WeatherForecasts = Enumerable.Range(1, 5).Select((s,i) => new WeatherForecast
            {
                Id = i,
                Date = DateTime.Now.AddDays(s),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        private static readonly string[] Summaries = new[]
      {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    }
}
