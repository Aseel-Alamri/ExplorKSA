using FinalWebApplication.Data;
using FinalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApplication.Controllers
{
    public class EventController : Controller
    {
        private static List<Event> events = new List<Event>
        {
            new Event{
                Id = 1,
                Name = "Riyadh Season Races ",
                Description = "Experience the magic at the enchanted-themed amusement park, with three distinct fantasy worlds offering fun for all ages.",
            Location = "Riyadh",
                Date = DateTime.Now.AddDays(5),
                Price = 150,
                ImageUrl = "https://albiladdaily.com/wp-content/uploads/2024/03/%D8%AE%D9%8A%D9%84-300x224.jpg"
            },
            new Event{
                Id = 2,
                Name = "Wonder Garden",
                Description = "Riyadh Season presents thrilling horse races at King Abdulaziz Racetrack (Oct 2023 - Apr 2024), featuring local and international.",
            Location = "Riyadh",
                Date = DateTime.Now.AddDays(5),
                Price = 150,
                ImageUrl = "https://images.ctfassets.net/vy53kjqs34an/1Rz7ORZVxJThk7W2gwboKv/d7dc8bf512ddc1e7efa7c8b6076ca383/Wonder_Garden_1920_x_1280.jpg"
            },
            new Event{
                Id = 3,
                Name = "Riyadh Zoo",
                Description = "Riyadh Zoo reopens with exciting activities like crocodile encounters, a Kangaroo Arena, and the largest birdcage, plus expanded zones.",
                Location = "Riyadh",
                Date = DateTime.Now.AddDays(5),
                Price = 150,
                ImageUrl = "https://images.ctfassets.net/vy53kjqs34an/6RzRxAq9Md9wjJtvoqXU1c/5e2ded9d10a39ce36172d0a7517ae715/Page-Cover.jpg?fm=webp&w=1921&h=1281"
            }
        };
        private readonly ApplicationDbContext _context;
        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // عرض الفعاليات  بالرياض 
            var riyadhEvents = events.Where(e => e.Location == "Riyadh").ToList();
            return View(riyadhEvents);

        }

        //عرض تفاصيل فعالية 
        public IActionResult Details(int id)
        {
            var selectedEvent = events.FirstOrDefault(e => e.Id == id);
            if (selectedEvent == null)
            {
                return NotFound();
            }
            return View(selectedEvent);
        }



        //[HttpPost]
        //public IActionResult Book(DateTime BookingDate, int NumberOfPeople, bool IsVIP)
        //{
        //    // Validate the data
        //    if (BookingDate == DateTime.MinValue || NumberOfPeople <= 0)
        //    {
        //        ViewBag.ErrorMessage = "Please enter valid data.";
        //        return View("Details");
        //    }

        //    //Prepare a success message using ViewBag
        //    ViewBag.Message = $"Booking successfully made on {BookingDate.ToShortDateString()} for {NumberOfPeople} person(s).";
        //    if (IsVIP)
        //    {
        //        ViewBag.Message += " VIP ticket.";
        //    }

        //    return View("BookingConfirmation");
        //}




        [HttpPost]
        public IActionResult Book(DateTime BookingDate, int NumberOfPeople, bool IsVIP)
        {

            if (BookingDate == DateTime.MinValue || NumberOfPeople <= 0)
            {
                ViewBag.ErrorMessage = "Please enter valid data.";
                return View("Details");
            }


            ViewBag.Message = $"Booking successfully made on {BookingDate.ToShortDateString()} for {NumberOfPeople} person(s).";
            if (IsVIP)
            {
                ViewBag.Message += " VIP ticket.";
            }

            return RedirectToAction("BookingConfirmation");

        }

        [HttpGet]
        public IActionResult BookingConfirmation()
        {
            return View();
        }








    }
}





