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

        return View();
        }

        public IActionResult HotelSelect()

        {
            List<Hotel> hotel = new List<Hotel>
        {
            new Hotel
        {
            Id = 1,
            Name = "Hilton Riyadh Olaya Luxury Hotel",
            City = "Riyadh",
            Address = "https://maps.app.goo.gl/7Up6CZnZmUbq5No47",
            Description = "2.6 km from Panorama Mall in Riyadh.",
            Image = "https://cf.bstatic.com/xdata/images/hotel/square600/587742639.webp?k=050a6a59008123a81233b91e82dce48e4826cf406c28177823f59f6315f44f5c&o=",
            EventId = 1,
        },

        new Hotel
        {
            Id = 2,
            Name = "Vittori Palace Hotel and Residences",
            City = "Riyadh",
            Address = "https://maps.app.goo.gl/MR6dNRnLaYryWkUe8",
            Description = "Near Saqr Aljazeera Museum, 4.5 km away.",
            Image = "https://cf.bstatic.com/xdata/images/hotel/square600/288047810.webp?k=cb83f02a29d491f3f7aede90386f271c131baa1be36053fc845a6a18204ce44b&o=",
            EventId = 2,
        },

        new Hotel
        {
            Id = 3,
            Name = "Hyatt Regency Riyadh Olaya",
            City = "Riyadh",
            Address = "https://maps.app.goo.gl/m4xrMV1dCk94xAc47",
            Description = "Located near Tahlia Street in Riyadh.",
            Image = "https://cf.bstatic.com/xdata/images/hotel/square600/563248959.webp?k=8054089d2dbefaf84faa9341ebb52fb49740ee9f39e03f2f1838ae04b237e579&o=",
            EventId = 3,
        },


        };
            return View(hotel);
        }
    }
}




