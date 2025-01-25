using System.Diagnostics;
using FinalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<City> cities = new List<City>
        {
            new City
            {
                Id = 1,
                Name = "Riyadh",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Riyadh_Skyline.jpg/1920px-Riyadh_Skyline.jpg",
                Title = "Welcome to Riyadh",
                Description = "Experience the capital of culture",
                IsAvailable = true,
                Events = new List<Event>
                {
                    new Event
                    {
                        Id = 1,
                        Name = "Cultural Festival",
                        Description = "Explore Riyadh's cultural heritage.",
                        Date = DateTime.Now.AddDays(10),
                        Location = "King Fahad Park",
                        ImageUrl = "https://example.com/riyadh_event.jpg"
                    }
                }
            },
            new City
            {
                Id = 2,
                Name = "Abha",
                ImageUrl = "https://i.pinimg.com/736x/d2/7a/ae/d27aaef0738de7196fb473479b593582.jpg",
                Title = "Welcome to Abha",
                Description = "Discover the cool highlands to explore",
                IsAvailable = false
            },
            new City
            {
                Id = 3,
                Name = "AlUla",
                ImageUrl = "https://details.sa/ar/wp-content/uploads/2024/01/%D8%A7%D9%84%D8%B9%D9%84%D8%A7-3.jpg",
                 Title = "Welcome to AlUla",
                Description = "Explore the beauty of history",
                IsAvailable = false
            },
            new City
            {
                Id = 4,
                Name = "Jeddah",
                ImageUrl = "https://scth.scene7.com/is/image/scth/a-world-of-discoveries-to-the-city-of-peace:crop-1920x1080?defaultImage=a-world-of-discoveries-to-the-city-of-peace&wid=1920&hei=1080",
                Title = "Welcome to Jeddah",
                Description = "The bride of the Red Sea",
                IsAvailable = false
            }
        };
            var developers = new List<Developer>
        {
            new Developer { Name = "Abdullah Aljohani", Role = "Software Developer", LinkedInUrl = "https://www.linkedin.com/in/abdullahjhn/", GitHubUrl = "https://github.com/AbdallahLearn" },
            new Developer { Name = "Heba", Role = "Software Developer", LinkedInUrl = "https://www.linkedin.com/in/heba-alahmadi", GitHubUrl = "https://github.com/heba1488" },
            new Developer { Name = "Aseel", Role = "Software Developer", LinkedInUrl = "#", GitHubUrl = "https://github.com/Aseel-Alamri" }
        };

            // Pass both lists to the view
            ViewData["Developers"] = developers;

            return View(cities);

        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
