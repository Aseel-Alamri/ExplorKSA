using FinalWebApplication.Data;
using FinalWebApplication.Extensions;
using Microsoft.AspNetCore.Mvc;

// For accessing session, cookies, and other HTTP-related features

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

        //public IActionResult Reservation()
        //{
        //    // Fetch reservation options from the database
        //    var reservationOptions = _context.Reservation.ToList();
        //    return View(reservationOptions); // Pass the list to the view
        //}
        [HttpGet]
        public IActionResult Reservation(int hotelId)
        {
            var reservationOptions = _context.Reservation.ToList();
            TempData["SelectedHotelId"] = hotelId;
            return View(reservationOptions);
        }



        public IActionResult HotelSelect()
        {
            var hotels = _context.Hotel.ToList(); // Fetch hotels from the database
            return View(hotels);
        }


        [HttpPost]
        public IActionResult SelectHotel(int hotelId)
        {
            var selectedHotel = _context.Hotel.Find(hotelId);
            if (selectedHotel != null)
            {
                // Store hotel data in session
                HttpContext.Session.SetString("HotelName", selectedHotel.Name);

                // Redirect to reservation page
                return RedirectToAction("Reservation");
            }

            return View();
        }

        [HttpPost]
        public IActionResult SummaryPage(string roomType, bool isVIP)
        {
            // Store reservation details in session
            HttpContext.Session.SetString("RoomType", roomType);
            HttpContext.Session.SetString("IsVIP", isVIP.ToString());

            // Calculate total price
            decimal totalPrice = CalculateTotalPrice();
            HttpContext.Session.SetDecimal("TotalPrice", totalPrice);

            // Redirect to summary page
            return RedirectToAction("SummaryPage", "UserSelection");
        }


        private decimal CalculateTotalPrice()
{
    // Example calculation
    decimal basePrice = 100m; // Assume a base price

    // Safely parse the session value
    string numberOfPeopleStr = HttpContext.Session.GetString("NumberOfPeople");
    int numberOfPeople = int.TryParse(numberOfPeopleStr, out int parsedValue) ? parsedValue : 1;

    bool isVIP = HttpContext.Session.GetString("IsVIP") == "true";

    decimal vipCharge = isVIP ? 40m : 0m;
    return (basePrice + vipCharge) * numberOfPeople;
}

    }
}




