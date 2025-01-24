using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinalWebApplication.Data;
using FinalWebApplication.Models;
using Microsoft.Extensions.Hosting;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.AspNetCore.Components.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace FinalWebApplication.Controllers
{
    public class EventController : Controller
    {
        private static List<Event> events = new List<Event>
        {
            new Event{
                Id = 1,
                Name = "Riyadh Season Races ",
                Description = "Riyadh Season introduces thrilling horse racing at King Abdulaziz Racetrack, running from October 2023 to April 2024. These events stand as some of the Kingdom’s top sporting attractions, featuring diverse races with local and international horses, promising excitement for all attendees.",
            Location = "Riyadh",
                Date = DateTime.Now.AddDays(5),
                Price = 150,
                ImageUrl = "https://albiladdaily.com/wp-content/uploads/2024/03/%D8%AE%D9%8A%D9%84-300x224.jpg"
            },
            new Event{
                Id = 2,
                Name = "Wonder Garden",
                Description = "Experience the adventure in every corner of the second edition of the enchanted-themed amusement park. Step through the grand fantasy gate and immerse yourself in three distinct magical worlds, filled with delight and wonder, offering a fun and unforgettable experience for visitors of all ages.",
            Location = "Riyadh",
                Date = DateTime.Now.AddDays(5),
                Price = 150,
                ImageUrl = "https://images.ctfassets.net/vy53kjqs34an/1Rz7ORZVxJThk7W2gwboKv/d7dc8bf512ddc1e7efa7c8b6076ca383/Wonder_Garden_1920_x_1280.jpg"
            },
            new Event{
                Id = 3,
                Name = "Riyadh Zoo",
                Description = "Riyadh Zoo reopens with a variety of new educational, interactive, and entertainment activities, including exciting regional events. Visitors can get up close with crocodiles, explore the Kangaroo Arena, interact with birds in the largest birdcage, and enjoy newly expanded zones, making for a memorable day at the zoo.",
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




        // دالة POST التي تعالج البيانات
        [HttpPost]
        public IActionResult Book(DateTime BookingDate, int NumberOfPeople, bool IsVIP)
        {
            // تحقق من صحة البيانات
            if (BookingDate == DateTime.MinValue || NumberOfPeople <= 0)
            {
                ViewBag.ErrorMessage = "Please enter valid data.";
                return View("Details");
            }

            // عرض رسالة النجاح
            ViewBag.Message = $"Booking successfully made on {BookingDate.ToShortDateString()} for {NumberOfPeople} person(s).";
            if (IsVIP)
            {
                ViewBag.Message += " VIP ticket.";
            }

            return RedirectToAction("BookingConfirmation");  // إعادة التوجيه إلى صفحة تأكيد الحجز
        }

        // دالة GET لعرض صفحة تأكيد الحجز
        [HttpGet]
        public IActionResult BookingConfirmation()
        {
            return View(); // عرض الفيو الخاص بتأكيد الحجز
        }








    }
}





