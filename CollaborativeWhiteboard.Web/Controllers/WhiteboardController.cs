using CollaborativeWhiteboard.Core.Interfaces;
using CollaborativeWhiteboard.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollaborativeWhiteboard.Web.Controllers;

public class WhiteboardController : Controller
{
    // Dependency injection for services/repositories.
    private readonly IWhiteboardService _whiteboardService;

    public WhiteboardController(IWhiteboardService whiteboardService)
    {
        _whiteboardService = whiteboardService;
    }

    // Example of an action method
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(WhiteboardViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Convert ViewModel to Domain Model
            // Call the service layer to process the data
            // Redirect or return the view as needed.
        }
        return View(model);
    }

    // ... other CRUD operations.
}