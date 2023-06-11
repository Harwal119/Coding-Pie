using CodingPie.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodingPie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPieService _pieService;

        public HomeController(ILogger<HomeController> logger, IPieService pieService)
        {
            _logger = logger;
            _pieService = pieService;
        }

        public IActionResult Index()
        {
           var pies = _pieService.GetAllPies ();
            
            //ViewBag.myPies = pies;
            return View(pies);
        }

        public IActionResult Privacy()
        {
            //if(TempData.ContainsKey("yearOfBirth"))

             //TempData["yearOfBirth"];
            //TempData.Keep("yearOfBirth");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}