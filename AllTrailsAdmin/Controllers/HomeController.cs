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
        }

        //
        // Action Methods
        //

        // GET: Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }



        // GET: Home/GetTrail
        public IActionResult GetTrail()
        {
            // Create a sample Trail
            Trail trail = new Trail();
            trail.Id = 1;
            trail.Description = "This trail begins by following an ATV and hiking trail, eventually getting thinner and more surrounded by nature. The route does arrive at a beautiful waterfall, which users recommend seeing in the spring or summer for best water volume.";
            trail.Title = "Johnson River Falls Trail";
            trail.Difficulty = "Easy";
            trail.EstimatedHours = 2.5; // 2.5 hr
            trail.Length = 1500; // 1500 m

            return View(trail); // pass the trail object into the View to display
        }

        public IActionResult GetAllTrails()
        {
            List<Trail> trails = new List<Trail>();

            // Create a sample Trail
            Trail trail = new Trail();
            trail.Id = 1;
            trail.Title = "Johnson River Falls";
            trail.Description = "This trail begins by following an ATV and hiking trail, eventually getting thinner and more surrounded by nature. The route does arrive at a beautiful waterfall, which users recommend seeing in the spring or summer for best water volume.";

            Trail trail2 = new Trail();
            trail2.Id = 2;
            trail2.Title = "Pot Lake trail";
            trail2.Description = "Skip to main content\r\nSearch\r\nSearch\r\nBegin typing to search, use the up and down arrow keys to navigate, press enter to select\r\n\r\nExplore\r\n\r\nSaved\r\n\r\nShop\r\n\r\nGet the app\r\n\r\nLog in\r\nBack to Explore\r\nCanada/\r\nNova Scotia/\r\nFive Bridge Lakes Wilderness Area/\r\nPot Lake Loop\r\nPot Lake Loop\r\nCaution\r\n1 alert\r\n·\r\n4.7\r\n(1,854 reviews)\r\n·\r\nModerate\r\n·\r\nFive Bridge Lakes Wilderness Area\r\n\r\n\r\n\r\n\r\nSave\r\n\r\nGet directions\r\n\r\nSend to phone\r\nPhoto of Pot Lake Loop in Five Bridge Lakes Wilderness Area\r\nSecond photo of Pot Lake Loop in Five Bridge Lakes Wilderness Area\r\nPot Lake Loop map\r\n\r\n\r\n1,978 photos\r\n7.9km\r\nLength\r\n155m\r\nElevation gain\r\n2–2.5hr\r\nEstimated time\r\nLoop\r\nPot Lake Loop is the first of four consecutive loops known as the Bluff Wilderness Hiking Trail in Timberlea, Nova Scotia. The Bluff Trail is located within the Five Bridge Lakes Wilderness Area, designated under the Wilderness Areas Protection Act. This loop is marked with yellow trail markers, and as a difficult wilderness trail should warrant 3-4 hours of planned hiking. Visitors should pack emergency gear and water, and be sure to pay close attention to markers so as not to accidentally wander onto a longer loop. ";

            trails.Add(trail);
            trails.Add (trail2);    

            return View(trails); // pass the trail object into the View to display
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
