using FinalWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApplication.Controllers
{
    public class EventController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // عرض الفعاليات  بالرياض 
            var riyadhEvents = _context.events.Where(e => e.Location == "Riyadh").ToList();
            return View(riyadhEvents);


        }

        //عرض تفاصيل فعالية 
        public IActionResult Details(int id)
        {
            var selectedEvent = _context.events.FirstOrDefault(e => e.Id == id);
            if (selectedEvent == null)
            {
                return NotFound();
            }
            return View(selectedEvent);
        }



       




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
        public IActionResult hotelselect()

        {
            return View();
        }








    }
}





