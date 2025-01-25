using Microsoft.AspNetCore.Mvc;

namespace FinalWebApplication.Controllers
{
    public class UserSelectionController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult SummaryPage()
        {
            return View();
        }

        
    }
}
