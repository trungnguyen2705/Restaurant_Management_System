using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Inventory.cshtml");
            //return RedirectToAction("List", "Table");
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
