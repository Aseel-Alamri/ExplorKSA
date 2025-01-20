using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinalWebApplication.Data;
using FinalWebApplication.Models;

namespace FinalWebApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        // إجراء Index لجلب وعرض قائمة الفعاليات
        public IActionResult Index(string city)
        {
            var events = _context.Events.AsQueryable(); 

            // ميزة الفلترة حسب المدينة
            if (!string.IsNullOrEmpty(city))
            {
                events = events.Where(e => e.City == city);
            }

            return View(events.ToList());
        }
    }
}




