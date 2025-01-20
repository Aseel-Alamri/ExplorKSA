using FinalWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApplication.Controllers
{
    public class HotelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int eventId)
        {
            var hotels = _context.Hotel.Where(h => h.EventId == eventId).ToList();
            return View(hotels);
        }
    }
}




