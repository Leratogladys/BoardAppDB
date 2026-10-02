// Programmer name : BoardAppDB Group
// Student nr      : 222049725;223022994;225007032;220024412;225004492
// Assignment nr   : Practical Assessment 2
// Purpose         : Controller used to display the Home, Privacy and Error views.

using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BoardAppDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        //
        // Name              : HomeController(ILogger<HomeController> logger)
        // Purpose           : Creates the Home controller using the injected logger
        // Re-use            : None
        // Method Parameters : ILogger<HomeController> logger
        //                     - logger used by the Home controller
        // Output Type       : None
        //
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        } // end constructor HomeController

        //
        // Name              : IActionResult Index()
        // Purpose           : Displays the application home page
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : IActionResult
        //                     - Home Index view
        //
        public IActionResult Index()
        {
            return View();
        } // end method Index

        //
        // Name              : IActionResult Privacy()
        // Purpose           : Displays the Privacy page
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : IActionResult
        //                     - Privacy view
        //
        public IActionResult Privacy()
        {
            return View();
        } // end method Privacy

        //
        // Name              : IActionResult Error()
        // Purpose           : Displays the Error view with request information
        // Re-use            : None
        // Method Parameters : None
        // Output Type       : IActionResult
        //                     - Error view containing an ErrorViewModel
        //
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        } // end method Error
    } // end class HomeController
} // end namespace BoardAppDB.Controllers
