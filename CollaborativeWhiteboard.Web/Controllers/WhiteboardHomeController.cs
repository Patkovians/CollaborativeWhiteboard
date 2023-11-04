using CollaborativeWhiteboard.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollaborativeWhiteboard.Web.Controllers
{
    public class WhiteboardHomeController : Controller
    {
        private readonly ILogger<WhiteboardHomeController> _logger;

        public WhiteboardHomeController(ILogger<WhiteboardHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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