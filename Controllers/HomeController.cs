using System.Diagnostics;
using FinalWebApplication.Data;
using FinalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        
        private readonly ApplicationDbContext _context;//global


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
           
            var cities = _context.Cities.Include(c => c.Events).ToList();
            var developers = new List<Developer>
        {
            new Developer { Name = "Abdullah Aljohani", Role = "Software Developer", LinkedInUrl = "https://www.linkedin.com/in/abdullahjhn/", GitHubUrl = "https://github.com/AbdallahLearn" },
            new Developer { Name = "Heba", Role = "Software Developer", LinkedInUrl = "https://www.linkedin.com/in/heba-alahmadi", GitHubUrl = "https://github.com/heba1488" },
            new Developer { Name = "Aseel", Role = "Software Developer", LinkedInUrl = "https://www.linkedin.com/in/aseel-alamri-8290963", GitHubUrl = "https://github.com/Aseel-Alamri" }
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
