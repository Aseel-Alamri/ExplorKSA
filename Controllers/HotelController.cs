using FinalWebApplication.Data;
using FinalWebApplication.Models;
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

        public IActionResult Reservation()
        {
            // Fetch reservation options from the database
            var reservationOptions = _context.Reservation.ToList();
            return View(reservationOptions); // Pass the list to the view
        }



        public IActionResult HotelSelect()
        {
            var hotels = _context.Hotel.ToList(); // Fetch hotels from the database
            return View(hotels);
        }
    }
}




