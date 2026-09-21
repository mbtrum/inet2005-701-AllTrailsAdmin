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
        public ViewResult Privacy()
        {
            Console.WriteLine("/Home/Privacy action method called.");

            return View(); // /View/Home/Privacy view
        }


        // GET : Home/MyFirstActionMethod
        public IActionResult MyFirstActionMethod()
        {
            Console.WriteLine("MyFirstActionMethod is called.");

            return View();
        }

        public ContentResult HelloWorld()
        {
            return Content("Hello world!!!");
        }

        public JsonResult MyFriend()
        {
            Friend friend = new Friend();
            friend.Id = 1;
            friend.Name = "Han Solo";
            friend.Email = "hansolo@rebels.ca";

            return Json(friend);
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
