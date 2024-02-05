using Microsoft.AspNetCore.Mvc;
using SEMS.Models;
using System.Diagnostics;

namespace SEMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
           
            return View();
        }
        public IActionResult Authenticate()
        {

            return RedirectToActionPreserveMethod("Homepage");
        }
        public IActionResult Homepage()
        {

            return View();
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
