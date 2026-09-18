using AllTrailsAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AllTrailsAdmin.Controllers
{
    public class HomeController : Controller
    {
        // Constructor
        public HomeController()
        {
            Console.WriteLine("Constructor called.");
        }

        //
        // Action Methods
        //

        // GET: Home/Index
        public IActionResult Index()
        {
            Console.WriteLine("/Home/Index action method called.");

            return View(); // /View/Home/Index view
        }

        // GET: Home/Privacy
        public IActionResult Privacy()
        {
            Console.WriteLine("/Home/Privacy action method called.");

            return View(); // /View/Home/Privacy view
        }


        public IActionResult MyFirstActionMethod()
        {
            Console.WriteLine("MyFirstActionMethod is called.");

            return View();
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
