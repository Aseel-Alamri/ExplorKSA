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

        [HttpPost]
        public IActionResult SaveEventSelection(int eventId)
        {
            var eventDetails = _context.events.FirstOrDefault(e => e.Id == eventId);
            if (eventDetails == null) return NotFound();

            var userSelection = _context.Userselection.OrderByDescending(u => u.Id).FirstOrDefault();
            if (userSelection == null) return NotFound();

            userSelection.EventName = eventDetails.Name;
            userSelection.EventDescription = eventDetails.Description;
            userSelection.TotalPrice += (decimal)eventDetails.Price;

            _context.SaveChanges();

            return RedirectToAction("Details", "Event", new { id = eventId });
        }



        [HttpPost]
        public IActionResult SelectEvent(int eventId)
        {
            var selectedEvent = _context.events.Find(eventId);
            if (selectedEvent != null)
            {
                // Store event data in session
                HttpContext.Session.SetString("EventName", selectedEvent.Name);
                HttpContext.Session.SetString("EventDescription", selectedEvent.Description);

                // Redirect to event details page
                return RedirectToAction("Details", new { id = eventId });
            }

            return View();
        }
        [HttpPost]
        public IActionResult EventDetails(int eventId, int numberOfPeople, DateTime eventDate, bool isVIP, string roomType)
        {
            var selectedEvent = _context.events.FirstOrDefault(e => e.Id == eventId);
            if (selectedEvent != null)
            {
                selectedEvent.IsVip = isVIP;
                _context.SaveChanges();

                HttpContext.Session.SetInt32("NumberOfPeople", numberOfPeople);
                HttpContext.Session.SetString("EventDate", eventDate.ToString("yyyy-MM-dd"));
                HttpContext.Session.SetString("IsVIP", isVIP.ToString());

                // Calculate price based on room type
                decimal basePrice = 150;  // Default price per person
                decimal vipFee = isVIP ? 40 : 0;

                decimal totalPrice = (basePrice + vipFee) * numberOfPeople;

                HttpContext.Session.SetString("TotalPrice", totalPrice.ToString("F2"));

                // Redirect to hotel selection page or confirmation page
                return RedirectToAction("hotelselect", "Hotel");
            }

            return RedirectToAction("Index");
        }








    }
}





