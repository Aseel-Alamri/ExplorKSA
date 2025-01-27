<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;

=======
﻿using FinalWebApplication.Data;
using FinalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
>>>>>>> master
namespace FinalWebApplication.Controllers
{
    public class UserSelectionController : Controller
    {
<<<<<<< HEAD
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult SummaryPage()
        {
            return View();
        }

        
=======
        // Example database context (replace with your actual DbContext)
        private readonly ApplicationDbContext _context;

        public UserSelectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitSelection(UserSelectionViewModel userSelection)
        {
            // Save the selection temporarily in TempData
            TempData["UserSelection"] = JsonConvert.SerializeObject(userSelection);
            return RedirectToAction("SummaryPage");
        }


        [HttpGet]
        public IActionResult SummaryPage()
        {
            // Retrieve session data
            var cityName = HttpContext.Session.GetString("CityName");
            var eventName = HttpContext.Session.GetString("EventName");
            var eventDescription = HttpContext.Session.GetString("EventDescription");
            var hotelName = HttpContext.Session.GetString("HotelName");
            var roomType = HttpContext.Session.GetString("RoomType");
            var isVIPStr = HttpContext.Session.GetString("IsVIP");
            var isVIP = isVIPStr == "true";
            var totalPriceStr = HttpContext.Session.GetString("TotalPrice");
            var totalPrice = decimal.TryParse(totalPriceStr, out var parsedPrice) ? parsedPrice : 0;

            // If any required data is missing, redirect to an error page
            if (string.IsNullOrEmpty(cityName) || string.IsNullOrEmpty(eventName) || string.IsNullOrEmpty(hotelName) || string.IsNullOrEmpty(roomType))
            {
                return View("Error", "Required data is missing.");
            }

            // Populate UserSelection model
            var model = new UserSelection
            {
                CityName = cityName,
                EventName = eventName,
                EventDescription = eventDescription,
                HotelName = hotelName,
                RoomType = roomType,
                IsVIP = isVIP,
                NumberOfPeople = 1, // Default value
                EventDate = DateTime.Now.AddDays(7), // Example event date
                TotalPrice = totalPrice
            };

            return View(model); // Pass the model to the view
        }








        [HttpPost]
        public IActionResult ConfirmSelection(UserSelection selection)
        {
            if (selection == null)
            {
                return View("Error", "Invalid submission data."); // Handle null model
            }

            // Save the selection to the database
            _context.Userselection.Add(selection);
            _context.SaveChanges();

            // Return the view with the data to display confirmation details
            return View(selection);
        }



        //[HttpGet]
        //public IActionResult EditUserSelection(int bookingId)
        //{
        //    var booking = _context.Userselection.FirstOrDefault(b => b.Id == bookingId);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    // Populate dropdowns
        //    ViewBag.Cities = new SelectList(_context.Cities, "Name", "Name", booking.CityName);
        //    ViewBag.Events = new SelectList(_context.events, "Name", "Name", booking.EventName);
        //    ViewBag.Hotels = new SelectList(_context.Hotel, "Name", "Name", booking.HotelName);

        //    return View(booking);
        //}


        //[HttpPost]
        //public IActionResult EditUserSelection(UserSelection model)
        //{
        //    // Validate the form
        //    if (!ModelState.IsValid)
        //    {
        //        // Repopulate dropdowns if the form validation fails
        //        ViewBag.Cities = new SelectList(_context.Cities, "Name", "Name", model.CityName);
        //        ViewBag.Events = new SelectList(_context.events, "Name", "Name", model.EventName);
        //        ViewBag.Hotels = new SelectList(_context.Hotel, "Name", "Name", model.HotelName);
        //        return View(model); // Return the same view with errors
        //    }

        //    // Fetch the existing booking to update it
        //    var booking = _context.Userselection.FirstOrDefault(b => b.Id == model.Id);
        //    if (booking == null)
        //    {
        //        return NotFound(); // Return 404 if booking doesn't exist
        //    }

        //    // Update booking details with submitted data
        //    booking.CityName = model.CityName;
        //    booking.EventName = model.EventName;
        //    booking.EventDescription = model.EventDescription;
        //    booking.HotelName = model.HotelName;

        //    // Save changes to the database
        //    _context.SaveChanges();

        //    // Redirect to the EditingMessage page after successful update
        //    return RedirectToAction("EditingMessage", new { bookingId = model.Id });
        //}


        // GET request to display the edit form
        [HttpGet]
        public IActionResult EditUserSelection(int bookingId)
        {
            var booking = _context.Userselection.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null)
            {
                return NotFound(); // Return 404 if booking doesn't exist
            }

            // Populate dropdowns with current values
            ViewBag.Cities = new SelectList(_context.Cities, "Name", "Name", booking.CityName);
            ViewBag.Events = new SelectList(_context.events, "Name", "Name", booking.EventName);
            ViewBag.Hotels = new SelectList(_context.Hotel, "Name", "Name", booking.HotelName);

            return View(booking);
        }

        // POST request to save updated data
        [HttpPost]
        public IActionResult EditUserSelection(UserSelection model)
        {
            // Validate the form
            if (!ModelState.IsValid)
            {
                // Repopulate dropdowns if the form validation fails
                ViewBag.Cities = new SelectList(_context.Cities, "Name", "Name", model.CityName);
                ViewBag.Events = new SelectList(_context.events, "Name", "Name", model.EventName);
                ViewBag.Hotels = new SelectList(_context.Hotel, "Name", "Name", model.HotelName);
                return View(model); // Return the same view with validation errors
            }

            // Fetch the existing booking to update it
            var booking = _context.Userselection.FirstOrDefault(b => b.Id == model.Id);
            if (booking == null)
            {
                return NotFound(); // Return 404 if booking doesn't exist
            }

            // Update booking details with submitted data
            booking.CityName = model.CityName;
            booking.EventName = model.EventName;
            booking.EventDescription = model.EventDescription;
            booking.HotelName = model.HotelName;

            // Save changes to the database
            _context.SaveChanges();

            // Redirect to the EditingMessage page after successful update
            return RedirectToAction("EditingMessage", new { bookingId = model.Id });
        }

        // GET request to show confirmation message after editing
        [HttpGet]
        public IActionResult EditingMessage(int bookingId)
        {
            var booking = _context.Userselection.FirstOrDefault(b => b.Id == bookingId);
            if (booking == null)
            {
                return NotFound(); // Return 404 if booking doesn't exist
            }

            return View(booking); // Return the confirmation view with the updated booking data
        }






        //public IActionResult EditingMessage(int bookingId)
        //{
        //    // Fetch the updated booking data (optional)
        //    var booking = _context.Userselection.FirstOrDefault(b => b.Id == bookingId);

        //    if (booking == null)
        //    {
        //        return NotFound(); // If booking is not found, return 404
        //    }

        //    // Optionally, pass the booking data to the view
        //    return View(booking); // Pass booking data to the view
        //}





        [HttpPost]
        public IActionResult DeleteBooking(int bookingId)
        {
            // Retrieve the booking from the database using the bookingId
            var booking = _context.Userselection.FirstOrDefault(b => b.Id == bookingId);

            if (booking != null)
            {
                // Delete the booking from the database
                _context.Userselection.Remove(booking);
                _context.SaveChanges();
                TempData["Message"] = "Booking successfully deleted.";  // Success message
            }
            else
            {
                TempData["Message"] = "Booking not found.";  // Error message if booking does not exist
            }

            return RedirectToAction("Index", "Home");  // Redirect to the list of bookings (or another page)
        }




>>>>>>> master
    }
}
